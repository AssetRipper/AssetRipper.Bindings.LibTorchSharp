namespace AssetRipper.Bindings.LibTorchSharp.LowLevel;

public partial struct TensorOrScalar
{
	[NativeTypeName("int64_t")]
	public long TypeCode;

	[NativeTypeName("int64_t")]
	public long ArrayIndex;

	[NativeTypeName("ptrdiff_t")]
	public nint Handle;
}
