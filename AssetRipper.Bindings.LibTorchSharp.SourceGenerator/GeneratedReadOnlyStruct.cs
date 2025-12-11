using SGF;
using System.Linq;

namespace AssetRipper.Bindings.LibTorchSharp.SourceGenerator;

internal abstract class GeneratedReadOnlyStruct : GeneratedType
{
	public sealed override string Kind => "readonly partial struct";
	public bool IsDisposable => Methods.Select(p => p.MidLevel).Where(IsInstance).Any(m => m.Name is "__Dispose" && m.ReturnType.IsVoid && m.Parameters.Length is 1);

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
				[global::System.Diagnostics.DebuggerHidden]
				[global::System.Diagnostics.DebuggerNonUserCode]
				[global::System.Diagnostics.DebuggerStepThrough]
				[global::System.Diagnostics.StackTraceHidden]
				public void Dispose()
				{
					if (!IsNull)
					{
						__Dispose();
					}
				}
			}
			""");
	}
}
