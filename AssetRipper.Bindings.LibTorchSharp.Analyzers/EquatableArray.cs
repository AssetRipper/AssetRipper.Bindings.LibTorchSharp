using System;
using System.Collections;
using System.Collections.Generic;

namespace AssetRipper.Bindings.LibTorchSharp.Analyzers;

internal readonly struct EquatableArray<T> : IEquatable<EquatableArray<T>>, IReadOnlyList<T>
	where T : IEquatable<T>
{
	private readonly IReadOnlyList<T> array;
	public EquatableArray(IReadOnlyList<T> array)
	{
		this.array = array;
	}

	public T this[int index] => array[index];

	public int Count => array.Count;

	public bool Equals(EquatableArray<T> other)
	{
		if (array.Count != other.array.Count)
		{
			return false;
		}
		for (int i = array.Count - 1; i >= 0; i--)
		{
			if (!array[i].Equals(other.array[i]))
			{
				return false;
			}
		}
		return true;
	}

	public IEnumerator<T> GetEnumerator()
	{
		return array.GetEnumerator();
	}

	public override int GetHashCode()
	{
		HashCode hash = new();
		foreach (T item in array)
		{
			hash.Add(item);
		}
		return hash.ToHashCode();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return array.GetEnumerator();
	}
}
