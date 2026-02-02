using AssetRipper.Bindings.LibTorchSharp.Attributes;
using System.Diagnostics;

namespace AssetRipper.Bindings.LibTorchSharp.Modules;

[GeneratedModule]
public readonly partial struct BooleanEmbedding
{
	private partial Tensor trueEmbedding { get; }
	private partial Tensor falseEmbedding { get; }

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public Tensor TrueEmbedding => trueEmbedding.AliasOrNull();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public Tensor FalseEmbedding => falseEmbedding.AliasOrNull();

	public BooleanEmbedding(long embeddingDim, ScalarType dtype = ScalarType.Float32, Device? device = null)
	{
		ArgumentOutOfRangeException.ThrowIfNegativeOrZero(embeddingDim);
		Tensor trueEmbedding = Tensor.Empty([embeddingDim], dtype, true, device);
		Tensor falseEmbedding = Tensor.Empty([embeddingDim], dtype, true, device);
		double bound = 1.0 / double.Sqrt(embeddingDim);
		Init.UniformInline(trueEmbedding, -bound, bound);
		Init.UniformInline(falseEmbedding, -bound, bound);
		Initialize(trueEmbedding, falseEmbedding);
	}

	public Tensor Forward(Tensor input)
	{
		using Tensor unsqueezed = input.Unsqueeze(-1);
		return unsqueezed.Where(trueEmbedding, falseEmbedding);
	}
}
