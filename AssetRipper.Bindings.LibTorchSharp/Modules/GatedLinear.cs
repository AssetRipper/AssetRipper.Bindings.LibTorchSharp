using AssetRipper.Bindings.LibTorchSharp.Attributes;

namespace AssetRipper.Bindings.LibTorchSharp.Modules;

[GeneratedModule]
public readonly partial struct GatedLinear
{
	private partial Linear outputLayer { get; }
	private partial Linear gateLayer { get; }
	private partial Linear valueLayer { get; }

	public GatedLinear(long inFeatures, long hiddenFeatures, long outFeatures, bool hasBias = true, ScalarType dtype = ScalarType.Float32, Device? device = null)
	{
		Linear outputLayer = new Linear(hiddenFeatures, outFeatures, hasBias, dtype, device);
		Linear gateLayer = new Linear(inFeatures, hiddenFeatures, hasBias, dtype, device);
		Linear valueLayer = new Linear(inFeatures, hiddenFeatures, hasBias, dtype, device);
		Initialize(outputLayer, gateLayer, valueLayer);
	}

	public GatedLinear(StateDictionary dictionary)
	{
		Linear outputLayer = new Linear(dictionary.GetChild(nameof(outputLayer)));
		Linear gateLayer = new Linear(dictionary.GetChild(nameof(gateLayer)));
		Linear valueLayer = new Linear(dictionary.GetChild(nameof(valueLayer)));
		Initialize(outputLayer, gateLayer, valueLayer);
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
