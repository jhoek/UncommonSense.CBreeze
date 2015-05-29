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
                    new Enumeration("BlankNumbers", "DontBlank", "BlankNeg", "BlankNegAndZero", "BlankZero", "BlankZeroAndPos", "BlankPos"),
                    new Item("Application", new ReferenceAttribute("Tables", "Tables"), new ReferenceAttribute("Pages", "Pages"), new ReferenceAttribute("Reports", "Reports"), new ReferenceAttribute("Codeunits", "Codeunits")),
                    new Item("Object", new ValueAttribute("int", "ID"), new ValueAttribute("string", "Name")).MakeAbstract(),
                    new Item("Table", "Object", new ReferenceAttribute("TableProperties", "Properties")),
                    new Item("Page", "Object"),
                    new Item("Report", "Object"),
                    new Item("Codeunit", "Object", new ReferenceAttribute("CodeunitProperties", "Properties")),
                    new Container("Table", "Tables"),
                    new Container("Page", "Pages"),
                    new Container("Report", "Reports"),
                    new Container("Codeunit", "Codeunits"),
                    new Properties("TableProperties"),
                    new Properties("CodeunitProperties")
                );

            foreach (var compilationUnit in objectModel.ToCompilationUnits())
            {
                compilationUnit.WriteTo(Console.Out);
            }
        }
    }
}
