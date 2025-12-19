using AssetRipper.Bindings.LibTorchSharp.SourceGenerator.Extensions;
using AssetRipper.Text.SourceGeneration;
using SGF;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;

namespace AssetRipper.Bindings.LibTorchSharp.SourceGenerator;

public partial class BindingsSourceGenerator
{
	private static void GenerateParameterOverloads(ref SgfSourceProductionContext context, ReflectionContext reflectionContext, MethodData[] nativeMethods)
	{
		StringWriter stringWriter = new();
		IndentedTextWriter writer = IndentedTextWriterFactory.Create(stringWriter);

		writer.WriteFileScopedNamespace("AssetRipper.Bindings.LibTorchSharp.LowLevel");
		writer.WriteLineNoTabs();
		writer.WriteLine("public static unsafe partial class NativeMethods");
		using (new CurlyBrackets(writer))
		{
			List<string> parameterDeclarationLines = [];
			List<string> stringFixedLines = [];
			List<string> outInitializationLines = [];
			List<string> parameterNames = [];
			for (int j = 0; j < nativeMethods.Length; j++)
			{
				MethodData nativeMethod = nativeMethods[j];

				parameterDeclarationLines.Clear();
				stringFixedLines.Clear();
				outInitializationLines.Clear();
				parameterNames.Clear();

				bool anyBooleanConversions = false;

				ParameterData[] modifiedParameterDatas = new ParameterData[nativeMethod.Parameters.Length];
				for (int i = 0; i < nativeMethod.Parameters.Length; i++)
				{
					ParameterData parameterData = nativeMethod.Parameters[i];

					if (parameterData.Type.IsPointer && reflectionContext.IsOutParameter(nativeMethod.Name, i, parameterData.Name))
					{
						TypeData modifiedParameterType = new(parameterData.Type.Name, parameterData.Type.PointerLevel - 1);

						parameterDeclarationLines.Add($"{modifiedParameterType} __parameter{i} = default;");
						outInitializationLines.Add($"{parameterData.Name} = __parameter{i};");
						parameterNames.Add($"&__parameter{i}");

						modifiedParameterDatas[i] = parameterData with { Type = modifiedParameterType, IsOut = true };
					}
					else if (!parameterData.Type.IsBoolean && reflectionContext.IsBooleanParameter(nativeMethod.Name, i, parameterData.Name))
					{
						anyBooleanConversions = true;
						modifiedParameterDatas[i] = parameterData with { Type = new("bool", 0) };
						parameterNames.Add($"{parameterData.Name} ? 1 : 0");
					}
					else if (parameterData.Type.IsSBytePointer && reflectionContext.IsStringParameter(nativeMethod.Name, i, parameterData.Name))
					{
						stringFixedLines.Add($"fixed (sbyte* __parameter{i} = {parameterData.Name})");
						parameterNames.Add($"{parameterData.Name}.IsNull ? null : __parameter{i}");
						modifiedParameterDatas[i] = parameterData with { Type = new("NativeString", 0) };
					}
					else
					{
						parameterNames.Add(parameterData.Name);
						modifiedParameterDatas[i] = parameterData;
					}
				}

				if (parameterDeclarationLines.Count is 0 && stringFixedLines.Count is 0 && outInitializationLines.Count is 0 && !anyBooleanConversions)
				{
					continue;
				}

				MethodData modifiedMethod = nativeMethod with { Parameters = new(modifiedParameterDatas) };
				nativeMethods[j] = modifiedMethod;

				writer.WriteDebuggerIgnoreAttributes();
				writer.WriteGeneratedCodeAttribute("Parameter Overloads");
				writer.Write("public static ");
				writer.WriteLine(modifiedMethod.ToString());
				using (new CurlyBrackets(writer))
				{
					if (!modifiedMethod.ReturnType.IsVoid)
					{
						writer.WriteLine($"{modifiedMethod.ReturnType} __result;");
					}
					foreach (string line in parameterDeclarationLines)
					{
						writer.WriteLine(line);
					}
					foreach (string line in stringFixedLines)
					{
						writer.WriteLine(line);
					}
					if (!modifiedMethod.ReturnType.IsVoid)
					{
						writer.Write("__result = ");
					}
					writer.Write(nativeMethod.Name);
					writer.Write('(');
					for (int i = 0; i < modifiedMethod.Parameters.Length; i++)
					{
						if (i > 0)
						{
							writer.Write(", ");
						}
						writer.Write(parameterNames[i]);
					}
					writer.WriteLine(");");
					foreach (string line in outInitializationLines)
					{
						writer.WriteLine(line);
					}
					if (!modifiedMethod.ReturnType.IsVoid)
					{
						writer.WriteLine("return __result;");
					}
				}
			}
		}

		context.AddSource("NativeMethods.ParameterOverloads.cs", stringWriter.ToString());
	}
}
