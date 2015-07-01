using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.ObjectModelBuilder;
using UncommonSense.CSharp;

namespace UncommonSense.CBreeze.ObjectModelWriter
{
	public static class ItemWriter
	{
		public static void WriteToFolder(this Item item, string folderName)
		{
			var @class = new Class(Visibility.Public, item.Name, item.BaseTypeName);
			@class.Abstract = item.Abstract;
			@class.AddConstructor(item);
			@class.OverrideToString(item);
			@class.AddChildNodeProperties(item);

			new CompilationUnit(new Namespace(item.ObjectModel.Namespace, @class)).WriteTo(Path.Combine(folderName, @class.FileName));
		}

		public static void AddConstructor(this Class @class, Item item)
		{
			var ctor = new Constructor(Visibility.Public, item.Name, null, null);

			foreach (var identifier in item.AllAttributes.OfType<Identifier>())
			{
				var parameter = new FixedParameter(identifier.InternalName, identifier.TypeName);
				ctor.Parameters.Add(parameter);
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

		public static void AddChildNodeProperties(this Class @class, Item item)
		{
			foreach (var childNode in item.Attributes.OfType<ChildNode>())
			{
				var getter = new PropertyAccessor(AccessorVisibility.Unspecified, null);
				var setter = new PropertyAccessor(AccessorVisibility.Internal, null);
				var property = new UncommonSense.CSharp.Property(Visibility.Public, childNode.Name, childNode.TypeName, getter, setter);

				@class.Properties.Add(property);
			}
		}
	}
}
