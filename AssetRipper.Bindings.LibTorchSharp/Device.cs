namespace AssetRipper.Bindings.LibTorchSharp;

public record struct Device(DeviceType Type, int Index = -1)
{
	static Device()
	{
		InitializeDeviceType(DeviceType.CPU);
	}

	public static Device CPU => new(DeviceType.CPU);
	public static Device Cuda => new(DeviceType.CUDA);
	public static Device Default
	{
		get;
		set
		{
			if (field != value)
			{
				InitializeDeviceType(value.Type);
				field = value;
			}
		}
	} = CPU;

	public readonly void Initialize()
	{
		InitializeDeviceType(Type);
	}

	private static void InitializeDeviceType(DeviceType deviceType)
	{
		TorchSharp.torch.InitializeDeviceType((TorchSharp.DeviceType)deviceType);
	}
}
