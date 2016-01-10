using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Temp
{
    class Program
    {
        static void Main(string[] args)
        {
            var xmlport = new XmlPort(50000, "Test");

            xmlport.Properties.Namespaces.Set("Foo", "Baz");
            xmlport.Properties.Namespaces.Set("Oink", "Boink");

            Console.WriteLine(xmlport.Properties.Namespaces.Count());
            Console.WriteLine(xmlport.Properties.Namespaces["Foo"]);
        }
    }
}
