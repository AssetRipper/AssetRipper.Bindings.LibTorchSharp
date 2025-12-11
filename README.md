# AssetRipper.Bindings.LibTorchSharp

[![](https://img.shields.io/nuget/vpre/AssetRipper.Bindings.LibTorchSharp)](https://www.nuget.org/packages/AssetRipper.Bindings.LibTorchSharp)

This is an alternate binding library for [LibTorchSharp](https://github.com/dotnet/TorchSharp/tree/main/src/Native), the native library portion of [TorchSharp](https://github.com/dotnet/TorchSharp).

## Differences from TorchSharp

This opinionated library requires unwavering vigilance to memory management, in exchange for maximum performance. Here be dragons.

### .NET 10

This library is built targeting .NET 10, while TorchSharp multi-targets older versions, including .NET Standard 2.0.

### Allocations

TorchSharp relies on the garbage collector to protect against native memory leaks. This library eliminates managed allocations by relying on users to dispose any native objects they create.

```csharp
using Tensor tensor = new Tensor([1, 2, 3]);
```

### Level of abstraction

This library exposes the native API directly and also offers a more user-friendly layer over top of that. TorchSharp is high-level and tries to mirror the PyTorch API almost exactly.

### Maintenance

Most of this library is procedurally generated.

* [ClangSharp](https://github.com/dotnet/clangsharp/) is used to generate the low-level interop code.
* A custom Roslyn source generator is used to create a mid-level layer on top of the interop code.

TorchSharp includes some hand-written C# code. Nearly all of that functionality is omitted from this library.

### Documentation

Procedurally generated code is not documented in this library. Users should refer to the TorchSharp source code or the [official PyTorch documentation](https://docs.pytorch.org/docs/stable/index.html).
