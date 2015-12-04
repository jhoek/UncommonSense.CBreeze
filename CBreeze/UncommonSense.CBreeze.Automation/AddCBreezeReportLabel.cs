using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.Add, "CBreezeReportLabel")]
    public class AddCBreezeReportLabel : Cmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipeline = true)]
        public Report Report
        {
            get;
            set;
        }

        [Parameter(Mandatory = true)]
        [Alias("Range")]
        public PSObject ID
        {
            get;
            set;
        }

        //[Parameter(Mandatory = true, ParameterSetName = "Range")]
        //public IEnumerable<int> Range
        //{
        //    get;
        //    set;
        //}

        [Parameter(Mandatory = true)]
        public string Name
        {
            get;
            set;
        }

        [Parameter()]
        public string Caption
        {
            get;
            set;
        }

        [Parameter()]
        public string Description
        {
            get;
            set;
        }

        protected int GetReportLabelID()
        {
            return ID.GetID(Report.Labels.Select(l => l.ID), Report.ID);
        }

        protected override void ProcessRecord()
        {
            var reportLabel = new ReportLabel(GetReportLabelID(), Name);
            reportLabel.Properties.CaptionML.Set("ENU", Caption);
            reportLabel.Properties.Description = Description;

            Report.Labels.Add(reportLabel);
        }
    }
}
