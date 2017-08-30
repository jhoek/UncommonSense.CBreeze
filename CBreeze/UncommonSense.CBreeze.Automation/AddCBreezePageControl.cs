using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using UncommonSense.CBreeze.Common;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Automation
{
    // FIXME: For fields, allow OptionCaptionML to be set using a hash table, like in New-CBreezeOptionTableField

    [Cmdlet(VerbsCommon.Add, "CBreezePageControl")]
    public class AddCBreezePageControl : NewCBreezePageControl
    {
        public AddCBreezePageControl()
        {
            Position = new DynamicParameter<Position?>("Position");
        }

        [Parameter(Mandatory = true, ValueFromPipeline = true)]
        public PSObject InputObject
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

        protected DynamicParameter<Position?> Position
        {
            get;
            set;
        }

        protected override void ProcessRecord()
        {
            var pageControl = CreatePageControl();

            if (InputObject.BaseObject is ContainerPageControl)
            {
                (InputObject.BaseObject as ContainerPageControl).AddChildPageControl(pageControl, Position.Value.GetValueOrDefault(Core.Position.LastWithinContainer));
            }
            else if (InputObject.BaseObject is GroupPageControl)
            {
                (InputObject.BaseObject as GroupPageControl).AddChildPageControl(pageControl, Position.Value.GetValueOrDefault(Core.Position.LastWithinContainer));
            }
            else if (InputObject.BaseObject is PageControls)
            {
                switch (Position.Value.GetValueOrDefault(Core.Position.LastWithinContainer))
                {
                    case Core.Position.FirstWithinContainer:
                        (InputObject.BaseObject as PageControls).Insert(0, pageControl);
                        break;

                    case Core.Position.LastWithinContainer:
                        (InputObject.BaseObject as PageControls).Add(pageControl);
                        break;
                }
            }
            else if (InputObject.BaseObject is Page)
            {
                switch (Position.Value.GetValueOrDefault(Core.Position.LastWithinContainer))
                {
                    case Core.Position.FirstWithinContainer:
                        (InputObject.BaseObject as Page).Controls.Insert(0, pageControl);
                        break;

                    case Core.Position.LastWithinContainer:
                        (InputObject.BaseObject as Page).Controls.Add(pageControl);
                        break;
                }
            }
            else if (InputObject.BaseObject is ReportRequestPage)
            {
                switch (Position.Value.GetValueOrDefault(Core.Position.LastWithinContainer))
                {
                    case Core.Position.FirstWithinContainer:
                        (InputObject.BaseObject as ReportRequestPage).Controls.Insert(0, pageControl);
                        break;

                    case Core.Position.LastWithinContainer:
                        (InputObject.BaseObject as ReportRequestPage).Controls.Add(pageControl);
                        break;
                }
            }
            else if (InputObject.BaseObject is XmlPortRequestPage)
            {
                switch (Position.Value.GetValueOrDefault(Core.Position.LastWithinContainer))
                {
                    case Core.Position.FirstWithinContainer:
                        (InputObject.BaseObject as XmlPortRequestPage).Controls.Insert(0, pageControl);
                        break;

                    case Core.Position.LastWithinContainer:
                        (InputObject.BaseObject as XmlPortRequestPage).Controls.Add(pageControl);
                        break;
                }
            }
            else
            {
                throw new ArgumentOutOfRangeException("Don't know how to add a page control to an InputObject of this type.");
            }

            if (ChildControls != null)
            {
                var variables = new List<PSVariable>() { new PSVariable("Indentation", pageControl.IndentationLevel + 1) };
                var childControls = ChildControls.InvokeWithContext(null, variables).Select(o => o.BaseObject).Cast<PageControl>();

                foreach (var childControl in childControls)
                {
                    pageControl.AddChildPageControl(childControl, Core.Position.LastWithinContainer);
                }
            }

            if (PassThru)
                WriteObject(pageControl);
        }

        protected PageControl CreatePageControl()
        {
            switch (Type)
            {
                case PageControlType.Container:
                    var containerPageControl = new ContainerPageControl(ID, 0);
                    containerPageControl.Properties.CaptionML.Set("ENU", Caption.Value);
                    containerPageControl.Properties.Description = Description;
                    containerPageControl.Properties.Name = Name;
                    containerPageControl.Properties.ContainerType = ContainerType.Value;

                    if (AutoCaption && string.IsNullOrEmpty(Caption.Value))
                        containerPageControl.AutoCaption();

                    return containerPageControl;

                case PageControlType.Group:
                    var groupPageControl = new GroupPageControl(ID, GetIndentationLevel());
                    groupPageControl.Properties.CaptionML.Set("ENU", Caption.Value);
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

                    if (AutoCaption && string.IsNullOrEmpty(Caption.Value))
                        groupPageControl.AutoCaption();

                    return groupPageControl;

                case PageControlType.Field:
                    var fieldPageControl = new FieldPageControl(SourceExpr.Value, ID, GetIndentationLevel());
                    fieldPageControl.Properties.Description = Description;
                    fieldPageControl.Properties.Name = Name;
                    fieldPageControl.Properties.AssistEdit = AssistEdit.Value;
                    fieldPageControl.Properties.AutoFormatExpr = AutoFormatExpr.Value;
                    fieldPageControl.Properties.AutoFormatType = AutoFormatType.Value;
                    fieldPageControl.Properties.BlankNumbers = BlankNumbers.Value;
                    fieldPageControl.Properties.BlankZero = BlankZero.Value;
                    fieldPageControl.Properties.CaptionML.Set("ENU", Caption.Value);
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
#if NAV2015
                    fieldPageControl.Properties.Image = Image.Value;
#endif
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
#if NAV2015
                    fieldPageControl.Properties.ShowMandatory = ShowMandatory.Value;
#endif

                    //fieldPageControl.Properties.SourceExpr = SourceExpr.Value;
                    fieldPageControl.Properties.Style = Style.Value;
                    fieldPageControl.Properties.StyleExpr = StyleExpr.Value;
                    fieldPageControl.Properties.Title = Title.Value;
                    fieldPageControl.Properties.ValuesAllowed = ValuesAllowed.Value;
                    fieldPageControl.Properties.Visible = Visible.Value;
                    fieldPageControl.Properties.Width = Width.Value;

                    if (AutoCaption && string.IsNullOrEmpty(Caption.Value))
                        fieldPageControl.AutoCaption();

                    return fieldPageControl;

                case PageControlType.Part:
                    var partPageControl = new PartPageControl(ID, GetIndentationLevel());
                    partPageControl.Properties.Description = Description;
                    partPageControl.Properties.Name = Name;

                    if (ChartPartID.Value != null)
                    {
                        partPageControl.Properties.PartType = PartType.Chart;
                        partPageControl.Properties.ChartPartID = ChartPartID.Value;
                    }

                    if (PagePartID.Value != null)
                    {
                        partPageControl.Properties.PartType = PartType.Page;
                        partPageControl.Properties.PagePartID = PagePartID.Value;
                    }

                    if (SystemPartID.Value != null)
                    {
                        partPageControl.Properties.PartType = PartType.System;
                        partPageControl.Properties.SystemPartID = SystemPartID.Value;
                    }

                    partPageControl.Properties.CaptionML.Set("ENU", Caption.Value);
                    partPageControl.Properties.Editable = Editable.Value;
                    partPageControl.Properties.Enabled = Enabled.Value;
                    partPageControl.Properties.ProviderID = ProviderID.Value;
                    partPageControl.Properties.ShowFilter = ShowFilter.Value;
                    partPageControl.Properties.SubPageView.Key = SubPageViewKey.Value;
                    partPageControl.Properties.SubPageView.Order = SubPageViewOrder.Value;
#if NAV2015
                    partPageControl.Properties.UpdatePropagation = UpdatePropagation.Value;
#endif
                    partPageControl.Properties.Visible = Visible.Value;

                    if (AutoCaption && string.IsNullOrEmpty(Caption.Value))
                        partPageControl.AutoCaption();

                    return partPageControl;

                default:
                    throw new ArgumentOutOfRangeException("Unknown control type.");
            }
        }

        protected int GetIndentationLevel()
        {
            if (InputObject.BaseObject is PageControls)
                return 0;
            else if (InputObject.BaseObject is Page)
                return 0;
            else if (InputObject.BaseObject is XmlPortRequestPage)
                return 0;
            else if (InputObject.BaseObject is ReportRequestPage)
                return 0;
            else if (InputObject.BaseObject is ContainerPageControl)
                return (InputObject.BaseObject as ContainerPageControl).IndentationLevel.GetValueOrDefault(0) + 1;
            else if (InputObject.BaseObject is GroupPageControl)
                return (InputObject.BaseObject as GroupPageControl).IndentationLevel.GetValueOrDefault(0) + 1;
            else
                throw new ArgumentOutOfRangeException("Cannot determine indentation.");
        }

        public override IEnumerable<RuntimeDefinedParameter> DynamicParameters
        {
            get
            {
                switch (Type)
                {
                    case PageControlType.Container:
                        yield return ContainerType.RuntimeDefinedParameter;
                        yield return Caption.RuntimeDefinedParameter;
                        break;

                    case PageControlType.Group:
                        yield return Position.RuntimeDefinedParameter;
                        yield return Caption.RuntimeDefinedParameter;
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
                        yield return Position.RuntimeDefinedParameter;
                        yield return AssistEdit.RuntimeDefinedParameter;
                        yield return AutoFormatExpr.RuntimeDefinedParameter;
                        yield return AutoFormatType.RuntimeDefinedParameter;
                        yield return BlankNumbers.RuntimeDefinedParameter;
                        yield return BlankZero.RuntimeDefinedParameter;
                        yield return Caption.RuntimeDefinedParameter;
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
#if NAV2015
                        yield return Image.RuntimeDefinedParameter;
#endif
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
#if NAV2015
                        yield return ShowMandatory.RuntimeDefinedParameter;
#endif
                        yield return SourceExpr.RuntimeDefinedParameter;
                        yield return Style.RuntimeDefinedParameter;
                        yield return StyleExpr.RuntimeDefinedParameter;
                        yield return Title.RuntimeDefinedParameter;
                        yield return ValuesAllowed.RuntimeDefinedParameter;
                        yield return Visible.RuntimeDefinedParameter;
                        yield return Width.RuntimeDefinedParameter;
                        break;

                    case PageControlType.Part:
                        yield return Position.RuntimeDefinedParameter;
                        yield return Caption.RuntimeDefinedParameter;
                        yield return Editable.RuntimeDefinedParameter;
                        yield return Enabled.RuntimeDefinedParameter;
                        yield return ChartPartID.RuntimeDefinedParameter;
                        yield return PagePartID.RuntimeDefinedParameter;
                        yield return ProviderID.RuntimeDefinedParameter;
                        yield return ShowFilter.RuntimeDefinedParameter;
                        yield return SubPageViewKey.RuntimeDefinedParameter;
                        yield return SubPageViewOrder.RuntimeDefinedParameter;
                        yield return SystemPartID.RuntimeDefinedParameter;
#if NAV2015
                        yield return UpdatePropagation.RuntimeDefinedParameter;
#endif
                        yield return Visible.RuntimeDefinedParameter;
                        break;
                }
            }
        }
    }
}