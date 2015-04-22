using System;
using UncommonSense.CBreeze.ObjectModelBuilder;
using System.Linq;
using UncommonSense.CSharp;
using System.IO;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.ObjectModelWriter
{
	public static class ObjectModelWriter
	{
		public static CompilationUnit[] ToCompilationUnits(this ObjectModel objectModel)
		{
			var compilationUnits = new List<CompilationUnit>();

			foreach (var item in objectModel.Elements.OfType<Item>())
			{
				compilationUnits.Add(item.ToCompilationUnit());	
			}

			return compilationUnits.ToArray();
		}

		public static CompilationUnit ToCompilationUnit(this Item item)
		{
			var @class = new Class(Visibility.Public, item.Name, item.BaseTypeName);
			var @namespace = new Namespace(item.ObjectModel.Namespace, @class);
			var compilationUnit = new CompilationUnit(@namespace);

			return compilationUnit;
		}
	}
}

