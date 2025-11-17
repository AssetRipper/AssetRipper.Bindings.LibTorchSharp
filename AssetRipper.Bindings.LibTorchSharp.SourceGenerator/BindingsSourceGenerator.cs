using AssetRipper.Text.SourceGeneration;
using Microsoft.CodeAnalysis;
using SGF;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;

namespace AssetRipper.Bindings.LibTorchSharp.SourceGenerator;

[IncrementalGenerator]
public class BindingsSourceGenerator() : IncrementalGenerator(nameof(BindingsSourceGenerator))
{
	public override void OnInitialize(SgfInitializationContext context)
	{
		// Find all structs with the OpaqueStructAttribute
		IncrementalValuesProvider<StructData> structs = context.SyntaxProvider.ForAttributeWithMetadataName("AssetRipper.Bindings.LibTorchSharp.Attributes.OpaqueStructAttribute", (_, _) => true, static (context, _) =>
		{
			// String in the first parameter of attribute
			string opaqueName = context.Attributes[0].ConstructorArguments[0].Value!.ToString()!;

			// String in the second parameter of attribute, which might be null
			string? prefixName = context.Attributes[0].ConstructorArguments[1].Value?.ToString();

			// Name of the type the attribute is applied to
			string structName = context.TargetSymbol.Name;

			if (prefixName is null)
			{
				Debug.Assert(opaqueName.StartsWith("Opaque", StringComparison.Ordinal));
				prefixName = opaqueName["Opaque".Length..];
			}

			return new StructData(structName, opaqueName, prefixName + '_');
		});

		// Get all methods in AssetRipper.Bindings.LibTorchSharp.LowLevel.PInvoke class
		IncrementalValuesProvider<MethodData> methods = context.CompilationProvider.SelectMany(static (compilation, _) =>
		{
			INamedTypeSymbol? type = compilation.GetTypeByMetadataName("AssetRipper.Bindings.LibTorchSharp.LowLevel.PInvoke");
			if (type is null)
			{
				return ImmutableArray<MethodData>.Empty;
			}

			return [.. type.GetMembers().OfType<IMethodSymbol>().Where(m => m.Name != "Torch_get_and_reset_last_err").Select(MethodData.From)];
		});

		context.RegisterSourceOutput(methods.Collect(), GenerateNativeMethods);
		context.RegisterSourceOutput(structs.Collect().Combine(methods.Collect()), (context, pair) => GenerateTypeMethods(context, pair.Left, pair.Right));
		context.RegisterPostInitializationOutput(GenerateTensorScalarOperators);
	}

	private static void GenerateTensorScalarOperators(IncrementalGeneratorPostInitializationContext context)
	{
		ReadOnlySpan<string> types = ["byte", "sbyte", "short", "int", "long", "bool", "BFloat16", "Half", "float", "double", "Complex32", "Complex"];
		ReadOnlySpan<string> operators = ["+", "-", "*", "/", "%", "<", "<=", ">", ">=", "==", "!="];

		StringWriter stringWriter = new();
		IndentedTextWriter writer = IndentedTextWriterFactory.Create(stringWriter);

		writer.WriteUsing("System.Numerics");
		writer.WriteLineNoTabs();
		writer.WriteFileScopedNamespace("AssetRipper.Bindings.LibTorchSharp");
		writer.WriteLineNoTabs();
		writer.WriteLine("public readonly partial struct Tensor :");
		using (new Indented(writer))
		{
			foreach (string type in types)
			{
				writer.WriteLine($"IAdditionOperators<Tensor, {type}, Tensor>,");
				writer.WriteLine($"ISubtractionOperators<Tensor, {type}, Tensor>,");
				writer.WriteLine($"IMultiplyOperators<Tensor, {type}, Tensor>,");
				writer.WriteLine($"IDivisionOperators<Tensor, {type}, Tensor>,");
				writer.WriteLine($"IModulusOperators<Tensor, {type}, Tensor>,");
				writer.WriteLine($"IComparisonOperators<Tensor, {type}, Tensor>,");
				writer.WriteLine($"IEqualityOperators<Tensor, {type}, Tensor>,");
			}

			// Trailing comma not allowed
			writer.WriteLine("IAdditionOperators<Tensor, Tensor, Tensor>");
		}
		using (new CurlyBrackets(writer))
		{
			foreach (string type in types)
			{
				writer.WriteComment(type);
				foreach (string @operator in operators)
				{
					writer.WriteLine($"public static Tensor operator {@operator}(Tensor left, {type} right)");
					using (new CurlyBrackets(writer))
					{
						writer.WriteLine("using Scalar scalar = (Scalar)right;");
						writer.WriteLine($"return left {@operator} scalar;");
					}
					writer.WriteLine($"public static Tensor operator {@operator}({type} left, Tensor right)");
					using (new CurlyBrackets(writer))
					{
						writer.WriteLine("using Scalar scalar = (Scalar)left;");
						writer.WriteLine($"return scalar {@operator} right;");
					}
				}
				writer.WriteLine($"public static explicit operator Tensor({type} value) => new Tensor(value);");
				writer.WriteLineNoTabs();
			}
		}

		context.AddSource("Tensor.Operators.cs", stringWriter.ToString());
	}

