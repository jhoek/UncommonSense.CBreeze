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
			var objectModel = 
				new ObjectModel(
					"Demo",
					new Item(
						"Application",
						new ReferenceAttribute("Tables", "Tables"),
						new ReferenceAttribute("Pages", "Pages"),
						new ReferenceAttribute("Reports", "Reports"),
						new ReferenceAttribute("Codeunits", "Codeunits")
					),
					new Container(
						"Table",
						"Tables"

					)
				);

			foreach (var compilationUnit in objectModel.ToCompilationUnits())
			{
				compilationUnit.WriteTo(Console.Out);
			}
		}
	}
}
