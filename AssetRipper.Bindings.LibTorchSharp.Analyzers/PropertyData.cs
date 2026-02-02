using System;
using System.Runtime.InteropServices;

namespace AssetRipper.Bindings.LibTorchSharp.Analyzers;

[StructLayout(LayoutKind.Auto)]
internal readonly record struct PropertyData(string Type, string Name)
{
	public string AsParameterString() => $"{Type} {Name}";
	public bool IsTensor => Type is "global::AssetRipper.Bindings.LibTorchSharp.Tensor";
	public bool IsTensorArray => Type is "global::AssetRipper.Bindings.LibTorchSharp.Modules.TensorArray";
	public bool IsModuleArray => Type.StartsWith("global::AssetRipper.Bindings.LibTorchSharp.Modules.ModuleArray<", StringComparison.Ordinal);
	public bool IsPrimitive => !Type.StartsWith("global::", StringComparison.Ordinal);
	public bool IsModule => !IsTensor && !IsPrimitive && !IsModuleArray && !IsTensorArray;
	public bool IsStorable => !IsPrimitive;
	public bool IsDisposable => !IsPrimitive;
}
