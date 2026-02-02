namespace AssetRipper.Bindings.LibTorchSharp.Modules;

public readonly struct TensorArray : IDisposable
{
	private readonly AllocatedArray<Tensor> array;

	public TensorArray(ReadOnlySpan<Tensor> span)
	{
		array = new(span.Length);
		span.CopyTo(array.AsSpan());
	}

	public Tensor this[int index] => array[index];

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

	public Tensor[] GetParameters()
	{
		return array.AsReadOnlySpan().ToArray();
	}

	public ReadOnlySpan<Tensor> AsSpan() => array.AsReadOnlySpan();
}
