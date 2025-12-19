using AssetRipper.Text.SourceGeneration;
using Microsoft.CodeAnalysis;
using System;
using System.CodeDom.Compiler;
using System.IO;

namespace AssetRipper.Bindings.LibTorchSharp.SourceGenerator;

public partial class BindingsSourceGenerator
{
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
}
