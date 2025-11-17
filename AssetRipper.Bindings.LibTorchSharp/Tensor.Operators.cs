using System.Numerics;

namespace AssetRipper.Bindings.LibTorchSharp;

public readonly partial struct Tensor :
	IAdditionOperators<Tensor, Tensor, Tensor>,
	IAdditionOperators<Tensor, Scalar, Tensor>,
	ISubtractionOperators<Tensor, Tensor, Tensor>,
	ISubtractionOperators<Tensor, Scalar, Tensor>,
	IMultiplyOperators<Tensor, Tensor, Tensor>,
	IMultiplyOperators<Tensor, Scalar, Tensor>,
	IDivisionOperators<Tensor, Tensor, Tensor>,
	IDivisionOperators<Tensor, Scalar, Tensor>,
	IUnaryNegationOperators<Tensor, Tensor>,
	IModulusOperators<Tensor, Tensor, Tensor>,
	IModulusOperators<Tensor, Scalar, Tensor>,
	IComparisonOperators<Tensor, Tensor, Tensor>,
	IComparisonOperators<Tensor, Scalar, Tensor>,
	IEqualityOperators<Tensor, Tensor, Tensor>,
	IEqualityOperators<Tensor, Scalar, Tensor>,
	IShiftOperators<Tensor, Tensor, Tensor>,
	IShiftOperators<Tensor, int, Tensor>,
	IBitwiseOperators<Tensor, Tensor, Tensor>
{
	public static Tensor operator +(Tensor left, Tensor right) => left.add(right);
	public static Tensor operator +(Tensor left, Scalar right) => left.add_scalar(right);
	public static Tensor operator +(Scalar left, Tensor right) => right.add_scalar(left);

	public static Tensor operator -(Tensor left, Tensor right) => left.sub(right);
	public static Tensor operator -(Tensor left, Scalar right) => left.sub_scalar(right);
	public static Tensor operator -(Scalar left, Tensor right)
	{
		using Tensor negation = -right;
		return left + negation;
	}

	public static Tensor operator *(Tensor left, Tensor right) => left.mul(right);
	public static Tensor operator *(Tensor left, Scalar right) => left.mul_scalar(right);
	public static Tensor operator *(Scalar left, Tensor right) => right.mul_scalar(left);

	public static unsafe Tensor operator /(Tensor left, Tensor right) => left.div(right, null);
	public static unsafe Tensor operator /(Tensor left, Scalar right) => left.div_scalar(right, null);
	public static Tensor operator /(Scalar left, Tensor right)
	{
		using Tensor reciprocal = right.reciprocal();
		return left * reciprocal;
	}

	public static Tensor operator %(Tensor left, Tensor right) => left.remainder(right);
	public static Tensor operator %(Tensor left, Scalar right) => left.remainder_scalar(right);
	public static Tensor operator %(Scalar left, Tensor right)
	{
		using Tensor leftTensor = new(left, false, right.GetDevice());
		return leftTensor % right;
	}

	public static Tensor operator -(Tensor tensor) => tensor.neg();

	public static Tensor operator <(Tensor left, Tensor right) => left.lt(right);
	public static Tensor operator <(Tensor left, Scalar right) => left.lt_scalar(right);
	public static Tensor operator <(Scalar left, Tensor right) => right >= left;

	public static Tensor operator <=(Tensor left, Tensor right) => left.le(right);
	public static Tensor operator <=(Tensor left, Scalar right) => left.le_scalar(right);
	public static Tensor operator <=(Scalar left, Tensor right) => right > left;

	public static Tensor operator >(Tensor left, Tensor right) => left.gt(right);
	public static Tensor operator >(Tensor left, Scalar right) => left.gt_scalar(right);
	public static Tensor operator >(Scalar left, Tensor right) => right <= left;

	public static Tensor operator >=(Tensor left, Tensor right) => left.ge(right);
	public static Tensor operator >=(Tensor left, Scalar right) => left.ge_scalar(right);
	public static Tensor operator >=(Scalar left, Tensor right) => right < left;

	public static Tensor operator ==(Tensor left, Tensor right) => left.eq(right);
	public static Tensor operator ==(Tensor left, Scalar right) => left.eq_scalar(right);
	public static Tensor operator ==(Scalar left, Tensor right) => right.eq_scalar(left);

	public static Tensor operator !=(Tensor left, Tensor right) => left.ne(right);
	public static Tensor operator !=(Tensor left, Scalar right) => left.ne_scalar(right);
	public static Tensor operator !=(Scalar left, Tensor right) => right.ne_scalar(left);

	public static Tensor operator &(Tensor left, Tensor right) => left.bitwise_and(right);
	public static Tensor operator |(Tensor left, Tensor right) => left.bitwise_or(right);
	public static Tensor operator ^(Tensor left, Tensor right) => left.bitwise_xor(right);
	public static Tensor operator ~(Tensor left) => left.bitwise_not();

	public static Tensor operator <<(Tensor left, Tensor right) => left.bitwise_left_shift(right);
	public static Tensor operator >>(Tensor left, Tensor right) => left.bitwise_right_shift(right);
	public static Tensor operator >>>(Tensor left, Tensor right)
	{
		int bitWidth = (ScalarType)left.type() switch
		{
			ScalarType.Int8 or ScalarType.Byte => 8,
			ScalarType.Int16 => 16,
			ScalarType.Int32 => 32,
			ScalarType.Int64 => 64,
			_ => throw new NotSupportedException("Unsigned right shift is only supported for integer tensor types."),
		};
		using Tensor inverseShiftAmount = bitWidth - right;
		using Tensor ones = right.ones_like(false);
		using Tensor ones_left_shifted = ones << inverseShiftAmount;
		using Tensor mask = ones_left_shifted - ones;
		using Tensor shifted = left >> right;
		return shifted & mask;
	}

	public static Tensor operator <<(Tensor left, int right)
	{
		using Tensor tensor = new(right);
		return left << tensor;
	}
	public static Tensor operator >>(Tensor left, int right)
	{
		using Tensor tensor = new(right);
		return left >> tensor;
	}
	public static Tensor operator >>>(Tensor left, int right)
	{
		using Tensor tensor = new(right);
		return left >>> tensor;
	}

	public static explicit operator Tensor(Scalar scalar) => new(scalar);
}
