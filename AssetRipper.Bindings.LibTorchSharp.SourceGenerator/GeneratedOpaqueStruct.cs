using AssetRipper.Text.SourceGeneration;
using Microsoft.CodeAnalysis;
using SGF;
using System.CodeDom.Compiler;
using System.IO;
using System.Linq;

namespace AssetRipper.Bindings.LibTorchSharp.SourceGenerator;

internal sealed class GeneratedOpaqueStruct(StructData @struct) : GeneratedReadOnlyStruct
{
	public StructData Struct { get; } = @struct;
	public override string Name => Struct.StructName;
	public override string Namespace => Struct.StructNamespace;

	public override bool IsInstance(MethodData method)
	{
		return method.Parameters.Length > 0 && method.Parameters[0].Type == Struct.StructType;
	}
	public static GeneratedOpaqueStruct Create(StructData @struct) => new(@struct);

	public override void GenerateConstructorFile(SgfSourceProductionContext context)
	{
		MethodData staticMethod = Methods
			.Select(p => p.MidLevel)
			.Where(IsStatic)
			.FirstOrDefault(m => m.Name is "Create" && m.ReturnType == Struct.StructType);

		if (staticMethod == default)
		{
			return;
		}

		StringWriter stringWriter = new();
		IndentedTextWriter writer = IndentedTextWriterFactory.Create(stringWriter);

		writer.WriteUsing("AssetRipper.Bindings.LibTorchSharp.LowLevel");
		writer.WriteLineNoTabs();
		writer.WriteFileScopedNamespace(Namespace);
		writer.WriteLineNoTabs();
		writer.WriteLine($"public readonly unsafe partial struct {Name}");
		using (new CurlyBrackets(writer))
		{
			writer.Write("public ");
			writer.Write(Name);
			writer.Write('(');
			writer.Write(string.Join(", ", staticMethod.Parameters));
			writer.WriteLine(')');
			using (new CurlyBrackets(writer))
			{
				writer.Write("this.handle = Create(");
				writer.Write(string.Join(", ", staticMethod.Parameters.Select(p => p.NameWithOutPrefix)));
				writer.WriteLine(");");
			}
		}

		context.AddSource($"{Name}.Constructor.cs", stringWriter.ToString());
	}

	public override void GenerateMainFile(SgfSourceProductionContext context)
	{
		context.AddSource($"{Name}.cs", $$"""
			using AssetRipper.Bindings.LibTorchSharp.LowLevel;

			namespace {{Namespace}};

			public readonly unsafe partial struct {{Name}} : System.IEquatable<{{Name}}>
			{
				private readonly {{Struct.OpaqueName}}* handle;

				public static {{Name}} Null => default;

				public bool IsNull => handle == null;

				public {{Name}}({{Struct.OpaqueName}}* handle)
				{
					this.handle = handle;
				}

				public static implicit operator {{Struct.OpaqueName}}*({{Name}} value) => value.handle;
				public static implicit operator {{Name}}({{Struct.OpaqueName}}* value) => new(value);

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
					return handle == other.handle;
				}

				public override int GetHashCode()
				{
					return new System.IntPtr(handle).GetHashCode();
				}
			}
			""");
	}
}
