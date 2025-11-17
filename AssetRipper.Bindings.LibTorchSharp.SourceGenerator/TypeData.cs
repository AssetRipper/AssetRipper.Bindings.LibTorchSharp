using Microsoft.CodeAnalysis;
using System;
using System.Collections.Immutable;

namespace AssetRipper.Bindings.LibTorchSharp.SourceGenerator;

internal readonly record struct TypeData(string Name, int PointerLevel)
{
	public bool IsVoid => Name is "void" && PointerLevel is 0;

	public bool IsPointer => PointerLevel > 0 || Name.StartsWith("delegate* ", StringComparison.Ordinal);

	public override string ToString() => PointerLevel switch
	{
		0 => Name,
		1 => Name + '*',
		2 => Name + "**",
		_ => Name + new string('*', PointerLevel),
	};

	public static TypeData From(ITypeSymbol type)
	{
		int pointerLevel = 0;
		while (type is IPointerTypeSymbol pointerType)
		{
			pointerLevel++;
			type = pointerType.PointedAtType;
		}
		string displayString = type.ToDisplayString(NullableFlowState.None);
		return new(displayString.StartsWith("AssetRipper", StringComparison.Ordinal) ? type.Name : displayString, pointerLevel);
	}

	public TypeData ReplaceIfUsingOpaqueType(ImmutableArray<StructData> structs)
	{
		foreach (StructData @struct in structs)
		{
			if (@struct.TryReplaceOpaqueType(this, out TypeData replacement))
			{
				return replacement;
			}
		}
		return this;
	}
}
