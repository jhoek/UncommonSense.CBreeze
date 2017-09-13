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
            inputObject.AddChildNode(item, Position.GetValueOrDefault(Core.Position.LastWithinContainer));
        }

        protected override IEnumerable<ColumnReportElement> CreateItems()
        {
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

        [Parameter(ParameterSetName = ParameterSetNames.AddWithID)]
        [Parameter(ParameterSetName = ParameterSetNames.AddWithoutID)]
        public Position? Position { get; set; }

        [Parameter(Mandatory = true, Position = 3, ParameterSetName = ParameterSetNames.NewWithID)]
        [Parameter(Mandatory = true, Position = 2, ParameterSetName = ParameterSetNames.NewWithoutID)]
        [Parameter(Mandatory = true, Position = 3, ParameterSetName = ParameterSetNames.AddWithID)]
        [Parameter(Mandatory = true, Position = 2, ParameterSetName = ParameterSetNames.AddWithoutID)]
        [Parameter(Mandatory = true)]
        public string SourceExpr { get; set; }
    }

    [Cmdlet(VerbsCommon.New, "CBreezeDataItemReportElement", DefaultParameterSetName = ParameterSetNames.NewWithoutID)]
    [Alias("ReportDataItem")]
    [OutputType(typeof(ReportElement))]
    public class NewCBreezeDataItemReportElement : NewItemWithIDCmdlet<ReportElement, int, PSObject>
    {
        protected override void AddItemToInputObject(ReportElement item, PSObject inputObject)
        {
            switch (inputObject.BaseObject)
            {
                case Report r when Position.GetValueOrDefault(Core.Position.LastWithinContainer) == Core.Position.LastWithinContainer:
                    r.Elements.Add(item);
                    break;

                case Report r when Position.GetValueOrDefault(Core.Position.LastWithinContainer) == Core.Position.FirstWithinContainer:
                    r.Elements.Insert(0, item);
                    break;

                case DataItemReportElement e:
                    e.AddChildNode(item, Position.GetValueOrDefault(Core.Position.LastWithinContainer));
                    break;

                default:
                    base.AddItemToInputObject(item, inputObject);
                    break;
            }
        }

        protected int? IndentationLevel => ParameterSetNames.IsNew(ParameterSetName) ? IndentationFromVariable : IndentationFromInputObject;
        protected int IndentationFromVariable => (int)GetVariableValue("Indentation", 0);

        protected int IndentationFromInputObject
        {
            get
            {
                switch (InputObject.BaseObject)
                {
                    case Report r:
                        return 0;

                    case DataItemReportElement e:
                        return e.IndentationLevel.GetValueOrDefault(0) + 1;

                    default:
                        return 0;
                }
            }
        }

        protected override IEnumerable<ReportElement> CreateItems()
        {
            var element = new DataItemReportElement(DataItemTable, ID, IndentationLevel);

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

            yield return element;

            var variables = new List<PSVariable>() { new PSVariable("Indentation", element.IndentationLevel + 1) };
            var subObjects = SubObjects?.InvokeWithContext(null, variables).Select(o => o.BaseObject);

            element.Properties.DataItemTableView.TableFilter.AddRange(subObjects.OfType<TableFilterLine>());

            foreach (var subObject in subObjects.OfType<ReportElement>())
            {
                yield return subObject;
            }
        }

        [Parameter()] public string[] CalcFields { get; set; }

        [Parameter(Mandatory = true, Position = 1, ParameterSetName = ParameterSetNames.NewWithoutID)]
        [Parameter(Mandatory = true, Position = 1, ParameterSetName = ParameterSetNames.AddWithoutID)]
        [Parameter(Mandatory = true, Position = 2, ParameterSetName = ParameterSetNames.NewWithID)]
        [Parameter(Mandatory = true, Position = 2, ParameterSetName = ParameterSetNames.AddWithID)]
        [ValidateRange(1, int.MaxValue)]
        public int DataItemTable { get; set; }

        [Parameter()] public string DataItemLinkReference { get; set; }
        [Parameter()] public string DataItemTableViewKey { get; set; }
        [Parameter()] public Order? DataItemTableViewOrder { get; set; }
        [Parameter()] [ValidateRange(1, int.MaxValue)] public int? MaxIteration { get; set; }

        [Parameter(ParameterSetName = ParameterSetNames.AddWithID)]
        [Parameter(ParameterSetName = ParameterSetNames.AddWithoutID)]
        public Position? Position { get; set; }

        [Parameter()] public bool? PrintOnlyIfDetail { get; set; }
        [Parameter()] public string[] ReqFilterFields { get; set; }
        [Parameter()] public string ReqFilterHeading { get; set; }
#if NAV2015
        [Parameter()] public bool? Temporary { get; set; }
#endif

        [Parameter(Position = 2, ParameterSetName = ParameterSetNames.NewWithoutID)]
        [Parameter(Position = 2, ParameterSetName = ParameterSetNames.AddWithoutID)]
        [Parameter(Position = 3, ParameterSetName = ParameterSetNames.NewWithID)]
        [Parameter(Position = 3, ParameterSetName = ParameterSetNames.AddWithID)]
        public ScriptBlock SubObjects { get; set; }
    }
}