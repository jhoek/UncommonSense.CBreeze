using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.New, "CBreezeReportLabel")]
    [OutputType(typeof(ReportLabel))]
    public class NewCBreezeReportLabel : NewNamedItemCmdlet<ReportLabel, Report>
    {
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

        protected override void AddItemToInputObject(ReportLabel item, Report inputObject)
        {
            inputObject.Labels.Add(item);
        }

        protected override ReportLabel CreateItem()
        {
            var reportLabel = new ReportLabel(ID, Name);
            reportLabel.Properties.CaptionML.Set("ENU", Caption);
            reportLabel.Properties.Description = Description;
            return reportLabel;
        }
    }
}