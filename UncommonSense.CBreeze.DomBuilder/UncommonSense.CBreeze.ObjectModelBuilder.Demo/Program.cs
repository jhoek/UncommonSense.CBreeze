using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.ObjectModelWriter;
using UncommonSense.CSharp;

namespace UncommonSense.CBreeze.ObjectModelBuilder.Demo
{
	class Program
	{
		static void Main(string[] args)
		{
			var objectModel = new ObjectModel("Demo");

			AddItem(objectModel, "Application");

			var compilationUnits = objectModel.ToCompilationUnits();

			foreach (var compilationUnit in compilationUnits)
			{
				compilationUnit.WriteTo(Console.Out);
			}
		}

		static void AddItem(ObjectModel objectModel, string name)
		{
			var item = new Item(name);
			objectModel.Elements.Add(item);
		}
	}
}
