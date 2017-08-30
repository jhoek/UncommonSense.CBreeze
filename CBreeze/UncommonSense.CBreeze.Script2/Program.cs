using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
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

            var codeField = new CodeTableField("Code", 20);
            codeField.Properties.NotBlank = true;
            table.Fields.Add(codeField);

            var key = new TableKey("Code");
            table.Keys.Add(key);

            var function = new Function("Foo");
            function.Local = true;
            table.Code.Functions.Add(function);

            application.Tables.Add(table);

            var table2 = new Table(50001, "Baz");
            application.Tables.Add(table2);

            Console.WriteLine(application.ToInvocation().ToString());
            File.WriteAllText(
                Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "script.ps1"), 
                application.ToInvocation().ToString());
        }
    }
}