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
                new Item("Application", new Attribute("Tables"), new Attribute("Pages")),
                new Item("Object", new Attribute("Properties", "ObjectProperties")),
                new Item("Table", "Object", new Attribute("TableProperties", "TableProperties")),
                new Container("Tables", "Table"),
                new ReferencePropertyType("MultiLanguageProperty")
                );

            objectModel.AsProject().WriteTo(Console.Out);
            // objectModel.AsProject().CompileTo(@".\output.dll");
        }
    }
}
