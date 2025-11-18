using AssetRipper.Bindings.LibTorchSharp.LowLevel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace AssetRipper.Bindings.LibTorchSharp;

internal static unsafe class ScratchAllocator
{
	[field: ThreadStatic]
	public static void* MostRecentAllocatedPointer { get; private set; }

	[field: ThreadStatic]
	public static nuint MostRecentAllocatedCount { get; private set; }

	private static void ThrowIfOpenAllocationExists()
	{
		if (MostRecentAllocatedPointer != null)
		{
			throw new InvalidOperationException("There is an open native memory allocation that has not been freed. Free the previous allocation before allocating new memory.");
		}
	}

	[UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
	public static long* AllocateInt64(nuint count)
	{
		return Allocate<long>(count);
	}

	[UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
	public static float* AllocateSingle(nuint count)
	{
		return Allocate<float>(count);
	}

	[UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
	public static double* AllocateDouble(nuint count)
	{
		return Allocate<double>(count);
	}

	[UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
	public static OpaqueTensor** AllocateTensor(nuint count)
	{
		return (OpaqueTensor**)Allocate<Tensor>(count);
	}

	[UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
	public static sbyte** AllocateInt8Pointer(nuint count)
	{
		return (sbyte**)Allocate<nint>(count);
	}

	public static T* Allocate<T>(nuint count) where T : unmanaged
	{
		ThrowIfOpenAllocationExists();
		void* ptr = NativeMemory.Alloc(count, (nuint)sizeof(T));
		MostRecentAllocatedPointer = ptr;
		MostRecentAllocatedCount = count;
		return (T*)ptr;
	}

	public static Span<T> GetAllocatedSpan<T>() where T : unmanaged
	{
		return new Span<T>(MostRecentAllocatedPointer, (int)MostRecentAllocatedCount);
	}

	public static void Free()
	{
		if (MostRecentAllocatedPointer != null)
		{
			NativeMemory.Free(MostRecentAllocatedPointer);
			MostRecentAllocatedPointer = null;
			MostRecentAllocatedCount = 0;
		}
	}
}
