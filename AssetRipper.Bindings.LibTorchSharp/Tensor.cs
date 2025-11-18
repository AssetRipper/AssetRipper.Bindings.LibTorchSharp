using AssetRipper.Bindings.LibTorchSharp.Attributes;
using AssetRipper.Bindings.LibTorchSharp.LowLevel;
using System.Numerics;

namespace AssetRipper.Bindings.LibTorchSharp;

[OpaqueStruct(nameof(OpaqueTensor))]
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

	public unsafe T[] ToArray<T>() where T : unmanaged
	{
		if (device_type() != (int)DeviceType.CPU)
		{
			using Tensor cpuTensor = cpu();
			return cpuTensor.ToArray<T>();
		}

		ValidateType<T>();

		if (ndimension() != 1)
		{
			throw new InvalidOperationException("Only 1-dimensional tensors can be converted to arrays.");
		}

		long length = sizes()[0];
		long stride = strides()[0];

		T[] result = new T[length];
		T* ptr = (T*)data();
		if (stride == 1)
		{
			fixed (T* pResult = result)
			{
				long byteLength = length * sizeof(T);
				Buffer.MemoryCopy(ptr, pResult, byteLength, byteLength);
			}
		}
		else
		{
			for (long i0 = 0, off0 = 0; i0 < length; i0++, off0 += stride)
			{
				result[i0] = ptr[off0];
			}
		}
		return result;
	}

	public unsafe long[] sizes()
	{
		try
		{
			sizes(&ScratchAllocator.AllocateInt64);
			return ScratchAllocator.GetAllocatedSpan<long>().ToArray();
		}
		finally
		{
			ScratchAllocator.Free();
		}
	}

	public unsafe long[] strides()
	{
		try
		{
			strides(&ScratchAllocator.AllocateInt64);
			return ScratchAllocator.GetAllocatedSpan<long>().ToArray();
		}
		finally
		{
			ScratchAllocator.Free();
		}
	}

	public static unsafe Tensor ones(ReadOnlySpan<long> sizes, ScalarType scalar_type, DeviceType device_type, int device_index, bool requires_grad)
	{
		fixed (long* psizes = sizes)
		{
			return ones(psizes, sizes.Length, (sbyte)scalar_type, (int)device_type, device_index, requires_grad);
		}
	}

	public Tensor ones_like(bool requires_grad)
	{
		return ones_like(type(), device_type(), device_index(), requires_grad);
	}

	public Device GetDevice()
	{
		return new Device((DeviceType)device_type(), device_index());
	}

	private static ScalarType GetScalarType<T>()
	{
		if (typeof(T) == typeof(byte))
			return ScalarType.Byte;
		if (typeof(T) == typeof(sbyte))
			return ScalarType.Int8;
		if (typeof(T) == typeof(short))
			return ScalarType.Int16;
		if (typeof(T) == typeof(int))
			return ScalarType.Int32;
		if (typeof(T) == typeof(long))
			return ScalarType.Int64;
		if (typeof(T) == typeof(bool))
			return ScalarType.Bool;
		if (typeof(T) == typeof(BFloat16))
			return ScalarType.BFloat16;
		if (typeof(T) == typeof(Half))
			return ScalarType.Float16;
		if (typeof(T) == typeof(float))
			return ScalarType.Float32;
		if (typeof(T) == typeof(double))
			return ScalarType.Float64;
		if (typeof(T) == typeof(Complex32))
			return ScalarType.ComplexFloat32;
		if (typeof(T) == typeof(Complex))
			return ScalarType.ComplexFloat64;

		throw new NotSupportedException($"Type '{typeof(T).FullName}' is not supported as a tensor scalar type.");
	}

	private void ValidateType<T>()
	{
		ScalarType dtype = (ScalarType)type();
		if (dtype != GetScalarType<T>())
		{
			throw new ArgumentException($"{typeof(T).Name} is not compatible with {dtype}");
		}
	}
}
