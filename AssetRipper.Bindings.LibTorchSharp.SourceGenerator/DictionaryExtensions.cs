using System;
using System.Collections.Generic;

namespace AssetRipper.Bindings.LibTorchSharp.SourceGenerator;

internal static class DictionaryExtensions
{
	public static TValue GetOrCreate<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key)
		where TKey : notnull
		where TValue : new()
	{
		if (!dictionary.TryGetValue(key, out TValue value))
		{
			value = new();
			dictionary.Add(key, value);
		}
		return value;
	}

	public static TValue GetOrCreate<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key, Func<TKey, TValue> creationMethod)
		where TKey : notnull
	{
		if (!dictionary.TryGetValue(key, out TValue value))
		{
			value = creationMethod(key);
			dictionary.Add(key, value);
		}
		return value;
	}
}
