using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management.Automation;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Write;
using System.IO;

namespace UncommonSense.CBreeze.PowerShell
{
    [Cmdlet(VerbsData.ConvertTo, "NavObjectText")]
    public class ConvertToNavObjectText : PSCmdlet
    {
        private Application application;

        [Parameter(ValueFromPipeline = true, ValueFromPipelineByPropertyName = true, Mandatory = true)]
        public Application Application
        {
            get
            {
                return this.application;
            }
            set
            {
                this.application = value;
            }
        }

        protected override void ProcessRecord()
        {
            var stringBuilder = new StringBuilder();

            using (var stringWriter = new StringWriter(stringBuilder))
            {
                Application.Write(stringWriter);
            }

            WriteObject(stringBuilder.ToString());
        }
    }
}
