using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace AssetRipper.Bindings.LibTorchSharp;

public readonly partial struct Tensor
{
	public static unsafe Tensor @new(ReadOnlySpan<byte> data, ReadOnlySpan<long> sizes, ScalarType scalar_type, ScalarType dtype, DeviceType device_type, int device_index, bool requires_grad)
	{
		// Allocate native memory and copy data
		void* pdata = NativeMemory.Alloc((nuint)data.Length);
		data.CopyTo(new Span<byte>(pdata, data.Length));

		fixed (long* psizes = sizes)
		{
			return @new(pdata, &FreeNativeMemory, psizes, sizes.Length, (sbyte)scalar_type, (sbyte)dtype, (int)device_type, device_index, requires_grad);
		}

		[UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
		static void FreeNativeMemory(void* ptr) => NativeMemory.Free(ptr);
	}

	private static Tensor @new<T>(ReadOnlySpan<T> data, ReadOnlySpan<long> sizes, bool requires_grad, ScalarType? dtype, Device? device) where T : unmanaged
	{
		ScalarType scalarType = ScalarType.Get<T>();
		(DeviceType deviceType, int deviceIndex) = device ?? Device.Default;
		return @new(MemoryMarshal.AsBytes(data), sizes.Length == 0 ? [data.Length] : sizes, scalarType, dtype ?? scalarType, deviceType, deviceIndex, requires_grad);
	}

	public static Tensor newByteScalar(byte value, int device_type, int device_index, bool requires_grad)
	{
		return newByteScalar(unchecked((sbyte)value), device_type, device_index, requires_grad);
	}

	public static Tensor newBFloat16Scalar(BFloat16 value, int device_type, int device_index, bool requires_grad)
	{
		return newBFloat16Scalar((float)value, device_type, device_index, requires_grad);
	}

	public static Tensor newFloat16Scalar(Half value, int device_type, int device_index, bool requires_grad)
	{
		return newFloat16Scalar((float)value, device_type, device_index, requires_grad);
	}

	public static Tensor newComplexFloat32Scalar(Complex32 value, int device_type, int device_index, bool requires_grad)
	{
		return newComplexFloat32Scalar(value.Real, value.Imaginary, device_type, device_index, requires_grad);
	}

	public static Tensor newComplexFloat64Scalar(Complex value, int device_type, int device_index, bool requires_grad)
	{
		return newComplexFloat64Scalar(value.Real, value.Imaginary, device_type, device_index, requires_grad);
	}

	public static Tensor newScalar(Scalar scalar, int device_type, int device_index, bool requires_grad) => (ScalarType)scalar.Type switch
	{
		ScalarType.Byte => newByteScalar(scalar.ToUInt8(), device_type, device_index, requires_grad),
		ScalarType.Int8 => newInt8Scalar(scalar.ToInt8(), device_type, device_index, requires_grad),
		ScalarType.Int16 => newInt16Scalar(scalar.ToInt16(), device_type, device_index, requires_grad),
		ScalarType.Int32 => newInt32Scalar(scalar.ToInt32(), device_type, device_index, requires_grad),
		ScalarType.Int64 => newInt64Scalar(scalar.ToInt64(), device_type, device_index, requires_grad),
		ScalarType.Bool => newBoolScalar(scalar.ToBoolean(), device_type, device_index, requires_grad),
		ScalarType.BFloat16 => newBFloat16Scalar(scalar.ToBFloat16(), device_type, device_index, requires_grad),
		ScalarType.Float16 => newFloat16Scalar(scalar.ToHalf(), device_type, device_index, requires_grad),
		ScalarType.Float32 => newFloat32Scalar(scalar.ToSingle(), device_type, device_index, requires_grad),
		ScalarType.Float64 => newFloat64Scalar(scalar.ToDouble(), device_type, device_index, requires_grad),
		ScalarType.ComplexFloat32 => newComplexFloat32Scalar(scalar.ToComplex32(), device_type, device_index, requires_grad),
		ScalarType.ComplexFloat64 => newComplexFloat64Scalar(scalar.ToComplex64(), device_type, device_index, requires_grad),
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
		(DeviceType deviceType, int deviceIndex) = device ?? Device.Default;
		handle = newByteScalar(value, (int)deviceType, deviceIndex, requires_grad);
	}

	public unsafe Tensor(sbyte value, bool requires_grad = false, Device? device = null)
	{
		(DeviceType deviceType, int deviceIndex) = device ?? Device.Default;
		handle = newInt8Scalar(value, (int)deviceType, deviceIndex, requires_grad);
	}

	public unsafe Tensor(short value, bool requires_grad = false, Device? device = null)
	{
		(DeviceType deviceType, int deviceIndex) = device ?? Device.Default;
		handle = newInt16Scalar(value, (int)deviceType, deviceIndex, requires_grad);
	}

	public unsafe Tensor(int value, bool requires_grad = false, Device? device = null)
	{
		(DeviceType deviceType, int deviceIndex) = device ?? Device.Default;
		handle = newInt32Scalar(value, (int)deviceType, deviceIndex, requires_grad);
	}

	public unsafe Tensor(long value, bool requires_grad = false, Device? device = null)
	{
		(DeviceType deviceType, int deviceIndex) = device ?? Device.Default;
		handle = newInt64Scalar(value, (int)deviceType, deviceIndex, requires_grad);
	}

	public unsafe Tensor(bool value, bool requires_grad = false, Device? device = null)
	{
		(DeviceType deviceType, int deviceIndex) = device ?? Device.Default;
		handle = newBoolScalar(value, (int)deviceType, deviceIndex, requires_grad);
	}

	public unsafe Tensor(BFloat16 value, bool requires_grad = false, Device? device = null)
	{
		(DeviceType deviceType, int deviceIndex) = device ?? Device.Default;
		handle = newBFloat16Scalar(value, (int)deviceType, deviceIndex, requires_grad);
	}

	public unsafe Tensor(Half value, bool requires_grad = false, Device? device = null)
	{
		(DeviceType deviceType, int deviceIndex) = device ?? Device.Default;
		handle = newFloat16Scalar(value, (int)deviceType, deviceIndex, requires_grad);
	}

	public unsafe Tensor(float value, bool requires_grad = false, Device? device = null)
	{
		(DeviceType deviceType, int deviceIndex) = device ?? Device.Default;
		handle = newFloat32Scalar(value, (int)deviceType, deviceIndex, requires_grad);
	}

	public unsafe Tensor(double value, bool requires_grad = false, Device? device = null)
	{
		(DeviceType deviceType, int deviceIndex) = device ?? Device.Default;
		handle = newFloat64Scalar(value, (int)deviceType, deviceIndex, requires_grad);
	}

	public unsafe Tensor(Complex32 value, bool requires_grad = false, Device? device = null)
	{
		(DeviceType deviceType, int deviceIndex) = device ?? Device.Default;
		handle = newComplexFloat32Scalar(value.Real, value.Imaginary, (int)deviceType, deviceIndex, requires_grad);
	}

	public unsafe Tensor(Complex value, bool requires_grad = false, Device? device = null)
	{
		(DeviceType deviceType, int deviceIndex) = device ?? Device.Default;
		handle = newComplexFloat64Scalar(value.Real, value.Imaginary, (int)deviceType, deviceIndex, requires_grad);
	}

	public unsafe Tensor(Scalar scalar, bool requires_grad = false, Device? device = null)
	{
		(DeviceType deviceType, int deviceIndex) = device ?? Device.Default;
		handle = newScalar(scalar, (int)deviceType, deviceIndex, requires_grad);
	}
}
