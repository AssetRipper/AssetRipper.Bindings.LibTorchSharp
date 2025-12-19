namespace AssetRipper.Bindings.LibTorchSharp.Modules;

public partial struct Linear
{
	private static readonly double _sqrt5 = double.Sqrt(5);

	public readonly Tensor Weights => weights;
	public readonly Tensor Bias => bias;

	public Linear(long inFeatures, long outFeatures, bool hasBias = true, ScalarType? dtype = null, Device? device = null)
	{
		weights = Tensor.Empty([outFeatures, inFeatures], (dtype ?? ScalarType.Float32), true, device);
		Init.KaimingUniformInline(weights, _sqrt5, 0, 10); // tensor, sqrt(5), fan_in, leaky relu
		if (hasBias)
		{
			bias = Tensor.Empty([outFeatures], (dtype ?? ScalarType.Float32), true, device);
			(long fanIn, long _) = Init.CalculateFanInAndFanOut(weights);
			double bound = fanIn > 0 ? 1 / double.Sqrt(fanIn) : 0;
			Init.UniformInline(bias, -bound, bound);
		}
		else
		{
			bias = null;
		}
	}

	// Because this module doesn't have any native sub-modules,
	// it can be constructed directly from a state dictionary.
	public Linear(StateDictionary dictionary)
	{
		weights = dictionary.GetTensor(nameof(weights));
		bias = dictionary.GetTensor(nameof(bias));
	}
}
