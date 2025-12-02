using AssetRipper.Bindings.LibTorchSharp.Attributes;
using AssetRipper.Bindings.LibTorchSharp.LowLevel;

namespace AssetRipper.Bindings.LibTorchSharp.Modules;

[OpaqueStruct(nameof(OpaqueNNModule), "NN_Module")]
public readonly partial struct NNModule
{
}
