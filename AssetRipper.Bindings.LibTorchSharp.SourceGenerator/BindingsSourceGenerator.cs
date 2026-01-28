using AssetRipper.Bindings.LibTorchSharp.SourceGenerator.Extensions;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using SGF;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;

namespace AssetRipper.Bindings.LibTorchSharp.SourceGenerator;

[IncrementalGenerator]
public partial class BindingsSourceGenerator() : IncrementalGenerator(nameof(BindingsSourceGenerator))
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

		Generate(ref context, structs, pinvokeMethods, nativeMethods, reflectionContext);
	}

	private static void Generate(ref SgfSourceProductionContext context, ImmutableArray<StructData> structs, ImmutableArray<MethodData> pinvokeMethods, MethodData[] nativeMethods, ReflectionContext reflectionContext)
	{
		// Generate NativeMethods
		GenerateInitialMethods(ref context, pinvokeMethods, reflectionContext, nativeMethods);

		// bool, string, and out parameters
		GenerateParameterOverloads(ref context, reflectionContext, nativeMethods);

		// Generate allocator overloads
		GenerateAllocatorOverloads(ref context, nativeMethods);

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

		// TensorIndex overloads
		GenerateTensorIndexOverloads(ref context, nativeMethods);

		// Span overloads
		GenerateSpanOverloads(ref context, nativeMethods);

		// Device? device = null overloads
		GenerateDeviceOverloads(ref context, nativeMethods);

		GenerateStructs(ref context, structs, nativeMethods);
	}
}
