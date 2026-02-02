using System.Collections;
using System.Runtime.InteropServices;

namespace AssetRipper.Bindings.LibTorchSharp.Modules;

internal unsafe readonly struct AllocatedArray<T> : IDisposable, IReadOnlyList<T> where T : unmanaged, IDisposable
{
	private readonly T* pointer;
	private readonly int length;
	public AllocatedArray(int length)
	{
		ArgumentOutOfRangeException.ThrowIfNegative(length);
		this.length = length;
		pointer = (T*)NativeMemory.AllocZeroed((nuint)length, (nuint)sizeof(T));
	}
	public ref T this[int index]
	{
		get
		{
			ArgumentOutOfRangeException.ThrowIfNegative(index);
			ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(index, length);
			return ref pointer[index];
		}
	}
	public int Length => length;

	public Span<T> AsSpan()
	{
		return new Span<T>(pointer, length);
	}
	public ReadOnlySpan<T> AsReadOnlySpan()
	{
		return new ReadOnlySpan<T>(pointer, length);
	}
	public void Dispose()
	{
		if (pointer == null)
		{
			return;
		}
		try
		{
			for (int i = 0; i < length; i++)
			{
				pointer[i].Dispose();
			}
		}
		finally
		{
			NativeMemory.Free(pointer);
		}
	}

	// IReadOnlyList<T> implementation
	int IReadOnlyCollection<T>.Count => Length;
	T IReadOnlyList<T>.this[int index] => this[index];
	public IEnumerator<T> GetEnumerator()
	{
		for (int i = 0; i < length; i++)
		{
			yield return this[i];
		}
	}
	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}
}
