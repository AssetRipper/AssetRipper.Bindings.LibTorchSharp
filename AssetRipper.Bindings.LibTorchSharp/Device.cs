namespace AssetRipper.Bindings.LibTorchSharp;

public record struct Device(DeviceType Type, int Index = -1)
{
	public static Device CPU => new(DeviceType.CPU);
	public static Device Cuda => new(DeviceType.CUDA);
	public static Device Default { get; set; } = CPU;
}