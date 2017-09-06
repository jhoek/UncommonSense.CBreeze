using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.New, "CBreezeColumnReportElement", DefaultParameterSetName = ParameterSetNames.NewWithoutID)]
    [Alias("ReportColumn")]
    [OutputType(typeof(ColumnReportElement))]
    public class NewCBreezeColumnReportElement : NewItemWithIDAndNameCmdlet<ColumnReportElement, int, DataItemReportElement>
    {
        protected override void AddItemToInputObject(ColumnReportElement item, DataItemReportElement inputObject)
        {
            // FIXME: inputObject.AddChildNode(item, Position.GetValueOrDefault(Core.Position.LastWithinContainer));
        }

        protected override IEnumerable<ColumnReportElement> CreateItems()
        {
            // FIXME: Should indentation for column be nullable?
            var element = new ColumnReportElement(Name, SourceExpr, ID, IndentationLevel);

            element.Properties.AutoCalcField = AutoCalcField;
            element.Properties.AutoFormatExpr = AutoFormatExpr;
            element.Properties.AutoFormatType = AutoFormatType;
            element.Properties.DecimalPlaces.AtLeast = DecimalPlacesAtLeast;
            element.Properties.DecimalPlaces.AtMost = DecimalPlacesAtMost;
            element.Properties.Description = Description;
            element.Properties.IncludeCaption = IncludeCaption;
            element.Properties.OptionString = OptionString;
            element.Properties.OptionCaptionML.Set(OptionCaptionML);

            if (AutoOptionCaption)
                element.Properties.OptionCaptionML.Set("ENU", element.Properties.OptionString);

            yield return element;
        }

        protected int? IndentationLevel => ParameterSetNames.IsNew(ParameterSetName) ? IndentationFromVariable : IndentationFromInputObject;
        protected int IndentationFromVariable => (int)GetVariableValue("Indentation", 0);
        protected int IndentationFromInputObject => InputObject.IndentationLevel.GetValueOrDefault(0) + 1;

        [Parameter()] public Hashtable OptionCaptionML { get; set; }
        [Parameter()] public string OptionString { get; set; }
        [Parameter()] public bool? AutoCalcField { get; set; }
        [Parameter()] public string AutoFormatExpr { get; set; }
        [Parameter()] public AutoFormatType? AutoFormatType { get; set; }
        [Parameter()] public SwitchParameter AutoOptionCaption { get; set; }
        [Parameter()] [ValidateRange(0, int.MaxValue)] public int? DecimalPlacesAtLeast { get; set; }
        [Parameter()] [ValidateRange(0, int.MaxValue)] public int? DecimalPlacesAtMost { get; set; }
        [Parameter()] public string Description { get; set; }
        [Parameter()] public bool? IncludeCaption { get; set; }

        [Parameter(ParameterSetName=ParameterSetNames.AddWithID)]
        [Parameter(ParameterSetName =ParameterSetNames.AddWithoutID)]
        public Position? Position { get; set; }

        [Parameter(Mandatory = true)] public string SourceExpr { get; set; }
    }

    [Cmdlet(VerbsCommon.New, "CBreezeDataItemReportElement", DefaultParameterSetName = ParameterSetNames.NewWithoutID)]
    [Alias("ReportDataItem")]
    [OutputType(typeof(DataItemReportElement))]
    public class NewCBreezeDataItemReportElement : NewItemWithIDCmdlet<DataItemReportElement, int, PSObject>
    {
        protected override void AddItemToInputObject(DataItemReportElement item, PSObject inputObject)
        {
            throw new NotImplementedException();
        }

        protected override IEnumerable<DataItemReportElement> CreateItems()
        {
            throw new NotImplementedException();
        }
    }
}