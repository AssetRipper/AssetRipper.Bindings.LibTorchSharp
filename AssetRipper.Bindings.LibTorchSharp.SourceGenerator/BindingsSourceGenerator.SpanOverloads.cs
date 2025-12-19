using AssetRipper.Bindings.LibTorchSharp.SourceGenerator.Extensions;
using AssetRipper.Text.SourceGeneration;
using SGF;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Linq;

namespace AssetRipper.Bindings.LibTorchSharp.SourceGenerator;

public partial class BindingsSourceGenerator
{
	private static void GenerateSpanOverloads(ref SgfSourceProductionContext context, MethodData[] nativeMethods)
	{
		StringWriter stringWriter = new();
		IndentedTextWriter writer = IndentedTextWriterFactory.Create(stringWriter);

		writer.WriteFileScopedNamespace("AssetRipper.Bindings.LibTorchSharp.LowLevel");
		writer.WriteLineNoTabs();
		writer.WriteLine("public static unsafe partial class NativeMethods");
		using (new CurlyBrackets(writer))
		{
			List<int> spanParameterIndices = [];
			List<string> parameterNames = [];
			List<ParameterData> modifiedParameters = [];
			for (int j = 0; j < nativeMethods.Length; j++)
			{
				MethodData nativeMethod = nativeMethods[j];

				spanParameterIndices.Clear();
				parameterNames.Clear();
				modifiedParameters.Clear();

				for (int i = 0; i < nativeMethod.Parameters.Length; i++)
				{
					ParameterData parameter = nativeMethod.Parameters[i];
					if (i == nativeMethod.Parameters.Length - 1)
					{
						parameterNames.Add(parameter.NameWithOutPrefix);
						modifiedParameters.Add(parameter);
						break;
					}

					ParameterData nextParameter = nativeMethod.Parameters[i + 1];
					if (parameter is { IsOut: false, Type.PointerLevel: 1 } && nextParameter is { IsOut: false, Type: { Name: "int" or "long", IsPointer: false } } && nextParameter.Name.Contains("len", StringComparison.OrdinalIgnoreCase))
					{
						spanParameterIndices.Add(i);
						i++; // Skip length parameter

						parameterNames.Add($"__pointer_{parameter.Name}");
						parameterNames.Add($"{parameter.Name}.Length");

						modifiedParameters.Add(new ParameterData
						{
							Type = new TypeData($"System.ReadOnlySpan<{parameter.Type.Name}>", 0),
							Name = parameter.Name,
							IsOut = false,
						});
					}
					else
					{
						parameterNames.Add(parameter.NameWithOutPrefix);
						modifiedParameters.Add(parameter);
					}
				}

				if (spanParameterIndices.Count is 0)
				{
					continue;
				}

				MethodData modifiedMethod = nativeMethod with { Parameters = new(modifiedParameters) };
				nativeMethods[j] = modifiedMethod;

				writer.WriteDebuggerIgnoreAttributes();
				writer.WriteGeneratedCodeAttribute("Span Overloads");
				writer.Write("public static ");
				writer.WriteLine(modifiedMethod.ToString());
				using (new CurlyBrackets(writer))
				{
					foreach (int parameterIndex in spanParameterIndices)
					{
						ParameterData parameter = nativeMethod.Parameters[parameterIndex];
						writer.WriteLine($"fixed ({parameter.Type.Name}* __pointer_{parameter.Name} = {parameter.Name})");
					}

					if (!modifiedMethod.ReturnType.IsVoid)
					{
						writer.Write("return ");
					}

					writer.Write(nativeMethod.Name);
					writer.Write('(');
					writer.Write(string.Join(", ", parameterNames));
					writer.WriteLine(");");
				}
			}
		}

		context.AddSource("NativeMethods.SpanOverloads.cs", stringWriter.ToString());
	}
}
