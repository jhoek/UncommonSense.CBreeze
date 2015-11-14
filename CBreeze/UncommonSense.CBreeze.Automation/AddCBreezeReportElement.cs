using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Utils;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.Add, "CBreezeReportElement")]
    public class AddCBreezeReportElement : CmdletWithDynamicParams
    {
        protected DynamicParameter<int> ID = new DynamicParameter<int>("ID", true, "ID");
        protected DynamicParameter<ReportElement> ParentElement = new DynamicParameter<ReportElement>("ParentElement", true);
        protected DynamicParameter<SwitchParameter> PassThru = new DynamicParameter<SwitchParameter>("PassThru");
        protected DynamicParameter<IEnumerable<int>> Range = new DynamicParameter<IEnumerable<int>>("Range", true, "Range");
        protected DynamicParameter<Report> Report = new DynamicParameter<Report>("Report", true, true);

        [Parameter(Mandatory = true)]
        public ReportElementType Type
        {
            get;
            set;
        }

        protected ReportElement CreateReportElement()
        {
            switch (Type)
            {
                case ReportElementType.DataItem:
                    var element = new DataItemReportElement(GetReportElementID(), ParentElement.Value.IndentationLevel + 1);
                    return element;

                case ReportElementType.Column:
                    var element = new ColumnReportElement(GetReportElementID());
                    return element;
            }
        }

        protected int GetReportElementID()
        {
            if (ID.Value != 0)
                return ID.Value;

            var range = Range.Value;
            if (range.Contains(Report.Value.ID))
                range = 1.To(int.MaxValue);

            return range.Except(Report.Value.Elements.Select(e => e.ID)).First();
        }

        protected override void ProcessRecord()
        {
            var reportElement = Report.Value.Elements.Add(CreateReportElement());

            if (PassThru.Value)
                WriteObject(reportElement);
        }

        public override IEnumerable<RuntimeDefinedParameter> DynamicParameters
        {
            get
            {
                yield return ID.RuntimeDefinedParameter;
                yield return ParentElement.RuntimeDefinedParameter;
                yield return PassThru.RuntimeDefinedParameter;
                yield return Range.RuntimeDefinedParameter;
                yield return Report.RuntimeDefinedParameter;
            }
        }
    }
}
