namespace AssetRipper.Bindings.LibTorchSharp;

public readonly partial struct Tensor
{
	public Tensor Add(Tensor other)
	{
		using Scalar alpha = Scalar.FromInt32(1);
		return Add(other, alpha);
	}

	public Tensor AddScalar(Scalar scalar)
	{
		using Scalar alpha = Scalar.FromInt32(1);
		return AddScalar(scalar, alpha);
	}

	public Tensor OnesLike(bool requires_grad)
	{
		return OnesLike(Type, requires_grad, GetDevice());
	}
}
