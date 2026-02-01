using SGF;
using System;

namespace AssetRipper.Bindings.LibTorchSharp.SourceGenerator;

internal sealed class CSharpNodeType : GeneratedType
{
	public override string Kind => "partial struct";

	public override string Name => "CSharpNode";

	public override string Namespace => "AssetRipper.Bindings.LibTorchSharp.LowLevel";

	public override bool IsInstance(MethodData method)
	{
		return method.Parameters.Length > 0 && method.Parameters[0].Type == new TypeData(Name);
	}

	public void TransferMethodsFrom(GeneratedStaticClass autogradClass)
	{
		for (int i = autogradClass.Methods.Count - 1; i >= 0; i--)
		{
			(MethodData method, MethodData nativeMethod) = autogradClass.Methods[i];
			if (method.Name.StartsWith("CSharpNode_", StringComparison.Ordinal))
			{
				autogradClass.Methods.RemoveAt(i);
				if (IsInstance(method))
				{
					method = method.ChangeFirstParameterNameToThis();
				}
				method = method with { Name = method.GetNameInType("CSharpNode_") };
				Methods.Add(new(method, nativeMethod));
			}
		}
	}

	public override void GenerateMainFile(SgfSourceProductionContext context)
	{
		context.AddSource("CSharpNode.cs", """
			namespace AssetRipper.Bindings.LibTorchSharp.LowLevel;
			public unsafe partial struct CSharpNode
			{
				[global::System.Diagnostics.DebuggerHidden]
				[global::System.Diagnostics.DebuggerNonUserCode]
				[global::System.Diagnostics.DebuggerStepThrough]
				[global::System.Diagnostics.StackTraceHidden]
				public unsafe void ThrowIfNull()
				{
					if (shared_ptr is null && weak_ptr is null)
					{
						throw new global::System.NullReferenceException("Node is null");
					}
				}
			}
			""");
	}
}
