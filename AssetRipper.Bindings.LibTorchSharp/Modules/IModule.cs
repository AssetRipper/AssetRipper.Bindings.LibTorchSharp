namespace AssetRipper.Bindings.LibTorchSharp.Modules;

public interface IModule : IDisposable
{
	bool IsTraining { set; }
	void CopyFrom(StateDictionary dictionary);
	void CopyTo(StateDictionary dictionary);
}
