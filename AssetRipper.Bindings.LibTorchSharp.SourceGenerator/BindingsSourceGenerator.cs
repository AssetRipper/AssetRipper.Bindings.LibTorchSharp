using AssetRipper.Bindings.LibTorchSharp.SourceGenerator.Extensions;
using AssetRipper.Text.SourceGeneration;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
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

			// Namespace of the type the attribute is applied to
			string structNamespace = context.TargetSymbol.ContainingNamespace.ToDisplayString();

			if (prefixName is null)
			{
				Debug.Assert(opaqueName.StartsWith("Opaque", StringComparison.Ordinal));
				prefixName = opaqueName["Opaque".Length..];
			}

			return new StructData(structName, structNamespace, opaqueName, prefixName + '_');
		});

		// Get all methods in AssetRipper.Bindings.LibTorchSharp.LowLevel.PInvoke class
		IncrementalValuesProvider<(string, MethodData)> methods = context.SyntaxProvider.ForAttributeWithMetadataName("System.Runtime.InteropServices.DllImportAttribute", static (node, _) =>
		{
			return node is MethodDeclarationSyntax { Identifier.Text: not "Torch_get_and_reset_last_err", Parent : TypeDeclarationSyntax { Identifier.Text: "PInvoke" } };
		}, static (context, _) =>
		{
			// Method name
			string methodName = context.TargetSymbol.Name;

			// EntryPoint named argument
			string entryPoint = context.Attributes[0].NamedArguments.FirstOrDefault(kv => kv.Key == "EntryPoint").Value.Value?.ToString() ?? methodName;

			return (entryPoint, MethodData.From((IMethodSymbol)context.TargetSymbol));
		});

		context.RegisterSourceOutput(structs.Collect(), methods.Select((t, _) => t.Item2).Collect(), methods.Select((t, _) => (t.Item1, t.Item2.Name)).Collect(), Generate);
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

	private static void Generate(SgfSourceProductionContext context, ImmutableArray<StructData> structs, ImmutableArray<MethodData> pinvokeMethods, ImmutableArray<(string EntryPoint, string MethodName)> entryPointArray)
	{
		ReflectionContext reflectionContext;
		MethodData[] nativeMethods = new MethodData[pinvokeMethods.Length];
		{
			Dictionary<string, string> pinvokeMethodNameToNativeMethodName = pinvokeMethods.ToDictionary(m => m.Name, m =>
			{
				string methodName = m.Name;
				return methodName[^1] == '_' ? methodName + "inline" : methodName;
			});
			Dictionary<string, string> pinvokeMethodNameToEntryPoint = entryPointArray.ToDictionary(t => t.MethodName, t => t.EntryPoint);
			reflectionContext = new(pinvokeMethodNameToEntryPoint, pinvokeMethodNameToNativeMethodName, pinvokeMethods);

			for (int j = 0; j < pinvokeMethods.Length; j++)
			{
				MethodData pinvokeMethod = pinvokeMethods[j];
				MethodData nativeMethod = pinvokeMethod.ReplaceOpaqueTypes(structs).ApplyParameterNameChanges() with
				{
					Name = pinvokeMethodNameToNativeMethodName[pinvokeMethod.Name]
				};

				string? returnTypeOverride = reflectionContext.GetReturnType(nativeMethod.Name);
				if (returnTypeOverride is not null)
				{
					nativeMethod = nativeMethod with { ReturnType = new TypeData(returnTypeOverride, 0) };
				}

				bool modifiedParameters = false;
				ParameterData[] modifiedParameterDatas = new ParameterData[nativeMethod.Parameters.Length];
				for (int i = 0; i < nativeMethod.Parameters.Length; i++)
				{
					ParameterData parameterData = nativeMethod.Parameters[i];
					if (parameterData is { Name: "scalar_type" or "dtype", Type.IsSByte: true })
					{
						modifiedParameters = true;
						modifiedParameterDatas[i] = parameterData with { Type = new TypeData("ScalarType", 0) };
					}
					else if (parameterData is { Name: "device_type", Type: { IsInt32: true } or { IsInt64: true } })
					{
						modifiedParameters = true;
						modifiedParameterDatas[i] = parameterData with { Type = new TypeData("DeviceType", 0) };
					}
					else
					{
						modifiedParameterDatas[i] = parameterData;
					}
				}
				if (modifiedParameters)
				{
					nativeMethod = nativeMethod with { Parameters = new(modifiedParameterDatas) };
				}

				nativeMethods[j] = nativeMethod;
			}
		}

		// Generate NativeMethods
		{
			StringWriter stringWriter = new();
			IndentedTextWriter writer = IndentedTextWriterFactory.Create(stringWriter);

			writer.WriteFileScopedNamespace("AssetRipper.Bindings.LibTorchSharp.LowLevel");
			writer.WriteLineNoTabs();
			writer.WriteLine("public static unsafe partial class NativeMethods");
			using (new CurlyBrackets(writer))
			{
				for (int j = 0; j < pinvokeMethods.Length; j++)
				{
					MethodData pinvokeMethod = pinvokeMethods[j];
					MethodData nativeMethod = nativeMethods[j];

					writer.WriteSummaryDocumentation(reflectionContext.GetEntryPoint(nativeMethod.Name));
					writer.WriteDebuggerIgnoreAttributes();
					writer.WriteGeneratedCodeAttribute();
					writer.Write("public static ");
					writer.WriteLine(nativeMethod.ToString());
					using (new CurlyBrackets(writer))
					{
						if (!nativeMethod.ReturnType.IsVoid)
						{
							writer.Write($"{nativeMethod.ReturnType} __result = ");

							if (nativeMethod.ReturnType == pinvokeMethod.ReturnType)
							{
							}
							else if (nativeMethod.ReturnType.IsBoolean)
							{
								writer.Write("0 != ");
							}
							else
							{
								writer.Write('(');
								writer.Write(nativeMethod.ReturnType);
								writer.Write(')');
							}
						}
						writer.Write("PInvoke.");
						writer.Write(pinvokeMethod.Name);
						writer.Write('(');
						for (int i = 0; i < nativeMethod.Parameters.Length; i++)
						{
							if (i > 0)
							{
								writer.Write(", ");
							}
							if (nativeMethod.Parameters[i].Type != pinvokeMethod.Parameters[i].Type)
							{
								writer.Write('(');
								writer.Write(pinvokeMethod.Parameters[i].Type);
								writer.Write(')');
							}
							writer.Write(nativeMethod.Parameters[i].Name);
						}
						writer.WriteLine(");");
						writer.WriteLine("CheckForErrors();");
						if (!nativeMethod.ReturnType.IsVoid)
						{
							writer.WriteLine("return __result;");
						}
					}
				}
			}

			context.AddSource("NativeMethods.cs", stringWriter.ToString());
		}

		// bool, string, and out parameters
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

		// Generate allocator overloads
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

		// Optimizer step method
		{
			int index = Array.FindIndex(nativeMethods, m => m.Name == "NN_Optimizer_step");
			nativeMethods[index] = nativeMethods[index] with
			{
				Parameters = new(nativeMethods[index].Parameters.Take(nativeMethods[index].Parameters.Length - 1))
			};
			context.AddSource("NativeMethods.OptimizerStepFunction.cs", """
				namespace AssetRipper.Bindings.LibTorchSharp.LowLevel;
				public static unsafe partial class NativeMethods
				{
					[global::System.Diagnostics.DebuggerHidden]
					[global::System.Diagnostics.DebuggerNonUserCode]
					[global::System.Diagnostics.DebuggerStepThrough]
					[global::System.Diagnostics.StackTraceHidden]
					public unsafe static Tensor NN_Optimizer_step(Optimizer optimizer)
					{
						return NN_Optimizer_step(optimizer, null);
					}
				}
				""");
		}

		// Span overloads
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

		// Device? device = null overloads
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

		Dictionary<StructData, GeneratedOpaqueStruct> structDictionary = structs.ToDictionary(s => s, s => new GeneratedOpaqueStruct(s));
		Dictionary<string, GeneratedStaticClass> classDictionary = [];

		foreach (MethodData nativeMethod in nativeMethods)
		{
			if (TryGetStruct(nativeMethod, structs, out StructData structResult, out string? classResult))
			{
				string instanceName = nativeMethod.GetNameInType(structResult.PrefixName);
				MethodData modified = nativeMethod with { Name = instanceName };

				GeneratedOpaqueStruct generatedType = structDictionary[structResult];

				if (generatedType.IsInstance(modified))
				{
					modified = modified.ChangeFirstParameterNameToThis();
				}

				generatedType.Methods.Add(new(modified, nativeMethod));
			}
			else
			{
				MethodData modified = nativeMethod with { Name = nativeMethod.GetNameInType(classResult + "_", false) };
				classDictionary.GetOrCreate(classResult, GeneratedStaticClass.Create).Methods.Add(new(modified, nativeMethod));
			}
		}

		List<GeneratedOpaqueStruct> structList = structDictionary.Values.ToList();
		List<GeneratedStaticClass> classList = classDictionary.Values.ToList();
		List<GeneratedChildStruct> childList = [];
		foreach (GeneratedStaticClass @class in classList)
		{
			childList.AddRange(@class.ExtractChildren(structList));
		}

		foreach (GeneratedStaticClass @class in classList)
		{
			for (int i = 0; i < @class.Methods.Count; i++)
			{
				(MethodData m1, MethodData m2) = @class.Methods[i];
				@class.Methods[i] = new(m1.CleanName(), m2);
			}
		}

		foreach (GeneratedChildStruct child in childList)
		{
			child.Methods.AddRange(child.Parent.InstanceMethods);
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
