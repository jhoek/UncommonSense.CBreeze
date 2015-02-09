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
                new Item("Application"),
                new Item("Object"),
                new Item("Table"),
                new Enumeration("BorderStyle", "Foo", "Baz", "Bar"),
                new ReferencePropertyType("MultiLanguageProperty")
                );

            var project = objectModel.ToProject();

            project.WriteTo(Console.Out);
        }
    }
}
