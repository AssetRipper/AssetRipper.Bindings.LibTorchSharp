namespace AssetRipper.Bindings.LibTorchSharp.Modules;

public static class Module
{
	extension<T>(T module) where T : struct, IModule
	{
		public void Load(string path, Device? device = null)
		{
			bool previousAutograd = Autograd.IsGradEnabled;
			Autograd.IsGradEnabled = false;
			try
			{
				using StateDictionary dictionary = StateDictionary.Load(path, device);
				module.CopyFromRoot(dictionary);
			}
			finally
			{
				Autograd.IsGradEnabled = previousAutograd;
			}
		}

		public void Load(Stream stream, Device? device = null)
		{
			bool previousAutograd = Autograd.IsGradEnabled;
			Autograd.IsGradEnabled = false;
			try
			{
				using StateDictionary dictionary = StateDictionary.Load(stream, device);
				module.CopyFromRoot(dictionary);
			}
			finally
			{
				Autograd.IsGradEnabled = previousAutograd;
			}
		}

		public void Save(string path)
		{
			using StateDictionary dictionary = new();
			module.CopyToRoot(dictionary);
			dictionary.Save(path);
		}

		public void Save(Stream stream)
		{
			using StateDictionary dictionary = new();
			module.CopyToRoot(dictionary);
			dictionary.Save(stream);
		}
	}
}
