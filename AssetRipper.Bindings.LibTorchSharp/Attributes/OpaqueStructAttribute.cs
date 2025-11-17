namespace AssetRipper.Bindings.LibTorchSharp.Attributes;

[AttributeUsage(AttributeTargets.Struct)]
internal sealed class OpaqueStructAttribute(string opaqueName, string? methodPrefix = null) : Attribute
{
	public string OpaqueName { get; } = opaqueName;

	public string? MethodPrefix { get; } = methodPrefix;
}
