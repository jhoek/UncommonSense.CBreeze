using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Write;

namespace UncommonSense.CBreeze.IO
{
    public static class ApplicationReader
    {
        // Reads from database, imports into Application object

        public static void Read(this Application application,string devClient, string serverName, string database, string filter)
        {
            var tempFileName = Path.ChangeExtension(Path.GetTempFileName(), "txt");
            var logFileName = Path.GetTempFileName();
            var resultFileName = Path.Combine(Path.GetTempPath(), "navcommandresult.txt");

            var arguments = new Arguments();
            arguments.Add("command", "exportobjects");
            arguments.Add("file", tempFileName);
            arguments.Add("servername", serverName);
            arguments.Add("database", database);
            arguments.Add("logfile", logFileName);
            arguments.Add("filter", filter);
            arguments.Add("ntauthentication", "1");

            var processStartInfo = new ProcessStartInfo();
            processStartInfo.FileName = devClient;
            processStartInfo.Arguments = arguments.ToString();
            processStartInfo.UseShellExecute = false;

            try
            {
                Process.Start(processStartInfo).WaitForExit();

                if (File.Exists(logFileName))
                {
                    var lines = File.ReadAllLines(logFileName).Where(l => !l.Contains("Caution: Your program license expires in"));

                    if (lines.Any())
                    {
                        throw new ApplicationException(string.Join("\n", lines));
                    }
                }
            }
            finally
            {
                if (File.Exists(tempFileName))
                {
                    File.Delete(tempFileName);
                }

                if (File.Exists(logFileName))
                {
                    File.Delete(logFileName);
                }

                if (File.Exists(resultFileName))
                {
                    File.Delete(resultFileName);
                }
            }
        }
    }
}
