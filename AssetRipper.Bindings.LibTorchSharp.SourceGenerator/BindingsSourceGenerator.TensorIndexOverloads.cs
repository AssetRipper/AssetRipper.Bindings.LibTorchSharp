using AssetRipper.Bindings.LibTorchSharp.SourceGenerator.Extensions;
using AssetRipper.Text.SourceGeneration;
using SGF;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;

namespace AssetRipper.Bindings.LibTorchSharp.SourceGenerator;

public partial class BindingsSourceGenerator
{
	private static void GenerateTensorIndexOverloads(ref SgfSourceProductionContext context, MethodData[] nativeMethods)
	{
		ReadOnlySpan<string> indexMethodNames =
		[
			"Tensor_index",
			"Tensor_index_put_inline",
			"Tensor_index_put_scalar_inline",
		];

		StringWriter stringWriter = new();
		IndentedTextWriter writer = IndentedTextWriterFactory.Create(stringWriter);
		writer.WriteFileScopedNamespace("AssetRipper.Bindings.LibTorchSharp.LowLevel");
		writer.WriteLine("public static unsafe partial class NativeMethods");
		using (new CurlyBrackets(writer))
		{
			foreach (string indexMethod in indexMethodNames)
			{
				int index = Array.FindIndex(nativeMethods, m => m.Name == indexMethod);
				MethodData originalMethod = nativeMethods[index];
				ParameterDataArray originalParameters = originalMethod.Parameters;
				List<ParameterData> newParameters = new(originalParameters.Length);
				for (int i = 0; i < originalParameters.Length; i++)
				{
					ParameterData parameter = originalParameters[i];
					switch (parameter.Name)
					{
						case "indexStarts":
							break;
						case "indexEnds":
							break;
						case "indexSteps":
							break;
						case "indexTensors":
							break;
						case "indicesLength":
							break;
						default:
							newParameters.Add(parameter);
							break;
					}
				}
				newParameters.Add(new ParameterData(new TypeData("ReadOnlySpan<TensorIndex>"), "indices"));
				MethodData modifiedMethod = originalMethod with
				{
					Parameters = new(newParameters)
				};
				nativeMethods[index] = modifiedMethod;

				writer.WriteDebuggerIgnoreAttributes();
				writer.WriteGeneratedCodeAttribute("TensorIndex Overloads");
				writer.Write("public static ");
				writer.WriteLine(modifiedMethod.ToString());
				using (new CurlyBrackets(writer))
				{
					writer.WriteLine("using TensorIndex.EncodedIndices encoded = TensorIndex.EncodedIndices.Encode(indices);");
					if (!originalMethod.ReturnType.IsVoid)
					{
						writer.Write("return ");
					}
					writer.Write(originalMethod.Name);
					writer.Write('(');
					for (int i = 0; i < originalParameters.Length; i++)
					{
						ParameterData parameter = originalParameters[i];
						switch (parameter.Name)
						{
							case "indexStarts":
								writer.Write("encoded.ArrayKindAndStarts");
								break;
							case "indexEnds":
								writer.Write("encoded.ArrayStops");
								break;
							case "indexSteps":
								writer.Write("encoded.ArraySteps");
								break;
							case "indexTensors":
								writer.Write("encoded.ArrayTensors");
								break;
							case "indicesLength":
								writer.Write("indices.Length");
								break;
							default:
								writer.Write(parameter.Name);
								break;
						}
						if (i < originalParameters.Length - 1)
						{
							writer.Write(", ");
						}
					}
					writer.WriteLine(");");
				}
			}
		}

		context.AddSource("NativeMethods.TensorIndexOverloads.cs", stringWriter.ToString());
	}
}
