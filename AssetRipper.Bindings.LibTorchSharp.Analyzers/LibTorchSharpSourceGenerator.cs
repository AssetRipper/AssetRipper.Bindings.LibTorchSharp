using SGF;

namespace AssetRipper.Bindings.LibTorchSharp.Analyzers;

[IncrementalGenerator]
public partial class LibTorchSharpSourceGenerator() : IncrementalGenerator(nameof(LibTorchSharpSourceGenerator))
{
	public override void OnInitialize(SgfInitializationContext context)
	{
	}
}
