using System;

namespace AssetRipper.Bindings.LibTorchSharp.SourceGenerator;

internal readonly record struct PropertyData(TypeData Type, string Name, bool IsInstance, MethodPair? GetMethod, MethodPair? SetMethod) : IComparable<PropertyData>
{
	int IComparable<PropertyData>.CompareTo(PropertyData other) => Name.CompareTo(other.Name);
}
