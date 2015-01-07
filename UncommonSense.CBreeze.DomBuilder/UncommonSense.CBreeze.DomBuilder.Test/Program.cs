using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.DomBuilder2;

namespace UncommonSense.CBreeze.DomBuilder.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var dom =
                new Dom(
                    "UncommonSense.CBreeze70.Core",
                    new Item(
                        "Application",
                        null,
                        Item.Options.None,
                        new Attribute("Tables", "Tables")),
                    new Item(
                        "Object",
                        null,
                        Item.Options.Abstract,
                        new Attribute("ID", "int"),
                        new Attribute("Name", "string")),
                    new Item(
                        "Table",
                        "Object",
                        Item.Options.AutoCollection,
                        new Property("CaptionML", "MultiLanguage")),
                    new PropertyType("MultiLanguage", "MultiLanguageValue", PropertyType.Options.ReferenceProperty),
                    new Collection("MultiLanguageValue", "MultiLanguageEntry"),
                    new Item(
                        "MultiLanguageEntry", 
                        null, 
                        Item.Options.None, 
                        new Attribute("LanguageID", "string"),
                        new Attribute("Value", "string"))
                );

            var project = dom.AsProject();

            UncommonSense.CBreeze.DomWriter.ExtensionMethods.WriteTo(project, Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop), "project.cs"));
            //project.Compile(Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop), "project.dll"));
        }
    }
}
