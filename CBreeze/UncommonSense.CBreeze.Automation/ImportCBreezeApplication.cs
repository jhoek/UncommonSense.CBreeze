using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Read;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsData.Import, "CBreezeApplication", DefaultParameterSetName = "FromPath")]
    [OutputType(typeof(Application))]
    public class ImportCBreezeApplication : PSCmdlet
    {
        public ImportCBreezeApplication()
        {
            DevClientPath = @"C:\Program Files (x86)\Microsoft Dynamics NAV\70\RoleTailored Client\finsql.exe";
            ServerName = ".";
        }

        [Parameter(Mandatory = true, Position = 0, ParameterSetName = "FromPath")]
        public string Path
        {
            get;
            set;
        }

        [Parameter(ParameterSetName = "FromDatabase")]
        public string DevClientPath
        {
            get;
            set;
        }

        [Parameter(ParameterSetName = "FromDatabase")]
        public string ServerName
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, ParameterSetName = "FromDatabase")]
        public string Database
        {
            get;
            set;
        }

        [Parameter(ParameterSetName="FromDatabase")]
        public string Filter
        {
            get;
            set;
        }

        protected override void ProcessRecord()
        {
            switch (ParameterSetName)
            {
                case "FromPath":
                    WriteObject(ApplicationBuilder.FromFile(Path));
                    break;
                case "FromDatabase":
                    var tempFileName = System.IO.Path.ChangeExtension(System.IO.Path.GetTempFileName(), "txt");
                    var logFileName = System.IO.Path.GetTempFileName();
                    var resultFileName = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "navcommandresult.txt");

                    var arguments = new Dictionary<string, string>();
                    arguments.Add("command", "exportobjects");
                    arguments.Add("file", tempFileName);
                    arguments.Add("servername", ServerName);
                    arguments.Add("database", Database);
                    arguments.Add("logfile", logFileName);
                    arguments.Add("filter", Filter);
                    arguments.Add("ntauthentication", "1");

                    var processStartInfo = new ProcessStartInfo();
                    processStartInfo.FileName = DevClientPath;
                    processStartInfo.Arguments = string.Join(", ", arguments.Where(k => !string.IsNullOrEmpty(k.Value)).Select(k => string.Format("{0}={1}", k.Key, k.Value)));
                    processStartInfo.UseShellExecute = false;

                    try
                    {
                        Process.Start(processStartInfo).WaitForExit();

                        if (File.Exists(logFileName))
                        {
                            throw new ApplicationException(File.ReadAllText(logFileName));
                        }

                        WriteObject(ApplicationBuilder.FromFile(tempFileName));
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

                    break;
            }
        }
    }
}
