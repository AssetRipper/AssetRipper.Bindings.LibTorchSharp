using Microsoft.CodeAnalysis;
using System.Collections.Immutable;

namespace AssetRipper.Bindings.LibTorchSharp.SourceGenerator;

internal readonly record struct ParameterData(TypeData Type, string Name, bool IsOut = false, string? DefaultValue = null)
{
	public string NameWithOutPrefix => IsOut ? $"out {Name}" : Name;
	public override string ToString()
	{
		string outPrefix = IsOut ? "out " : "";
		return string.IsNullOrEmpty(DefaultValue) ? $"{outPrefix}{Type} {Name}" : $"{outPrefix}{Type} {Name} = {DefaultValue}";
	}

	public static ParameterData From(IParameterSymbol parameter)
	{
		return new(TypeData.From(parameter.Type), parameter.Name.PrefixWithAtSignIfKeyword());
	}
	public ParameterData ReplaceIfUsingOpaqueType(ImmutableArray<StructData> structs)
	{
		return new ParameterData(Type.ReplaceIfUsingOpaqueType(structs), Name, IsOut);
	}
}
