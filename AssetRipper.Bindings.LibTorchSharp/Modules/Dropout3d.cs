using AssetRipper.Bindings.LibTorchSharp.Attributes;
using System.Diagnostics;

namespace AssetRipper.Bindings.LibTorchSharp.Modules;

[GeneratedModule(IsTrainingField = true)]
public readonly partial struct Dropout3d
{
	private partial double p { get; }

	[DebuggerHidden]
	[DebuggerStepThrough]
	[StackTraceHidden]
	public Tensor Forward(Tensor input)
	{
		return NN.Dropout3d(input, p, IsTraining, inplace: false);
	}
}
