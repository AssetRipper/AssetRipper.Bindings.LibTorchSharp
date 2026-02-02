using AssetRipper.Bindings.LibTorchSharp.Attributes;

namespace AssetRipper.Bindings.LibTorchSharp.Modules;

[GeneratedModule]
public readonly partial struct RootMeanSquareNorm
{
	private partial Tensor weight { get; }
	private partial double eps { get; }

	public RootMeanSquareNorm(long normalizedShape, double eps = 1e-8, ScalarType dtype = ScalarType.Float32, Device? device = null)
	{
		Tensor weight = Tensor.Ones([normalizedShape], dtype, true, device: device);
		Initialize(weight, eps);
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
