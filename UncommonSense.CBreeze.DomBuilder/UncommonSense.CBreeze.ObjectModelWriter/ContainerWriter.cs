using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.ObjectModelBuilder;
using UncommonSense.CSharp;

namespace UncommonSense.CBreeze.ObjectModelWriter
{
	public static class ContainerWriter
	{
		public static void WriteToFolder(this Container container, string folderName)
		{
			var @class = new Class(Visibility.Public, container.Name, string.Format("KeyedContainer<int,{0}>", container.ItemTypeName));
			@class.Partial = true;
			@class.AddConstructor(container);
			@class.OverrideToString(container);

			new CompilationUnit(new Namespace(container.ObjectModel.Namespace, @class)).WriteTo(Path.Combine(folderName, @class.FileName));
		}

		public static void OverrideToString(this Class @class, Container container)
		{
			var method = new Method(Visibility.Public, "ToString", "string", null);
			method.Overriding = Overriding.Override;
			method.CodeBlock.Statements.AddFormat("return \"{0}\";", container.Name);
			@class.Methods.Add(method);
		}

		public static void AddConstructor(this Class @class, Container container)
		{
			var argument = new ExpressionArgument("parentNode");
			var initializer = new ConstructorBaseInitializer(argument);
			var parameter = new FixedParameter("parentNode", "Node");
			var ctor = new Constructor(Visibility.Internal, container.Name, initializer, null, parameter);							
			@class.Constructors.Add(ctor);
		}
	}
}
