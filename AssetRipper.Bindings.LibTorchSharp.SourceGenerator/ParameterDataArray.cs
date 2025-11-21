using Microsoft.CodeAnalysis;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;

namespace AssetRipper.Bindings.LibTorchSharp.SourceGenerator;

internal readonly struct ParameterDataArray(ImmutableArray<ParameterData> array) : IEquatable<ParameterDataArray>, IReadOnlyList<ParameterData>
{
	private readonly int hash = CalculateHash(array);
	public ImmutableArray<ParameterData> Array { get; } = array;
	public int Length => Array.IsDefaultOrEmpty ? 0 : Array.Length;
	public ParameterData this[int index] => Array[index];
	public static ParameterDataArray Empty => new(ImmutableArray<ParameterData>.Empty);

	public ParameterDataArray(ParameterData[] array) : this(ImmutableArray.Create(array))
	{
	}

	public ParameterDataArray(IEnumerable<ParameterData> array) : this(ImmutableArray.CreateRange(array))
	{
	}

	public override bool Equals(object obj)
	{
		return obj is ParameterDataArray other && Equals(other);
	}

	public bool Equals(ParameterDataArray other)
	{
		if (hash != other.hash || Length != other.Length)
		{
			return false;
		}

		for (int i = Length - 1; i >= 0; i--)
		{
			if (this[i] != other[i])
			{
				return false;
			}
		}

		return true;
	}

	public override int GetHashCode()
	{
		return hash;
	}

	public static bool operator ==(ParameterDataArray left, ParameterDataArray right) => left.Equals(right);
	public static bool operator !=(ParameterDataArray left, ParameterDataArray right) => !(left == right);

	public override string ToString() => $"Length = {Length}";

	private static int CalculateHash(ImmutableArray<ParameterData> array)
	{
		HashCode hashCode = default;
		foreach (ParameterData parameter in array)
		{
			hashCode.Add(parameter);
		}
		return hashCode.ToHashCode();
	}

	public static ParameterDataArray From(ImmutableArray<IParameterSymbol> parameters)
	{
		if (parameters.IsEmpty)
		{
			return Empty;
		}

		ParameterData[] array = new ParameterData[parameters.Length];
		for (int i = parameters.Length - 1; i >= 0; i--)
		{
			array[i] = ParameterData.From(parameters[i]);
		}

		return new(array);
	}

	public ParameterDataArray ReplaceOpaqueTypes(ImmutableArray<StructData> structs)
	{
		if (Length == 0)
		{
			return this;
		}

		ParameterData[] array = new ParameterData[Length];
		for (int i = Length - 1; i >= 0; i--)
		{
			array[i] = this[i].ReplaceIfUsingOpaqueType(structs);
		}
		return new(array);
	}

	public ParameterDataArray ChangeFirstParameterNameToThis()
	{
		Debug.Assert(Length > 0);

		ParameterData[] array = [.. Array];
		array[0] = array[0] with { Name = "this" };
		return new(array);
	}

	public ParameterDataArray ChangeLastParameterNameToValue()
	{
		Debug.Assert(Length > 0);

		ParameterData[] array = [.. Array];
		array[^1] = array[^1] with { Name = "value" };
		return new(array);
	}

	int IReadOnlyCollection<ParameterData>.Count => Length;
	IEnumerator<ParameterData> IEnumerable<ParameterData>.GetEnumerator()
	{
		return ((IEnumerable<ParameterData>)Array).GetEnumerator();
	}
	IEnumerator IEnumerable.GetEnumerator()
	{
		return ((IEnumerable)Array).GetEnumerator();
	}
}
