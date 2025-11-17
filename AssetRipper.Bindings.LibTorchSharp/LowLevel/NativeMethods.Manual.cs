namespace AssetRipper.Bindings.LibTorchSharp.LowLevel;

public static unsafe partial class NativeMethods
{
	// Fixes an issue with the Tensor::requires_grad setter having a different type from the getter.
	internal static void Tensor_set_requires_grad(OpaqueTensor* tensor, int value)
	{
		Tensor_set_requires_grad(tensor, value != 0);
	}
}
