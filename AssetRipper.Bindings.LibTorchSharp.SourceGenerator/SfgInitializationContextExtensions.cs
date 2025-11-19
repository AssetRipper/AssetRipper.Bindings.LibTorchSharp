using Microsoft.CodeAnalysis;
using SGF;
using System;

namespace AssetRipper.Bindings.LibTorchSharp.SourceGenerator;

internal static class SfgInitializationContextExtensions
{
	public static void RegisterSourceOutput<T1, T2>(this SgfInitializationContext context, IncrementalValueProvider<T1> source1, IncrementalValueProvider<T2> source2, Action<SgfSourceProductionContext, T1, T2> action)
	{
		context.RegisterSourceOutput(source1.Combine(source2), (context, pair) => action(context, pair.Left, pair.Right));
	}
}
