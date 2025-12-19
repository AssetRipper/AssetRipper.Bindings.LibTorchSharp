using AssetRipper.Bindings.LibTorchSharp.SourceGenerator.Extensions;
using AssetRipper.Text.SourceGeneration;
using Microsoft.CodeAnalysis;
using SGF;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AssetRipper.Bindings.LibTorchSharp.SourceGenerator;

public partial class BindingsSourceGenerator
{
	private static void GenerateDeviceOverloads(ref SgfSourceProductionContext context, MethodData[] nativeMethods)
	{
		StringWriter stringWriter = new();
		IndentedTextWriter writer = IndentedTextWriterFactory.Create(stringWriter);
		writer.WriteFileScopedNamespace("AssetRipper.Bindings.LibTorchSharp.LowLevel");
		writer.WriteLineNoTabs();
		writer.WriteLine("public static unsafe partial class NativeMethods");
		using (new CurlyBrackets(writer))
		{
			for (int j = 0; j < nativeMethods.Length; j++)
			{
				MethodData nativeMethod = nativeMethods[j];

				int device_type_Index = -1;
				int device_index_Index = -1;
				for (int i = 0; i < nativeMethod.Parameters.Length; i++)
				{
					ParameterData parameter = nativeMethod.Parameters[i];
					if (parameter is { Name: "device_type", Type: { Name: "DeviceType", IsPointer: false }, IsOut: false })
					{
						device_type_Index = i;
					}
					else if (parameter is { Name: "device_index", Type: { IsInt32: true } or { IsInt64: true }, IsOut: false })
					{
						device_index_Index = i;
					}
				}
				if (device_type_Index == -1 || device_index_Index == -1)
				{
					continue;
				}

				List<ParameterData> modifiedParameters = nativeMethod.Parameters.ToList();
				modifiedParameters.RemoveAt(Math.Max(device_type_Index, device_index_Index));
				modifiedParameters.RemoveAt(Math.Min(device_type_Index, device_index_Index));
				modifiedParameters.Add(new ParameterData(new TypeData("Device?"), "device", false, "null"));

				MethodData modifiedMethod = nativeMethod with { Parameters = new(modifiedParameters) };
				nativeMethods[j] = modifiedMethod;

				writer.WriteDebuggerIgnoreAttributes();
				writer.WriteGeneratedCodeAttribute("Device Overloads");
				writer.Write("public static ");
				writer.WriteLine(modifiedMethod.ToString());
				using (new CurlyBrackets(writer))
				{
					writer.WriteLine("(DeviceType device_type, int device_index) = device ?? Device.Default;");
					if (!modifiedMethod.ReturnType.IsVoid)
					{
						writer.Write("return ");
					}
					writer.Write(nativeMethod.Name);
					writer.Write('(');
					writer.Write(string.Join(", ", nativeMethod.Parameters.Select(p => p.NameWithOutPrefix)));
					writer.WriteLine(");");
				}
			}
		}
		context.AddSource("NativeMethods.DeviceOverloads.cs", stringWriter.ToString());
	}
}
