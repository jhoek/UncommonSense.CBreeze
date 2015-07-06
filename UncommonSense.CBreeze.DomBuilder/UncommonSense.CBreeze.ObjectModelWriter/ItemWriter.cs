using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.ObjectModelBuilder;
using UncommonSense.CSharp;
using System.Text.RegularExpressions;

namespace UncommonSense.CBreeze.ObjectModelWriter
{
	public static class ItemWriter
	{
		public static void WriteToFolder(this Item item, string folderName)
		{
			var @class = new Class(Visibility.Public, item.Name, item.BaseTypeName); // ?? "Node");

			foreach (var interfaceName in item.ImplementedInterfaces)
			{
				@class.ImplementedInterfaces.Add(new ImplementedInterface(interfaceName));
			}

			@class.Abstract = item.Abstract;
			@class.Partial = true;
			@class.AddConstructor(item);
			@class.OverrideToString(item);
			@class.AddTypeProperty(item);
			@class.AddAttributeProperties(item);
			@class.OverrideChildNodes(item);

			var @namespace = new Namespace(item.ObjectModel.Namespace, @class);
			var compilationUnit = new CompilationUnit(@namespace);

			if (item.Attributes.OfType<ChildNode>().Any())
			{
				var @using = new UsingNamespaceDirective("System.Collections.Generic");
				compilationUnit.UsingDirectives.Add(@using);
			}

			compilationUnit.WriteTo(Path.Combine(folderName, @class.FileName));
		}

		public static void AddConstructor(this Class @class, Item item)
		{
			ConstructorInitializer initializer = null;
			var inheritedIdentifiers = item.InheritedAttributes.OfType<Identifier>();

			if (inheritedIdentifiers.Any())
			{
				initializer = new ConstructorBaseInitializer();

				foreach (var identifier in inheritedIdentifiers)
				{
					var argument = new ExpressionArgument(identifier.InternalName);
					initializer.Arguments.Add(argument);
				}
			}

			var ctorVisibility = item.Createable ? Visibility.Public : Visibility.Internal;	
			var ctor = new Constructor(ctorVisibility, item.Name, initializer, null);

			// Parameters
			foreach (var identifier in item.AllAttributes.OfType<Identifier>())
			{
				var parameter = new FixedParameter(identifier.InternalName, identifier.TypeName);
				ctor.Parameters.Add(parameter);
			}

			// Statements
			foreach (var identifier in item.Attributes.OfType<Identifier>())
			{
				ctor.CodeBlock.Statements.AddFormat("{0} = {1};", identifier.Name, identifier.InternalName);
			}

			foreach (var childNode in item.Attributes.OfType<ChildNode>())
			{
				ctor.CodeBlock.Statements.AddFormat("{0} = new {1}(this);", childNode.Name, childNode.TypeName);
			}

			@class.Constructors.Add(ctor);
		}

		public static void OverrideToString(this Class @class, Item item)
		{
			var method = new Method(Visibility.Public, "ToString", "string", null);
			method.Overriding = Overriding.Override;
			method.CodeBlock.Statements.AddFormat("return \"{0}\";", item.Name);
			@class.Methods.Add(method);
		}

		public static void AddTypeProperty(this Class @class, Item item)
		{
			if (!string.IsNullOrEmpty(item.BaseTypeName))
			{
				var codeBlock = new CodeBlock();
				codeBlock.Statements.AddFormat("return {0}Type.{1};", item.BaseTypeName, Regex.Replace(item.Name, string.Format("{0}$", item.BaseTypeName), ""));
				var getter = new PropertyAccessor(AccessorVisibility.Unspecified, codeBlock);

				var property = new UncommonSense.CSharp.Property(Visibility.Public, "Type", string.Format("{0}Type", item.BaseTypeName), getter, null);
				property.Overriding = Overriding.Override;
				@class.Properties.Add(property);
			}
		}

		public static void AddAttributeProperties(this Class @class, Item item)
		{
			foreach (var attribute in item.Attributes)
			{
				var setterVisibility = (attribute is ChildNode || attribute is Identifier) ? AccessorVisibility.Internal : AccessorVisibility.Unspecified;

				var getter = new PropertyAccessor(AccessorVisibility.Unspecified, null);
				var setter = new PropertyAccessor(setterVisibility, null);
				var property = new UncommonSense.CSharp.Property(Visibility.Public, attribute.Name, attribute.TypeName, getter, setter);

				@class.Properties.Add(property);
			}
		}

		public static void OverrideChildNodes(this Class @class, Item item)
		{
			var childNodes = item.Attributes.OfType<ChildNode>();

			if (childNodes.Any())
			{
				var codeBlock = new CodeBlock();

				codeBlock.Statements.Add("foreach(var childNode in base.ChildNodes)");
				codeBlock.Statements.Add("{");
				codeBlock.Statements.Add("    yield return childNode;");
				codeBlock.Statements.Add("}");
				codeBlock.Statements.Add("");

				foreach (var childNode in childNodes)
				{
					codeBlock.Statements.AddFormat("yield return {0};", childNode.Name);		
				}

				var getter = new PropertyAccessor(AccessorVisibility.Unspecified, codeBlock);
				var property = new UncommonSense.CSharp.Property(Visibility.Public, "ChildNodes", "IEnumerable<INode>", getter, null);
				property.Overriding = Overriding.Override;
				@class.Properties.Add(property);
			}
		}
	}
}
