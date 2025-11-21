using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace AssetRipper.Bindings.LibTorchSharp.SourceGenerator;

internal sealed class GeneratedStaticClass(string name) : GeneratedType
{
	public override string Kind => "static partial class";
	public override string Name { get; } = name;
	public override bool IsInstance(MethodData method) => false;
	public static GeneratedStaticClass Create(string name) => new(name);

	public IEnumerable<GeneratedChildStruct> ExtractChildren(List<GeneratedOpaqueStruct> structs)
	{
		while (TryFindNewClass(out string? newTypeName, out GeneratedOpaqueStruct? baseType, structs))
		{
			string prefix = newTypeName + '_';
			GeneratedChildStruct generatedType = new(baseType, newTypeName);
			for (int i = Methods.Count - 1; i >= 0; i--)
			{
				(MethodData method, MethodData nativeMethod) = Methods[i];
				if (method.Name.StartsWith(prefix, StringComparison.Ordinal))
				{
					Methods.RemoveAt(i);
					method = method with { Name = method.Name[prefix.Length..] };
					if (generatedType.IsInstance(method))
					{
						method = method.ChangeFirstParameterNameToThis();
					}
					if (method.ReturnType == baseType.Struct.StructType)
					{
						method = method with { ReturnType = new(newTypeName, 0) };
					}
					generatedType.Methods.Add(new(method, nativeMethod));
				}
			}
			yield return generatedType;
		}
	}

	private bool TryFindNewClass([NotNullWhen(true)] out string? typeName, [NotNullWhen(true)] out GeneratedOpaqueStruct? baseType, List<GeneratedOpaqueStruct> structs)
	{
		foreach (MethodPair methodPair in Methods)
		{
			if (!methodPair.MidLevel.Name.EndsWith("_ctor", StringComparison.Ordinal))
			{
				continue;
			}

			typeName = methodPair.MidLevel.Name[..^5];
			baseType = structs.FirstOrDefault(s => s.Struct.StructType == methodPair.MidLevel.ReturnType);
			return baseType is not null;
		}
		typeName = null;
		baseType = null;
		return false;
	}
}
