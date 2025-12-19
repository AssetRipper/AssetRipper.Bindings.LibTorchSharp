using AssetRipper.Bindings.LibTorchSharp.SourceGenerator.Extensions;
using SGF;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace AssetRipper.Bindings.LibTorchSharp.SourceGenerator;

public partial class BindingsSourceGenerator
{
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
}
