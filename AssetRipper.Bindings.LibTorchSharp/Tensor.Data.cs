using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace AssetRipper.Bindings.LibTorchSharp;

public readonly partial struct Tensor
{
	public unsafe T ToValue<T>() where T : unmanaged
	{
		ValidateType<T>();
		T* ptr = (T*)Data();
		return *ptr;
	}

	public T[] ToArray<T>() where T : unmanaged
	{
		if (DeviceType() != LibTorchSharp.DeviceType.CPU)
		{
			using Tensor cpuTensor = Cpu();
			return cpuTensor.ToArray<T>();
		}
		ValidateType<T>();
		ValidateDimension(1);
		return ToArray1D_Internal<T>();
	}

	private unsafe T[] ToArray1D_Internal<T>() where T : unmanaged
	{
		long length = Size(0);
		long stride = this.Stride(0);

		T[] result = new T[length];
		T* ptr = (T*)Data();
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

	public T[,] ToArray2D<T>() where T : unmanaged
	{
		if (DeviceType() != LibTorchSharp.DeviceType.CPU)
		{
			using Tensor cpuTensor = Cpu();
			return cpuTensor.ToArray2D<T>();
		}
		ValidateType<T>();
		ValidateDimension(2);
		return ToArray2D_Internal<T>();
	}

	private unsafe T[,] ToArray2D_Internal<T>() where T : unmanaged
	{
		long length0 = Size(0);
		long length1 = Size(1);
		long stride0 = Stride(0);
		long stride1 = Stride(1);

		T[,] result = new T[length0, length1];
		T* ptr = (T*)Data();
		for (long i0 = 0, off0 = 0; i0 < length0; i0++, off0 += stride0)
		{
			for (long i1 = 0, off1 = 0; i1 < length1; i1++, off1 += stride1)
			{
				result[i0, i1] = ptr[off0 + off1];
			}
		}
		return result;
	}

	public T[,,] ToArray3D<T>() where T : unmanaged
	{
		if (DeviceType() != LibTorchSharp.DeviceType.CPU)
		{
			using Tensor cpuTensor = Cpu();
			return cpuTensor.ToArray3D<T>();
		}
		ValidateType<T>();
		ValidateDimension(3);
		return ToArray3D_Internal<T>();
	}

	private unsafe T[,,] ToArray3D_Internal<T>() where T : unmanaged
	{
		long length0 = Size(0);
		long length1 = Size(1);
		long length2 = Size(2);
		long stride0 = Stride(0);
		long stride1 = Stride(1);
		long stride2 = Stride(2);
		T[,,] result = new T[length0, length1, length2];
		T* ptr = (T*)Data();
		for (long i0 = 0, off0 = 0; i0 < length0; i0++, off0 += stride0)
		{
			for (long i1 = 0, off1 = 0; i1 < length1; i1++, off1 += stride1)
			{
				for (long i2 = 0, off2 = 0; i2 < length2; i2++, off2 += stride2)
				{
					result[i0, i1, i2] = ptr[off0 + off1 + off2];
				}
			}
		}
		return result;
	}

	public T[,,,] ToArray4D<T>() where T : unmanaged
	{
		if (DeviceType() != LibTorchSharp.DeviceType.CPU)
		{
			using Tensor cpuTensor = Cpu();
			return cpuTensor.ToArray4D<T>();
		}
		ValidateType<T>();
		ValidateDimension(4);
		return ToArray4D_Internal<T>();
	}

	private unsafe T[,,,] ToArray4D_Internal<T>() where T : unmanaged
	{
		long length0 = Size(0);
		long length1 = Size(1);
		long length2 = Size(2);
		long length3 = Size(3);
		long stride0 = Stride(0);
		long stride1 = Stride(1);
		long stride2 = Stride(2);
		long stride3 = Stride(3);
		T[,,,] result = new T[length0, length1, length2, length3];
		T* ptr = (T*)Data();
		for (long i0 = 0, off0 = 0; i0 < length0; i0++, off0 += stride0)
		{
			for (long i1 = 0, off1 = 0; i1 < length1; i1++, off1 += stride1)
			{
				for (long i2 = 0, off2 = 0; i2 < length2; i2++, off2 += stride2)
				{
					for (long i3 = 0, off3 = 0; i3 < length3; i3++, off3 += stride3)
					{
						result[i0, i1, i2, i3] = ptr[off0 + off1 + off2 + off3];
					}
				}
			}
		}
		return result;
	}

	public T[,,,,] ToArray5D<T>() where T : unmanaged
	{
		if (DeviceType() != LibTorchSharp.DeviceType.CPU)
		{
			using Tensor cpuTensor = Cpu();
			return cpuTensor.ToArray5D<T>();
		}
		ValidateType<T>();
		ValidateDimension(5);
		return ToArray5D_Internal<T>();
	}

	private unsafe T[,,,,] ToArray5D_Internal<T>() where T : unmanaged
	{
		long length0 = Size(0);
		long length1 = Size(1);
		long length2 = Size(2);
		long length3 = Size(3);
		long length4 = Size(4);
		long stride0 = Stride(0);
		long stride1 = Stride(1);
		long stride2 = Stride(2);
		long stride3 = Stride(3);
		long stride4 = Stride(4);
		T[,,,,] result = new T[length0, length1, length2, length3, length4];
		T* ptr = (T*)Data();
		for (long i0 = 0, off0 = 0; i0 < length0; i0++, off0 += stride0)
		{
			for (long i1 = 0, off1 = 0; i1 < length1; i1++, off1 += stride1)
			{
				for (long i2 = 0, off2 = 0; i2 < length2; i2++, off2 += stride2)
				{
					for (long i3 = 0, off3 = 0; i3 < length3; i3++, off3 += stride3)
					{
						for (long i4 = 0, off4 = 0; i4 < length4; i4++, off4 += stride4)
						{
							result[i0, i1, i2, i3, i4] = ptr[off0 + off1 + off2 + off3 + off4];
						}
					}
				}
			}
		}
		return result;
	}

	public T[,,,,,] ToArray6D<T>() where T : unmanaged
	{
		if (DeviceType() != LibTorchSharp.DeviceType.CPU)
		{
			using Tensor cpuTensor = Cpu();
			return cpuTensor.ToArray6D<T>();
		}
		ValidateType<T>();
		ValidateDimension(6);
		return ToArray6D_Internal<T>();
	}

	private unsafe T[,,,,,] ToArray6D_Internal<T>() where T : unmanaged
	{
		long length0 = Size(0);
		long length1 = Size(1);
		long length2 = Size(2);
		long length3 = Size(3);
		long length4 = Size(4);
		long length5 = Size(5);
		long stride0 = Stride(0);
		long stride1 = Stride(1);
		long stride2 = Stride(2);
		long stride3 = Stride(3);
		long stride4 = Stride(4);
		long stride5 = Stride(5);
		T[,,,,,] result = new T[length0, length1, length2, length3, length4, length5];
		T* ptr = (T*)Data();
		for (long i0 = 0, off0 = 0; i0 < length0; i0++, off0 += stride0)
		{
			for (long i1 = 0, off1 = 0; i1 < length1; i1++, off1 += stride1)
			{
				for (long i2 = 0, off2 = 0; i2 < length2; i2++, off2 += stride2)
				{
					for (long i3 = 0, off3 = 0; i3 < length3; i3++, off3 += stride3)
					{
						for (long i4 = 0, off4 = 0; i4 < length4; i4++, off4 += stride4)
						{
							for (long i5 = 0, off5 = 0; i5 < length5; i5++, off5 += stride5)
							{
								result[i0, i1, i2, i3, i4, i5] = ptr[off0 + off1 + off2 + off3 + off4 + off5];
							}
						}
					}
				}
			}
		}
		return result;
	}

	public Array ToArrayND<T>() where T : unmanaged
	{
		if (DeviceType() != LibTorchSharp.DeviceType.CPU)
		{
			using Tensor cpuTensor = Cpu();
			return cpuTensor.ToArrayND<T>();
		}
		ValidateType<T>();
		return Ndimension() switch
		{
			0 => (T[])[ToValue<T>()],
			1 => ToArray1D_Internal<T>(),
			2 => ToArray2D_Internal<T>(),
			3 => ToArray3D_Internal<T>(),
			4 => ToArray4D_Internal<T>(),
			5 => ToArray5D_Internal<T>(),
			6 => ToArray6D_Internal<T>(),
			_ => ToArrayND_Internal<T>(),
		};
	}

	[UnconditionalSuppressMessage("AotAnalysis", "IL3050:RequiresDynamicCode", Justification = "MDArrays of Rank != 1 can be created because they don't implement generic interfaces.")]
	private unsafe Array ToArrayND_Internal<T>() where T : unmanaged
	{
		// Iterate over every index tuple in the N-dimensional space:
		// - Use an odometer-style index array `indices` initialized to zeros.
		// - For each position, compute the flat offset into `ptr` as:
		//   offset = sum(indices[i] * strides[i]) for i in [0..rank-1]
		// - Read the value from `ptr[offset]` and store it into `result` at `indices`.
		// - Increment `indices` like an odometer; when the most significant digit rolls over,
		//   the iteration is complete.

		// Note: Boxing of T will occur when setting values into the Array.

		long[] lengths = Sizes();
		long[] strides = this.Strides();
		Debug.Assert(lengths.Length == strides.Length);
		Array result = Array.CreateInstance(typeof(T), lengths);

		T* ptr = (T*)Data();

		int rank = lengths.Length;
		Debug.Assert(rank >= 1);

		long[] indices = new long[rank];
		while (true)
		{
			long offset = 0;
			for (int d = 0; d < rank; d++)
			{
				offset += indices[d] * strides[d];
			}

			T value = ptr[offset];
			result.SetValue(value, indices);

			// Increment indices odometer-style
			for (int dim = rank - 1; dim >= 0; dim--)
			{
				indices[dim]++;
				if (indices[dim] < lengths[dim])
				{
					break;
				}
				indices[dim] = 0;
				if (dim == 0)
				{
					// Completed all iterations
					return result;
				}
			}
		}
	}

	public unsafe void WriteValues(Stream stream)
	{
		if (DeviceType() != LibTorchSharp.DeviceType.CPU)
		{
			using Tensor cpuTensor = Cpu();
			cpuTensor.WriteValues(stream);
			return;
		}

		int typeSize = (int)ElementSize();
		long totalBytes = Numel() * typeSize;

		byte* ptr = (byte*)Data();

		if (IsContiguous())
		{
			// Contiguous tensor - can write in one go
			long bytesWritten = 0;
			while (bytesWritten < totalBytes)
			{
				long chunkSize = long.Min(totalBytes - bytesWritten, int.MaxValue);
				stream.Write(new ReadOnlySpan<byte>(ptr + bytesWritten, (int)chunkSize));
				bytesWritten += chunkSize;
			}
			return;
		}

		long[] lengths = Sizes();
		long[] strides = this.Strides();
		Debug.Assert(lengths.Length == strides.Length);

		int rank = lengths.Length;

		long[] indices = new long[rank];
		while (true)
		{
			long offset = 0;
			for (int d = 0; d < rank; d++)
			{
				offset += indices[d] * strides[d];
			}

			stream.Write(new ReadOnlySpan<byte>(ptr + offset * typeSize, typeSize));

			// Increment indices odometer-style
			for (int dim = rank - 1; dim >= 0; dim--)
			{
				indices[dim]++;
				if (indices[dim] < lengths[dim])
				{
					break;
				}
				indices[dim] = 0;
				if (dim == 0)
				{
					// Completed all iterations
					return;
				}
			}
		}
	}

	private void ValidateType<T>()
	{
		if (Type != ScalarType.Get<T>())
		{
			throw new ArgumentException($"{typeof(T).Name} is not compatible with {Type}");
		}
	}

	private void ValidateDimension(int expectedDimension)
	{
		if (Ndimension() != expectedDimension)
		{
			throw new InvalidOperationException($"{Ndimension()}-dimensional tensors cannot be converted to {expectedDimension}-dimensional arrays.");
		}
	}
}
