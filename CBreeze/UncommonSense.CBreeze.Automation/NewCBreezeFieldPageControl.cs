using System.Collections;
using System.Collections.Generic;
using System.Management.Automation;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Automation
{
    // FIXME: Scriptblock for table relation

    [Cmdlet(VerbsCommon.New, "CBreezeFieldPageControl", DefaultParameterSetName =ParameterSetNames.NewWithoutID)]
    [OutputType(typeof(FieldPageControl))]
    [Alias("FieldControl")]
    public class NewCBreezeFieldPageControl : NewItemWithIDCmdlet<PageControl, int, PSObject>
    {
        protected override void AddItemToInputObject(PageControl item, PSObject inputObject)
        {
            base.AddItemToInputObject(item, inputObject);
        }

        [Parameter()] public AccessByPermission AccessByPermission { get; set; }
        [Parameter()] public bool? AssistEdit { get; set; }
        [Parameter()] public SwitchParameter AutoCaption { get; set; }
        [Parameter()] public string AutoFormatExpr { get; set; }
        [Parameter()] public AutoFormatType? AutoFormatType { get; set; }
        [Parameter()] public BlankNumbers? BlankNumbers { get; set; }
        [Parameter()] public bool? BlankZero { get; set; }
        [Parameter()] public string CaptionClass { get; set; }
        [Parameter()] public string CharAllowed { get; set; }
        [Parameter()] public bool? ClosingDates { get; set; }
        [Parameter()] public int? ColumnSpan { get; set; }
        [Parameter()] public string ControlAddIn { get; set; }
        [Parameter()] public bool? DateFormula { get; set; }
        [Parameter()] [ValidateRange(0, int.MaxValue)] public int? DecimalPlacesAtLeast { get; set; }
        [Parameter()] [ValidateRange(0, int.MaxValue)] public int? DecimalPlacesAtMost { get; set; }
        [Parameter()] public string Description { get; set; }
        [Parameter()] public bool? DrillDown { get; set; }
        [Parameter()] public string DrillDownPageID { get; set; }
        [Parameter()] public string Editable { get; set; }
        [Parameter()] public string Enabled { get; set; }
        [Parameter()] public ExtendedDataType? ExtendedDataType { get; set; }
        [Parameter()] public string HideValue { get; set; }
#if NAV2015
        [Parameter()] public string Image { get; set; }
#endif
        [Parameter()] public Importance? Importance { get; set; }
        [Parameter()] public bool? Lookup { get; set; }
        [Parameter()] public string LookupPageID { get; set; }
        [Parameter()] public object MaxValue { get; set; }
        [Parameter()] public object MinValue { get; set; }
        [Parameter()] public bool? MultiLine { get; set; }
        [Parameter()] public string Name { get; set; }
        [Parameter()] public bool? NotBlank { get; set; }
        [Parameter()] public bool? Numeric { get; set; }
        [Parameter()] public Hashtable OptionCaptionML { get; set; }
        [Parameter()] public string QuickEntry { get; set; }
        [Parameter()] public int? RowSpan { get; set; }
        [Parameter()] public bool? ShowCaption { get; set; }
#if NAV2015
        [Parameter()] public string ShowMandatory { get; set; }
#endif

        [Parameter(Mandatory = true, Position = 1, ParameterSetName =ParameterSetNames.NewWithoutID)]
        [Parameter(Mandatory = true, Position = 2, ParameterSetName = ParameterSetNames.NewWithID)]
        [Parameter(Mandatory = true, Position = 1, ParameterSetName = ParameterSetNames.AddWithoutID)]
        [Parameter(Mandatory = true, Position = 2, ParameterSetName = ParameterSetNames.AddWithID)]
        public string SourceExpr { get; set; }

        [Parameter()] public Style? Style { get; set; }
        [Parameter()] public string StyleExpr { get; set; }
        [Parameter()] public bool? Title { get; set; }
        [Parameter()] public string ValuesAllowed { get; set; }
        [Parameter()] public string Visible { get; set; }
        [Parameter()] [ValidateRange(0, int.MaxValue)] public int? Width { get; set; }

        protected override IEnumerable<PageControl> CreateItems()
        {
            var fieldPageControl = new FieldPageControl(SourceExpr, ID, GetIndentation());

            fieldPageControl.Properties.AccessByPermission.Set(AccessByPermission);
            fieldPageControl.Properties.AssistEdit = AssistEdit;
            fieldPageControl.Properties.AutoFormatExpr = AutoFormatExpr;
            fieldPageControl.Properties.AutoFormatType = AutoFormatType;
            fieldPageControl.Properties.BlankNumbers = BlankNumbers;
            fieldPageControl.Properties.BlankZero = BlankZero;
            fieldPageControl.Properties.CaptionClass = CaptionClass;
            fieldPageControl.Properties.CharAllowed = CharAllowed;
            fieldPageControl.Properties.ClosingDates = ClosingDates;
            fieldPageControl.Properties.ColumnSpan = ColumnSpan;
            fieldPageControl.Properties.ControlAddIn = ControlAddIn;
            fieldPageControl.Properties.DateFormula = DateFormula;
            fieldPageControl.Properties.DecimalPlaces.AtLeast = DecimalPlacesAtLeast;
            fieldPageControl.Properties.DecimalPlaces.AtMost = DecimalPlacesAtMost;
            fieldPageControl.Properties.Description = Description;
            fieldPageControl.Properties.DrillDown = DrillDown;
            fieldPageControl.Properties.DrillDownPageID = DrillDownPageID;
            fieldPageControl.Properties.Editable = Editable;
            fieldPageControl.Properties.Enabled = Enabled;
            fieldPageControl.Properties.ExtendedDatatype = ExtendedDataType;
            fieldPageControl.Properties.HideValue = HideValue;
#if NAV2015
            fieldPageControl.Properties.Image = Image;
#endif
            fieldPageControl.Properties.Importance = Importance;
            fieldPageControl.Properties.Lookup = Lookup;
            fieldPageControl.Properties.LookupPageID = LookupPageID;
            fieldPageControl.Properties.MaxValue = MaxValue;
            fieldPageControl.Properties.MinValue = MinValue;
            fieldPageControl.Properties.MultiLine = MultiLine;
            fieldPageControl.Properties.Name = Name;
            fieldPageControl.Properties.NotBlank = NotBlank;
            fieldPageControl.Properties.Numeric = Numeric;
            fieldPageControl.Properties.OptionCaptionML.Set(OptionCaptionML);
            fieldPageControl.Properties.QuickEntry = QuickEntry;
            fieldPageControl.Properties.RowSpan = RowSpan;
            fieldPageControl.Properties.ShowCaption = ShowCaption;
#if NAV2015
            fieldPageControl.Properties.ShowMandatory = ShowMandatory;
#endif
            fieldPageControl.Properties.Style = Style;
            fieldPageControl.Properties.StyleExpr = StyleExpr;
            fieldPageControl.Properties.Title = Title;
            fieldPageControl.Properties.ValuesAllowed = ValuesAllowed;
            fieldPageControl.Properties.Visible = Visible;
            fieldPageControl.Properties.Width = Width;
            fieldPageControl.AutoCaption(AutoCaption);

            yield return fieldPageControl;
        }

        protected int GetIndentation()
        {
            return ParameterSetNames.IsNew(ParameterSetName)
                ? (int)GetVariableValue("Indentation", 0)
                : GetParentIndentation() + 1;
        }

        protected int GetParentIndentation()
        {
            switch (InputObject.BaseObject)
            {
                case IPage page:
                    return 0;

                case PageControls pageControls:
                    return 0;

                case ContainerPageControl containerPageControl:
                    return containerPageControl.IndentationLevel.GetValueOrDefault(0);

                case GroupPageControl groupPageControl:
                    return groupPageControl.IndentationLevel.GetValueOrDefault(0);

                default:
                    return 0;
            }
        }
    }
}