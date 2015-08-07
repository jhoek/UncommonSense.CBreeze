using System;
using System.Collections.Generic;
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
            }
        }
    }
}
