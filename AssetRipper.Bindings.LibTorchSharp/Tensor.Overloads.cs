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

	public Tensor ones_like(bool requires_grad)
	{
		return ones_like(Type, requires_grad, GetDevice());
	}
}
