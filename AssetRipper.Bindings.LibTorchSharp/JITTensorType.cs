using AssetRipper.Bindings.LibTorchSharp.Attributes;
using AssetRipper.Bindings.LibTorchSharp.LowLevel;

namespace AssetRipper.Bindings.LibTorchSharp;

[OpaqueStruct(nameof(OpaqueJITTensorType), "JIT_TensorType")]
public readonly partial struct JITTensorType
{
}
