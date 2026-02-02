using System.Runtime.InteropServices;

namespace AssetRipper.Bindings.LibTorchSharp.Modules;

public unsafe readonly struct AllocatedData<T> : IDisposable where T : unmanaged, IDisposable
{
	private readonly T* pointer;
	public bool IsNull => pointer == null;
	public AllocatedData()
	{
		pointer = (T*)NativeMemory.AllocZeroed((nuint)sizeof(T));
	}
	public ref T Value => ref *pointer;
	public void Dispose()
	{
		if (IsNull)
		{
			return;
		}
		try
		{
			Value.Dispose();
		}
		finally
		{
			NativeMemory.Free(pointer);
		}
	}
}
