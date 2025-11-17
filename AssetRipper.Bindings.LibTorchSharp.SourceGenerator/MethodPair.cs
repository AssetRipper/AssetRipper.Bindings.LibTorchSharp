using System;

namespace AssetRipper.Bindings.LibTorchSharp.SourceGenerator;

internal readonly record struct MethodPair(MethodData MidLevel, MethodData LowLevel) : IComparable<MethodPair>
{
	int IComparable<MethodPair>.CompareTo(MethodPair other) => MidLevel.Name.CompareTo(other.MidLevel.Name);
}