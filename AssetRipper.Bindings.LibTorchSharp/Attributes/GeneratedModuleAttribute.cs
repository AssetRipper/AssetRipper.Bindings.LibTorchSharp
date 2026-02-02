namespace AssetRipper.Bindings.LibTorchSharp.Attributes;

[AttributeUsage(AttributeTargets.Struct)]
public sealed class GeneratedModuleAttribute() : Attribute
{
	public bool IsTrainingField { get; set; }
}
