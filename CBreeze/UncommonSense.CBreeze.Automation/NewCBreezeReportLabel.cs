using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.New, "CBreezeReportLabel")]
    public class NewCBreezeReportLabel : Cmdlet
    {
        [Parameter(Mandatory = true, Position = 0)]
        public int ID
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, Position = 1)]
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

        protected virtual int GetID()
        {
            return ID;
        }

        protected ReportLabel CreateReportLabel()
        {
            var reportLabel = new ReportLabel(GetID(), Name);
            reportLabel.Properties.CaptionML.Set("ENU", Caption);
            reportLabel.Properties.Description = Description;
            return reportLabel;
        }

        protected override void ProcessRecord()
        {
            WriteObject(CreateReportLabel());
        }
    }
}
