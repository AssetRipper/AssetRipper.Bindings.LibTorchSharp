using System.Collections;

namespace AssetRipper.Bindings.LibTorchSharp.Modules;

public readonly struct ModuleArray<T> : IDisposable, IReadOnlyList<T> where T : unmanaged, IModule
{
	private readonly AllocatedArray<T> array;

	public ModuleArray(ReadOnlySpan<T> span)
	{
		array = new(span.Length);
		span.CopyTo(array.AsSpan());
	}

	public T this[int index] => array[index];

	public int Length => array.Length;

	public bool IsTraining
	{
		set
		{
			for (int i = 0; i < array.Length; i++)
			{
				array[i].IsTraining = value;
			}
		}
	}

	internal void CopyFromRoot(StateDictionary dictionary)
	{
		for (int i = 0; i < array.Length; i++)
		{
			array[i].CopyFrom(dictionary, i);
		}
	}

	internal void CopyToRoot(StateDictionary dictionary)
	{
		for (int i = 0; i < array.Length; i++)
		{
			array[i].CopyTo(dictionary, i);
		}
	}

	public void Dispose() => array.Dispose();

	public IEnumerable<Tensor> GetParameters()
	{
		List<Tensor> tensors = [];
		for (int i = 0; i < array.Length; i++)
		{
			tensors.AddRange(array[i].GetParameters());
		}
		return tensors;
	}

	public ReadOnlySpan<T> AsSpan() => array.AsReadOnlySpan();

	// IReadOnlyList<T> implementation
	int IReadOnlyCollection<T>.Count => Length;
	IEnumerator<T> IEnumerable<T>.GetEnumerator() => array.GetEnumerator();
	IEnumerator IEnumerable.GetEnumerator() => array.GetEnumerator();
}
