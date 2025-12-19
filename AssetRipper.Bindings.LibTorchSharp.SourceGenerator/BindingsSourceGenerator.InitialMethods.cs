using AssetRipper.Bindings.LibTorchSharp.SourceGenerator.Extensions;
using AssetRipper.Text.SourceGeneration;
using SGF;
using System.CodeDom.Compiler;
using System.Collections.Immutable;
using System.IO;

namespace AssetRipper.Bindings.LibTorchSharp.SourceGenerator;

public partial class BindingsSourceGenerator
{
	private static void GenerateInitialMethods(ref SgfSourceProductionContext context, ImmutableArray<MethodData> pinvokeMethods, ReflectionContext reflectionContext, MethodData[] nativeMethods)
	{
		StringWriter stringWriter = new();
		IndentedTextWriter writer = IndentedTextWriterFactory.Create(stringWriter);

		writer.WriteFileScopedNamespace("AssetRipper.Bindings.LibTorchSharp.LowLevel");
		writer.WriteLineNoTabs();
		writer.WriteLine("public static unsafe partial class NativeMethods");
		using (new CurlyBrackets(writer))
		{
			for (int j = 0; j < pinvokeMethods.Length; j++)
			{
				MethodData pinvokeMethod = pinvokeMethods[j];
				MethodData nativeMethod = nativeMethods[j];

				writer.WriteSummaryDocumentation(reflectionContext.GetEntryPoint(nativeMethod.Name));
				writer.WriteDebuggerIgnoreAttributes();
				writer.WriteGeneratedCodeAttribute();
				writer.Write("public static ");
				writer.WriteLine(nativeMethod.ToString());
				using (new CurlyBrackets(writer))
				{
					if (!nativeMethod.ReturnType.IsVoid)
					{
						writer.Write($"{nativeMethod.ReturnType} __result = ");

						if (nativeMethod.ReturnType == pinvokeMethod.ReturnType)
						{
						}
						else if (nativeMethod.ReturnType.IsBoolean)
						{
							writer.Write("0 != ");
						}
						else
						{
							writer.Write('(');
							writer.Write(nativeMethod.ReturnType);
							writer.Write(')');
						}
					}
					writer.Write("PInvoke.");
					writer.Write(pinvokeMethod.Name);
					writer.Write('(');
					for (int i = 0; i < nativeMethod.Parameters.Length; i++)
					{
						if (i > 0)
						{
							writer.Write(", ");
						}
						if (nativeMethod.Parameters[i].Type != pinvokeMethod.Parameters[i].Type)
						{
							writer.Write('(');
							writer.Write(pinvokeMethod.Parameters[i].Type);
							writer.Write(')');
						}
						writer.Write(nativeMethod.Parameters[i].Name);
					}
					writer.WriteLine(");");
					writer.WriteLine("CheckForErrors();");
					if (!nativeMethod.ReturnType.IsVoid)
					{
						writer.WriteLine("return __result;");
					}
				}
			}
		}

		context.AddSource("NativeMethods.cs", stringWriter.ToString());
	}
}
