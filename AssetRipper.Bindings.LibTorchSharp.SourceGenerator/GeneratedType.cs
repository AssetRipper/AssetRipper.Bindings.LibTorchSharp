using AssetRipper.Text.SourceGeneration;
using SGF;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AssetRipper.Bindings.LibTorchSharp.SourceGenerator;

internal abstract class GeneratedType
{
	public abstract string Kind { get; }
	public abstract string Name { get; }
	public virtual string Namespace => "AssetRipper.Bindings.LibTorchSharp";
	public List<PropertyData> Properties { get; } = [];
	public List<MethodPair> Methods { get; } = [];
	public abstract bool IsInstance(MethodData method);
	public bool IsStatic(MethodData method) => !IsInstance(method);

	private enum PropertyMethodKind
	{
		None,
		GetWithPrefix,
		GetWithoutPrefix,
		Set,
	}
	public void DetectProperties()
	{
		Dictionary<string, MethodPair> getters = [];
		Dictionary<string, MethodPair> setters = [];
		HashSet<string> methodNames = [.. Methods.Select(m => m.MidLevel.Name)];
		for (int i = Methods.Count - 1; i >= 0; i--)
		{
			(MethodData method, MethodData nativeMethod) = Methods[i];
			switch (GetAccessorType(method, methodNames))
			{
				case PropertyMethodKind.GetWithPrefix:
					{
						string propertyName = method.Name[4..];
						getters.Add(propertyName, new(method, nativeMethod));
						Methods.RemoveAt(i);
					}
					break;
				case PropertyMethodKind.GetWithoutPrefix:
					{
						string propertyName = method.Name;
						getters.Add(propertyName, new(method, nativeMethod));
						Methods.RemoveAt(i);
					}
					break;
				case PropertyMethodKind.Set:
					{
						string propertyName = method.Name[4..];
						setters.Add(propertyName, new(method.ChangeLastParameterNameToValue(), nativeMethod));
						Methods.RemoveAt(i);
					}
					break;
			}
		}

		foreach ((string propertyName, MethodPair getter) in getters)
		{
			MethodPair? setter = setters.TryGetValue(propertyName, out MethodPair temp) ? temp : null;
			PropertyData property = new(getter.MidLevel.ReturnType, propertyName, getter.MidLevel.Parameters.Length > 0, getter, setter);
			Properties.Add(property);
		}

		foreach ((string propertyName, MethodPair setter) in setters)
		{
			if (getters.ContainsKey(propertyName))
			{
				continue;
			}
			PropertyData property = new(setter.MidLevel.Parameters[^1].Type, propertyName, setter.MidLevel.Parameters.Length > 1, null, setter);
			Properties.Add(property);
		}

		PropertyMethodKind GetAccessorType(MethodData method, HashSet<string> methodNames)
		{
			if (method.Name.StartsWith("get_", StringComparison.Ordinal) && !method.ReturnType.IsVoid && method.Name.Length > 4)
			{
				int expectedParameterCount = IsInstance(method) ? 1 : 0;
				return method.Parameters.Length == expectedParameterCount ? PropertyMethodKind.GetWithPrefix : PropertyMethodKind.None;
			}
			else if (method.Name.StartsWith("set_", StringComparison.Ordinal) && method.ReturnType.IsVoid && method.Name.Length > 4)
			{
				int expectedParameterCount = IsInstance(method) ? 2 : 1;
				return method.Parameters.Length == expectedParameterCount ? PropertyMethodKind.Set : PropertyMethodKind.None;
			}
			else if (methodNames.Contains("set_" + method.Name) && !method.ReturnType.IsVoid && method.Name.Length > 0)
			{
				int expectedParameterCount = IsInstance(method) ? 1 : 0;
				return method.Parameters.Length == expectedParameterCount ? PropertyMethodKind.GetWithoutPrefix : PropertyMethodKind.None;
			}
			else
			{
				return PropertyMethodKind.None; // Not an accessor
			}
		}
	}
	public void SortMethods() => Methods.Sort();
	public void SortProperties() => Properties.Sort();

	public void GenerateMembersFile(SgfSourceProductionContext context)
	{
		if (Methods.Count == 0 && Properties.Count == 0)
		{
			return;
		}

		StringWriter stringWriter = new();
		IndentedTextWriter writer = IndentedTextWriterFactory.Create(stringWriter);

		writer.WriteUsing("AssetRipper.Bindings.LibTorchSharp.LowLevel");
		writer.WriteLineNoTabs();
		writer.WriteFileScopedNamespace(Namespace);
		writer.WriteLineNoTabs();
		writer.WriteLine($"public unsafe {Kind} {Name}");
		using (new CurlyBrackets(writer))
		{
			foreach ((MethodData method, MethodData nativeMethod) in Methods)
			{
				bool isInstance = IsInstance(method);

				writer.Write("public ");
				if (!isInstance)
				{
					writer.Write("static ");
				}
				writer.Write(method.ReturnType);
				writer.Write(' ');
				writer.Write(method.Name);
				writer.Write('(');
				int parameterOffset = isInstance ? 1 : 0;
				for (int i = parameterOffset; i < method.Parameters.Length; i++)
				{
					if (i > parameterOffset)
					{
						writer.Write(", ");
					}
					writer.Write(method.Parameters[i]);
				}
				writer.WriteLine(')');
				using (new CurlyBrackets(writer))
				{
					WriteImplementation(writer, method, nativeMethod, isInstance);
				}
			}

			foreach (PropertyData property in Properties)
			{
				writer.Write("public ");
				if (!property.IsInstance)
				{
					writer.Write("static ");
				}
				writer.Write(property.Type);
				writer.Write(' ');
				writer.WriteLine(property.Name);
				using (new CurlyBrackets(writer))
				{
					if (property.GetMethod is { } getMethod)
					{
						writer.WriteLine("get");
						using (new CurlyBrackets(writer))
						{
							WriteImplementation(writer, getMethod.MidLevel, getMethod.LowLevel, property.IsInstance);
						}
					}
					if (property.SetMethod is { } setMethod)
					{
						writer.WriteLine("set");
						using (new CurlyBrackets(writer))
						{
							WriteImplementation(writer, setMethod.MidLevel, setMethod.LowLevel, property.IsInstance);
						}
					}
				}
			}
		}

		context.AddSource($"{Name}.Members.cs", stringWriter.ToString());

		static void WriteImplementation(IndentedTextWriter writer, MethodData method, MethodData nativeMethod, bool isInstance)
		{
			if (isInstance)
			{
				writer.WriteLine("ThrowIfNull();");
			}
			if (!method.ReturnType.IsVoid)
			{
				writer.Write("return ");
			}
			if (method.ReturnType != nativeMethod.ReturnType)
			{
				writer.Write('(');
				writer.Write(method.ReturnType);
				writer.Write(')');
			}
			writer.Write("NativeMethods.");
			writer.Write(nativeMethod.Name);
			writer.Write('(');
			for (int i = 0; i < method.Parameters.Length; i++)
			{
				if (i > 0)
				{
					writer.Write(", ");
				}
				if (method.Parameters[i].Type != nativeMethod.Parameters[i].Type)
				{
					writer.Write('(');
					writer.Write(nativeMethod.Parameters[i].Type);
					writer.Write(')');
				}
				writer.Write(method.Parameters[i].Name);
			}
			writer.WriteLine(");");
		}
	}

	public virtual void GenerateDisposableFile(SgfSourceProductionContext context)
	{
	}

	public virtual void GenerateConstructorFile(SgfSourceProductionContext context)
	{
	}

	public virtual void GenerateMainFile(SgfSourceProductionContext context)
	{
	}
}
