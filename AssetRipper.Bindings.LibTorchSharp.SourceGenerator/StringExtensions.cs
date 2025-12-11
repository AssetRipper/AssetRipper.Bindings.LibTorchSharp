using Microsoft.CodeAnalysis.CSharp;

namespace AssetRipper.Bindings.LibTorchSharp.SourceGenerator;

internal static class StringExtensions
{
	public static string PrefixWithAtSignIfKeyword(this string text)
	{
		return text.IsKeyword() ? '@' + text : text;
	}

	public static bool IsKeyword(this string text)
	{
		return SyntaxFacts.GetKeywordKind(text) != SyntaxKind.None || SyntaxFacts.GetContextualKeywordKind(text) != SyntaxKind.None;
	}
}
