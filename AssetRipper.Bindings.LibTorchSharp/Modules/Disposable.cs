namespace AssetRipper.Bindings.LibTorchSharp.Modules;

public static class Disposable
{
	public static void DisposeAndSetDefault<T>(this ref T disposable) where T : struct, IDisposable
	{
		disposable.Dispose();
		disposable = default;
	}

	public static void DisposeAll<T>(this Span<T> span) where T : struct, IDisposable
	{
		foreach (ref T item in span)
		{
			item.Dispose();
		}
	}

	public static void DisposeAllAndClear<T>(this Span<T> span) where T : struct, IDisposable
	{
		span.DisposeAll();
		span.Clear();
	}
}
