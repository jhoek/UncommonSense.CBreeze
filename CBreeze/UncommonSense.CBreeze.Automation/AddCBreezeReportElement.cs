using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Common;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.Add, "CBreezeReportElement")]
    public class AddCBreezeReportElement : CmdletWithDynamicParams
    {
        protected DynamicParameter<bool?> AutoCalcField = new DynamicParameter<bool?>("AutoCalcField");
        protected DynamicParameter<string> AutoFormatExpr = new DynamicParameter<string>("AutoFormatExpr");
        protected DynamicParameter<AutoFormatType?> AutoFormatType = new DynamicParameter<AutoFormatType?>("AutoFormatType");
        protected DynamicParameter<SwitchParameter> AutoOptionCaption = new DynamicParameter<SwitchParameter>("AutoOptionCaption");
        protected DynamicParameter<string[]> CalcFields = new DynamicParameter<string[]>("CalcFields");
        protected DynamicParameter<string> DataItemLinkReference = new DynamicParameter<string>("DataItemLinkReference");
        protected DynamicParameter<int?> DataItemTable = new DynamicParameter<int?>("DataItemTable", true);
        protected DynamicParameter<string> DataItemTableViewKey = new DynamicParameter<string>("DataItemTableViewKey");
        protected DynamicParameter<Order?> DataItemTableViewOrder = new DynamicParameter<Order?>("DataItemTableViewOrder");
        protected DynamicParameter<int?> DecimalPlacesAtLeast = new DynamicParameter<int?>("DecimalPlacesAtLeast", minRange: 0, maxRange: int.MaxValue);
        protected DynamicParameter<int?> DecimalPlacesAtMost = new DynamicParameter<int?>("DecimalPlacesAtMost", minRange: 0, maxRange: int.MaxValue);
        protected DynamicParameter<string> Description = new DynamicParameter<string>("Description");
        protected DynamicParameter<int> ID = new DynamicParameter<int>("ID", true, parameterSetNames: new string[] { "ID" });
        protected DynamicParameter<bool?> IncludeCaption = new DynamicParameter<bool?>("IncludeCaption");
        protected DynamicParameter<int?> MaxIteration = new DynamicParameter<int?>("MaxIteration", minRange: 0, maxRange: int.MaxValue);
        protected DynamicParameter<string> OptionString = new DynamicParameter<string>("OptionString");
        protected DynamicParameter<bool?> PrintOnlyIfDetail = new DynamicParameter<bool?>("PrintOnlyIfDetail");
        protected DynamicParameter<ReportElement> ParentElement = new DynamicParameter<ReportElement>("ParentElement", true);
        protected DynamicParameter<SwitchParameter> PassThru = new DynamicParameter<SwitchParameter>("PassThru");
        protected DynamicParameter<IEnumerable<int>> Range = new DynamicParameter<IEnumerable<int>>("Range", true, parameterSetNames: new string[] { "Range" });
        protected DynamicParameter<Report> Report = new DynamicParameter<Report>("Report", true, true);
        protected DynamicParameter<string[]> ReqFilterFields = new DynamicParameter<string[]>("ReqFilterFields");
        protected DynamicParameter<string> ReqFilterHeading = new DynamicParameter<string>("ReqFilterHeader");
        protected DynamicParameter<string> SourceExpr = new DynamicParameter<string>("SourceExpr", true);
#if NAV2015
        protected DynamicParameter<bool?> Temporary = new DynamicParameter<bool?>("Temporary");
#endif

        [Parameter(Mandatory = true, Position = 0)]
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
                    var dataItemReportElement = new DataItemReportElement(GetReportElementID(), ParentElement.Value.IndentationLevel + 1);
                    dataItemReportElement.Properties.CalcFields.AddRange(CalcFields.Value);
                    dataItemReportElement.Properties.DataItemLinkReference = DataItemLinkReference.Value;
                    dataItemReportElement.Properties.DataItemTable = DataItemTable.Value;
                    dataItemReportElement.Properties.DataItemTableView.Key = DataItemTableViewKey.Value;
                    dataItemReportElement.Properties.DataItemTableView.Order = DataItemTableViewOrder.Value;
                    dataItemReportElement.Properties.MaxIteration = MaxIteration.Value;
                    dataItemReportElement.Properties.PrintOnlyIfDetail = PrintOnlyIfDetail.Value;
                    dataItemReportElement.Properties.ReqFilterFields.AddRange(ReqFilterFields.Value);
                    dataItemReportElement.Properties.ReqFilterHeadingML.Set("ENU", ReqFilterHeading.Value);
#if NAV2015
                    dataItemReportElement.Properties.Temporary = Temporary.Value;
#endif
                    return dataItemReportElement;

                case ReportElementType.Column:
                    var columnReportElement = new ColumnReportElement(GetReportElementID(), ParentElement.Value.IndentationLevel + 1);
                    columnReportElement.Properties.AutoCalcField = AutoCalcField.Value;
                    columnReportElement.Properties.AutoFormatExpr = AutoFormatExpr.Value;
                    columnReportElement.Properties.AutoFormatType = AutoFormatType.Value;
                    columnReportElement.Properties.DecimalPlaces.AtLeast = DecimalPlacesAtLeast.Value;
                    columnReportElement.Properties.DecimalPlaces.AtMost = DecimalPlacesAtMost.Value;
                    columnReportElement.Properties.Description = Description.Value;
                    columnReportElement.Properties.IncludeCaption = IncludeCaption.Value;
                    columnReportElement.Properties.OptionString = OptionString.Value;
                    columnReportElement.Properties.SourceExpr = SourceExpr.Value;

                    if (AutoOptionCaption.Value)
                        columnReportElement.Properties.OptionCaptionML.Set("ENU", columnReportElement.Properties.OptionString);

                    return columnReportElement;

                default:
                    throw new ArgumentOutOfRangeException("Type");
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

                switch (Type)
                {
                    case ReportElementType.DataItem:
                        yield return CalcFields.RuntimeDefinedParameter;
                        yield return DataItemLinkReference.RuntimeDefinedParameter;
                        yield return DataItemTable.RuntimeDefinedParameter;
                        yield return DataItemTableViewKey.RuntimeDefinedParameter;
                        yield return DataItemTableViewOrder.RuntimeDefinedParameter;
                        yield return MaxIteration.RuntimeDefinedParameter;
                        yield return PrintOnlyIfDetail.RuntimeDefinedParameter;
                        yield return ReqFilterFields.RuntimeDefinedParameter;
                        yield return ReqFilterHeading.RuntimeDefinedParameter;
#if NAV2015
                        yield return Temporary.RuntimeDefinedParameter;
#endif
                        break;

                    case ReportElementType.Column:
                        yield return AutoCalcField.RuntimeDefinedParameter;
                        yield return AutoFormatExpr.RuntimeDefinedParameter;
                        yield return AutoFormatType.RuntimeDefinedParameter;
                        yield return AutoOptionCaption.RuntimeDefinedParameter;
                        yield return DecimalPlacesAtLeast.RuntimeDefinedParameter;
                        yield return DecimalPlacesAtMost.RuntimeDefinedParameter;
                        yield return Description.RuntimeDefinedParameter;
                        yield return IncludeCaption.RuntimeDefinedParameter;
                        yield return OptionString.RuntimeDefinedParameter;
                        yield return SourceExpr.RuntimeDefinedParameter;
                        break;
                }
            }
        }
    }
}
