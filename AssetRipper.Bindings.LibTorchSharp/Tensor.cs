using AssetRipper.Bindings.LibTorchSharp.Attributes;
using AssetRipper.Bindings.LibTorchSharp.LowLevel;

namespace AssetRipper.Bindings.LibTorchSharp;

[OpaqueStruct(nameof(OpaqueTensor))]
public readonly partial struct Tensor
{
	public Device GetDevice()
	{
		return new Device(DeviceType(), DeviceIndex());
	}
}
