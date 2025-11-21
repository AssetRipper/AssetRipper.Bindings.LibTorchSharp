using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace AssetRipper.Bindings.LibTorchSharp;

public readonly partial struct CustomModule
{
	public unsafe CustomModule(NativeString name) : this(name, &TrivialForwardMethod)
	{
	}

	[UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
	private static Tensor TrivialForwardMethod(Tensor tensor)
	{
		return tensor;
	}
}
