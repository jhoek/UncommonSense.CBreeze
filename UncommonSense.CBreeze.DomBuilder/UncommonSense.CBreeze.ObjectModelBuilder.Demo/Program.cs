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
                    new Enumeration("BlankNumbers"),
					new Item(
						"Application",
						new ReferenceAttribute("Tables", "Tables"),
						new ReferenceAttribute("Pages", "Pages"),
						new ReferenceAttribute("Reports", "Reports"),
						new ReferenceAttribute("Codeunits", "Codeunits")
					),
					new Item(
						"Object",
						new ValueAttribute("int", "ID"),
						new ValueAttribute("string", "Name")
					).MakeAbstract(),
					new Item(
						"Table",
						"Object"
					),
					new Item(
						"Page",
						"Object"
					),
					new Container(
						"Table",
						"Tables"
					),
					new Container(
						"Page",
						"Pages"
					)
				);

			foreach (var compilationUnit in objectModel.ToCompilationUnits())
			{
				compilationUnit.WriteTo(Console.Out);
			}
		}
	}
}
