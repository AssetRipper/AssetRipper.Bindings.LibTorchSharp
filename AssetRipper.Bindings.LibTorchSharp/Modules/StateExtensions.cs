using System.Runtime.CompilerServices;

namespace AssetRipper.Bindings.LibTorchSharp.Modules;

public static class StateExtensions
{
	public static void CopyTo(this Tensor tensor, StateDictionary dictionary, [CallerArgumentExpression(nameof(tensor))] string tensorName = "")
	{
		ArgumentException.ThrowIfNullOrEmpty(tensorName);
		dictionary.AddTensor(tensorName, tensor);
	}

	public static void CopyTo(this Tensor tensor, StateDictionary dictionary, int index)
	{
		dictionary.AddTensor(index, tensor);
	}

	public static void CopyFrom(this ref Tensor tensor, StateDictionary dictionary, [CallerArgumentExpression(nameof(tensor))] string tensorName = "")
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

	public static void CopyFrom(this ref Tensor tensor, StateDictionary dictionary, int index)
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

	public static void CopyTo<T>(this T module, StateDictionary dictionary, [CallerArgumentExpression(nameof(module))] string moduleName = "") where T : struct, IDerived<NNModule>
	{
		ArgumentException.ThrowIfNullOrEmpty(moduleName);
		dictionary.AddChild(moduleName).CopyFrom(module.AsBase());
	}

	public static void CopyTo<T>(this T module, StateDictionary dictionary, int index) where T : struct, IDerived<NNModule>
	{
		dictionary.AddChild(index).CopyFrom(module.AsBase());
	}

	public static void CopyFrom<T>(this T module, StateDictionary dictionary, [CallerArgumentExpression(nameof(module))] string moduleName = "") where T : struct, IDerived<NNModule>
	{
		ArgumentException.ThrowIfNullOrEmpty(moduleName);
		dictionary.GetChild(moduleName).CopyTo(module.AsBase());
	}

	public static void CopyFrom<T>(this T module, StateDictionary dictionary, int index) where T : struct, IDerived<NNModule>
	{
		dictionary.GetChild(index).CopyTo(module.AsBase());
	}
}
