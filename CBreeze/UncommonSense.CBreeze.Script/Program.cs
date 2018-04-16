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
            var outputFolderName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "output");
            var scriptFolderName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "scripts");
            var runnerFileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "runner.ps1");

            if (Directory.Exists(outputFolderName))
                Directory.Delete(outputFolderName, true);

            if (Directory.Exists(scriptFolderName))
                Directory.Delete(scriptFolderName, true);

            Directory.CreateDirectory(outputFolderName);
            Directory.CreateDirectory(scriptFolderName);

            foreach (var inputFileName in Directory.GetFiles(inputFolderName))
            {
                var application = ApplicationBuilder.ReadFromFile(inputFileName);
                var invocation = application.ToInvocation().ToString();
                var scriptFileName = Path.Combine(scriptFolderName, Path.ChangeExtension(Path.GetFileName(inputFileName), "ps1"));
                File.WriteAllText(scriptFileName, invocation, Encoding.UTF8);
            }

            File.WriteAllLines(runnerFileName, @"Import-Module c:\users\jhoek\GitHub\UncommonSense.CBreeze\CBreeze\UncommonSense.CBreeze.Automation\bin\Debug\UncommonSense.CBreeze.Automation\UncommonSense.CBreeze.Automation.psd1 -Force -DisableNameCheck".Concatenate(Directory.GetFiles(scriptFolderName).Select(s => $"& {s} | Export-CBreezeApplication -Path {outputFolderName} -Directory")));

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