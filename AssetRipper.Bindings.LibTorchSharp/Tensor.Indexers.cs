namespace AssetRipper.Bindings.LibTorchSharp;

public readonly partial struct Tensor
{
	public Tensor this[long i0]
	{
		get => Get1(i0);
		set => Set1(i0, value);
	}

	public Tensor this[long i0, long i1]
	{
		get => Get2(i0, i1);
		set => Set2(i0, i1, value);
	}

	public Tensor this[long i0, long i1, long i2]
	{
		get => Get3(i0, i1, i2);
		set => Set3(i0, i1, i2, value);
	}

	public Tensor this[long i0, long i1, long i2, long i3]
	{
		get => Get4(i0, i1, i2, i3);
		set => Set4(i0, i1, i2, i3, value);
	}

	public Tensor this[long i0, long i1, long i2, long i3, long i4]
	{
		get => Get5(i0, i1, i2, i3, i4);
		set => Set5(i0, i1, i2, i3, i4, value);
	}

	public Tensor this[long i0, long i1, long i2, long i3, long i4, long i5]
	{
		get => Get6(i0, i1, i2, i3, i4, i5);
		set => Set6(i0, i1, i2, i3, i4, i5, value);
	}
}
