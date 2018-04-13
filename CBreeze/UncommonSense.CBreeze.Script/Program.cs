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
            var inputFolderName = args.First();
            var scriptFileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "script.ps1");
            var runnerFileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "runner.ps1");
            var outputFolderName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "output");
            var application = ApplicationBuilder.ReadFromFolder(inputFolderName);

            File.WriteAllText(scriptFileName, application.ToInvocation().ToString(), Encoding.UTF8);
            File.WriteAllText(runnerFileName, $"& {scriptFileName} | Export-CBreezeApplication -Path {outputFolderName} -Directory");

            var processStartInfo = new ProcessStartInfo()
            {
                FileName = @"C:\WINDOWS\System32\WindowsPowerShell\v1.0\powershell.exe",
                Arguments = $"-NoExit -File runner.ps1",
                WorkingDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
            };

            Process.Start(processStartInfo).WaitForExit();        
        }
    }
}