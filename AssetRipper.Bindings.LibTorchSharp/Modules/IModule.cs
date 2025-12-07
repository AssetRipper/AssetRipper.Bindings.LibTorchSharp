namespace AssetRipper.Bindings.LibTorchSharp.Modules;

public interface IModule : IDisposable
{
	void CopyFrom(StateDictionary dictionary);
	void CopyTo(StateDictionary dictionary);
}
