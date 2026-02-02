using AssetRipper.Bindings.LibTorchSharp.Attributes;
using System.Diagnostics;

namespace AssetRipper.Bindings.LibTorchSharp.Modules;

[GeneratedModule]
public readonly partial struct Bilinear
{
	private partial Tensor weights { get; }
	private partial Tensor bias { get; }

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public readonly Tensor Weights => weights.AliasOrNull();
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public readonly Tensor Bias => bias.AliasOrNull();

	[DebuggerHidden]
	[DebuggerStepThrough]
	[StackTraceHidden]
	public Tensor Forward(Tensor input1, Tensor input2)
	{
		return NN.Bilinear(input1, input2, weights, bias);
	}
}
