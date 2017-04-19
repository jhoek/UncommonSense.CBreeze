using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.Add, "CBreezeReport", DefaultParameterSetName = "ManualObjectProperties")]
    public class AddCBreezeReport : NewCBreezeReport
    {
        public AddCBreezeReport()
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
            var report = CreateReport();
            Application.Reports.Add(report);

            if (PassThru)
            {
                WriteObject(report);
            }
        }
    }
}
