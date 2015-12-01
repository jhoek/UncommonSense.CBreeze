using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.IO;
using UncommonSense.CBreeze.Read;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsData.Import, "CBreezeApplication", DefaultParameterSetName = "FromPath")]
    [OutputType(typeof(Application))]
    public class ImportCBreezeApplication : PSCmdlet
    {
        public ImportCBreezeApplication()
        {
#if NAV2016
            DevClientPath = @"C:\Program Files (x86)\Microsoft Dynamics NAV\90\RoleTailored Client\finsql.exe";
#elif NAV2015
            DevClientPath = @"C:\Program Files (x86)\Microsoft Dynamics NAV\80\RoleTailored Client\finsql.exe";
#elif NAV2013R2
            DevClientPath = @"C:\Program Files (x86)\Microsoft Dynamics NAV\71\RoleTailored Client\finsql.exe";
#else
            DevClientPath = @"C:\Program Files (x86)\Microsoft Dynamics NAV\70\RoleTailored Client\finsql.exe";
#endif
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
                    WriteObject(ApplicationExporter.Export(DevClientPath, ServerName, Database, Filter));
                    break;
            }
        }
    }
}
