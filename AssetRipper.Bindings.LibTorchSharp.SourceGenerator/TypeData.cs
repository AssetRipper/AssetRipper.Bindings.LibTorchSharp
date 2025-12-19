using Microsoft.CodeAnalysis;
using System;
using System.Collections.Immutable;

namespace AssetRipper.Bindings.LibTorchSharp.SourceGenerator;

internal readonly record struct TypeData(string Name, int PointerLevel = 0)
{
	public bool IsVoid => Name is "void" && PointerLevel is 0;
	public bool IsBoolean => Name is "bool" && PointerLevel is 0;
	public bool IsPointer => PointerLevel > 0;
	public bool IsFunctionPointer => PointerLevel is 0 && Name.StartsWith("delegate* ", StringComparison.Ordinal);
	public bool IsSByte=> Name is "sbyte" && PointerLevel is 0;
	public bool IsSBytePointer => Name is "sbyte" && PointerLevel is 1;
	public bool IsInt32 => Name is "int" && PointerLevel is 0;
	public bool IsInt64 => Name is "long" && PointerLevel is 0;
	public bool IsTensor => Name is "Tensor" && PointerLevel is 0;

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
