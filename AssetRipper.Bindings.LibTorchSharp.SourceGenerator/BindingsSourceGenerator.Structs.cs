using AssetRipper.Bindings.LibTorchSharp.SourceGenerator.Extensions;
using AssetRipper.Text.SourceGeneration;
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

public partial class BindingsSourceGenerator
{
	private static readonly (string, int[])[] ModuleStructDefinitions =
	[
		("AlphaDropout", [0]),
		("Bilinear", [0, 1]),
		("Dropout", [0]),
		("Dropout2d", [0]),
		("Dropout3d", [0]),
		("FeatureAlphaDropout", [0]),
		("Linear", [0]),
	];

	private static void GenerateStructs(ref SgfSourceProductionContext context, ImmutableArray<StructData> structs, MethodData[] nativeMethods)
	{
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

		CSharpNodeType csharpNodeType = new();
		csharpNodeType.TransferMethodsFrom(classDictionary["Autograd"]);

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

		foreach (GeneratedType type in structList.Concat<GeneratedType>(classList).Concat(childList).Concat([csharpNodeType]))
		{
			type.DetectProperties();
			type.SortMethods();
			type.SortProperties();
			type.GenerateMembersFile(context);
			type.GenerateConstructorFile(context);
			type.GenerateDisposableFile(context);
			type.GenerateMainFile(context);
		}

		// Generate module structs
		{
			GeneratedStaticClass nn = classDictionary["NN"];
			StringWriter stringWriter = new();
			IndentedTextWriter writer = IndentedTextWriterFactory.Create(stringWriter);
			writer.WriteFileScopedNamespace("AssetRipper.Bindings.LibTorchSharp.Modules");
			foreach ((string methodName, int[] inputParameters) in ModuleStructDefinitions)
			{
				MethodData forwardMethod = nn.Methods.First(p => p.MidLevel.Name == methodName).MidLevel;
				int trainingParameter = forwardMethod.Parameters.IndexOf(p => p.Name == "training" && p.Type.IsBoolean);
				int inplaceParameter = forwardMethod.Parameters.IndexOf(p => p.Name == "inplace" && p.Type.IsBoolean);
				GenerateModuleStruct(writer, nn, forwardMethod, inputParameters, trainingParameter, inplaceParameter);
			}
			context.AddSource("ModuleStructs.cs", stringWriter.ToString());
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

	private static void GenerateModuleStruct(IndentedTextWriter writer, GeneratedStaticClass forwardMethodDeclaringType, MethodData forwardMethod, int[] inputParameters, int trainingParameter, int inplaceParameter)
	{
		string typeName = forwardMethod.Name;
		bool anyErrors = false;
		foreach (int inputParameter in inputParameters)
		{
			if (inputParameter >= forwardMethod.Parameters.Length)
			{
				writer.WriteLine($"#error Input parameter index out of range in {typeName}");
				anyErrors = true;
				continue;
			}
		}
		if (trainingParameter >= forwardMethod.Parameters.Length)
		{
			writer.WriteLine($"#error Training parameter index out of range in {typeName}");
			anyErrors = true;
		}
		if (inplaceParameter >= forwardMethod.Parameters.Length)
		{
			writer.WriteLine($"#error Inplace parameter index out of range in {typeName}");
			anyErrors = true;
		}
		if (anyErrors)
		{
			return;
		}

		writer.WriteLine($"public partial struct {typeName} : IModule");
		using (new CurlyBrackets(writer))
		{
			// IsTraining property
			if (trainingParameter < 0)
			{
				writer.WriteLine("public readonly bool IsTraining { set { } }");
			}
			else
			{
				writer.WriteLine("public bool IsTraining { readonly get; set; }");
			}

			int[] fieldParameters = Enumerable.Range(0, forwardMethod.Parameters.Length)
				.Except(inputParameters)
				.Where(i => i != trainingParameter && i != inplaceParameter)
				.ToArray();

			// Properties
			foreach (int fieldParameter in fieldParameters)
			{
				ParameterData parameter = forwardMethod.Parameters[fieldParameter];
				string propertyName = $"{char.ToUpperInvariant(parameter.Name[0])}{parameter.Name[1..]}";
				writer.WriteLine($"private {parameter.Type} {parameter.Name};");
				if (parameter.Type.IsTensor)
				{
					writer.WriteLine($"public readonly {parameter.Type} {propertyName} => this.{parameter.Name}.IsNull ? Tensor.Null : this.{parameter.Name}.Alias();");
				}
				else
				{
					writer.WriteLine($"public {parameter.Type} {propertyName}");
					using (new CurlyBrackets(writer))
					{
						writer.WriteLine($"readonly get => this.{parameter.Name};");
						writer.WriteLine($"set => this.{parameter.Name} = value;");
					}
				}
			}

			// Constructor
			writer.Write("public ");
			writer.Write(typeName);
			writer.Write('(');
			writer.Write(string.Join(", ", fieldParameters.Select(i => forwardMethod.Parameters[i].ToString())));
			writer.WriteLine(")");
			using (new CurlyBrackets(writer))
			{
				foreach (int fieldParameter in fieldParameters)
				{
					ParameterData parameter = forwardMethod.Parameters[fieldParameter];
					writer.WriteLine($"this.{parameter.Name} = {parameter.Name};");
				}
			}

			// Forward method
			writer.WriteDebuggerIgnoreAttributes();
			writer.Write("public ");
			writer.Write(forwardMethod.ReturnType.ToString());
			writer.Write(" Forward(");
			writer.Write(string.Join(", ", inputParameters.Select(i => forwardMethod.Parameters[i].ToString())));
			writer.WriteLine(')');
			using (new CurlyBrackets(writer))
			{
				writer.Write("return ");
				writer.Write(forwardMethodDeclaringType.GloballyQualifiedFullName);
				writer.Write('.');
				writer.Write(forwardMethod.Name);
				writer.Write('(');
				for (int parameterIndex = 0; parameterIndex < forwardMethod.Parameters.Length; parameterIndex++)
				{
					if (parameterIndex > 0)
					{
						writer.Write(", ");
					}

					if (parameterIndex == inplaceParameter)
					{
						writer.Write("false");
					}
					else if (parameterIndex == trainingParameter)
					{
						writer.Write("this.IsTraining");
					}
					else if (inputParameters.Contains(parameterIndex))
					{
						writer.Write(forwardMethod.Parameters[parameterIndex].Name);
					}
					else
					{
						writer.Write("this.");
						writer.Write(forwardMethod.Parameters[parameterIndex].Name);
					}
				}
				writer.WriteLine(");");
			}

			int[] weightParameters = fieldParameters.Where(i => forwardMethod.Parameters[i].Type.IsTensor).ToArray();

			// CopyFromRoot method
			writer.WriteLine("void IModule.CopyFromRoot(StateDictionary dictionary)");
			using (new CurlyBrackets(writer))
			{
				foreach (int weightParameter in weightParameters)
				{
					ParameterData parameter = forwardMethod.Parameters[weightParameter];
					writer.WriteLine($"this.{parameter.Name}.CopyFrom(dictionary, nameof({typeName}.{parameter.Name}));");
				}
			}

			// CopyToRoot method
			writer.WriteLine("readonly void IModule.CopyToRoot(StateDictionary dictionary)");
			using (new CurlyBrackets(writer))
			{
				foreach (int weightParameter in weightParameters)
				{
					ParameterData parameter = forwardMethod.Parameters[weightParameter];
					writer.WriteLine($"this.{parameter.Name}.CopyTo(dictionary, nameof({typeName}.{parameter.Name}));");
				}
			}

			// GetParameters method
			writer.Write("public readonly IEnumerable<Tensor> GetParameters() => [");
			foreach (int weightParameter in weightParameters)
			{
				ParameterData parameter = forwardMethod.Parameters[weightParameter];
				string propertyName = $"{char.ToUpperInvariant(parameter.Name[0])}{parameter.Name[1..]}";
				writer.Write(propertyName);
				writer.Write(", ");
			}
			writer.WriteLine("];");

			// Dispose method
			writer.WriteLine("public void Dispose()");
			using (new CurlyBrackets(writer))
			{
				foreach (int weightParameter in weightParameters)
				{
					ParameterData parameter = forwardMethod.Parameters[weightParameter];
					writer.WriteLine($"this.{parameter.Name}.Dispose();");
					writer.WriteLine($"this.{parameter.Name} = default;");
				}
			}
		}
	}
}
