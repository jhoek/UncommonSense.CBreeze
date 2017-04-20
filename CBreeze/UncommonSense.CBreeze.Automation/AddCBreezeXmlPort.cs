using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.Add, "CBreezeXmlPort")]
    public class AddCBreezeXmlPort : NewCBreezeXmlPort
    {
        public AddCBreezeXmlPort()
        {
            PassThru = true;
        }

        [Parameter(Mandatory = true, ValueFromPipeline = true)]
        public Application Application
        {
            get; set;
        }

        [Parameter()]
        public SwitchParameter PassThru
        {
            get; set;
        }

        protected override void ProcessRecord()
        {
            var xmlPort = CreateXmlPort();
            Application.XmlPorts.Add(xmlPort);

            if (PassThru)
            {
                WriteObject(xmlPort);
            }
        }
    }
}