using System.Collections.Generic;
using System.Linq;

namespace AssetRipper.Bindings.LibTorchSharp.SourceGenerator.Extensions;

internal static class ReadOnlyCollectionExtensions
{
	public static IEnumerable<T> SkipLast<T>(this IReadOnlyCollection<T> source, int n)
	{
		return source.Take(source.Count - n);
	}
}