using AssetRipper.Bindings.LibTorchSharp.Attributes;
using System.Diagnostics;

namespace AssetRipper.Bindings.LibTorchSharp.Modules;

[GeneratedModule]
public readonly partial struct Linear
{
	private partial Tensor weights { get; }
	private partial Tensor bias { get; }

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public readonly Tensor Weights => weights.AliasOrNull();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public readonly Tensor Bias => bias.AliasOrNull();

	public Linear(long inFeatures, long outFeatures, bool hasBias = true, ScalarType dtype = ScalarType.Float32, Device? device = null)
	{
		Tensor weights = Tensor.Empty([outFeatures, inFeatures], dtype, true, device);
		Init.KaimingUniformInline(weights, double.Sqrt(5), 0, 10); // tensor, sqrt(5), fan_in, leaky relu
		Tensor bias;
		if (hasBias)
		{
			bias = Tensor.Empty([outFeatures], dtype, true, device);
			(long fanIn, long _) = Init.CalculateFanInAndFanOut(weights);
			double bound = fanIn > 0 ? 1 / double.Sqrt(fanIn) : 0;
			Init.UniformInline(bias, -bound, bound);
		}
		else
		{
			bias = null;
		}
		Initialize(weights, bias);
	}

	// Because this module doesn't have any native sub-modules,
	// it can be constructed directly from a state dictionary.
	public Linear(StateDictionary dictionary)
	{
		Tensor weights = dictionary.GetTensor(nameof(weights));
		Tensor bias = dictionary.GetTensor(nameof(bias));
		Initialize(weights, bias);
	}

	[DebuggerHidden]
	[DebuggerStepThrough]
	[StackTraceHidden]
	public Tensor Forward(Tensor input)
	{
		return NN.Linear(input, weights, bias);
	}
}
