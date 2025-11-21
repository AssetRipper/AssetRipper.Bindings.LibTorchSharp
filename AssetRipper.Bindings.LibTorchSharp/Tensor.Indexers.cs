namespace AssetRipper.Bindings.LibTorchSharp;

public readonly partial struct Tensor
{
	public Tensor this[long i0]
	{
		get => get1(i0);
		set => set1(i0, value);
	}

	public Tensor this[long i0, long i1]
	{
		get => get2(i0, i1);
		set => set2(i0, i1, value);
	}

	public Tensor this[long i0, long i1, long i2]
	{
		get => get3(i0, i1, i2);
		set => set3(i0, i1, i2, value);
	}

	public Tensor this[long i0, long i1, long i2, long i3]
	{
		get => get4(i0, i1, i2, i3);
		set => set4(i0, i1, i2, i3, value);
	}

	public Tensor this[long i0, long i1, long i2, long i3, long i4]
	{
		get => get5(i0, i1, i2, i3, i4);
		set => set5(i0, i1, i2, i3, i4, value);
	}

	public Tensor this[long i0, long i1, long i2, long i3, long i4, long i5]
	{
		get => get6(i0, i1, i2, i3, i4, i5);
		set => set6(i0, i1, i2, i3, i4, i5, value);
	}
}
