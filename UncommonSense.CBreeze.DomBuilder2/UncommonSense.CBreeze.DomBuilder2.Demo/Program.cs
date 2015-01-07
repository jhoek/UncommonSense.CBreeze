using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UncommonSense.CBreeze.DomBuilder2.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintNode(BuildDom(), 0);
        }

        static Dom BuildDom()
        {
            return
                new Dom("UncommonSense.CBreeze70.Core",
                    new Import("System"),

                    new Item("MultiLanguageEntry", null, Item.Options.None,
                        new Attribute("LanguageID", "string"),
                        new Attribute("Value", "string")),
                    new Collection("MultiLanguageValue", "MultiLanguageEntry"),
                    
                    new PropertyType("MultiLanguage", "MultiLanguageValue", PropertyType.Options.ReferenceProperty),
                    new PropertyType("NullableDateTime", "DateTime?", PropertyType.Options.None),
                    new PropertyType("Boolean", "bool", PropertyType.Options.None),
                    new Item("Object", null, Item.Options.Abstract,
                        new Attribute("ID", "int"),
                        new Attribute("Name", "string"),
                        new Property("DateTime", "NullableDateTime"),
                        new Property("Modified", "Boolean")),
                    new Item("Table", "Object", Item.Options.AutoCollection,
                        new Property("CaptionML", "MultiLanguage")),
                    new Item("Page", "Object", Item.Options.AutoCollection,
                        new Property("CaptionML", "MultiLanguage")),
                    new Item ("Function", null, Item.Options.AutoCollection),
                    new Item ("Code", null, Item.Options.None,
                        new Attribute("Functions", "Functions"))
                );
        }

        static void PrintNode(INode node, int indentation)
        {
            Console.Write(new string(' ', indentation * 2));
            Console.WriteLine(node);

            foreach (var childNode in node.ChildNodes)
            {
                PrintNode(childNode, indentation + 1);
            }
        }
    }
}
