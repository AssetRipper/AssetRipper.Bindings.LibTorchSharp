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

	public static void WriteGeneratedCodeAttribute(this IndentedTextWriter writer, string? toolName = null, string? version = null)
	{
		writer.Write("[global::System.CodeDom.Compiler.GeneratedCode(");
		if (toolName is null)
		{
			writer.Write("null, ");
		}
		else
		{
			writer.Write('"');
			writer.Write(toolName);
			writer.Write("\", ");
		}
		if (version is null)
		{
			writer.WriteLine("null)]");
		}
		else
		{
			writer.Write('"');
			writer.Write(version);
			writer.WriteLine("\")]");
		}
	}
}
