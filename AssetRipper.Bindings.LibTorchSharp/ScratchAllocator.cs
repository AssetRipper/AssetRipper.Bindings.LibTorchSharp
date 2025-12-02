using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace AssetRipper.Bindings.LibTorchSharp;

internal static unsafe class ScratchAllocator
{
	private readonly record struct Data(nint Pointer, nuint Count, int SizeOf)
	{
		public void ThrowIfOpenAllocationExists()
		{
			if (Pointer != 0)
			{
				throw new InvalidOperationException("There is an open native memory allocation that has not been freed. Free the previous allocation before allocating new memory.");
			}
		}
	}

	[field: ThreadStatic]
	private static Data MostRecentAllocatedArray;

	[field: ThreadStatic]
	private static Data MostRecentAllocatedStrings;

	[UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
	public static long* AllocateInt64(nuint count)
	{
		return AllocateArray<long>(count);
	}

	[UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
	public static float* AllocateSingle(nuint count)
	{
		return AllocateArray<float>(count);
	}

	[UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
	public static double* AllocateDouble(nuint count)
	{
		return AllocateArray<double>(count);
	}

	[UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
	public static Tensor* AllocateTensor(nuint count)
	{
		return AllocateArray<Tensor>(count);
	}

	[UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
	public static JITModule* AllocateJITModule(nuint count)
	{
		return AllocateArray<JITModule>(count);
	}

	[UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
	public static NNModule* AllocateNNModule(nuint count)
	{
		return AllocateArray<NNModule>(count);
	}

	[UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
	public static sbyte** AllocateString(nuint count)
	{
		return (sbyte**)Allocate<nint>(count, ref MostRecentAllocatedStrings);
	}

	private static T* AllocateArray<T>(nuint count) where T : unmanaged
	{
		return Allocate<T>(count, ref MostRecentAllocatedArray);
	}

	private static T* Allocate<T>(nuint count, ref Data data) where T : unmanaged
	{
		data.ThrowIfOpenAllocationExists();
		void* ptr = NativeMemory.Alloc(count, (nuint)sizeof(T));
		data = new Data((nint)ptr, count, sizeof(T));
		return (T*)ptr;
	}

	public static Span<T> GetAllocatedSpan<T>() where T : unmanaged
	{
		return GetAllocatedSpan<T>(in MostRecentAllocatedArray);
	}

	private static Span<T> GetAllocatedSpan<T>(in Data data) where T : unmanaged
	{
		if (data.SizeOf != sizeof(T))
		{
			throw new InvalidOperationException("The requested type does not match the type of the most recent allocation.");
		}
		return new Span<T>(data.Pointer.ToPointer(), (int)data.Count);
	}

	public static T[] GetAllocatedArray<T>() where T : unmanaged
	{
		return GetAllocatedSpan<T>().ToArray();
	}

	public static string[] GetAllocatedStrings()
	{
		Span<nint> span = GetAllocatedSpan<nint>(in MostRecentAllocatedStrings);
		if (span.Length == 0)
		{
			return [];
		}
		string[] result = new string[span.Length];
		for (int i = 0; i < span.Length; i++)
		{
			result[i] = NativeString.FromNullTerminated((sbyte*)span[i]);
		}
		return result;
	}

	public static void Free()
	{
		if (MostRecentAllocatedArray.Pointer != 0)
		{
			NativeMemory.Free(MostRecentAllocatedArray.Pointer.ToPointer());
			MostRecentAllocatedArray = default;
		}
		if (MostRecentAllocatedStrings.Pointer != 0)
		{
			NativeMemory.Free(MostRecentAllocatedStrings.Pointer.ToPointer());
			MostRecentAllocatedStrings = default;
		}
	}
}
