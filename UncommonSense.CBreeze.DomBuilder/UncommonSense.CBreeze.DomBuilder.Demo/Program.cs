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
            // Principles:
            // Simplicity over efficiency
            // References are strings; are not resolved until the object model is complete

            var objectModel = new ObjectModel("UncommonSense.CBreeze.Core");

            var @object = new Item("Object");
            



            var table = new Item("Table", @object);
            var tables = new Container("Tables", table);

            var application = new Item("Application", 
                    
            


                new Item("Application", new ReferenceAttribute("Tables"), new ReferenceAttribute("Pages")),
                new Item("Object", new ReferenceAttribute("Properties", "ObjectProperties")),
                new Item("Table", "Object", new ReferenceAttribute("TableProperties", "TableProperties")),
                new Container("Tables", "Table"),
                new ReferencePropertyType("MultiLanguageProperty")
                );

            objectModel.AsProject().WriteTo(Console.Out);
            // objectModel.AsProject().CompileTo(@".\output.dll");
        }
    }
}
