namespace AssetRipper.Bindings.LibTorchSharp.LowLevel;

public unsafe partial struct TensorArray
{
	[NativeTypeName("Tensor *")]
	public OpaqueTensor** array;

	[NativeTypeName("int64_t")]
	public long size;
}
