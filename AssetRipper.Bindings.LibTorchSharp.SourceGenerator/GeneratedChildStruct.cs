using AssetRipper.Text.SourceGeneration;
using SGF;
using System.CodeDom.Compiler;
using System.IO;
using System.Linq;

namespace AssetRipper.Bindings.LibTorchSharp.SourceGenerator;

internal sealed class GeneratedChildStruct(GeneratedOpaqueStruct parent, string name) : GeneratedReadOnlyStruct
{
	public GeneratedOpaqueStruct Parent { get; } = parent;
	public override string Name { get; } = name;
	public override bool IsInstance(MethodData method)
	{
		return method.Parameters.Length > 0 && method.Parameters[0].Type == Parent.Struct.StructType && method.Name is not "ctor";
	}

	public override void GenerateMainFile(SgfSourceProductionContext context)
	{
		context.AddSource($"{Name}.cs", $$"""
            using AssetRipper.Bindings.LibTorchSharp.LowLevel;

            namespace AssetRipper.Bindings.LibTorchSharp;

            public readonly unsafe partial struct {{Name}}
            {
                private readonly {{Parent.Name}} handle;

                public static {{Name}} Null => default;

                public bool IsNull => handle.IsNull;

                internal {{Name}}({{Parent.Name}} handle)
                {
                    this.handle = handle;
                }

                public static implicit operator {{Parent.Struct.OpaqueName}}*({{Name}} value) => value.handle;
                public static explicit operator {{Name}}({{Parent.Struct.OpaqueName}}* value) => new(value);

                public static implicit operator {{Parent.Name}}({{Name}} value) => value.handle;
                public static explicit operator {{Name}}({{Parent.Name}} value) => new(value);

                public void ThrowIfNull()
                {
                    if (IsNull)
                    {
                        throw new System.NullReferenceException("{{Name}} handle is null.");
                    }
                }
            }
            """);
	}

	public override void GenerateDisposableFile(SgfSourceProductionContext context)
	{
		if (!Parent.IsDisposable)
		{
			return;
		}

		context.AddSource($"{Name}.Disposable.cs", $$"""
            namespace {{Namespace}};

            public readonly unsafe partial struct {{Name}} : System.IDisposable
            {
                public void Dispose() => handle.Dispose();
            }
            """);
	}

	public override void GenerateConstructorFile(SgfSourceProductionContext context)
	{
		MethodData staticMethod = Methods
			.Select(p => p.MidLevel)
			.Where(IsStatic)
			.First(m => m.Name is "ctor" && m.ReturnType == Parent.Struct.StructType);

		StringWriter stringWriter = new();
		IndentedTextWriter writer = IndentedTextWriterFactory.Create(stringWriter);

		writer.WriteUsing("AssetRipper.Bindings.LibTorchSharp.LowLevel");
		writer.WriteLineNoTabs();
		writer.WriteFileScopedNamespace("AssetRipper.Bindings.LibTorchSharp");
		writer.WriteLineNoTabs();
		writer.WriteLine($"public readonly unsafe partial struct {Name}");
		using (new CurlyBrackets(writer))
		{
			if (staticMethod.Parameters.Length > 0 && staticMethod.Parameters[^1] is { Type.IsPointer: true, Name: "outAsAnyModule" })
			{
				writer.Write("public ");
				writer.Write(Name);
				writer.Write('(');
				writer.Write(string.Join(", ", staticMethod.Parameters.SkipLast(1)));
				writer.WriteLine(')');
				using (new CurlyBrackets(writer))
				{
					writer.Write("this.handle = ctor(");
					writer.Write(string.Join(", ", staticMethod.Parameters.SkipLast(1).Select(p => p.Name).Append("null")));
					writer.WriteLine(");");
				}
			}
			else
			{
				writer.Write("public ");
				writer.Write(Name);
				writer.Write('(');
				writer.Write(string.Join(", ", staticMethod.Parameters));
				writer.WriteLine(')');
				using (new CurlyBrackets(writer))
				{
					writer.Write("this.handle = ctor(");
					writer.Write(string.Join(", ", staticMethod.Parameters.Select(p => p.Name)));
					writer.WriteLine(");");
				}
			}
		}

		context.AddSource($"{Name}.Constructor.cs", stringWriter.ToString());
	}
}
