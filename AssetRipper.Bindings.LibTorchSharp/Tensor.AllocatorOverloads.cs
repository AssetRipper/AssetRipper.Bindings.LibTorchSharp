namespace AssetRipper.Bindings.LibTorchSharp;

public readonly partial struct Tensor
{
	public unsafe static Tensor[] broadcast_tensors(ReadOnlySpan<Tensor> tensors)
	{
		try
		{
			fixed (Tensor* pTensors = tensors)
			{
				broadcast_tensors(pTensors, tensors.Length, &ScratchAllocator.AllocateTensor);
			}
			return ScratchAllocator.GetAllocatedArray<Tensor>();
		}
		finally
		{
			ScratchAllocator.Free();
		}
	}

	public unsafe Tensor[] chunk(long chunks, long dim)
	{
		try
		{
			chunk(&ScratchAllocator.AllocateTensor, chunks, dim);
			return ScratchAllocator.GetAllocatedArray<Tensor>();
		}
		finally
		{
			ScratchAllocator.Free();
		}
	}

	public unsafe Tensor[] cummax(long dim)
	{
		try
		{
			cummax(&ScratchAllocator.AllocateTensor, dim);
			return ScratchAllocator.GetAllocatedArray<Tensor>();
		}
		finally
		{
			ScratchAllocator.Free();
		}
	}

	public unsafe Tensor[] cummin(long dim)
	{
		try
		{
			cummin(&ScratchAllocator.AllocateTensor, dim);
			return ScratchAllocator.GetAllocatedArray<Tensor>();
		}
		finally
		{
			ScratchAllocator.Free();
		}
	}

	public unsafe Tensor[] dsplit_with_size(long split_size)
	{
		try
		{
			dsplit_with_size(&ScratchAllocator.AllocateTensor, split_size);
			return ScratchAllocator.GetAllocatedArray<Tensor>();
		}
		finally
		{
			ScratchAllocator.Free();
		}
	}

	public unsafe Tensor[] dsplit_with_sizes(ReadOnlySpan<long> sizes)
	{
		try
		{
			fixed (long* pSizes = sizes)
			{
				dsplit_with_sizes(&ScratchAllocator.AllocateTensor, pSizes, sizes.Length);
			}
			return ScratchAllocator.GetAllocatedArray<Tensor>();
		}
		finally
		{
			ScratchAllocator.Free();
		}
	}

	public unsafe Tensor[] hsplit_with_size(long split_size)
	{
		try
		{
			hsplit_with_size(&ScratchAllocator.AllocateTensor, split_size);
			return ScratchAllocator.GetAllocatedArray<Tensor>();
		}
		finally
		{
			ScratchAllocator.Free();
		}
	}

	public unsafe Tensor[] hsplit_with_sizes(ReadOnlySpan<long> sizes)
	{
		try
		{
			fixed (long* pSizes = sizes)
			{
				hsplit_with_sizes(&ScratchAllocator.AllocateTensor, pSizes, sizes.Length);
			}
			return ScratchAllocator.GetAllocatedArray<Tensor>();
		}
		finally
		{
			ScratchAllocator.Free();
		}
	}

	public unsafe Tensor[] max_along_dimension(long dim, bool keep_dim)
	{
		try
		{
			max_along_dimension(&ScratchAllocator.AllocateTensor, dim, keep_dim);
			return ScratchAllocator.GetAllocatedArray<Tensor>();
		}
		finally
		{
			ScratchAllocator.Free();
		}
	}

	public unsafe Tensor[] min_along_dimension(long dim, bool keep_dim)
	{
		try
		{
			min_along_dimension(&ScratchAllocator.AllocateTensor, dim, keep_dim);
			return ScratchAllocator.GetAllocatedArray<Tensor>();
		}
		finally
		{
			ScratchAllocator.Free();
		}
	}

	public unsafe Tensor[] max_pool1d_with_indices(ReadOnlySpan<long> kernelSize, ReadOnlySpan<long> stride, ReadOnlySpan<long> padding, ReadOnlySpan<long> dilation, bool ceil_mode)
	{
		try
		{
			fixed (long* pKernelSize = kernelSize)
			fixed (long* pStride = stride)
			fixed (long* pPadding = padding)
			fixed (long* pDilation = dilation)
			{
				max_pool1d_with_indices(&ScratchAllocator.AllocateTensor, pKernelSize, kernelSize.Length, pStride, stride.Length, pPadding, padding.Length, pDilation, dilation.Length, ceil_mode);
			}
			return ScratchAllocator.GetAllocatedArray<Tensor>();
		}
		finally
		{
			ScratchAllocator.Free();
		}
	}

	public unsafe Tensor[] max_pool2d_with_indices(ReadOnlySpan<long> kernelSize, ReadOnlySpan<long> stride, ReadOnlySpan<long> padding, ReadOnlySpan<long> dilation, bool ceil_mode)
	{
		try
		{
			fixed (long* pKernelSize = kernelSize)
			fixed (long* pStride = stride)
			fixed (long* pPadding = padding)
			fixed (long* pDilation = dilation)
			{
				max_pool2d_with_indices(&ScratchAllocator.AllocateTensor, pKernelSize, kernelSize.Length, pStride, stride.Length, pPadding, padding.Length, pDilation, dilation.Length, ceil_mode);
			}
			return ScratchAllocator.GetAllocatedArray<Tensor>();
		}
		finally
		{
			ScratchAllocator.Free();
		}
	}

	public unsafe Tensor[] max_pool3d_with_indices(ReadOnlySpan<long> kernelSize, ReadOnlySpan<long> stride, ReadOnlySpan<long> padding, ReadOnlySpan<long> dilation, bool ceil_mode)
	{
		try
		{
			fixed (long* pKernelSize = kernelSize)
			fixed (long* pStride = stride)
			fixed (long* pPadding = padding)
			fixed (long* pDilation = dilation)
			{
				max_pool3d_with_indices(&ScratchAllocator.AllocateTensor, pKernelSize, kernelSize.Length, pStride, stride.Length, pPadding, padding.Length, pDilation, dilation.Length, ceil_mode);
			}
			return ScratchAllocator.GetAllocatedArray<Tensor>();
		}
		finally
		{
			ScratchAllocator.Free();
		}
	}

	public unsafe static Tensor[] meshgrid(ReadOnlySpan<Tensor> tensors, ReadOnlySpan<byte> indexing)
	{
		try
		{
			fixed (Tensor* pTensors = tensors)
			fixed (byte* pIndexing = indexing)
			{
				meshgrid(pTensors, tensors.Length, (sbyte*)pIndexing, &ScratchAllocator.AllocateTensor);
			}
			return ScratchAllocator.GetAllocatedArray<Tensor>();
		}
		finally
		{
			ScratchAllocator.Free();
		}
	}

	public unsafe Tensor[] mode(long dim, bool keep_dim)
	{
		try
		{
			mode(&ScratchAllocator.AllocateTensor, dim, keep_dim);
			return ScratchAllocator.GetAllocatedArray<Tensor>();
		}
		finally
		{
			ScratchAllocator.Free();
		}
	}

	public unsafe string[] names()
	{
		try
		{
			names(&ScratchAllocator.AllocateInt8Pointer);
			return ScratchAllocator.GetAllocatedStrings();
		}
		finally
		{
			ScratchAllocator.Free();
		}
	}

	public unsafe long[] sizes()
	{
		try
		{
			sizes(&ScratchAllocator.AllocateInt64);
			return ScratchAllocator.GetAllocatedArray<long>();
		}
		finally
		{
			ScratchAllocator.Free();
		}
	}

	public unsafe Tensor[] split_with_size(long split_size, long dim)
	{
		try
		{
			split_with_size(&ScratchAllocator.AllocateTensor, split_size, dim);
			return ScratchAllocator.GetAllocatedArray<Tensor>();
		}
		finally
		{
			ScratchAllocator.Free();
		}
	}

	public unsafe Tensor[] split_with_sizes(ReadOnlySpan<long> sizes, long dim)
	{
		try
		{
			fixed (long* pSizes = sizes)
			{
				split_with_sizes(&ScratchAllocator.AllocateTensor, pSizes, sizes.Length, dim);
			}
			return ScratchAllocator.GetAllocatedArray<Tensor>();
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
			return ScratchAllocator.GetAllocatedArray<long>();
		}
		finally
		{
			ScratchAllocator.Free();
		}
	}

	public unsafe Tensor[] tensor_split_with_size(long split_size, long dim)
	{
		try
		{
			tensor_split_with_size(&ScratchAllocator.AllocateTensor, split_size, dim);
			return ScratchAllocator.GetAllocatedArray<Tensor>();
		}
		finally
		{
			ScratchAllocator.Free();
		}
	}

	public unsafe Tensor[] tensor_split_with_sizes(ReadOnlySpan<long> sizes, long dim)
	{
		try
		{
			fixed (long* pSizes = sizes)
			{
				tensor_split_with_sizes(&ScratchAllocator.AllocateTensor, pSizes, sizes.Length, dim);
			}
			return ScratchAllocator.GetAllocatedArray<Tensor>();
		}
		finally
		{
			ScratchAllocator.Free();
		}
	}

	public unsafe Tensor[] tensor_split_with_tensor_sizes(Tensor sizes, long dim)
	{
		try
		{
			tensor_split_with_tensor_sizes(&ScratchAllocator.AllocateTensor, sizes, dim);
			return ScratchAllocator.GetAllocatedArray<Tensor>();
		}
		finally
		{
			ScratchAllocator.Free();
		}
	}

	public unsafe Tensor[] topk(int k, long dim, bool largest, bool sorted)
	{
		try
		{
			topk(&ScratchAllocator.AllocateTensor, k, dim, largest, sorted);
			return ScratchAllocator.GetAllocatedArray<Tensor>();
		}
		finally
		{
			ScratchAllocator.Free();
		}
	}

	public unsafe Tensor[] unbind(long dim)
	{
		try
		{
			unbind(&ScratchAllocator.AllocateTensor, dim);
			return ScratchAllocator.GetAllocatedArray<Tensor>();
		}
		finally
		{
			ScratchAllocator.Free();
		}
	}

	public unsafe Tensor[] vsplit_with_size(long split_size)
	{
		try
		{
			vsplit_with_size(&ScratchAllocator.AllocateTensor, split_size);
			return ScratchAllocator.GetAllocatedArray<Tensor>();
		}
		finally
		{
			ScratchAllocator.Free();
		}
	}

	public unsafe Tensor[] vsplit_with_sizes(ReadOnlySpan<long> sizes)
	{
		try
		{
			fixed (long* pSizes = sizes)
			{
				vsplit_with_sizes(&ScratchAllocator.AllocateTensor, pSizes, sizes.Length);
			}
			return ScratchAllocator.GetAllocatedArray<Tensor>();
		}
		finally
		{
			ScratchAllocator.Free();
		}
	}

	public unsafe Tensor[] where_list()
	{
		try
		{
			where_list(&ScratchAllocator.AllocateTensor);
			return ScratchAllocator.GetAllocatedArray<Tensor>();
		}
		finally
		{
			ScratchAllocator.Free();
		}
	}
}
