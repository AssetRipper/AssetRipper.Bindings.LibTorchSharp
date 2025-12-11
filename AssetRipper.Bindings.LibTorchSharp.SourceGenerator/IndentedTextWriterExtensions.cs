using System.CodeDom.Compiler;

namespace AssetRipper.Bindings.LibTorchSharp.SourceGenerator;

internal static class IndentedTextWriterExtensions
{
	public static void WriteDebuggerIgnoreAttributes(this IndentedTextWriter writer)
	{
		writer.WriteLine("[global::System.Diagnostics.DebuggerHidden]");
		writer.WriteLine("[global::System.Diagnostics.DebuggerNonUserCode]");
		writer.WriteLine("[global::System.Diagnostics.DebuggerStepThrough]");
		writer.WriteLine("[global::System.Diagnostics.StackTraceHidden]");
	}
}
