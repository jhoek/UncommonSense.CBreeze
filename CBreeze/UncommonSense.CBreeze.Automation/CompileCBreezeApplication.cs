using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.IO;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet("Compile", "CBreezeApplication")]
    public class CompileCBreezeApplication : Cmdlet
    {
        public CompileCBreezeApplication()
        {
            DevClientPath = @"C:\Program Files (x86)\Microsoft Dynamics NAV\70\RoleTailored Client\finsql.exe";
            ServerName = ".";
        }

        [Parameter(Mandatory = true, ValueFromPipeline = true)]
        public Application Application
        {
            get;
            set;
        }

        [Parameter()]
        public string DevClientPath
        {
            get;
            set;
        }

        [Parameter()]
        public string ServerName
        {
            get;
            set;
        }

        [Parameter(Mandatory = true)]
        public string Database
        {
            get;
            set;
        }

        protected override void ProcessRecord()
        {
            ApplicationCompiler.Compile(Application, DevClientPath, ServerName, Database);
        }
    }
}
