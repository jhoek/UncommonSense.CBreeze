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
                new Item("Application", null, 
                    new Attribute("Tables")),
                new Item("Object", null,
                    new Property("DateTime", "DateTime"),
                    new Property("Modified", "Boolean"),
                    new Property("VersionList", "String")),
                new Item("Table", "Object",
                    new Property("CaptionML", "MultiLanguage")),
                new Enumeration("BorderStyle", "Foo", "Baz", "Bar"),
                new ReferencePropertyType("MultiLanguage")
                );

            objectModel.AsProject().CompileTo(@".\output.dll");
        }
    }
}
