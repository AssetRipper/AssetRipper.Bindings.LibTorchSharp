using System.Runtime.InteropServices;

namespace AssetRipper.Bindings.LibTorchSharp.LowLevel;

public static unsafe partial class NativeMethods
{
	private static void CheckForErrors()
	{
		sbyte* error = PInvoke.Torch_get_and_reset_last_err();

		if (error != null)
		{
			throw new ExternalException(Marshal.PtrToStringAnsi((nint)error));
		}
	}
}
