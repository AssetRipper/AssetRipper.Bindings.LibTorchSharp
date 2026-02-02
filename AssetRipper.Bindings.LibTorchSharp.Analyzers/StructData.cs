using Microsoft.CodeAnalysis;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace AssetRipper.Bindings.LibTorchSharp.Analyzers;

[StructLayout(LayoutKind.Auto)]
internal readonly record struct StructData(string Namespace, string Name, bool IsTrainingField, EquatableArray<PropertyData> Properties)
{
	public string GetNameForModuleData()
	{
		return GetNonConflictingName("__ModuleData");
	}

	public string GetNameForModuleDataField()
	{
		return GetNonConflictingName("__data");
	}

	public string GetNameForInitializeMethod()
	{
		return GetNonConflictingName("Initialize");
	}

	private string GetNonConflictingName(string candidateName)
	{
		HashSet<string> reservedNames =
		[
			Name,
			..Properties.Select(p => p.Name)
		];
		while (reservedNames.Contains(candidateName))
		{
			candidateName = $"_{candidateName}";
		}
		return candidateName;
	}
}
