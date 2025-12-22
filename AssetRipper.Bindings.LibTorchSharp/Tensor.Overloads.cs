namespace AssetRipper.Bindings.LibTorchSharp;

public readonly partial struct Tensor
{
	public Tensor Add(Tensor other)
	{
		using Scalar alpha = Scalar.FromInt32(1);
		return Add(other, alpha);
	}

	public static Tensor Add(Tensor t1, Tensor t2)
	{
		return t1.Add(t2);
	}

	public static Tensor Add(Tensor t1, Tensor t2, Tensor t3)
	{
		using Scalar alpha = Scalar.FromInt32(1);
		using Tensor temp = t1.Add(t2, alpha);
		return temp.Add(t3, alpha);
	}

	public static Tensor Add(Tensor t1, Tensor t2, Tensor t3, Tensor t4)
	{
		using Scalar alpha = Scalar.FromInt32(1);
		using Tensor temp1 = t1.Add(t2, alpha);
		using Tensor temp2 = temp1.Add(t3, alpha);
		return temp2.Add(t4, alpha);
	}

	public static Tensor Add(params ReadOnlySpan<Tensor> tensors)
	{
		if (tensors.Length == 0)
		{
			return Null;
		}
		if (tensors.Length == 1)
		{
			return tensors[0].Alias();
		}
		using Scalar alpha = Scalar.FromInt32(1);
		Tensor result = tensors[0].Add(tensors[1], alpha);
		for (int i = 2; i < tensors.Length; i++)
		{
			Tensor temp;
			try
			{
				temp = result.Add(tensors[i], alpha);
			}
			finally
			{
				result.Dispose();
			}
			result = temp;
		}
		return result;
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
