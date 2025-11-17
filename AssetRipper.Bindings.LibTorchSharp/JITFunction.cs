using AssetRipper.Bindings.LibTorchSharp.Attributes;
using AssetRipper.Bindings.LibTorchSharp.LowLevel;

namespace AssetRipper.Bindings.LibTorchSharp;

[OpaqueStruct(nameof(OpaqueJITFunction), "JIT_Function")]
public readonly partial struct JITFunction
{
}
