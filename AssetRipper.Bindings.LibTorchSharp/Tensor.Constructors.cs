using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace AssetRipper.Bindings.LibTorchSharp;

public readonly partial struct Tensor
{
	public static unsafe Tensor @new(ReadOnlySpan<byte> data, ReadOnlySpan<long> sizes, ScalarType scalar_type, ScalarType dtype, bool requires_grad, Device? device = null)
	{
		// Allocate native memory and copy data
		void* pdata = NativeMemory.Alloc((nuint)data.Length);
		data.CopyTo(new Span<byte>(pdata, data.Length));

		return @new(pdata, &FreeNativeMemory, sizes, scalar_type, dtype, requires_grad, device);

		[UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
		static void FreeNativeMemory(void* ptr) => NativeMemory.Free(ptr);
	}

	private static Tensor @new<T>(ReadOnlySpan<T> data, ReadOnlySpan<long> sizes, bool requires_grad, ScalarType? dtype, Device? device) where T : unmanaged
	{
		ScalarType scalarType = ScalarType.Get<T>();
		return @new(MemoryMarshal.AsBytes(data), sizes.Length == 0 ? [data.Length] : sizes, scalarType, dtype ?? scalarType, requires_grad, device);
	}

	public static Tensor newByteScalar(byte value, bool requires_grad, Device? device = null)
	{
		return newByteScalar(unchecked((sbyte)value), requires_grad, device);
	}

	public static Tensor newBFloat16Scalar(BFloat16 value, bool requires_grad, Device? device = null)
	{
		return newBFloat16Scalar((float)value, requires_grad, device);
	}

	public static Tensor newFloat16Scalar(Half value, bool requires_grad, Device? device = null)
	{
		return newFloat16Scalar((float)value, requires_grad, device);
	}

	public static Tensor newComplexFloat32Scalar(Complex32 value, bool requires_grad, Device? device = null)
	{
		return newComplexFloat32Scalar(value.Real, value.Imaginary, requires_grad, device);
	}

	public static Tensor newComplexFloat64Scalar(Complex value, bool requires_grad, Device? device = null)
	{
		return newComplexFloat64Scalar(value.Real, value.Imaginary, requires_grad, device);
	}

	public static Tensor newScalar(Scalar scalar, bool requires_grad, Device? device = null) => scalar.Type switch
	{
		ScalarType.Byte => newByteScalar(scalar.ToUInt8(), requires_grad, device),
		ScalarType.Int8 => newInt8Scalar(scalar.ToInt8(), requires_grad, device),
		ScalarType.Int16 => newInt16Scalar(scalar.ToInt16(), requires_grad, device),
		ScalarType.Int32 => newInt32Scalar(scalar.ToInt32(), requires_grad, device),
		ScalarType.Int64 => newInt64Scalar(scalar.ToInt64(), requires_grad, device),
		ScalarType.Bool => newBoolScalar(scalar.ToBoolean(), requires_grad, device),
		ScalarType.BFloat16 => newBFloat16Scalar(scalar.ToBFloat16(), requires_grad, device),
		ScalarType.Float16 => newFloat16Scalar(scalar.ToHalf(), requires_grad, device),
		ScalarType.Float32 => newFloat32Scalar(scalar.ToSingle(), requires_grad, device),
		ScalarType.Float64 => newFloat64Scalar(scalar.ToDouble(), requires_grad, device),
		ScalarType.ComplexFloat32 => newComplexFloat32Scalar(scalar.ToComplex32(), requires_grad, device),
		ScalarType.ComplexFloat64 => newComplexFloat64Scalar(scalar.ToComplex64(), requires_grad, device),
		_ => throw new NotSupportedException($"Scalar type '{scalar.Type}' is not supported."),
	};

	public unsafe Tensor(ReadOnlySpan<byte> data, ReadOnlySpan<long> sizes = default, bool requires_grad = false, ScalarType? dtype = null, Device? device = null)
	{
		handle = @new(data, sizes, requires_grad, dtype, device);
	}

	public unsafe Tensor(ReadOnlySpan<sbyte> data, ReadOnlySpan<long> sizes = default, bool requires_grad = false, ScalarType? dtype = null, Device? device = null)
	{
		handle = @new(data, sizes, requires_grad, dtype, device);
	}

	public unsafe Tensor(ReadOnlySpan<short> data, ReadOnlySpan<long> sizes = default, bool requires_grad = false, ScalarType? dtype = null, Device? device = null)
	{
		handle = @new(data, sizes, requires_grad, dtype, device);
	}

	public unsafe Tensor(ReadOnlySpan<int> data, ReadOnlySpan<long> sizes = default, bool requires_grad = false, ScalarType? dtype = null, Device? device = null)
	{
		handle = @new(data, sizes, requires_grad, dtype, device);
	}

	public unsafe Tensor(ReadOnlySpan<long> data, ReadOnlySpan<long> sizes = default, bool requires_grad = false, ScalarType? dtype = null, Device? device = null)
	{
		handle = @new(data, sizes, requires_grad, dtype, device);
	}

	public unsafe Tensor(ReadOnlySpan<bool> data, ReadOnlySpan<long> sizes = default, bool requires_grad = false, ScalarType? dtype = null, Device? device = null)
	{
		handle = @new(data, sizes, requires_grad, dtype, device);
	}

	public unsafe Tensor(ReadOnlySpan<BFloat16> data, ReadOnlySpan<long> sizes = default, bool requires_grad = false, ScalarType? dtype = null, Device? device = null)
	{
		handle = @new(data, sizes, requires_grad, dtype, device);
	}

	public unsafe Tensor(ReadOnlySpan<Half> data, ReadOnlySpan<long> sizes = default, bool requires_grad = false, ScalarType? dtype = null, Device? device = null)
	{
		handle = @new(data, sizes, requires_grad, dtype, device);
	}

	public unsafe Tensor(ReadOnlySpan<float> data, ReadOnlySpan<long> sizes = default, bool requires_grad = false, ScalarType? dtype = null, Device? device = null)
	{
		handle = @new(data, sizes, requires_grad, dtype, device);
	}

	public unsafe Tensor(ReadOnlySpan<double> data, ReadOnlySpan<long> sizes = default, bool requires_grad = false, ScalarType? dtype = null, Device? device = null)
	{
		handle = @new(data, sizes, requires_grad, dtype, device);
	}

	public unsafe Tensor(ReadOnlySpan<Complex32> data, ReadOnlySpan<long> sizes = default, bool requires_grad = false, ScalarType? dtype = null, Device? device = null)
	{
		handle = @new(data, sizes, requires_grad, dtype, device);
	}

	public unsafe Tensor(ReadOnlySpan<Complex> data, ReadOnlySpan<long> sizes = default, bool requires_grad = false, ScalarType? dtype = null, Device? device = null)
	{
		handle = @new(data, sizes, requires_grad, dtype, device);
	}

	public unsafe Tensor(byte value, bool requires_grad = false, Device? device = null)
	{
		handle = newByteScalar(value, requires_grad, device);
	}

	public unsafe Tensor(sbyte value, bool requires_grad = false, Device? device = null)
	{
		handle = newInt8Scalar(value, requires_grad, device);
	}

	public unsafe Tensor(short value, bool requires_grad = false, Device? device = null)
	{
		handle = newInt16Scalar(value, requires_grad, device);
	}

	public unsafe Tensor(int value, bool requires_grad = false, Device? device = null)
	{
		handle = newInt32Scalar(value, requires_grad, device);
	}

	public unsafe Tensor(long value, bool requires_grad = false, Device? device = null)
	{
		handle = newInt64Scalar(value, requires_grad, device);
	}

	public unsafe Tensor(bool value, bool requires_grad = false, Device? device = null)
	{
		handle = newBoolScalar(value, requires_grad, device);
	}

	public unsafe Tensor(BFloat16 value, bool requires_grad = false, Device? device = null)
	{
		handle = newBFloat16Scalar(value, requires_grad, device);
	}

	public unsafe Tensor(Half value, bool requires_grad = false, Device? device = null)
	{
		handle = newFloat16Scalar(value, requires_grad, device);
	}

	public unsafe Tensor(float value, bool requires_grad = false, Device? device = null)
	{
		handle = newFloat32Scalar(value, requires_grad, device);
	}

	public unsafe Tensor(double value, bool requires_grad = false, Device? device = null)
	{
		handle = newFloat64Scalar(value, requires_grad, device);
	}

	public unsafe Tensor(Complex32 value, bool requires_grad = false, Device? device = null)
	{
		handle = newComplexFloat32Scalar(value.Real, value.Imaginary, requires_grad, device);
	}

	public unsafe Tensor(Complex value, bool requires_grad = false, Device? device = null)
	{
		handle = newComplexFloat64Scalar(value.Real, value.Imaginary, requires_grad, device);
	}

	public unsafe Tensor(Scalar scalar, bool requires_grad = false, Device? device = null)
	{
		handle = newScalar(scalar, requires_grad, device);
	}
}
