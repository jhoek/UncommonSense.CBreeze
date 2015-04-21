using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
                        new ReferenceAttribute("Reports", "Reports")
                    ),
                    new Item(
                        "Object",
                        new ValueAttribute("int", "ID"),
                        new ValueAttribute("string", "Name")
                    ),
                    new Item(
                        "Table"
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
        }
    }
}
