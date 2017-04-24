using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.Add, "CBreezeColumnReportElement")]
    public class AddCBreezeColumnReportElement : Cmdlet
    {
        [Parameter()]
        public bool? AutoCalcField { get; set; }

        [Parameter()]
        public string AutoFormatExpr { get; set; }

        [Parameter()]
        public AutoFormatType? AutoFormatType { get; set; }

        [Parameter()]
        public SwitchParameter AutoOptionCaption { get; set; }

        [Parameter()]
        [ValidateRange(0, int.MaxValue)]
        public int? DecimalPlacesAtLeast { get; set; }

        [Parameter()]
        [ValidateRange(0, int.MaxValue)]
        public int? DecimalPlacesAtMost { get; set; }

        [Parameter()]
        public string Description { get; set; }

        [Parameter(Mandatory = true)]
        public int ID { get; set; }

        [Parameter()]
        public bool? IncludeCaption { get; set; }

        [Parameter(Mandatory = true)]
        public string Name { get; set; }

        [Parameter()]
        public string OptionString { get; set; }

        [Parameter()]
        public ReportElement ParentElement { get; set; }

        [Parameter()]
        public SwitchParameter PassThru { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true)]
        public Report Report { get; set; }

        [Parameter(Mandatory = true)]
        public string SourceExpr { get; set; }

        protected override void ProcessRecord()
        {
            var element = Report.Elements.Add(new ColumnReportElement(Name, SourceExpr, ID, (ParentElement?.IndentationLevel ?? 0) + 1));
            element.Properties.AutoCalcField = AutoCalcField;
            element.Properties.AutoFormatExpr = AutoFormatExpr;
            element.Properties.AutoFormatType = AutoFormatType;
            element.Properties.DecimalPlaces.AtLeast = DecimalPlacesAtLeast;
            element.Properties.DecimalPlaces.AtMost = DecimalPlacesAtMost;
            element.Properties.Description = Description;
            element.Properties.IncludeCaption = IncludeCaption;
            element.Properties.OptionString = OptionString;

            if (AutoOptionCaption)
                element.Properties.OptionCaptionML.Set("ENU", element.Properties.OptionString);

            if (PassThru)
                WriteObject(element);
        }
    }
}