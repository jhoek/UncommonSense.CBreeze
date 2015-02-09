using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UncommonSense.CBreeze.DomBuilder.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            var objectModel = new ObjectModel(
                "UncommonSense.CBreeze.Core",
                new Item(),
                new Item(),
                new Item()
                );
        }
    }
}
