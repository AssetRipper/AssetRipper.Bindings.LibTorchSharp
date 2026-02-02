using AssetRipper.Text.SourceGeneration;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using SGF;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;

namespace AssetRipper.Bindings.LibTorchSharp.Analyzers;

[IncrementalGenerator]
public partial class ModuleGenerator() : IncrementalGenerator(nameof(ModuleGenerator))
{
	private const string ModulesNamespace = "AssetRipper.Bindings.LibTorchSharp.Modules";
	private const string StateDictionaryTypeFullName = "global::AssetRipper.Bindings.LibTorchSharp.Modules.StateDictionary";
	private const string IModuleTypeFullName = "global::AssetRipper.Bindings.LibTorchSharp.Modules.IModule";

	public override void OnInitialize(SgfInitializationContext context)
	{
		IncrementalValuesProvider<StructData> structs = context.SyntaxProvider.ForAttributeWithMetadataName("AssetRipper.Bindings.LibTorchSharp.Attributes.GeneratedModuleAttribute", (syntaxNode, _) =>
		{
			return syntaxNode is TypeDeclarationSyntax type
				&& type.Modifiers.Any(SyntaxKind.PartialKeyword)
				&& type.Modifiers.Any(SyntaxKind.ReadOnlyKeyword)
				&& !type.Modifiers.Any(SyntaxKind.RecordKeyword)
				&& type.Parent is BaseNamespaceDeclarationSyntax
				&& type.Arity == 0;
		}, static (context, _) =>
		{
			ITypeSymbol structSymbol = (ITypeSymbol)context.TargetSymbol;

			// Name of the type the attribute is applied to
			string structName = structSymbol.Name;

			// Namespace of the type the attribute is applied to
			string structNamespace = structSymbol.ContainingNamespace.ToDisplayString();

			// Attribute has a property called "IsTrainingField" that indicates whether the struct has an IsTraining field
			bool isTrainingField = context.Attributes.Single().NamedArguments.Any(kv => kv.Key == "IsTrainingField" && kv.Value.Value is bool b && b);

			List<PropertyData> properties = [];
			foreach (ISymbol member in structSymbol.GetMembers())
			{
				if (member is not IPropertySymbol { IsStatic: false, IsPartialDefinition: true, GetMethod: not null, SetMethod: null, DeclaredAccessibility: Accessibility.Private } property)
				{
					continue;
				}

				properties.Add(new PropertyData(property.Type.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat), property.Name));
			}

			return new StructData(structNamespace, structName, isTrainingField, new EquatableArray<PropertyData>(properties));
		});

