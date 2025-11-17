using Microsoft.CodeAnalysis;
using System.Collections.Immutable;

namespace AssetRipper.Bindings.LibTorchSharp.SourceGenerator;

internal readonly record struct ParameterData(TypeData Type, string Name)
{
	public override string ToString() => $"{Type} {Name}";
	public static ParameterData From(IParameterSymbol parameter)
	{
		return new(TypeData.From(parameter.Type), parameter.Name.PrefixWithAtSignIfKeyword());
	}
	public ParameterData ReplaceIfUsingOpaqueType(ImmutableArray<StructData> structs)
	{
		return new ParameterData(Type.ReplaceIfUsingOpaqueType(structs), Name);
	}
}
