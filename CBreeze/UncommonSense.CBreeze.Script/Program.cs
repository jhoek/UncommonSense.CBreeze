using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Read;

namespace UncommonSense.CBreeze.Script
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Paths.Output.Recreate();
            Paths.Script.Recreate();
            Thread.Sleep(500);

            //foreach (var inputFileName in Directory.GetFiles(Paths.Input, "xml*.txt"))
            foreach (var inputFileName in Directory.GetFiles(Paths.Input))
            {
                var application = ApplicationBuilder.ReadFromFile(inputFileName);
                var invocation = application.ToInvocation().ToString();
                var scriptFileName = Path.Combine(Paths.Script, Path.ChangeExtension(Path.GetFileName(inputFileName), "ps1"));
                File.WriteAllText(scriptFileName, invocation, Encoding.UTF8);
            }

            foreach (var prefix in new[] { "tab", "pag", "rep", "cod", "xml", "que", "men" })
            //foreach (var prefix in new[] { "xml" })
            {
                File.WriteAllLines(
                    Paths.Runner(prefix),
                        @"$ErrorActionPreference = 'Stop'; Import-Module c:\users\jhoek\GitHub\UncommonSense.CBreeze\CBreeze\UncommonSense.CBreeze.Automation\bin\Release\UncommonSense.CBreeze.Automation\UncommonSense.CBreeze.Automation.psd1 -Force -DisableNameCheck"
                        .ToEnumerable()
                        .Concat(
                            Directory
                                .GetFiles(Paths.Script, $"{prefix}*.ps1")
                                .Select(s => $"& {s} | Export-CBreezeApplication -Path {Paths.Output} -Directory")));

                var processStartInfo = new ProcessStartInfo()
                {
                    FileName = @"C:\WINDOWS\System32\WindowsPowerShell\v1.0\powershell.exe",
                    Arguments = $"-NoExit -File {Paths.Runner(prefix)}",
                    WorkingDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
                };

                Process.Start(processStartInfo);
            }
        }
    }
}