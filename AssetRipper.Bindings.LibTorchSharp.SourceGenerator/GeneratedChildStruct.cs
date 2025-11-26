using AssetRipper.Text.SourceGeneration;
using SGF;
using System.CodeDom.Compiler;
using System.IO;
using System.Linq;

namespace AssetRipper.Bindings.LibTorchSharp.SourceGenerator;

internal sealed class GeneratedChildStruct(GeneratedOpaqueStruct parent, string name) : GeneratedReadOnlyStruct
{
	public GeneratedOpaqueStruct Parent { get; } = parent;
	public TypeData ParentType => Parent.Struct.StructType;
	public TypeData Type => new(Name, 0);
	public override string Name { get; } = name;
	public override bool IsInstance(MethodData method)
	{
		return method.Parameters.Length > 0 && method.Parameters[0].Type == ParentType && method.Name is not "ctor";
	}

	public override void GenerateMainFile(SgfSourceProductionContext context)
	{
		context.AddSource($"{Name}.cs", $$"""
			using AssetRipper.Bindings.LibTorchSharp.LowLevel;

			namespace AssetRipper.Bindings.LibTorchSharp;

			public readonly unsafe partial struct {{Name}} : System.IEquatable<{{Name}}>
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
			
				public override bool Equals(object? obj)
				{
					return obj is {{Name}} other && Equals(other);
				}
			
				public bool Equals({{Name}} other)
				{
					return handle.Equals(other.handle);
				}
			
				public override int GetHashCode()
				{
					return handle.GetHashCode();
				}
			}
			""");
	}

	public override void GenerateConstructorFile(SgfSourceProductionContext context)
	{
		MethodData staticMethod = Methods
			.Select(p => p.MidLevel)
			.Where(IsStatic)
			.First(m => m.Name is "ctor" && m.ReturnType == Type);

		StringWriter stringWriter = new();
		IndentedTextWriter writer = IndentedTextWriterFactory.Create(stringWriter);

		writer.WriteUsing("AssetRipper.Bindings.LibTorchSharp.LowLevel");
		writer.WriteLineNoTabs();
		writer.WriteFileScopedNamespace("AssetRipper.Bindings.LibTorchSharp");
		writer.WriteLineNoTabs();
		writer.WriteLine($"public readonly unsafe partial struct {Name}");
		using (new CurlyBrackets(writer))
		{
			if (staticMethod.Parameters.Length > 0 && staticMethod.Parameters[^1] is { IsOut: true, Type: { Name: "NNAnyModule", IsPointer: false }, Name: "outAsAnyModule" })
			{
				writer.Write("public ");
				writer.Write(Name);
				writer.Write('(');
				writer.Write(string.Join(", ", staticMethod.Parameters.SkipLast(1)));
				writer.WriteLine(')');
				using (new CurlyBrackets(writer))
				{
					writer.Write("this.handle = ctor(");
					writer.Write(string.Join(", ", staticMethod.Parameters.SkipLast(1).Select(p => p.NameWithOutPrefix).Append("out NNAnyModule outAsAnyModule")));
					writer.WriteLine(");");
					writer.WriteLine("outAsAnyModule.Dispose();");
				}

				writer.Write("public static NNAnyModule CreateAsAnyModule(");
				writer.Write(string.Join(", ", staticMethod.Parameters.SkipLast(1)));
				writer.WriteLine(')');
				using (new CurlyBrackets(writer))
				{
					writer.Write("ctor(");
					writer.Write(string.Join(", ", staticMethod.Parameters.SkipLast(1).Select(p => p.NameWithOutPrefix).Append("out NNAnyModule outAsAnyModule")));
					writer.WriteLine(").Dispose();");
					writer.WriteLine("return outAsAnyModule;");
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
					writer.Write(string.Join(", ", staticMethod.Parameters.Select(p => p.NameWithOutPrefix)));
					writer.WriteLine(");");
				}
			}
		}

		context.AddSource($"{Name}.Constructor.cs", stringWriter.ToString());
	}
}
