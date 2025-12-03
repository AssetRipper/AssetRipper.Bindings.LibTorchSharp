namespace AssetRipper.Bindings.LibTorchSharp;

public readonly partial struct Tensor
{
	public Tensor add(Tensor other)
	{
		using Scalar alpha = Scalar.FromInt32(1);
		return add(other, alpha);
	}

	public Tensor add_scalar(Scalar scalar)
	{
		using Scalar alpha = Scalar.FromInt32(1);
		return add_scalar(scalar, alpha);
	}

	public static unsafe Tensor ones(ReadOnlySpan<long> sizes, ScalarType scalar_type, DeviceType device_type, int device_index, bool requires_grad)
	{
		return ones(sizes, (sbyte)scalar_type, (int)device_type, device_index, requires_grad);
	}

	public Tensor ones_like(bool requires_grad)
	{
		return ones_like(type(), device_type(), device_index(), requires_grad);
	}
}
