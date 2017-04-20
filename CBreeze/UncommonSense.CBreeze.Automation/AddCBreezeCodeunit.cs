using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.Add, "CBreezeCodeunit")]
    public class AddCBreezeCodeunit : NewCBreezeCodeunit
    {
        public AddCBreezeCodeunit()
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
            var codeunit = CreateCodeunit();
            Application.Codeunits.Add(codeunit);

            if (PassThru)
            {
                WriteObject(codeunit);
            }
        }
    }
}