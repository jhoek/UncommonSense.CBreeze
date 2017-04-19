using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.Add, "CBreezeDataItemReportElement")]
    public class AddCBreezeDataItemReportElement : Cmdlet
    {
        [Parameter(Mandatory = true, ParameterSetName = "ID")]
        public int ID { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = "Range")]
        public IEnumerable<int> Range { get; set; }

        [Parameter()]
        public ReportElement ParentElement { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true)]
        public Report Report { get; set; }

        [Parameter()]
        public SwitchParameter PassThru { get; set; }

        [Parameter()]
        public string[] CalcFields { get; set; }

        [Parameter(Mandatory = true)]
        public int? DataItemTable { get; set; }

        [Parameter()]
        public string DataItemLinkReference { get; set; }

        [Parameter()]
        public string DataItemTableViewKey { get; set; }

        [Parameter()]
        public Order? DataItemTableViewOrder { get; set; }

        [Parameter()]
        [ValidateRange(0, int.MaxValue)]
        public int? MaxIteration { get; set; }

        [Parameter()]
        public bool? PrintOnlyIfDetail { get; set; }

        [Parameter()]
        public string[] ReqFilterFields { get; set; }

        [Parameter()]
        public string ReqFilterHeading { get; set; }

#if NAV2015

        [Parameter()]
        public bool? Temporary { get; set; }

#endif

        protected override void ProcessRecord()
        {
            Report.Elements.Range = Range;

            var element = Report.Elements.Add(new DataItemReportElement(DataItemTable, ID, (ParentElement?.IndentationLevel ?? 0) + 1));
            element.Properties.CalcFields.AddRange(CalcFields);
            element.Properties.DataItemLinkReference = DataItemLinkReference;
            element.Properties.DataItemTableView.Key = DataItemTableViewKey;
            element.Properties.DataItemTableView.Order = DataItemTableViewOrder;
            element.Properties.MaxIteration = MaxIteration;
            element.Properties.PrintOnlyIfDetail = PrintOnlyIfDetail;
            element.Properties.ReqFilterFields.AddRange(ReqFilterFields);
            element.Properties.ReqFilterHeadingML.Set("ENU", ReqFilterHeading);
#if NAV2015
            element.Properties.Temporary = Temporary;
#endif

            if (PassThru)
                WriteObject(element);
        }
    }
}