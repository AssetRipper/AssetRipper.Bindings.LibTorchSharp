using AssetRipper.Bindings.LibTorchSharp.Attributes;
using AssetRipper.Bindings.LibTorchSharp.LowLevel;
using System.Numerics;

namespace AssetRipper.Bindings.LibTorchSharp;

[OpaqueStruct(nameof(OpaqueScalar))]
public readonly partial struct Scalar
{
	public static Scalar FromHalf(Half value) => FromHalf((float)value);
	public unsafe Half ToHalf()
	{
		Half result = default;
		ToHalf((ushort*)&result);
		return result;
	}

	public static Scalar FromBFloat16(BFloat16 value) => FromBFloat16((float)value);
	public BFloat16 ToBFloat16() => (BFloat16)ToSingle(); // https://github.com/dotnet/TorchSharp/pull/1505

	public static Scalar FromComplex32(Complex32 value) => FromComplex32(value.Real, value.Imaginary);
	public unsafe Complex32 ToComplex32()
	{
		try
		{
			ToComplex32(&ScratchAllocator.AllocateSingle);
			Span<float> span = ScratchAllocator.GetAllocatedSpan<float>();
			return new(span[0], span[1]);
		}
		finally
		{
			ScratchAllocator.Free();
		}
	}

	public static Scalar FromComplex64(Complex value) => FromComplex64(value.Real, value.Imaginary);
	public unsafe Complex ToComplex64()
	{
		try
		{
			ToComplex64(&ScratchAllocator.AllocateDouble);
			Span<double> span = ScratchAllocator.GetAllocatedSpan<double>();
			return new Complex(span[0], span[1]);
		}
		finally
		{
			ScratchAllocator.Free();
		}
	}

	public static explicit operator Scalar(byte value) => FromUInt8(value);
	public static implicit operator byte(Scalar scalar) => scalar.ToUInt8();

	public static explicit operator Scalar(sbyte value) => FromInt8(value);
	public static implicit operator sbyte(Scalar scalar) => scalar.ToInt8();

	public static explicit operator Scalar(short value) => FromInt16(value);
	public static implicit operator short(Scalar scalar) => scalar.ToInt16();

	public static explicit operator Scalar(int value) => FromInt32(value);
	public static implicit operator int(Scalar scalar) => scalar.ToInt32();

	public static explicit operator Scalar(long value) => FromInt64((int)value);
	public static implicit operator long(Scalar scalar) => scalar.ToInt64();

	public static explicit operator Scalar(bool value) => FromBoolean(value);
	public static implicit operator bool(Scalar scalar) => scalar.ToBoolean();

	public static explicit operator Scalar(BFloat16 value) => FromBFloat16(value);
	public static implicit operator BFloat16(Scalar scalar) => scalar.ToBFloat16();

	public static explicit operator Scalar(Half value) => FromHalf(value);
	public static implicit operator Half(Scalar scalar) => scalar.ToHalf();

	public static explicit operator Scalar(float value) => FromSingle(value);
	public static implicit operator float(Scalar scalar) => scalar.ToSingle();

	public static explicit operator Scalar(double value) => FromDouble(value);
	public static implicit operator double(Scalar scalar) => scalar.ToDouble();

	public static explicit operator Scalar(Complex32 value) => FromComplex32(value);
	public static implicit operator Complex32(Scalar scalar) => scalar.ToComplex32();

	public static explicit operator Scalar(Complex value) => FromComplex64(value);
	public static implicit operator Complex(Scalar scalar) => scalar.ToComplex64();
}
