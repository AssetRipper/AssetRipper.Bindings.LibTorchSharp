using SGF;
using System.Linq;

namespace AssetRipper.Bindings.LibTorchSharp.SourceGenerator;

internal abstract class GeneratedReadOnlyStruct : GeneratedType
{
	public sealed override string Kind => "readonly partial struct";
	public bool IsDisposable => Methods.Select(p => p.MidLevel).Where(IsInstance).Any(m => m.Name is "dispose" && m.ReturnType.IsVoid && m.Parameters.Length is 1);

	public override void GenerateDisposableFile(SgfSourceProductionContext context)
	{
		if (!IsDisposable)
		{
			return;
		}

		context.AddSource($"{Name}.Disposable.cs", $$"""
			namespace {{Namespace}};
				
			public readonly unsafe partial struct {{Name}} : System.IDisposable
			{
				public void Dispose()
				{
					if (!IsNull)
					{
						dispose();
					}
				}
			}
			""");
	}
}
