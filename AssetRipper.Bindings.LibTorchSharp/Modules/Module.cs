namespace AssetRipper.Bindings.LibTorchSharp.Modules;

public static class Module
{
	extension<T>(T) where T : struct, IModule
	{
		public static void Load(ref T module, string path, Device? device = null)
		{
			using StateDictionary dictionary = StateDictionary.Load(path, device);
			module.CopyFrom(dictionary);
		}

		public static void Load(ref T module, Stream stream, Device? device = null)
		{
			using StateDictionary dictionary = StateDictionary.Load(stream, device);
			module.CopyFrom(dictionary);
		}
	}
	extension<T>(T module) where T : struct, IModule
	{
		public void Save(string path, Device? device = null)
		{
			using StateDictionary dictionary = new(device);
			module.CopyTo(dictionary);
			dictionary.Save(path);
		}

		public void Save(Stream stream, Device? device = null)
		{
			using StateDictionary dictionary = new(device);
			module.CopyTo(dictionary);
			dictionary.Save(stream);
		}
	}
}
