namespace AssetRipper.Bindings.LibTorchSharp.Modules;

public interface IModule : IDisposable
{
	bool IsTraining { set; }
	void CopyFromRoot(StateDictionary dictionary);
	void CopyToRoot(StateDictionary dictionary);
	IEnumerable<Tensor> GetParameters();
}
