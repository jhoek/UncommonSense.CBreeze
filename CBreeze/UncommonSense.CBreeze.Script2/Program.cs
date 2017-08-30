using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Read;

namespace UncommonSense.CBreeze.Script2
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            foreach (var arg in args)
            {
                var scriptFileName = Path.ChangeExtension(arg, ".ps1");
                var application = ApplicationBuilder.FromFile(arg);

                File.WriteAllText(scriptFileName, application.ToInvocation().ToString());
            }
        }
    }
}