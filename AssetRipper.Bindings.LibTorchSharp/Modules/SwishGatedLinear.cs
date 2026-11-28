using AssetRipper.Bindings.LibTorchSharp.Attributes;

namespace AssetRipper.Bindings.LibTorchSharp.Modules;

[GeneratedModule]
public readonly partial struct SwishGatedLinear
{
	private partial Linear outputLayer { get; }
	private partial Linear gateLayer { get; }
	private partial Linear valueLayer { get; }

	public SwishGatedLinear(long inFeatures, long hiddenFeatures, long outFeatures, bool hasBias = true, ScalarType dtype = ScalarType.Float32, Device? device = null)
	{
		Linear outputLayer = new(hiddenFeatures, outFeatures, hasBias, dtype, device);
		Linear gateLayer = new(inFeatures, hiddenFeatures, hasBias, dtype, device);
		Linear valueLayer = new(inFeatures, hiddenFeatures, hasBias, dtype, device);
		Initialize(outputLayer, gateLayer, valueLayer);
	}

	public SwishGatedLinear(StateDictionary dictionary)
	{
		Linear outputLayer = new(dictionary.GetChild(nameof(outputLayer)));
		Linear gateLayer = new(dictionary.GetChild(nameof(gateLayer)));
		Linear valueLayer = new(dictionary.GetChild(nameof(valueLayer)));
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
