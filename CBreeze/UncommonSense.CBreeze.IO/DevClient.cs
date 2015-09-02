using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace UncommonSense.CBreeze.IO
{
    public static class DevClient
    {
        public static void Run(string fileName, Arguments arguments)
        {
            var logFileName = Path.GetTempFileName();
            var resultFileName = Path.Combine(Path.GetDirectoryName(logFileName), "navcommandresult.txt");

            arguments.Add("logfile", logFileName);

            var processStartInfo = new ProcessStartInfo();
            processStartInfo.FileName = fileName;
            processStartInfo.Arguments = arguments.ToString();
            processStartInfo.UseShellExecute = false;

            try
            {
                Process.Start(processStartInfo).WaitForExit();

                if (File.Exists(logFileName))
                {
                    var lines = File.ReadAllLines(logFileName).Where(l=>!l.Contains("Caution: Your program license expires in"));

                    if (lines.Any())
                    {
                        throw new ApplicationException(string.Join("\n", lines));
                    }
                }
            }
            finally
            {
                File.Delete(logFileName);
                File.Delete(resultFileName);
            }
        }
    }
}
