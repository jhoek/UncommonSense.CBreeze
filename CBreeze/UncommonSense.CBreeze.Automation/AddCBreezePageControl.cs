using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Utils;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.Add, "CBreezePageControl", DefaultParameterSetName = FieldPageControlWithRange)]
    public class AddCBreezePageControl : CmdletWithDynamicParams
    {
        private const string ChartPartWithID = "ChartPartWithID";
        private const string ChartPartWithRange = "ChartPartWithRange";
        private const string PagePartWithID = "PagePartWithID";
        private const string PagePartWithRange = "PagePartWithRange";
        private const string SystemPartWithID = "SystemPartWithID";
        private const string SystemPartWithRange = "SystemPartWithRange";
        private const string FieldPageControlWithID = "FieldPageControlWithID";
        private const string FieldPageControlWithRange = "FieldPageControlWithRange";

        public AddCBreezePageControl()
        {
            AssistEdit = new DynamicParameter<bool?>("AssistEdit");
            AutoFormatExpr = new DynamicParameter<string>("AutoFormatExpr");
            AutoFormatType = new DynamicParameter<Core.AutoFormatType?>("AutoFormatType");
            BlankNumbers = new DynamicParameter<Core.BlankNumbers?>("BlankNumbers");
            BlankZero = new DynamicParameter<bool?>("BlankZero");
            CaptionClass = new DynamicParameter<string>("CaptionClass");
            CharAllowed = new DynamicParameter<string>("CharAllowed");
            ChartPartID = new DynamicParameter<string>("ChartPartID", ChartPartWithID, ChartPartWithRange);
            ClosingDates = new DynamicParameter<bool?>("ClosingDates");
            ColumnSpan = new DynamicParameter<int?>("ColumnSpan");
            ContainerType = new DynamicParameter<ContainerType?>("ContainerType");
            ControlAddIn = new DynamicParameter<string>("ControlAddIn");
            DateFormula = new DynamicParameter<bool?>("DateFormula");
            DecimalPlacesAtLeast = new DynamicParameter<int?>("DecimalPlacesAtLeast", 0, int.MaxValue);
            DecimalPlacesAtMost = new DynamicParameter<int?>("DecimalPlacesAtMost", 0, int.MaxValue);
            DrillDown = new DynamicParameter<bool?>("DrillDown");
            DrillDownPageID = new DynamicParameter<string>("DrillDownPageID");
            Editable = new DynamicParameter<string>("Editable");
            Enabled = new DynamicParameter<string>("Enabled");
            ExtendedDataType = new DynamicParameter<Core.ExtendedDataType?>("ExtendedDataType");
            FreezeColumnID = new DynamicParameter<string>("FreezeColumnID");
            GroupType = new DynamicParameter<Core.GroupType?>("GroupType");
            HideValue = new DynamicParameter<string>("HideValue");
            Importance = new DynamicParameter<Core.Importance?>("Importance");
            IndentationColumnName = new DynamicParameter<string>("IndentationColumnName");
            IndentationControls = new DynamicParameter<string[]>("IndentationControls");
            Layout = new DynamicParameter<GroupPageControlLayout?>("Layout");
            Lookup = new DynamicParameter<bool?>("Lookup");
            LookupPageID = new DynamicParameter<string>("LookupPageID");
            MaxValue = new DynamicParameter<object>("MaxValue");
            MinValue = new DynamicParameter<object>("MinValue");
            MultiLine = new DynamicParameter<bool?>("MultiLine");
            NotBlank = new DynamicParameter<bool?>("NotBlank");
            Numeric = new DynamicParameter<bool?>("Numeric");
            PagePartID = new DynamicParameter<int?>("PagePartID", PagePartWithID, PagePartWithRange);
            QuickEntry = new DynamicParameter<string>("QuickEntry");
            SystemPartID = new DynamicParameter<SystemPartID?>("SystemPartID", SystemPartWithID, SystemPartWithRange);
            ProviderID = new DynamicParameter<int?>("ProviderID");
            RowSpan = new DynamicParameter<int?>("RowSpan");
            ShowAsTree = new DynamicParameter<bool?>("ShowAsTree");
            ShowCaption = new DynamicParameter<bool?>("ShowCaption");
            ShowFilter = new DynamicParameter<bool?>("ShowFilter");
            SourceExpr = new DynamicParameter<string>("SourceExpr", true, FieldPageControlWithID, FieldPageControlWithRange);
            Style = new DynamicParameter<Core.Style?>("Style");
            StyleExpr = new DynamicParameter<string>("StyleExpr");
            SubPageViewKey = new DynamicParameter<string>("SubPageViewKey");
            SubPageViewOrder = new DynamicParameter<Order?>("SubPageViewOrder");
            Title = new DynamicParameter<bool?>("Title");
            ValuesAllowed = new DynamicParameter<string>("ValuesAllowed");
            Visible = new DynamicParameter<string>("Visible");
            Width = new DynamicParameter<int?>("Width");
        }

        [Parameter(Mandatory = true, ValueFromPipeline = true)]
        public Page Page
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, ParameterSetName = ChartPartWithRange)]
        [Parameter(Mandatory = true, ParameterSetName = PagePartWithRange)]
        [Parameter(Mandatory = true, ParameterSetName = SystemPartWithRange)]
        [Parameter(Mandatory = true, ParameterSetName = ChartPartWithID)]
        [Parameter(Mandatory = true, ParameterSetName = PagePartWithID)]
        [Parameter(Mandatory = true, ParameterSetName = SystemPartWithID)]
        [Parameter(Mandatory = true, ParameterSetName = FieldPageControlWithID)]
        [Parameter(Mandatory = true, ParameterSetName = FieldPageControlWithRange)]
        public PageControlType Type
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, ParameterSetName = ChartPartWithRange)]
        [Parameter(Mandatory = true, ParameterSetName = PagePartWithRange)]
        [Parameter(Mandatory = true, ParameterSetName = SystemPartWithRange)]
        [Parameter(Mandatory = true, ParameterSetName = FieldPageControlWithRange)]
        public IEnumerable<int> Range
        {
            get;
            set;
        }

        [Parameter(Mandatory = true, ParameterSetName = ChartPartWithID)]
        [Parameter(Mandatory = true, ParameterSetName = PagePartWithID)]
        [Parameter(Mandatory = true, ParameterSetName = SystemPartWithID)]
        [Parameter(Mandatory = true, ParameterSetName = FieldPageControlWithID)]
        [ValidateRange(1, int.MaxValue)]
        public int ID
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

        [Parameter()]
        public string Name
        {
            get;
            set;
        }

        [Parameter()]
        public SwitchParameter AutoCaption
        {
            get;
            set;
        }

        [Parameter]
        public SwitchParameter PassThru
        {
            get;
            set;
        }

        protected DynamicParameter<bool?> AssistEdit
        {
            get;
            set;
        }

        protected DynamicParameter<string> AutoFormatExpr
        {
            get;
            set;
        }

        protected DynamicParameter<AutoFormatType?> AutoFormatType
        {
            get;
            set;
        }

        protected DynamicParameter<BlankNumbers?> BlankNumbers
        {
            get;
            set;
        }

        protected DynamicParameter<bool?> BlankZero
        {
            get;
            set;
        }

        protected DynamicParameter<string> CaptionClass
        {
            get;
            set;
        }

        protected DynamicParameter<string> CharAllowed
        {
            get;
            set;
        }

        protected DynamicParameter<string> ChartPartID
        {
            get;
            set;
        }

        protected DynamicParameter<bool?> ClosingDates
        {
            get;
            set;
        }

        protected DynamicParameter<int?> ColumnSpan
        {
            get;
            set;
        }

        protected DynamicParameter<ContainerType?> ContainerType
        {
            get;
            set;
        }

        protected DynamicParameter<string> ControlAddIn
        {
            get;
            set;
        }

        protected DynamicParameter<bool?> DateFormula
        {
            get;
            set;
        }

        protected DynamicParameter<int?> DecimalPlacesAtLeast
        {
            get;
            set;
        }

        protected DynamicParameter<int?> DecimalPlacesAtMost
        {
            get;
            set;
        }

        protected DynamicParameter<bool?> DrillDown
        {
            get;
            set;
        }

        protected DynamicParameter<string> DrillDownPageID
        {
            get;
            set;
        }

        protected DynamicParameter<string> Editable
        {
            get;
            set;
        }

        protected DynamicParameter<string> Enabled
        {
            get;
            set;
        }

        protected DynamicParameter<ExtendedDataType?> ExtendedDataType
        {
            get;
            set;
        }

        protected DynamicParameter<string> FreezeColumnID
        {
            get;
            set;
        }

        protected DynamicParameter<GroupType?> GroupType
        {
            get;
            set;
        }

        protected DynamicParameter<string> HideValue
        {
            get;
            set;
        }

        protected DynamicParameter<Importance?> Importance
        {
            get;
            set;
        }

        protected DynamicParameter<string> IndentationColumnName
        {
            get;
            set;
        }

        protected DynamicParameter<string[]> IndentationControls
        {
            get;
            set;
        }

        protected DynamicParameter<GroupPageControlLayout?> Layout
        {
            get;
            set;
        }

        protected DynamicParameter<bool?> Lookup
        {
            get;
            set;
        }

        protected DynamicParameter<string> LookupPageID
        {
            get;
            set;
        }

        protected DynamicParameter<object> MaxValue
        {
            get;
            set;
        }

        protected DynamicParameter<object> MinValue
        {
            get;
            set;
        }

        protected DynamicParameter<bool?> MultiLine
        {
            get;
            set;
        }

        protected DynamicParameter<bool?> NotBlank
        {
            get;
            set;
        }

        protected DynamicParameter<bool?> Numeric
        {
            get;
            set;
        }

        protected DynamicParameter<int?> PagePartID
        {
            get;
            set;
        }

        protected DynamicParameter<int?> ProviderID
        {
            get;
            set;
        }

        protected DynamicParameter<string> QuickEntry
        {
            get;
            set;
        }

        protected DynamicParameter<int?> RowSpan
        {
            get;
            set;
        }

        protected DynamicParameter<bool?> ShowAsTree
        {
            get;
            set;
        }

        protected DynamicParameter<bool?> ShowCaption
        {
            get;
            set;
        }

        protected DynamicParameter<bool?> ShowFilter
        {
            get;
            set;
        }

        protected DynamicParameter<string> SourceExpr
        {
            get;
            set;
        }

        protected DynamicParameter<Style?> Style
        {
            get;
            set;
        }

        protected DynamicParameter<string> StyleExpr
        {
            get;
            set;
        }

        protected DynamicParameter<string> SubPageViewKey
        {
            get;
            set;
        }

        protected DynamicParameter<Order?> SubPageViewOrder
        {
            get;
            set;
        }

        protected DynamicParameter<SystemPartID?> SystemPartID
        {
            get;
            set;
        }

        protected DynamicParameter<bool?> Title
        {
            get;
            set;
        }

        protected DynamicParameter<string> ValuesAllowed
        {
            get;
            set;
        }

        protected DynamicParameter<string> Visible
        {
            get;
            set;
        }

        protected DynamicParameter<int?> Width
        {
            get;
            set;
        }

        protected override void ProcessRecord()
        {
            var pageControl = Page.Controls.Add(CreatePageControl());

            if (PassThru)
                WriteObject(pageControl);
        }

        protected PageControl CreatePageControl()
        {
            // FIXME: Intelligent indentation

            switch (Type)
            {
                case PageControlType.Container:
                    var containerPageControl = new ContainerPageControl(GetPageControlID(), 0);
                    containerPageControl.Properties.Description = Description;
                    containerPageControl.Properties.Name = Name;
                    containerPageControl.Properties.ContainerType = ContainerType.Value;

                    if (AutoCaption)
                        containerPageControl.AutoCaption();

                    return containerPageControl;

                case PageControlType.Group:
                    var groupPageControl = new GroupPageControl(GetPageControlID(), 1);
                    groupPageControl.Properties.Description = Description;
                    groupPageControl.Properties.Name = Name;
                    groupPageControl.Properties.Editable = Editable.Value;
                    groupPageControl.Properties.Enabled = Enabled.Value;
                    groupPageControl.Properties.FreezeColumnID = FreezeColumnID.Value;
                    groupPageControl.Properties.GroupType = GroupType.Value;
                    groupPageControl.Properties.IndentationColumnName = IndentationColumnName.Value;
                    groupPageControl.Properties.IndentationControls.AddRange(IndentationControls.Value ?? new string[] { });
                    groupPageControl.Properties.Layout = Layout.Value;
                    groupPageControl.Properties.ShowAsTree = ShowAsTree.Value;
                    groupPageControl.Properties.Visible = Visible.Value;

                    if (AutoCaption)
                        groupPageControl.AutoCaption();

                    return groupPageControl;

                case PageControlType.Field:
                    var fieldPageControl = new FieldPageControl(GetPageControlID(), 2);
                    fieldPageControl.Properties.Description = Description;
                    fieldPageControl.Properties.Name = Name;
                    fieldPageControl.Properties.AssistEdit = AssistEdit.Value;
                    fieldPageControl.Properties.AutoFormatExpr = AutoFormatExpr.Value;
                    fieldPageControl.Properties.AutoFormatType = AutoFormatType.Value;
                    fieldPageControl.Properties.BlankNumbers = BlankNumbers.Value;
                    fieldPageControl.Properties.BlankZero = BlankZero.Value;
                    fieldPageControl.Properties.CaptionClass = CaptionClass.Value;
                    fieldPageControl.Properties.CharAllowed = CharAllowed.Value;
                    fieldPageControl.Properties.ClosingDates = ClosingDates.Value;
                    fieldPageControl.Properties.ColumnSpan = ColumnSpan.Value;
                    fieldPageControl.Properties.ControlAddIn = ControlAddIn.Value;
                    fieldPageControl.Properties.DateFormula = DateFormula.Value;
                    fieldPageControl.Properties.DecimalPlaces.AtLeast = DecimalPlacesAtLeast.Value;
                    fieldPageControl.Properties.DecimalPlaces.AtMost = DecimalPlacesAtMost.Value;
                    fieldPageControl.Properties.DrillDown = DrillDown.Value;
                    fieldPageControl.Properties.DrillDownPageID = DrillDownPageID.Value;
                    fieldPageControl.Properties.Editable = Editable.Value;
                    fieldPageControl.Properties.Enabled = Enabled.Value;
                    fieldPageControl.Properties.ExtendedDatatype = ExtendedDataType.Value;
                    fieldPageControl.Properties.HideValue = HideValue.Value;
                    fieldPageControl.Properties.Importance = Importance.Value;
                    fieldPageControl.Properties.Lookup = Lookup.Value;
                    fieldPageControl.Properties.LookupPageID = LookupPageID.Value;
                    fieldPageControl.Properties.MaxValue = MaxValue.Value;
                    fieldPageControl.Properties.MinValue = MinValue.Value;
                    fieldPageControl.Properties.MultiLine = MultiLine.Value;
                    fieldPageControl.Properties.NotBlank = NotBlank.Value;
                    fieldPageControl.Properties.Numeric = Numeric.Value;
                    fieldPageControl.Properties.QuickEntry = QuickEntry.Value;
                    fieldPageControl.Properties.RowSpan = RowSpan.Value;
                    fieldPageControl.Properties.ShowCaption = ShowCaption.Value;
                    fieldPageControl.Properties.SourceExpr = SourceExpr.Value;
                    fieldPageControl.Properties.Style = Style.Value;
                    fieldPageControl.Properties.StyleExpr = StyleExpr.Value;
                    fieldPageControl.Properties.Title = Title.Value;
                    fieldPageControl.Properties.ValuesAllowed = ValuesAllowed.Value;
                    fieldPageControl.Properties.Visible = Visible.Value;
                    fieldPageControl.Properties.Width = Width.Value;

                    if (AutoCaption)
                        fieldPageControl.AutoCaption();

                    return fieldPageControl;

                case PageControlType.Part:
                    var partPageControl = new PartPageControl(GetPageControlID(), 1);
                    partPageControl.Properties.Description = Description;
                    partPageControl.Properties.Name = Name;

                    if (ChartPartID.RuntimeDefinedParameter.IsSet)
                    {
                        partPageControl.Properties.PartType = PartType.Chart;
                        partPageControl.Properties.ChartPartID = ChartPartID.Value;
                    }

                    if (PagePartID.RuntimeDefinedParameter.IsSet)
                    {
                        partPageControl.Properties.PartType = PartType.Page;
                        partPageControl.Properties.PagePartID = PagePartID.Value;
                    }

                    if (SystemPartID.RuntimeDefinedParameter.IsSet)
                    {
                        partPageControl.Properties.PartType = PartType.System;
                        partPageControl.Properties.SystemPartID = SystemPartID.Value;
                    }

                    partPageControl.Properties.Editable = Editable.Value;
                    partPageControl.Properties.Enabled = Enabled.Value;
                    partPageControl.Properties.ProviderID = ProviderID.Value;
                    partPageControl.Properties.ShowFilter = ShowFilter.Value;
                    partPageControl.Properties.SubPageView.Key = SubPageViewKey.Value;
                    partPageControl.Properties.SubPageView.Order = SubPageViewOrder.Value;
                    partPageControl.Properties.Visible = Visible.Value;

                    if (AutoCaption)
                        partPageControl.AutoCaption();

                    return partPageControl;
                default:
                    throw new ArgumentOutOfRangeException("Unknown control type.");
            }
        }

        protected int GetPageControlID()
        {
            if (ID != 0)
                return ID;

            var range = Range;

            if (Range.Contains(Page.ID))
                range = 1.To(int.MaxValue);

            return range.Except(Page.Controls.Select(c => c.ID)).First();
        }

        public override IEnumerable<RuntimeDefinedParameter> DynamicParameters
        {
            get
            {
                switch (Type)
                {
                    case PageControlType.Container:
                        yield return ContainerType.RuntimeDefinedParameter;
                        break;

                    case PageControlType.Group:
                        yield return Editable.RuntimeDefinedParameter;
                        yield return Enabled.RuntimeDefinedParameter;
                        yield return FreezeColumnID.RuntimeDefinedParameter;
                        yield return GroupType.RuntimeDefinedParameter;
                        yield return IndentationColumnName.RuntimeDefinedParameter;
                        yield return IndentationControls.RuntimeDefinedParameter;
                        yield return Layout.RuntimeDefinedParameter;
                        yield return ShowAsTree.RuntimeDefinedParameter;
                        yield return Visible.RuntimeDefinedParameter;
                        break;

                    case PageControlType.Field:
                        yield return AssistEdit.RuntimeDefinedParameter;
                        yield return AutoFormatExpr.RuntimeDefinedParameter;
                        yield return AutoFormatType.RuntimeDefinedParameter;
                        yield return BlankNumbers.RuntimeDefinedParameter;
                        yield return BlankZero.RuntimeDefinedParameter;
                        yield return CaptionClass.RuntimeDefinedParameter;
                        yield return CharAllowed.RuntimeDefinedParameter;
                        yield return ClosingDates.RuntimeDefinedParameter;
                        yield return ColumnSpan.RuntimeDefinedParameter;
                        yield return ControlAddIn.RuntimeDefinedParameter;
                        yield return DateFormula.RuntimeDefinedParameter;
                        yield return DecimalPlacesAtLeast.RuntimeDefinedParameter;
                        yield return DecimalPlacesAtMost.RuntimeDefinedParameter;
                        yield return DrillDown.RuntimeDefinedParameter;
                        yield return DrillDownPageID.RuntimeDefinedParameter;
                        yield return Editable.RuntimeDefinedParameter;
                        yield return Enabled.RuntimeDefinedParameter;
                        yield return ExtendedDataType.RuntimeDefinedParameter;
                        yield return HideValue.RuntimeDefinedParameter;
                        yield return Importance.RuntimeDefinedParameter;
                        yield return Lookup.RuntimeDefinedParameter;
                        yield return LookupPageID.RuntimeDefinedParameter;
                        yield return MaxValue.RuntimeDefinedParameter;
                        yield return MinValue.RuntimeDefinedParameter;
                        yield return MultiLine.RuntimeDefinedParameter;
                        yield return NotBlank.RuntimeDefinedParameter;
                        yield return Numeric.RuntimeDefinedParameter;
                        yield return QuickEntry.RuntimeDefinedParameter;
                        yield return RowSpan.RuntimeDefinedParameter;
                        yield return ShowCaption.RuntimeDefinedParameter;
                        yield return SourceExpr.RuntimeDefinedParameter;
                        yield return Style.RuntimeDefinedParameter;
                        yield return StyleExpr.RuntimeDefinedParameter;
                        yield return Title.RuntimeDefinedParameter;
                        yield return ValuesAllowed.RuntimeDefinedParameter;
                        yield return Visible.RuntimeDefinedParameter;
                        yield return Width.RuntimeDefinedParameter;
                        break;

                    case PageControlType.Part:
                        yield return Editable.RuntimeDefinedParameter;
                        yield return Enabled.RuntimeDefinedParameter;
                        yield return ChartPartID.RuntimeDefinedParameter;
                        yield return PagePartID.RuntimeDefinedParameter;
                        yield return ProviderID.RuntimeDefinedParameter;
                        yield return ShowFilter.RuntimeDefinedParameter;
                        yield return SubPageViewKey.RuntimeDefinedParameter;
                        yield return SubPageViewOrder.RuntimeDefinedParameter;
                        yield return SystemPartID.RuntimeDefinedParameter;
                        yield return Visible.RuntimeDefinedParameter;
                        break;
                }
            }
        }
    }
}
