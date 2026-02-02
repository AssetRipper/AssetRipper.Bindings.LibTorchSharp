using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace AssetRipper.Bindings.LibTorchSharp.Analyzers;

internal static class IndentedTextWriterExtensions
{
	public static void WriteDebuggerIgnoreAttributes(this IndentedTextWriter writer)
	{
		writer.WriteDebuggerHiddenAttribute();
		writer.WriteDebuggerNonUserCodeAttribute();
		writer.WriteDebuggerStepThroughAttribute();
		writer.WriteStackTraceHiddenAttribute();
	}

	public static void WriteDebuggerHiddenAttribute(this IndentedTextWriter writer)
	{
		writer.WriteLine("[global::System.Diagnostics.DebuggerHidden]");
	}

	public static void WriteDebuggerNonUserCodeAttribute(this IndentedTextWriter writer)
	{
		writer.WriteLine("[global::System.Diagnostics.DebuggerNonUserCode]");
	}

	public static void WriteDebuggerStepThroughAttribute(this IndentedTextWriter writer)
	{
		writer.WriteLine("[global::System.Diagnostics.DebuggerStepThrough]");
	}

	public static void WriteStackTraceHiddenAttribute(this IndentedTextWriter writer)
	{
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

	public static void WriteStructLayoutAttribute(this IndentedTextWriter writer, LayoutKind layoutKind)
	{
		writer.WriteLine($"[global::System.Runtime.InteropServices.StructLayout(global::System.Runtime.InteropServices.LayoutKind.{layoutKind})]");
	}

	public static void WriteEditorBrowsableAttribute(this IndentedTextWriter writer, EditorBrowsableState state)
	{
		writer.WriteLine($"[global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.{state})]");
	}

	public static void WriteDebuggerBrowsableAttribute(this IndentedTextWriter writer, DebuggerBrowsableState state)
	{
		writer.WriteLine($"[global::System.Diagnostics.DebuggerBrowsable(global::System.Diagnostics.DebuggerBrowsableState.{state})]");
	}
}
