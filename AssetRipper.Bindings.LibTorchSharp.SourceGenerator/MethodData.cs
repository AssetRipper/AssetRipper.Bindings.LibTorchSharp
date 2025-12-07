using Microsoft.CodeAnalysis;
using System;
using System.Buffers;
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

	public string GetNameInType(string prefix, bool clean = true)
	{
		string snake_case = Name[(Name.IndexOf(prefix) + prefix.Length)..];
		if (!clean)
		{
			return snake_case;
		}
		string PascalCase = SnakeToPascal(snake_case);
		return GetAlternateName(PascalCase);
	}

	public MethodData CleanName()
	{
		return this with { Name = GetAlternateName(SnakeToPascal(Name)) };
	}

	private static string GetAlternateName(string input)
	{
		if (input is "Dispose")
		{
			return "__Dispose";
		}
		else if (input is "Ctor" or "New")
		{
			return "Create";
		}
		else if (input.StartsWith("New", StringComparison.Ordinal))
		{
			return $"Create{input["New".Length..]}";
		}
		else if (input is "Item")
		{
			return "ToScalar"; // Conflicts with indexer properties
		}
		else
		{
			return input;
		}
	}

	private static string SnakeToPascal(string input)
	{
		if (string.IsNullOrEmpty(input))
			return input;

		char[] buffer = ArrayPool<char>.Shared.Rent(input.Length);

		int pos = 0;
		bool capitalizeNext = true;

		for (int i = 0; i < input.Length; i++)
		{
			char c = input[i];

			if (c == '_')
			{
				capitalizeNext = true;
				continue;
			}

			if (capitalizeNext)
			{
				buffer[pos++] = char.ToUpperInvariant(c);
				capitalizeNext = false;
			}
			else
			{
				buffer[pos++] = c;
			}
		}

		string result;
		if (pos == input.Length && buffer[0] == input[0])
		{
			// No characters were changed
			result = input;
		}
		else
		{
			// Create final string of correct length
			result = new string(buffer, 0, pos);
		}

		// Return buffer to pool
		ArrayPool<char>.Shared.Return(buffer);

		return result;
	}
}
