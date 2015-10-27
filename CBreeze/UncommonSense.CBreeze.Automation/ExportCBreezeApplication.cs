using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.IO;
using UncommonSense.CBreeze.Write;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsData.Export, "CBreezeApplication", DefaultParameterSetName = "ToPath")]
    public class ExportCBreezeApplication : PSCmdlet
    {
        public ExportCBreezeApplication()
        {
            DevClientPath = @"C:\Program Files (x86)\Microsoft Dynamics NAV\70\RoleTailored Client\finsql.exe";
            ServerName = ".";
            ImportAction = "Skip";
        }

        [Parameter(Mandatory = true, ValueFromPipeline = true)]
        public Application Application
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, ParameterSetName = "ToPath", Position = 0)]
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

        [Parameter(Mandatory = true, ParameterSetName = "ToDatabase")]
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
                    ApplicationImporter.Import(Application, DevClientPath, ServerName, Database);
                    break;
            }
        }
    }
}
