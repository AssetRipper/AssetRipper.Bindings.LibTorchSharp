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
	public static Tensor operator +(Tensor left, Tensor right) => left.Add(right);
	public static Tensor operator +(Tensor left, Scalar right) => left.AddScalar(right);
	public static Tensor operator +(Scalar left, Tensor right) => right.AddScalar(left);

	public static Tensor operator -(Tensor left, Tensor right) => left.Sub(right);
	public static Tensor operator -(Tensor left, Scalar right) => left.SubScalar(right);
	public static Tensor operator -(Scalar left, Tensor right)
	{
		using Tensor negation = -right;
		return left + negation;
	}

	public static Tensor operator *(Tensor left, Tensor right) => left.Mul(right);
	public static Tensor operator *(Tensor left, Scalar right) => left.MulScalar(right);
	public static Tensor operator *(Scalar left, Tensor right) => right.MulScalar(left);

	public static unsafe Tensor operator /(Tensor left, Tensor right) => left.Div(right, default);
	public static unsafe Tensor operator /(Tensor left, Scalar right) => left.DivScalar(right, default);
	public static Tensor operator /(Scalar left, Tensor right)
	{
		using Tensor reciprocal = right.Reciprocal();
		return left * reciprocal;
	}

	public static Tensor operator %(Tensor left, Tensor right) => left.Remainder(right);
	public static Tensor operator %(Tensor left, Scalar right) => left.RemainderScalar(right);
	public static Tensor operator %(Scalar left, Tensor right)
	{
		using Tensor leftTensor = new(left, false, right.GetDevice());
		return leftTensor % right;
	}

	public static Tensor operator -(Tensor tensor) => tensor.Neg();

	public static Tensor operator <(Tensor left, Tensor right) => left.Lt(right);
	public static Tensor operator <(Tensor left, Scalar right) => left.LtScalar(right);
	public static Tensor operator <(Scalar left, Tensor right) => right >= left;

	public static Tensor operator <=(Tensor left, Tensor right) => left.Le(right);
	public static Tensor operator <=(Tensor left, Scalar right) => left.LeScalar(right);
	public static Tensor operator <=(Scalar left, Tensor right) => right > left;

	public static Tensor operator >(Tensor left, Tensor right) => left.Gt(right);
	public static Tensor operator >(Tensor left, Scalar right) => left.GtScalar(right);
	public static Tensor operator >(Scalar left, Tensor right) => right <= left;

	public static Tensor operator >=(Tensor left, Tensor right) => left.Ge(right);
	public static Tensor operator >=(Tensor left, Scalar right) => left.GeScalar(right);
	public static Tensor operator >=(Scalar left, Tensor right) => right < left;

	public static Tensor operator ==(Tensor left, Tensor right) => left.Eq(right);
	public static Tensor operator ==(Tensor left, Scalar right) => left.EqScalar(right);
	public static Tensor operator ==(Scalar left, Tensor right) => right.EqScalar(left);

	public static Tensor operator !=(Tensor left, Tensor right) => left.Ne(right);
	public static Tensor operator !=(Tensor left, Scalar right) => left.NeScalar(right);
	public static Tensor operator !=(Scalar left, Tensor right) => right.NeScalar(left);

	public static Tensor operator &(Tensor left, Tensor right) => left.BitwiseAnd(right);
	public static Tensor operator |(Tensor left, Tensor right) => left.BitwiseOr(right);
	public static Tensor operator ^(Tensor left, Tensor right) => left.BitwiseXor(right);
	public static Tensor operator ~(Tensor left) => left.BitwiseNot();

	public static Tensor operator <<(Tensor left, Tensor right) => left.BitwiseLeftShift(right);
	public static Tensor operator >>(Tensor left, Tensor right) => left.BitwiseRightShift(right);
	public static Tensor operator >>>(Tensor left, Tensor right)
	{
		int bitWidth = left.Type switch
		{
			ScalarType.Int8 or ScalarType.Byte => 8,
			ScalarType.Int16 => 16,
			ScalarType.Int32 => 32,
			ScalarType.Int64 => 64,
			_ => throw new NotSupportedException("Unsigned right shift is only supported for integer tensor types."),
		};
		using Tensor inverseShiftAmount = bitWidth - right;
		using Tensor ones = right.OnesLike(false);
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
