namespace AssetRipper.Bindings.LibTorchSharp.Modules;

public partial struct GatedLinear
{
	private Linear outputLayer;
	private Linear gateLayer;
	private Linear valueLayer;

	public GatedLinear(long inFeatures, long hiddenFeatures, long outFeatures, bool hasBias = true, ScalarType dtype = ScalarType.Float32, Device? device = null)
	{
		outputLayer = new Linear(hiddenFeatures, outFeatures, hasBias, dtype, device);
		gateLayer = new Linear(inFeatures, hiddenFeatures, hasBias, dtype, device);
		valueLayer = new Linear(inFeatures, hiddenFeatures, hasBias, dtype, device);
	}

	public Tensor Forward(Tensor input)
	{
		using Tensor tensor = gateLayer.Forward(input);
		using Tensor gate = tensor.Silu();
		using Tensor value = valueLayer.Forward(input);
		using Tensor gatedValue = gate * value;
		return outputLayer.Forward(gatedValue);
	}
}
public partial struct GatedLinear : IModule
{
	// Source generated
	public readonly bool IsTraining
	{
		set
		{
			outputLayer.IsTraining = value;
			gateLayer.IsTraining = value;
			valueLayer.IsTraining = value;
		}
	}

	void IModule.CopyFromRoot(StateDictionary dictionary)
	{
		outputLayer.CopyFrom(dictionary);
		gateLayer.CopyFrom(dictionary);
		valueLayer.CopyFrom(dictionary);
	}

	readonly void IModule.CopyToRoot(StateDictionary dictionary)
	{
		outputLayer.CopyTo(dictionary);
		gateLayer.CopyTo(dictionary);
		valueLayer.CopyTo(dictionary);
	}

	public readonly IEnumerable<Tensor> GetParameters() =>
	[
		..outputLayer.GetParameters(),
		..gateLayer.GetParameters(),
		..valueLayer.GetParameters(),
	];

	public void Dispose()
	{
		outputLayer.Dispose();
		outputLayer = default;
		gateLayer.Dispose();
		gateLayer = default;
		valueLayer.Dispose();
		valueLayer = default;
	}

	public GatedLinear(StateDictionary dictionary)
	{
		outputLayer = new Linear(dictionary.GetChild(nameof(outputLayer)));
		gateLayer = new Linear(dictionary.GetChild(nameof(gateLayer)));
		valueLayer = new Linear(dictionary.GetChild(nameof(valueLayer)));
	}
}
