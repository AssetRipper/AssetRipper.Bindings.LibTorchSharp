namespace AssetRipper.Bindings.LibTorchSharp.Modules;

public static class Disposable
{
	public static void DisposeAndSetDefault<T>(this ref T disposable) where T : struct, IDisposable
	{
		disposable.Dispose();
		disposable = default;
	}
}
