using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Core.Report;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.New, "CBreezeReportLink", DefaultParameterSetName = ParameterSetNames.NewWithoutID)]
    [Alias("ReportLink", "Add-CBreezeReportLink")]
    [OutputType(typeof(ReportDataItemLinkLine))]
    public class NewCBreezeReportLink : NewItemCmdlet<ReportDataItemLinkLine, DataItemReportElement>
    {
        protected override void AddItemToInputObject(ReportDataItemLinkLine item, DataItemReportElement inputObject)
        {
            inputObject.Properties.DataItemLink.Add(item);
        }

        protected override IEnumerable<ReportDataItemLinkLine> CreateItems()
        {
            yield return new ReportDataItemLinkLine(FieldName, ReferenceFieldName);
        }

        [Parameter(Mandatory = true, Position = 1)]
        public string FieldName { get; set; }

        [Parameter(Mandatory = true, Position = 2)]
        public string ReferenceFieldName { get; set; }
    }
}
