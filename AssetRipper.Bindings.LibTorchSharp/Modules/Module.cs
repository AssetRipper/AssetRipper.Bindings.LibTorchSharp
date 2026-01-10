using System.Runtime.CompilerServices;

namespace AssetRipper.Bindings.LibTorchSharp.Modules;

public static class Module
{
	extension<T>(ref T module) where T : struct, IModule
	{
		public void Load(string path, Device? device = null)
		{
			using StateDictionary dictionary = StateDictionary.Load(path, device);
			module.CopyFromRoot(dictionary);
		}

		public void Load(Stream stream, Device? device = null)
		{
			using StateDictionary dictionary = StateDictionary.Load(stream, device);
			module.CopyFromRoot(dictionary);
		}
	}

	extension<T>(T module) where T : struct, IModule
	{
		public void Save(string path, Device? device = null)
		{
			using StateDictionary dictionary = new(device);
			module.CopyToRoot(dictionary);
			dictionary.Save(path);
		}

		public void Save(Stream stream, Device? device = null)
		{
			using StateDictionary dictionary = new(device);
			module.CopyToRoot(dictionary);
			dictionary.Save(stream);
		}
	}

	extension<T>(T module) where T : struct, IModule
	{
		public void CopyTo(StateDictionary dictionary, [CallerArgumentExpression(nameof(module))] string moduleName = "")
		{
			ArgumentException.ThrowIfNullOrEmpty(moduleName);
			module.CopyToRoot(dictionary.AddChild(moduleName));
		}

		public void CopyTo(StateDictionary dictionary, int index)
		{
			module.CopyToRoot(dictionary.AddChild(index));
		}
	}

	extension<T>(ref T module) where T : struct, IModule
	{
		public void CopyFrom(StateDictionary dictionary, [CallerArgumentExpression(nameof(module))] string moduleName = "")
		{
			ArgumentException.ThrowIfNullOrEmpty(moduleName);
			module.CopyFromRoot(dictionary.GetChild(moduleName));
		}

		public void CopyFrom(StateDictionary dictionary, int index)
		{
			module.CopyFromRoot(dictionary.GetChild(index));
		}
	}
}
