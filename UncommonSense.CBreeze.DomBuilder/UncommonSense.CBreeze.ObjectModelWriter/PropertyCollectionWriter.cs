using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.ObjectModelBuilder;
using UncommonSense.CSharp;

namespace UncommonSense.CBreeze.ObjectModelWriter
{
	public static class PropertyCollectionWriter
	{
		public static void WriteToFolder(this PropertyCollection propertyCollection, string folderName)
		{
			var @class = new Class(Visibility.Public, propertyCollection.Name, "Properties");

			foreach (var property in propertyCollection)
			{
				var expression = string.Format("new {0}(\"{1}\")", property.TypeName, property.Name);
				var field = new Field(Visibility.Protected, property.InternalName, property.TypeName, expression);
				@class.Fields.Add(field);
			}

			new CompilationUnit(new Namespace(propertyCollection.ObjectModel.Namespace, @class)).WriteTo(Path.Combine(folderName, string.Format("{0}.cs", propertyCollection.Name)));
		}
	}
}
