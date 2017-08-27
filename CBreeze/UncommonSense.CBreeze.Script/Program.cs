using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Script
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var writer = new ScriptWriter(Console.Out);

            var application = new Application();
            application.Tables.Add(new Table(50000, "Foo"));
            application.Tables.Add(new Table(50001, "Baz"));

            application.ToScript(writer);
        }
    }
}