using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace AssetRipper.Bindings.LibTorchSharp;

public readonly partial struct Tensor
{
	public static unsafe Tensor Create(ReadOnlySpan<byte> data, ReadOnlySpan<long> sizes, ScalarType scalar_type, ScalarType dtype, bool requires_grad, Device? device = null)
	{
		// Allocate native memory and copy data
		void* pdata = NativeMemory.Alloc((nuint)data.Length);
		data.CopyTo(new Span<byte>(pdata, data.Length));

		return Create(pdata, &FreeNativeMemory, sizes, scalar_type, dtype, requires_grad, device);

		[UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
		static void FreeNativeMemory(void* ptr) => NativeMemory.Free(ptr);
	}

	private static Tensor Create<T>(ReadOnlySpan<T> data, ReadOnlySpan<long> sizes, bool requires_grad, ScalarType? dtype, Device? device) where T : unmanaged
	{
		ScalarType scalarType = ScalarType.Get<T>();
		return Create(MemoryMarshal.AsBytes(data), sizes.Length == 0 ? [data.Length] : sizes, scalarType, dtype ?? scalarType, requires_grad, device);
	}

	public static Tensor CreateByteScalar(byte value, bool requires_grad, Device? device = null)
	{
		return CreateByteScalar(unchecked((sbyte)value), requires_grad, device);
	}

	public static Tensor CreateBFloat16Scalar(BFloat16 value, bool requires_grad, Device? device = null)
	{
		return CreateBFloat16Scalar((float)value, requires_grad, device);
	}

	public static Tensor CreateFloat16Scalar(Half value, bool requires_grad, Device? device = null)
	{
		return CreateFloat16Scalar((float)value, requires_grad, device);
	}

	public static Tensor CreateComplexFloat32Scalar(Complex32 value, bool requires_grad, Device? device = null)
	{
		return CreateComplexFloat32Scalar(value.Real, value.Imaginary, requires_grad, device);
	}

	public static Tensor CreateComplexFloat64Scalar(Complex value, bool requires_grad, Device? device = null)
	{
		return CreateComplexFloat64Scalar(value.Real, value.Imaginary, requires_grad, device);
	}

	public static Tensor CreateScalar(Scalar scalar, bool requires_grad, Device? device = null) => scalar.Type switch
	{
		ScalarType.Byte => CreateByteScalar(scalar.ToUInt8(), requires_grad, device),
		ScalarType.Int8 => CreateInt8Scalar(scalar.ToInt8(), requires_grad, device),
		ScalarType.Int16 => CreateInt16Scalar(scalar.ToInt16(), requires_grad, device),
		ScalarType.Int32 => CreateInt32Scalar(scalar.ToInt32(), requires_grad, device),
		ScalarType.Int64 => CreateInt64Scalar(scalar.ToInt64(), requires_grad, device),
		ScalarType.Bool => CreateBoolScalar(scalar.ToBoolean(), requires_grad, device),
		ScalarType.BFloat16 => CreateBFloat16Scalar(scalar.ToBFloat16(), requires_grad, device),
		ScalarType.Float16 => CreateFloat16Scalar(scalar.ToHalf(), requires_grad, device),
		ScalarType.Float32 => CreateFloat32Scalar(scalar.ToSingle(), requires_grad, device),
		ScalarType.Float64 => CreateFloat64Scalar(scalar.ToDouble(), requires_grad, device),
		ScalarType.ComplexFloat32 => CreateComplexFloat32Scalar(scalar.ToComplex32(), requires_grad, device),
		ScalarType.ComplexFloat64 => CreateComplexFloat64Scalar(scalar.ToComplex64(), requires_grad, device),
		_ => throw new NotSupportedException($"Scalar type '{scalar.Type}' is not supported."),
	};

	public unsafe Tensor(ReadOnlySpan<byte> data, ReadOnlySpan<long> sizes = default, bool requires_grad = false, ScalarType? dtype = null, Device? device = null)
	{
		handle = Create(data, sizes, requires_grad, dtype, device);
	}

	public unsafe Tensor(ReadOnlySpan<sbyte> data, ReadOnlySpan<long> sizes = default, bool requires_grad = false, ScalarType? dtype = null, Device? device = null)
	{
		handle = Create(data, sizes, requires_grad, dtype, device);
	}

	public unsafe Tensor(ReadOnlySpan<short> data, ReadOnlySpan<long> sizes = default, bool requires_grad = false, ScalarType? dtype = null, Device? device = null)
	{
		handle = Create(data, sizes, requires_grad, dtype, device);
	}

	public unsafe Tensor(ReadOnlySpan<int> data, ReadOnlySpan<long> sizes = default, bool requires_grad = false, ScalarType? dtype = null, Device? device = null)
	{
		handle = Create(data, sizes, requires_grad, dtype, device);
	}

	public unsafe Tensor(ReadOnlySpan<long> data, ReadOnlySpan<long> sizes = default, bool requires_grad = false, ScalarType? dtype = null, Device? device = null)
	{
		handle = Create(data, sizes, requires_grad, dtype, device);
	}

	public unsafe Tensor(ReadOnlySpan<bool> data, ReadOnlySpan<long> sizes = default, bool requires_grad = false, ScalarType? dtype = null, Device? device = null)
	{
		handle = Create(data, sizes, requires_grad, dtype, device);
	}

	public unsafe Tensor(ReadOnlySpan<BFloat16> data, ReadOnlySpan<long> sizes = default, bool requires_grad = false, ScalarType? dtype = null, Device? device = null)
	{
		handle = Create(data, sizes, requires_grad, dtype, device);
	}

	public unsafe Tensor(ReadOnlySpan<Half> data, ReadOnlySpan<long> sizes = default, bool requires_grad = false, ScalarType? dtype = null, Device? device = null)
	{
		handle = Create(data, sizes, requires_grad, dtype, device);
	}

	public unsafe Tensor(ReadOnlySpan<float> data, ReadOnlySpan<long> sizes = default, bool requires_grad = false, ScalarType? dtype = null, Device? device = null)
	{
		handle = Create(data, sizes, requires_grad, dtype, device);
	}

	public unsafe Tensor(ReadOnlySpan<double> data, ReadOnlySpan<long> sizes = default, bool requires_grad = false, ScalarType? dtype = null, Device? device = null)
	{
		handle = Create(data, sizes, requires_grad, dtype, device);
	}

	public unsafe Tensor(ReadOnlySpan<Complex32> data, ReadOnlySpan<long> sizes = default, bool requires_grad = false, ScalarType? dtype = null, Device? device = null)
	{
		handle = Create(data, sizes, requires_grad, dtype, device);
	}

	public unsafe Tensor(ReadOnlySpan<Complex> data, ReadOnlySpan<long> sizes = default, bool requires_grad = false, ScalarType? dtype = null, Device? device = null)
	{
		handle = Create(data, sizes, requires_grad, dtype, device);
	}

	public unsafe Tensor(byte value, bool requires_grad = false, Device? device = null)
	{
		handle = CreateByteScalar(value, requires_grad, device);
	}

	public unsafe Tensor(sbyte value, bool requires_grad = false, Device? device = null)
	{
		handle = CreateInt8Scalar(value, requires_grad, device);
	}

	public unsafe Tensor(short value, bool requires_grad = false, Device? device = null)
	{
		handle = CreateInt16Scalar(value, requires_grad, device);
	}

	public unsafe Tensor(int value, bool requires_grad = false, Device? device = null)
	{
		handle = CreateInt32Scalar(value, requires_grad, device);
	}

	public unsafe Tensor(long value, bool requires_grad = false, Device? device = null)
	{
		handle = CreateInt64Scalar(value, requires_grad, device);
	}

	public unsafe Tensor(bool value, bool requires_grad = false, Device? device = null)
	{
		handle = CreateBoolScalar(value, requires_grad, device);
	}

	public unsafe Tensor(BFloat16 value, bool requires_grad = false, Device? device = null)
	{
		handle = CreateBFloat16Scalar(value, requires_grad, device);
	}

	public unsafe Tensor(Half value, bool requires_grad = false, Device? device = null)
	{
		handle = CreateFloat16Scalar(value, requires_grad, device);
	}

	public unsafe Tensor(float value, bool requires_grad = false, Device? device = null)
	{
		handle = CreateFloat32Scalar(value, requires_grad, device);
	}

	public unsafe Tensor(double value, bool requires_grad = false, Device? device = null)
	{
		handle = CreateFloat64Scalar(value, requires_grad, device);
	}

	public unsafe Tensor(Complex32 value, bool requires_grad = false, Device? device = null)
	{
		handle = CreateComplexFloat32Scalar(value.Real, value.Imaginary, requires_grad, device);
	}

	public unsafe Tensor(Complex value, bool requires_grad = false, Device? device = null)
	{
		handle = CreateComplexFloat64Scalar(value.Real, value.Imaginary, requires_grad, device);
	}

	public unsafe Tensor(Scalar scalar, bool requires_grad = false, Device? device = null)
	{
		handle = CreateScalar(scalar, requires_grad, device);
	}
}
