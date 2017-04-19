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

        [Parameter(Mandatory = true, Position=0)]
        [Alias("Range")]
        public new PSObject ID
        {
            get;
            set;
        }

        protected override int GetID()
        {
            return ID.GetID(Report.Labels.Select(l => l.ID), Report.ID);
        }

        protected override void ProcessRecord()
        {
            Report.Labels.Add(CreateReportLabel());
        }
    }
}
