using AssetRipper.Bindings.LibTorchSharp.Attributes;
using AssetRipper.Bindings.LibTorchSharp.LowLevel;

namespace AssetRipper.Bindings.LibTorchSharp;

[OpaqueStruct(nameof(OpaqueTensor))]
public readonly partial struct Tensor
{
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

	public unsafe T ToValue<T>() where T : unmanaged
	{
		ValidateType<T>();
		T* ptr = (T*)data();
		return *ptr;
	}

	public Device GetDevice()
	{
		return new Device(device_type(), device_index());
	}

	private void ValidateType<T>()
	{
		if (Type != ScalarType.Get<T>())
		{
			throw new ArgumentException($"{typeof(T).Name} is not compatible with {Type}");
		}
	}
}
