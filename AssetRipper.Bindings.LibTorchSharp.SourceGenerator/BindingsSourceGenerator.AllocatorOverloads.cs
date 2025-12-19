using AssetRipper.Bindings.LibTorchSharp.SourceGenerator.Extensions;
using AssetRipper.Text.SourceGeneration;
using SGF;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;

namespace AssetRipper.Bindings.LibTorchSharp.SourceGenerator;

public partial class BindingsSourceGenerator
{
	private static void GenerateAllocatorOverloads(ref SgfSourceProductionContext context, MethodData[] nativeMethods)
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
				if (TryGetAllocatorParameter(nativeMethod, out int parameterIndex, out string? allocatedType))
				{
					List<ParameterData> modifiedParameters = nativeMethod.Parameters.ToList();
					modifiedParameters.RemoveAt(parameterIndex);
					MethodData modifiedMethod = nativeMethod with
					{
						ReturnType = new TypeData($"{allocatedType}[]", 0),
						Parameters = new(modifiedParameters)
					};

					nativeMethods[j] = modifiedMethod;

					writer.WriteDebuggerIgnoreAttributes();
					writer.WriteGeneratedCodeAttribute("Allocator Overloads");
					writer.Write("public static ");
					writer.WriteLine(modifiedMethod.ToString());
					using (new CurlyBrackets(writer))
					{
						using (new Try(writer))
						{
							string allocateMethod = allocatedType switch
							{
								"long" => "AllocateInt64",
								"string" => "AllocateString",
								_ => $"Allocate{allocatedType}",
							};
							string resultMethod = allocatedType switch
							{
								"string" => "GetAllocatedStrings",
								_ => $"GetAllocatedArray<{allocatedType}>",
							};
							writer.Write(nativeMethod.Name);
							writer.Write('(');
							for (int i = 0; i < nativeMethod.Parameters.Length; i++)
							{
								if (i > 0)
								{
									writer.Write(", ");
								}
								if (i == parameterIndex)
								{
									writer.Write($"&ScratchAllocator.{allocateMethod}");
								}
								else
								{
									writer.Write(nativeMethod.Parameters[i].NameWithOutPrefix);
								}
							}
							writer.WriteLine(");");
							writer.WriteLine($"return ScratchAllocator.{resultMethod}();");
						}
						using (new Finally(writer))
						{
							writer.WriteLine("ScratchAllocator.Free();");
						}
					}
				}
				else if (TryGetAllocatorParameters(nativeMethod, out int parameter1Index, out string? allocatedType1, out int parameter2Index))
				{
					List<ParameterData> modifiedParameters = nativeMethod.Parameters.ToList();
					modifiedParameters.RemoveAt(Math.Max(parameter1Index, parameter2Index));
					modifiedParameters.RemoveAt(Math.Min(parameter1Index, parameter2Index));
					MethodData modifiedMethod = nativeMethod with
					{
						ReturnType = new TypeData($"(string,{allocatedType1})[]", 0),
						Parameters = new(modifiedParameters)
					};

					nativeMethods[j] = modifiedMethod;

					writer.WriteDebuggerIgnoreAttributes();
					writer.WriteGeneratedCodeAttribute("Allocator Overloads");
					writer.Write("public static ");
					writer.WriteLine(modifiedMethod.ToString());
					using (new CurlyBrackets(writer))
					{
						using (new Try(writer))
						{
							string allocateMethod1 = allocatedType1 switch
							{
								"long" => "AllocateInt64",
								_ => $"Allocate{allocatedType1}",
							};
							writer.Write(nativeMethod.Name);
							writer.Write('(');
							for (int i = 0; i < nativeMethod.Parameters.Length; i++)
							{
								if (i > 0)
								{
									writer.Write(", ");
								}
								if (i == parameter1Index)
								{
									writer.Write($"&ScratchAllocator.{allocateMethod1}");
								}
								else if (i == parameter2Index)
								{
									writer.Write("&ScratchAllocator.AllocateString");
								}
								else
								{
									writer.Write(nativeMethod.Parameters[i].NameWithOutPrefix);
								}
							}
							writer.WriteLine(");");
							writer.WriteLine($"{allocatedType1}[] __result1 = ScratchAllocator.GetAllocatedArray<{allocatedType1}>();");
							writer.WriteLine("string[] __result2 =  ScratchAllocator.GetAllocatedStrings();");
							using (new If(writer, "__result1.Length != __result2.Length"))
							{
								writer.WriteLine("throw new InvalidOperationException(\"Allocator returned arrays of different lengths.\");");
							}
							writer.WriteLine($"(string,{allocatedType1})[] __result = new (string,{allocatedType1})[__result1.Length];");
							using (new For(writer, "int i = 0", "i < __result1.Length", "i++"))
							{
								writer.WriteLine($"__result[i] = (__result2[i], __result1[i]);");
							}
							writer.WriteLine("return __result;");
						}
						using (new Finally(writer))
						{
							writer.WriteLine("ScratchAllocator.Free();");
						}
					}
				}
			}
		}

		context.AddSource("NativeMethods.AllocatorOverloads.cs", stringWriter.ToString());
	}

	private static bool TryGetAllocatorParameter(MethodData method, out int parameterIndex, [NotNullWhen(true)] out string? allocatedType)
	{
		if (!method.ReturnType.IsVoid)
		{
			parameterIndex = -1;
			allocatedType = null;
			return false;
		}

		for (int i = 0; i < method.Parameters.Length; i++)
		{
			ParameterData parameter = method.Parameters[i];
			if (parameter.Name is not "allocator")
			{
				continue;
			}

			parameterIndex = i;
			allocatedType = parameter.Type.Name switch
			{
				"delegate* unmanaged[Cdecl]<nuint, AssetRipper.Bindings.LibTorchSharp.Tensor*>" => "Tensor",
				"delegate* unmanaged[Cdecl]<nuint, AssetRipper.Bindings.LibTorchSharp.JITModule*>" => "JITModule",
				"delegate* unmanaged[Cdecl]<nuint, AssetRipper.Bindings.LibTorchSharp.Modules.NNModule*>" => "NNModule",
				"delegate* unmanaged[Cdecl]<nuint, long*>" => "long",
				"delegate* unmanaged[Cdecl]<nuint, sbyte**>" => "string",
				_ => null,
			};
			return allocatedType is not null;
		}

		parameterIndex = -1;
		allocatedType = null;
		return false;
	}

	private static bool TryGetAllocatorParameters(MethodData method, out int parameter1Index, [NotNullWhen(true)] out string? allocatedType1, out int parameter2Index)
	{
		parameter1Index = -1;
		allocatedType1 = null;
		parameter2Index = -1;

		if (!method.ReturnType.IsVoid)
		{
			return false;
		}

		for (int i = 0; i < method.Parameters.Length; i++)
		{
			ParameterData parameter = method.Parameters[i];
			if (parameter.Name is "allocator1")
			{
				parameter1Index = i;
				allocatedType1 = parameter.Type.Name switch
				{
					"delegate* unmanaged[Cdecl]<nuint, AssetRipper.Bindings.LibTorchSharp.Tensor*>" => "Tensor",
					"delegate* unmanaged[Cdecl]<nuint, AssetRipper.Bindings.LibTorchSharp.JITModule*>" => "JITModule",
					"delegate* unmanaged[Cdecl]<nuint, AssetRipper.Bindings.LibTorchSharp.Modules.NNModule*>" => "NNModule",
					"delegate* unmanaged[Cdecl]<nuint, long*>" => "long",
					_ => null,
				};
			}
			else if (parameter.Name is "allocator2" && parameter.Type.Name is "delegate* unmanaged[Cdecl]<nuint, sbyte**>")
			{
				parameter2Index = i;
			}
		}

		return parameter1Index != -1 && allocatedType1 is not null && parameter2Index != -1;
	}
}