		context.RegisterSourceOutput(structs, Generate);
	}

	private static void Generate(SgfSourceProductionContext context, StructData structData)
	{
		using StringWriter stringWriter = new();
		using IndentedTextWriter writer = IndentedTextWriterFactory.Create(stringWriter);

		string moduleDataName = structData.GetNameForModuleData();
		string moduleDataFieldName = structData.GetNameForModuleDataField();
		string initializeMethodName = structData.GetNameForInitializeMethod();
		string parametersString = string.Join(", ", structData.Properties.Select(p => p.AsParameterString()));

		writer.WriteGeneratedCodeWarning();
		writer.WriteLineNoTabs();
		writer.WriteFileScopedNamespace(structData.Namespace);
		writer.WriteLineNoTabs();
		writer.WriteStructLayoutAttribute(LayoutKind.Auto);
		writer.WriteLine($"public readonly partial struct {structData.Name} : {IModuleTypeFullName}");
		using (new CurlyBrackets(writer))
		{
			writer.WriteStructLayoutAttribute(LayoutKind.Auto);
			writer.WriteEditorBrowsableAttribute(EditorBrowsableState.Never);
			writer.WriteDebuggerNonUserCodeAttribute();
			WriteGeneratedCodeAttribute(writer);
			writer.WriteLine($"private struct {moduleDataName} : global::System.IDisposable");
			using (new CurlyBrackets(writer))
			{
				foreach (PropertyData property in structData.Properties)
				{
					writer.WriteLine($"public {property.Type} {property.Name};");
				}
				writer.WriteLineNoTabs();

				// Constructor
				writer.WriteLine($"public {moduleDataName}({parametersString})");
				using (new CurlyBrackets(writer))
				{
					foreach (PropertyData property in structData.Properties)
					{
						writer.WriteLine($"this.{property.Name} = {property.Name};");
					}
				}
				writer.WriteLineNoTabs();

				writer.WriteLine("public bool IsTraining");
				using (new CurlyBrackets(writer))
				{
					if (structData.IsTrainingField)
					{
						writer.WriteLine("get;");
					}
					using (new Set(writer))
					{
						if (structData.IsTrainingField)
						{
							writer.WriteLine("field = value;");
						}
						foreach (PropertyData property in structData.Properties)
						{
							if (property.IsModule)
							{
								writer.WriteLine($"this.{property.Name}.IsTraining = value;");
							}
						}
					}
				}
				writer.WriteLineNoTabs();

				writer.WriteLine($"public void CopyFromRoot({StateDictionaryTypeFullName} dictionary)");
				using (new CurlyBrackets(writer))
				{
					foreach (PropertyData property in structData.Properties)
					{
						if (property.IsStorable)
						{
							writer.WriteLine($"global::{ModulesNamespace}.StateExtensions.CopyFrom(this.{property.Name}, dictionary, \"{property.Name}\");");
						}
					}
				}
				writer.WriteLineNoTabs();

				writer.WriteLine($"public void CopyToRoot({StateDictionaryTypeFullName} dictionary)");
				using (new CurlyBrackets(writer))
				{
					foreach (PropertyData property in structData.Properties)
					{
						if (property.IsStorable)
						{
							writer.WriteLine($"global::{ModulesNamespace}.StateExtensions.CopyTo(this.{property.Name}, dictionary, \"{property.Name}\");");
						}
					}
				}
				writer.WriteLineNoTabs();

				writer.WriteLine("public readonly global::System.Collections.Generic.IEnumerable<global::AssetRipper.Bindings.LibTorchSharp.Tensor> GetParameters() =>");
				using (new SquareBracketsWithSemicolon(writer))
				{
					foreach (PropertyData property in structData.Properties)
					{
						if (property.IsTensor)
						{
							writer.WriteLine($"this.{property.Name}.AliasOrNull(),");
						}
						else if (property.IsModule || property.IsModuleArray || property.IsTensorArray)
						{
							writer.WriteLine($"..this.{property.Name}.GetParameters(),");
						}
					}
				}
				writer.WriteLineNoTabs();

				writer.WriteLine("public void Dispose()");
				using (new CurlyBrackets(writer))
				{
					foreach (PropertyData property in structData.Properties)
					{
						if (property.IsDisposable)
						{
							writer.WriteLine($"global::{ModulesNamespace}.Disposable.DisposeAndSetDefault(ref this.{property.Name});");
						}
					}
				}
			}
			writer.WriteLineNoTabs();

			writer.WriteEditorBrowsableAttribute(EditorBrowsableState.Never);
			WriteGeneratedCodeAttribute(writer);
			writer.WriteLine($"private readonly global::{ModulesNamespace}.AllocatedData<{moduleDataName}> {moduleDataFieldName} = new();");
			writer.WriteLineNoTabs();

			// Properties
			foreach (PropertyData property in structData.Properties)
			{
				writer.WriteDebuggerNonUserCodeAttribute();
				WriteGeneratedCodeAttribute(writer);
				writer.WriteLine($"private partial {property.Type} {property.Name} => this.{moduleDataFieldName}.Value.{property.Name};");
			}
			writer.WriteLineNoTabs();

			// Constructor
			writer.WriteDebuggerNonUserCodeAttribute();
			WriteGeneratedCodeAttribute(writer);
			writer.WriteLine($"public {structData.Name}({parametersString})");
			using (new CurlyBrackets(writer))
			{
				string parametersPassingString = string.Join(", ", structData.Properties.Select(p => p.Name));
				writer.WriteLine($"this.{initializeMethodName}({parametersPassingString});");
			}

			// Initializer
			writer.WriteDebuggerNonUserCodeAttribute();
			WriteGeneratedCodeAttribute(writer);
			writer.WriteLine($"private void {initializeMethodName}({parametersString})");
			using (new CurlyBrackets(writer))
			{
				string parametersPassingString = string.Join(", ", structData.Properties.Select(p => p.Name));
				writer.WriteLine($"this.{moduleDataFieldName}.Value = new({parametersPassingString});");
			}
			writer.WriteLineNoTabs();

			// IModule implementation
			writer.WriteDebuggerNonUserCodeAttribute();
			WriteGeneratedCodeAttribute(writer);
			writer.WriteLine("public bool IsTraining");
			using (new CurlyBrackets(writer))
			{
				if (structData.IsTrainingField)
				{
					writer.WriteLine($"get => this.{moduleDataFieldName}.Value.IsTraining;");
				}
				writer.WriteLine($"set => this.{moduleDataFieldName}.Value.IsTraining = value;");
			}

			writer.WriteDebuggerNonUserCodeAttribute();
			WriteGeneratedCodeAttribute(writer);
			writer.WriteLine($"void {IModuleTypeFullName}.CopyFromRoot({StateDictionaryTypeFullName} dictionary) => this.{moduleDataFieldName}.Value.CopyFromRoot(dictionary);");

			writer.WriteDebuggerNonUserCodeAttribute();
			WriteGeneratedCodeAttribute(writer);
			writer.WriteLine($"void {IModuleTypeFullName}.CopyToRoot({StateDictionaryTypeFullName} dictionary) => this.{moduleDataFieldName}.Value.CopyToRoot(dictionary);");

			writer.WriteDebuggerNonUserCodeAttribute();
			WriteGeneratedCodeAttribute(writer);
			writer.WriteLine($"public global::System.Collections.Generic.IEnumerable<global::AssetRipper.Bindings.LibTorchSharp.Tensor> GetParameters() => this.{moduleDataFieldName}.Value.GetParameters();");

			writer.WriteDebuggerNonUserCodeAttribute();
			WriteGeneratedCodeAttribute(writer);
			writer.WriteLine($"public void Dispose() => this.{moduleDataFieldName}.Value.Dispose();");
		}

		context.AddSource($"{structData.Name}.cs", stringWriter.ToString());
	}

	private static void WriteGeneratedCodeAttribute(IndentedTextWriter writer)
	{
		writer.WriteGeneratedCodeAttribute(typeof(ModuleGenerator).Namespace, typeof(ModuleGenerator).Assembly.GetName().Version?.ToString());
	}
}
