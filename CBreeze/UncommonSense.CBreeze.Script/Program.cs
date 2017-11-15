using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Read;

namespace UncommonSense.CBreeze.Script
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            foreach (var arg in args)
            {
                var scriptFileName = Path.ChangeExtension(arg, ".ps1");
                var application = ApplicationBuilder.ReadFromFiles(arg);

                File.WriteAllText(scriptFileName, application.ToInvocation().ToString(), Encoding.UTF8);

                //var processStartInfo = new ProcessStartInfo()
                //{
                //    FileName = @"C:\WINDOWS\System32\WindowsPowerShell\v1.0\powershell.exe",
                //    Arguments = $"-NoExit -File test.ps1",
                //    WorkingDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
                //};

                //Process.Start(processStartInfo);
            }
        }
    }
}