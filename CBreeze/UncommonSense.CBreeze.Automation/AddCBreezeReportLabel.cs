using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.Add, "CBreezeReportLabel")]
    public class AddCBreezeReportLabel : NewCBreezeReportLabel
    {
        [Parameter(Mandatory = true, ValueFromPipeline = true)]
        public Report Report
        {
            get;
            set;
        }

        protected override void ProcessRecord()
        {
            Report.Labels.Add(CreateReportLabel());
        }
    }
}