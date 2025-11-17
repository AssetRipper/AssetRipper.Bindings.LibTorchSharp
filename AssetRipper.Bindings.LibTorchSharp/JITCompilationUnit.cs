using AssetRipper.Bindings.LibTorchSharp.Attributes;
using AssetRipper.Bindings.LibTorchSharp.LowLevel;

namespace AssetRipper.Bindings.LibTorchSharp;

[OpaqueStruct(nameof(OpaqueJITCompilationUnit), "JIT_CompilationUnit")]
public readonly partial struct JITCompilationUnit
{
}
