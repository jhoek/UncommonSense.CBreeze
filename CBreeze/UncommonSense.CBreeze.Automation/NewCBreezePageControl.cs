using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using UncommonSense.CBreeze.Core;

namespace UncommonSense.CBreeze.Automation
{
    [Cmdlet(VerbsCommon.New, "CBreezePageControl", DefaultParameterSetName = ParameterSetNames.NewWithoutID)]
    [OutputType(typeof(PageControl))]
    [Alias("FieldControl", "Add-CBreezePageControl")]
    public class NewCBreezePageControl : NewItemWithIDCmdlet<PageControlBase, int, PSObject>
    {
        protected override void AddItemToInputObject(PageControlBase item, PSObject inputObject)
        {
            var position = Position.GetValueOrDefault(Core.Position.LastWithinContainer);

            switch (InputObject.BaseObject)
            {
                case PageControlContainer c:
                    c.AddChildPageControl(item, position);
                    break;

                case PageControlGroup g:
                    g.AddChildPageControl(item, position);
                    break;

                case PageControls c:
                    c.AddPageControlAtPosition(item, position);
                    break;

                case IPage p:
                    p.AddPageControlAtPosition(item, position);
                    break;

                default:
                    base.AddItemToInputObject(item, inputObject);
                    break;
            }
        }

#if NAV2015
        [Parameter()] public AccessByPermission AccessByPermission { get; set; }
#endif
#if NAV2017
        [Parameter()] public string[] ApplicationArea { get; set; }
#endif
        [Parameter()] public SwitchParameter AssistEdit { get; set; }
        [Parameter()] public SwitchParameter AutoCaption { get; set; }
        [Parameter()] public string AutoFormatExpr { get; set; }
        [Parameter()] public AutoFormatType? AutoFormatType { get; set; }
        [Parameter()] public BlankNumbers? BlankNumbers { get; set; }
        [Parameter()] public SwitchParameter BlankZero { get; set; }
        [Parameter()] public string CaptionClass { get; set; }
        [Parameter()] public Hashtable CaptionML { get; set; }
        [Parameter()] public string CharAllowed { get; set; }
        [Parameter()] public SwitchParameter ClosingDates { get; set; }
        [Parameter()] public int? ColumnSpan { get; set; }
        [Parameter()] public string ControlAddIn { get; set; }
        [Parameter()] public SwitchParameter DateFormula { get; set; }
        [Parameter()] [ValidateRange(0, int.MaxValue)] public int? DecimalPlacesAtLeast { get; set; }
        [Parameter()] [ValidateRange(0, int.MaxValue)] public int? DecimalPlacesAtMost { get; set; }
        [Parameter()] public string Description { get; set; }
        [Parameter()] public SwitchParameter DrillDown { get; set; }
        [Parameter()] public string DrillDownPageID { get; set; }

        [Parameter()] public string Editable { get; set; }
        [Parameter()] public string Enabled { get; set; }
        [Parameter()] public ExtendedDataType? ExtendedDataType { get; set; }
        [Parameter()] public string HideValue { get; set; }
#if NAV2015
        [Parameter()] public string Image { get; set; }
#endif
        [Parameter()] public Importance? Importance { get; set; }
        [Parameter()] public SwitchParameter Lookup { get; set; }
        [Parameter()] public string LookupPageID { get; set; }
        [Parameter()] public object MaxValue { get; set; }
        [Parameter()] public object MinValue { get; set; }
        [Parameter()] public SwitchParameter MultiLine { get; set; }
        [Parameter()] public string Name { get; set; }
        [Parameter()] public SwitchParameter NotBlank { get; set; }
        [Parameter()] public SwitchParameter Numeric { get; set; }
#if NAV2018
        [Parameter()] public string ODataEdmType { get; set; }
#endif

        [Parameter()] public ScriptBlock OnAssistEdit { get; set; }
        [Parameter()] public ScriptBlock OnControlAddIn { get; set; }
        [Parameter()] public ScriptBlock OnDrillDown { get; set; }
        [Parameter()] public ScriptBlock OnLookup { get; set; }
        [Parameter()] public ScriptBlock OnValidate { get; set; }
        [Parameter()] public Hashtable OptionCaptionML { get; set; }
        [Parameter()] public Position? Position { get; set; }
        [Parameter()] public string QuickEntry { get; set; }
        [Parameter()] public int? RowSpan { get; set; }
        [Parameter()] public SwitchParameter ShowCaption { get; set; }
#if NAV2015
        [Parameter()] public string ShowMandatory { get; set; }
#endif

        [Parameter(Position = 1, ParameterSetName = ParameterSetNames.NewWithoutID)]
        [Parameter(Position = 2, ParameterSetName = ParameterSetNames.NewWithID)]
        [Parameter(Position = 1, ParameterSetName = ParameterSetNames.AddWithoutID)]
        [Parameter(Position = 2, ParameterSetName = ParameterSetNames.AddWithID)]
        public string SourceExpr { get; set; }

