using AssetRipper.Bindings.LibTorchSharp.SourceGenerator.Extensions;
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
	public override string Namespace => Parent.Namespace;
	public override bool IsInstance(MethodData method)
	{
		return method.Parameters.Length > 0 && method.Parameters[0].Type == ParentType && method.Name is not "Create";
	}

	public override void GenerateMainFile(SgfSourceProductionContext context)
	{
		context.AddSource($"{Name}.cs", $$"""
			using AssetRipper.Bindings.LibTorchSharp.LowLevel;

			namespace {{Namespace}};

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
			
				[global::System.Diagnostics.DebuggerHidden]
				[global::System.Diagnostics.DebuggerNonUserCode]
				[global::System.Diagnostics.DebuggerStepThrough]
				[global::System.Diagnostics.StackTraceHidden]
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
			.First(m => m.Name is "Create" && m.ReturnType == Type);

		StringWriter stringWriter = new();
		IndentedTextWriter writer = IndentedTextWriterFactory.Create(stringWriter);

		writer.WriteUsing("AssetRipper.Bindings.LibTorchSharp.LowLevel");
		writer.WriteLineNoTabs();
		writer.WriteFileScopedNamespace(Namespace);
		writer.WriteLineNoTabs();
		writer.WriteLine($"public readonly unsafe partial struct {Name}");
		using (new CurlyBrackets(writer))
		{
			if (staticMethod.Parameters.Length > 0 && staticMethod.Parameters[^1] is { IsOut: false, Type: { Name: "NNAnyModule", IsPointer: true }, Name: "outAsAnyModule" })
			{
				ParameterData deviceParameter = new(new("Device?"), "device", DefaultValue: "null");
				writer.WriteDebuggerIgnoreAttributes();
				writer.Write("public ");
				writer.Write(Name);
				writer.Write('(');
				writer.Write(string.Join(", ", staticMethod.Parameters.SkipLast(1).Concat([deviceParameter])));
				writer.WriteLine(')');
				using (new CurlyBrackets(writer))
				{
					writer.Write("this.handle = Create(");
					writer.Write(string.Join(", ", staticMethod.Parameters.SkipLast(1).Select(p => p.NameWithOutPrefix).Append("null")));
					writer.WriteLine(");");
					writer.WriteLine("this.handle.ToDevice(false, device);");
				}

				writer.WriteDebuggerIgnoreAttributes();
				writer.Write("public static NNAnyModule CreateAsAnyModule(");
				writer.Write(string.Join(", ", staticMethod.Parameters.SkipLast(1).Concat([deviceParameter])));
				writer.WriteLine(')');
				using (new CurlyBrackets(writer))
				{
					writer.WriteLine("NNAnyModule outAsAnyModule = default;");
					writer.Write("using NNModule handle = Create(");
					writer.Write(string.Join(", ", staticMethod.Parameters.SkipLast(1).Select(p => p.NameWithOutPrefix).Append("&outAsAnyModule")));
					writer.WriteLine(");");
					writer.WriteLine("handle.ToDevice(false, device);");
					writer.WriteLine("return outAsAnyModule;");
				}
			}
			else
			{
				writer.WriteDebuggerIgnoreAttributes();
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
		}

		context.AddSource($"{Name}.Constructor.cs", stringWriter.ToString());
	}
}
