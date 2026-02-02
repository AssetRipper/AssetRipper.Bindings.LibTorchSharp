using System.Runtime.CompilerServices;

namespace AssetRipper.Bindings.LibTorchSharp.Modules;

public static class StateExtensions
{
	extension(Tensor tensor)
	{
		public void CopyTo(StateDictionary dictionary, [CallerArgumentExpression(nameof(tensor))] string tensorName = "")
		{
			ArgumentException.ThrowIfNullOrEmpty(tensorName);
			dictionary.AddTensor(tensorName, tensor);
		}

		public void CopyTo(StateDictionary dictionary, int index)
		{
			dictionary.AddTensor(index, tensor);
		}

		public void CopyFrom(StateDictionary dictionary, [CallerArgumentExpression(nameof(tensor))] string tensorName = "")
		{
			ArgumentException.ThrowIfNullOrEmpty(tensorName);
			using Tensor temp = dictionary.GetTensor(tensorName);
			if (tensor.IsNull)
			{
				if (!temp.IsNull)
				{
					throw new ArgumentNullException(nameof(tensor));
				}
			}
			else
			{
				tensor.CopyInline(temp, false);
			}
		}

		public void CopyFrom(StateDictionary dictionary, int index)
		{
			using Tensor temp = dictionary.GetTensor(index);
			if (tensor.IsNull)
			{
				if (!temp.IsNull)
				{
					throw new ArgumentNullException(nameof(tensor));
				}
			}
			else
			{
				tensor.CopyInline(temp, false);
			}
		}
	}

	extension<T>(T module) where T : unmanaged, IModule
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

	extension(TensorArray array)
	{
		public void CopyTo(StateDictionary dictionary, [CallerArgumentExpression(nameof(array))] string name = "")
		{
			ArgumentException.ThrowIfNullOrEmpty(name);
			array.CopyToRoot(dictionary.GetChild(name));
		}

		public void CopyFrom(StateDictionary dictionary, [CallerArgumentExpression(nameof(array))] string name = "")
		{
			ArgumentException.ThrowIfNullOrEmpty(name);
			array.CopyFromRoot(dictionary.GetChild(name));
		}
	}

	extension<T>(ModuleArray<T> array) where T : unmanaged, IModule
	{
		public void CopyTo(StateDictionary dictionary, [CallerArgumentExpression(nameof(array))] string name = "")
		{
			ArgumentException.ThrowIfNullOrEmpty(name);
			array.CopyToRoot(dictionary.GetChild(name));
		}

		public void CopyFrom(StateDictionary dictionary, [CallerArgumentExpression(nameof(array))] string name = "")
		{
			ArgumentException.ThrowIfNullOrEmpty(name);
			array.CopyFromRoot(dictionary.GetChild(name));
		}
	}
}
