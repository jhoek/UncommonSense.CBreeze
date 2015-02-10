using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UncommonSense.CBreeze.DomBuilder;
using UncommonSense.CBreeze.DomWriter;

namespace UncommonSense.CBreeze.DomBuilder.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            var objectModel = new ObjectModel(
                "UncommonSense.CBreeze.Core",
                new Item("Application",
                    new Attribute("Tables")),
                new Item("Object",
                    new Property("DateTime", "DateTime"),
                    new Property("Modified", "Boolean"),
                    new Property("VersionList", "String")),
                new Item("Table", 
                    new Property("CaptionML", "MultiLanguage")),
                new Enumeration("BorderStyle", "Foo", "Baz", "Bar"),
                new ReferencePropertyType("MultiLanguage")
                );

            var project = objectModel.ToProject();

            project.WriteTo(Console.Out);
        }
    }
}
