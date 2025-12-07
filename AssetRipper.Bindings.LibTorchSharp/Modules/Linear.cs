namespace AssetRipper.Bindings.LibTorchSharp.Modules;

public partial struct Linear
{
	private static readonly double _sqrt5 = double.Sqrt(5);
	public Tensor weights { readonly get; private set; }
	public Tensor bias { readonly get; private set; }

	public Linear(long inFeatures, long outFeatures, bool hasBias = true, ScalarType? dtype = null, Device? device = null)
	{
		weights = Tensor.empty([outFeatures, inFeatures], (dtype ?? ScalarType.Float32), true, device);
		Init.kaiming_uniform_(weights, _sqrt5, 0, 10); // tensor, sqrt(5), fan_in, leaky relu
		if (hasBias)
		{
			bias = Tensor.empty([outFeatures], (dtype ?? ScalarType.Float32), true, device);
			(long fanIn, long _) = Init.CalculateFanInAndFanOut(weights);
			double bound = fanIn > 0 ? 1 / double.Sqrt(fanIn) : 0;
			Init.uniform_(bias, -bound, bound);
		}
		else
		{
			bias = null;
		}
	}

	public readonly Tensor Forward(Tensor tensor)
	{
		return NN.linear(tensor, weights, bias);
	}
}
public partial struct Linear : IDisposable, IModule
{
	// Source generated
	public Linear(Tensor weights, Tensor bias)
	{
		this.weights = weights;
		this.bias = bias;
	}

	// Because this module doesn't have any native sub-modules,
	// it can be constructed directly from a state dictionary.
	public Linear(StateDictionary dictionary)
	{
		weights = dictionary.GetTensor(nameof(weights));
		bias = dictionary.GetTensor(nameof(bias));
	}

	public void CopyFrom(StateDictionary dictionary)
	{
		Tensor temp_weight = dictionary.GetTensor(nameof(weights));
		weights.Dispose();
		weights = temp_weight;

		Tensor temp_bias = dictionary.GetTensor(nameof(bias));
		bias.Dispose();
		bias = temp_bias;
	}

	public readonly void CopyTo(StateDictionary dictionary)
	{
		dictionary.AddTensor(nameof(weights), weights);
		dictionary.AddTensor(nameof(bias), bias);
	}

	public void Dispose()
	{
		weights.Dispose();
		weights = default;
		bias.Dispose();
		bias = default;
	}
}