	private static void GenerateNativeMethods(SgfSourceProductionContext context, ImmutableArray<MethodData> methods)
	{
		StringWriter stringWriter = new();
		IndentedTextWriter writer = IndentedTextWriterFactory.Create(stringWriter);

		writer.WriteFileScopedNamespace("AssetRipper.Bindings.LibTorchSharp.LowLevel");
		writer.WriteLineNoTabs();
		writer.WriteLine("public static unsafe partial class NativeMethods");
		using (new CurlyBrackets(writer))
		{
			foreach (MethodData method in methods)
			{
				writer.Write("public static ");
				writer.WriteLine(method.ToString());
				using (new CurlyBrackets(writer))
				{
					if (!method.ReturnType.IsVoid)
					{
						writer.Write($"{method.ReturnType} __result = ");
					}
					string parameters = string.Join(", ", method.Parameters.Select(p => p.Name));
					writer.WriteLine($"PInvoke.{method.Name}({parameters});");
					writer.WriteLine("CheckForErrors();");
					if (!method.ReturnType.IsVoid)
					{
						writer.WriteLine("return __result;");
					}
				}
			}
		}

		context.AddSource("NativeMethods.cs", stringWriter.ToString());
	}

	private static void GenerateTypeMethods(SgfSourceProductionContext context, ImmutableArray<StructData> structs, ImmutableArray<MethodData> methods)
	{
		Dictionary<StructData, GeneratedOpaqueStruct> structDictionary = structs.ToDictionary(s => s, s => new GeneratedOpaqueStruct(s));
		Dictionary<string, GeneratedStaticClass> classDictionary = [];

		foreach (MethodData method in methods)
		{
			MethodData replaced = method.ReplaceOpaqueTypes(structs);
			if (TryGetStruct(method, structs, out StructData structResult, out string? classResult))
			{
				replaced = replaced with { Name = method.GetNameInStruct(structResult) };

				GeneratedOpaqueStruct generatedType = structDictionary[structResult];

				if (generatedType.IsInstance(replaced))
				{
					replaced = replaced.ChangeFirstParameterNameToThis();
				}

				generatedType.Methods.Add(new(replaced, method));
			}
			else
			{
				replaced = replaced with { Name = method.GetNameInClass(classResult) };
				classDictionary.GetOrCreate(classResult, GeneratedStaticClass.Create).Methods.Add(new(replaced, method));
			}
		}

		List<GeneratedOpaqueStruct> structList = structDictionary.Values.ToList();
		List<GeneratedStaticClass> classList = classDictionary.Values.ToList();
		List<GeneratedChildStruct> childList = [];
		foreach (GeneratedStaticClass @class in classList)
		{
			childList.AddRange(@class.ExtractChildren(structList));
		}

		//foreach (GeneratedChildStruct child in childList)
		{
			//child.Methods.AddRange(child.Parent.Methods);
		}

		foreach (GeneratedType type in structList.Concat<GeneratedType>(classList).Concat(childList))
		{
			type.DetectProperties();
			type.SortMethods();
			type.SortProperties();
			type.GenerateMembersFile(context);
			type.GenerateConstructorFile(context);
			type.GenerateDisposableFile(context);
			type.GenerateMainFile(context);
		}
	}

	private static bool TryGetStruct(MethodData method, ImmutableArray<StructData> structs, out StructData structResult, [NotNullWhen(false)] out string? classResult)
	{
		foreach (StructData @struct in structs)
		{
			if (method.Name.StartsWith(@struct.PrefixName, StringComparison.Ordinal))
			{
				structResult = @struct;
				classResult = null;
				return true;
			}
		}

		int firstUnderscore = method.Name.IndexOf('_');
		Debug.Assert(firstUnderscore > 0);

		string shortenedName = method.Name[(firstUnderscore + 1)..];
		foreach (StructData @struct in structs)
		{
			if (shortenedName.StartsWith(@struct.PrefixName, StringComparison.Ordinal))
			{
				structResult = @struct;
				classResult = null;
				return true;
			}
		}

		structResult = default;
		classResult = method.Name[..firstUnderscore];
		return false;
	}
}
