namespace AssetRipper.Bindings.LibTorchSharp.Modules;

public partial struct BooleanEmbedding
{
	private Tensor trueEmbedding;
	private Tensor falseEmbedding;

	public BooleanEmbedding(long embeddingDim, ScalarType dtype = ScalarType.Float32, Device? device = null)
	{
		ArgumentOutOfRangeException.ThrowIfNegativeOrZero(embeddingDim);
		trueEmbedding = Tensor.Empty([embeddingDim], dtype, true, device);
		falseEmbedding = Tensor.Empty([embeddingDim], dtype, true, device);
		double bound = 1.0 / double.Sqrt(embeddingDim);
		Init.UniformInline(trueEmbedding, -bound, bound);
		Init.UniformInline(falseEmbedding, -bound, bound);
	}

	public readonly Tensor Forward(Tensor input)
	{
		using Tensor unsqueezed = input.Unsqueeze(-1);
		return unsqueezed.Where(trueEmbedding, falseEmbedding);
	}
}
public partial struct BooleanEmbedding : IModule
{
	// Source generated
	public readonly bool IsTraining
	{
		set
		{
		}
	}
	public readonly Tensor TrueEmbedding => trueEmbedding.Alias();
	public readonly Tensor FalseEmbedding => falseEmbedding.Alias();

	public BooleanEmbedding(Tensor trueEmbedding, Tensor falseEmbedding)
	{
		this.trueEmbedding = trueEmbedding;
		this.falseEmbedding = falseEmbedding;
	}

	void IModule.CopyFromRoot(StateDictionary dictionary)
	{
		trueEmbedding.CopyFrom(dictionary);
		falseEmbedding.CopyFrom(dictionary);
	}

	readonly void IModule.CopyToRoot(StateDictionary dictionary)
	{
		trueEmbedding.CopyTo(dictionary);
		falseEmbedding.CopyTo(dictionary);
	}

	public void Dispose()
	{
		trueEmbedding.DisposeAndSetDefault();
		falseEmbedding.DisposeAndSetDefault();
	}

	public readonly IEnumerable<Tensor> GetParameters() => [TrueEmbedding, FalseEmbedding];
}
