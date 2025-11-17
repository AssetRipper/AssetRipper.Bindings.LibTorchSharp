using AssetRipper.Bindings.LibTorchSharp.Attributes;
using AssetRipper.Bindings.LibTorchSharp.LowLevel;

namespace AssetRipper.Bindings.LibTorchSharp;

[OpaqueStruct(nameof(OpaqueJITModule), "JIT_Module")]
public readonly partial struct JITModule
{
}