        [Parameter()] public Style? Style { get; set; }
        [Parameter()] public string StyleExpr { get; set; }
        [Parameter()] public SwitchParameter Title { get; set; }
        [Parameter()] public Hashtable ToolTipML { get; set; }
        [Parameter()] public string ValuesAllowed { get; set; }
        [Parameter()] public string Visible { get; set; }
        [Parameter()] [ValidateRange(0, int.MaxValue)] public int? Width { get; set; }

        [Parameter()] public ScriptBlock SubObjects { get; set; }

        protected override IEnumerable<PageControlBase> CreateItems()
        {
            var pageControl = new PageControl(SourceExpr, ID, GetIndentation());

#if NAV2015
            pageControl.Properties.AccessByPermission.Set(AccessByPermission);
#endif
#if NAV2017
            pageControl.Properties.ApplicationArea.Set(ApplicationArea);
#endif
            pageControl.Properties.AssistEdit = NullableBooleanFromSwitch(nameof(AssistEdit));
            pageControl.Properties.AutoFormatExpr = AutoFormatExpr;
            pageControl.Properties.AutoFormatType = AutoFormatType;
            pageControl.Properties.BlankNumbers = BlankNumbers;
            pageControl.Properties.BlankZero = NullableBooleanFromSwitch(nameof(BlankZero));
            pageControl.Properties.CaptionClass = CaptionClass;
            pageControl.Properties.CaptionML.Set(CaptionML);
            pageControl.Properties.CharAllowed = CharAllowed;
            pageControl.Properties.ClosingDates = NullableBooleanFromSwitch(nameof(ClosingDates));
            pageControl.Properties.ColumnSpan = ColumnSpan;
            pageControl.Properties.ControlAddIn = ControlAddIn;
            pageControl.Properties.DateFormula = NullableBooleanFromSwitch(nameof(DateFormula));
            pageControl.Properties.DecimalPlaces.AtLeast = DecimalPlacesAtLeast;
            pageControl.Properties.DecimalPlaces.AtMost = DecimalPlacesAtMost;
            pageControl.Properties.Description = Description;
            pageControl.Properties.DrillDown = NullableBooleanFromSwitch(nameof(DrillDown));
            pageControl.Properties.DrillDownPageID = DrillDownPageID;
            pageControl.Properties.Editable = Editable;
            pageControl.Properties.Enabled = Enabled;
            pageControl.Properties.ExtendedDatatype = ExtendedDataType;
            pageControl.Properties.HideValue = HideValue;
#if NAV2015
            pageControl.Properties.Image = Image;
#endif
            pageControl.Properties.Importance = Importance;
            pageControl.Properties.Lookup = NullableBooleanFromSwitch(nameof(Lookup));
            pageControl.Properties.LookupPageID = LookupPageID;
            pageControl.Properties.MaxValue = MaxValue;
            pageControl.Properties.MinValue = MinValue;
            pageControl.Properties.MultiLine = NullableBooleanFromSwitch(nameof(MultiLine));
            pageControl.Properties.Name = Name;
            pageControl.Properties.NotBlank = NullableBooleanFromSwitch(nameof(NotBlank));
            pageControl.Properties.Numeric = NullableBooleanFromSwitch(nameof(Numeric));
            pageControl.Properties.ODataEDMType = ODataEdmType;
            pageControl.Properties.OnAssistEdit.Set(OnAssistEdit);
            pageControl.Properties.OnControlAddIn.Set(OnControlAddIn);
            pageControl.Properties.OnDrillDown.Set(OnDrillDown);
            pageControl.Properties.OnLookup.Set(OnLookup);
            pageControl.Properties.OnValidate.Set(OnValidate);
            pageControl.Properties.OptionCaptionML.Set(OptionCaptionML);
            pageControl.Properties.QuickEntry = QuickEntry;
            pageControl.Properties.RowSpan = RowSpan;
            pageControl.Properties.ShowCaption = NullableBooleanFromSwitch(nameof(ShowCaption));
#if NAV2015
            pageControl.Properties.ShowMandatory = ShowMandatory;
#endif
            pageControl.Properties.Style = Style;
            pageControl.Properties.StyleExpr = StyleExpr;
            pageControl.Properties.Title = NullableBooleanFromSwitch(nameof(Title));
            pageControl.Properties.ToolTipML.Set(ToolTipML);
            pageControl.Properties.ValuesAllowed = ValuesAllowed;
            pageControl.Properties.Visible = Visible;
            pageControl.Properties.Width = Width;
            pageControl.AutoCaption(AutoCaption);

            if (SubObjects != null)
            {
                var subObjects = SubObjects.Invoke().Select(o => o.BaseObject);
                pageControl.Properties.TableRelation.AddRange(subObjects.OfType<TableRelationLine>());
            }

            yield return pageControl;
        }

        protected int GetIndentation()
        {
            return ParameterSetNames.IsNew(ParameterSetName)
                ? (int)GetVariableValue("ControlIndentation", 0)
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

                case PageControlContainer containerPageControl:
                    return containerPageControl.IndentationLevel.GetValueOrDefault(0);

                case PageControlGroup groupPageControl:
                    return groupPageControl.IndentationLevel.GetValueOrDefault(0);

                default:
                    return 0;
            }
        }
    }
}