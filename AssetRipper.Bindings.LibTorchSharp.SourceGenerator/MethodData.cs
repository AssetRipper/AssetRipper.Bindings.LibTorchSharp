using Microsoft.CodeAnalysis;
using System;
using System.Collections.Immutable;

namespace AssetRipper.Bindings.LibTorchSharp.SourceGenerator;

internal readonly record struct MethodData(TypeData ReturnType, string Name, ParameterDataArray Parameters) : IComparable<MethodData>
{
	public static MethodData From(IMethodSymbol method)
	{
		return new(TypeData.From(method.ReturnType), method.Name, ParameterDataArray.From(method.Parameters));
	}

	public override string ToString()
	{
		string parametersString = string.Join(", ", Parameters);
		return $"{ReturnType} {Name}({parametersString})";
	}

	int IComparable<MethodData>.CompareTo(MethodData other)
	{
		return Name.CompareTo(other.Name);
	}

	public MethodData ReplaceOpaqueTypes(ImmutableArray<StructData> structs)
	{
		return new MethodData(ReturnType.ReplaceIfUsingOpaqueType(structs), Name, Parameters.ReplaceOpaqueTypes(structs));
	}

	public MethodData ChangeFirstParameterNameToThis()
	{
		return new MethodData(ReturnType, Name, Parameters.ChangeFirstParameterNameToThis());
	}

	public MethodData ChangeLastParameterNameToValue()
	{
		return new MethodData(ReturnType, Name, Parameters.ChangeLastParameterNameToValue());
	}

	public string GetNameInStruct(StructData @struct)
	{
		return Name.Substring(Name.IndexOf(@struct.PrefixName) + @struct.PrefixName.Length).PrefixWithAtSignIfKeyword();
	}

	public string GetNameInClass(string className)
	{
		return Name.Substring(Name.IndexOf(className) + className.Length + 1).PrefixWithAtSignIfKeyword();
	}
}
