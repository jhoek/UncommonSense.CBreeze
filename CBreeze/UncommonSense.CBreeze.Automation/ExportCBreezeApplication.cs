using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Write;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsData.Export, "CBreezeApplication")]
    public class ExportCBreezeApplication : PSCmdlet
    {
        public ExportCBreezeApplication()
        {
            DevClientPath = @"C:\Program Files (x86)\Microsoft Dynamics NAV\70\RoleTailored Client\finsql.exe";
            ServerName = ".";
            ImportAction = "Skip";
        }

        [Parameter(Mandatory=true,ValueFromPipeline=true)]
        public Application Application
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, ParameterSetName = "ToPath")]
        public string Path
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, ParameterSetName = "ToTextWriter")]
        public TextWriter TextWriter
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, ParameterSetName = "ToStream")]
        public Stream Stream
        {
            get;
            set;
        }

        [Parameter(ParameterSetName = "ToDatabase")]
        public string DevClientPath
        {
            get;
            set;
        }

        [Parameter(ParameterSetName = "ToDatabase")]
        public string ServerName
        {
            get;
            set;
        }

        [Parameter(Mandatory=true,ParameterSetName="ToDatabase")]
        public string Database
        {
            get;
            set;
        }

        [Parameter(ParameterSetName = "ToDatabase")]
        [ValidateSet("Default", "Overwrite", "Skip")]
        public string ImportAction
        {
            get;
            set;
        }

        protected override void ProcessRecord()
        {
            switch (ParameterSetName)
            {
                case "ToPath":
                    Application.Write(Path);
                    break;
                case "ToTextWriter":
                    Application.Write(TextWriter);
                    break;
                case "ToStream":
                    Application.Write(Stream);
                    break;
                case "ToDatabase":
                    var tempFileName = System.IO.Path.ChangeExtension(System.IO.Path.GetTempFileName(), "txt");
                    var logFileName = System.IO.Path.GetTempFileName();
                    var resultFileName = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "navcommandresult.txt");

                    Application.Write(tempFileName);

                    var arguments = new Dictionary<string, string>();
                    arguments.Add("command", "importobjects");
                    arguments.Add("file", tempFileName);
                    arguments.Add("servername", ServerName);
                    arguments.Add("database", Database);
                    arguments.Add("logfile", logFileName);
                    arguments.Add("importaction", ImportAction);
                    arguments.Add("ntauthentication", "1");

                    var processStartInfo = new ProcessStartInfo();
                    processStartInfo.FileName = DevClientPath;
                    processStartInfo.Arguments = string.Join(", ", arguments.Where(k=>!string.IsNullOrEmpty(k.Value)).Select(k => string.Format("{0}={1}", k.Key, k.Value)));
                    processStartInfo.UseShellExecute = false;

                    try
                    {
                        Process.Start(processStartInfo).WaitForExit();

                        if (File.Exists(logFileName))
                        {
                            var errorText = File.ReadAllText(logFileName);
                            throw new ApplicationException(errorText);
                        }
                    }
                    finally
                    {
                        if (File.Exists(tempFileName))
                        {
                            File.Delete(tempFileName);
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
