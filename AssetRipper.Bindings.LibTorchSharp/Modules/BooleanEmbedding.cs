namespace AssetRipper.Bindings.LibTorchSharp.Modules;

public partial struct BooleanEmbedding
{
	private Tensor trueEmbedding;
	private Tensor falseEmbedding;

	public BooleanEmbedding(long embeddingDim, ScalarType? dtype = null, Device? device = null)
	{
		ArgumentOutOfRangeException.ThrowIfNegativeOrZero(embeddingDim);
		trueEmbedding = Tensor.Empty([embeddingDim], dtype ?? ScalarType.Float32, true, device);
		falseEmbedding = Tensor.Empty([embeddingDim], dtype ?? ScalarType.Float32, true, device);
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

	public BooleanEmbedding(StateDictionary dictionary)
	{
		trueEmbedding = dictionary.GetTensor(nameof(trueEmbedding));
		falseEmbedding = dictionary.GetTensor(nameof(falseEmbedding));
	}

	public void CopyFrom(StateDictionary dictionary)
	{
		Tensor temp_true = dictionary.GetTensor(nameof(trueEmbedding));
		Tensor temp_false = dictionary.GetTensor(nameof(falseEmbedding));
		trueEmbedding.Dispose();
		trueEmbedding = temp_true;
		falseEmbedding.Dispose();
		falseEmbedding = temp_false;
	}

	public readonly void CopyTo(StateDictionary dictionary)
	{
		dictionary.AddTensor(nameof(trueEmbedding), trueEmbedding);
		dictionary.AddTensor(nameof(falseEmbedding), falseEmbedding);
	}

	public void Dispose()
	{
		trueEmbedding.Dispose();
		trueEmbedding = default;
		falseEmbedding.Dispose();
		falseEmbedding = default;
	}
}
