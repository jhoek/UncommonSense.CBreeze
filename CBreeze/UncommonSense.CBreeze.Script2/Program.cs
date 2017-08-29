using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Script2
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var application = new Application();

            var table = new Table(50000, "Foo");
            table.ObjectProperties.DateTime = DateTime.Now;
            table.ObjectProperties.VersionList = "NAVJH1.00";
            application.Tables.Add(table);

            var table2 = new Table(50001, "Baz");
            application.Tables.Add(table2);

            application.ScriptTo(new IndentedTextWriter(Console.Out), useAliases: true, usePositionalParameters: true);
        }
    }
}