using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.ObjectModelBuilder;

namespace UncommonSense.CBreeze.DomBuilder._70
{
    class Program
    {
        const string @namespace = "UncommonSense.CBreeze.70.Core";
        static ObjectModel objectModel = new ObjectModel(@namespace);

        static void Main(string[] args)
        {
            Item("Application");

            Item("Object")
        }

        static Item Item(string name)
        {
            var item = new Item(name);
            objectModel.Elements.Add(item);
            return item;
        }

        static Item Derive(string name)
        {
            var item = new Item(name, 
        }
    }
}
