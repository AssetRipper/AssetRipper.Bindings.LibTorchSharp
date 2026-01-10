namespace AssetRipper.Bindings.LibTorchSharp.Modules;

public partial struct RootMeanSquareNorm
{
	private Tensor weight;
	private readonly double eps;

	public RootMeanSquareNorm(long normalizedShape, double eps = 1e-8, ScalarType? dtype = null, Device? device = null)
	{
		weight = Tensor.Ones([normalizedShape], dtype ?? ScalarType.Float32, true, device: device);
		this.eps = eps;
	}

	public readonly Tensor Forward(Tensor input)
	{
		using Tensor squared = input * input;
		using Tensor mean = squared.MeanAlongDimensions([-1], true, false, default);
		using Tensor meanAddEps = mean + eps;
		using Tensor rms = meanAddEps.Sqrt();
		using Tensor normed = input / rms;
		return normed * weight;
	}
}
public partial struct RootMeanSquareNorm : IModule
{
	// Source generated
	public readonly bool IsTraining
	{
		set
		{
		}
	}

	void IModule.CopyFromRoot(StateDictionary dictionary)
	{
		weight.CopyFrom(dictionary);
	}

	readonly void IModule.CopyToRoot(StateDictionary dictionary)
	{
		weight.CopyTo(dictionary);
	}

	public readonly IEnumerable<Tensor> GetParameters() => [weight.Alias()];

	public void Dispose()
	{
		weight.Dispose();
		weight = default;
	}
}
