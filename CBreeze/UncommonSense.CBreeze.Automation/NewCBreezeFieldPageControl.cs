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
    [Cmdlet(VerbsCommon.New, "CBreezeFieldPageControl")]
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
        [Parameter()] public bool? DrillDown { get; set; }
        [Parameter()] public string DrillDownPageID { get; set; }
        [Parameter()] public string Editable { get; set; }
        [Parameter()] public string Enabled { get; set; }
        [Parameter()] public ExtendedDataType? ExtendedDataType { get; set; }
        [Parameter()] public Hashtable OptionCaptionML { get; set; }
        [Parameter(Mandatory = true)] public string SourceExpr { get; set; }

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
            fieldPageControl.Properties.DrillDown = DrillDown;
            fieldPageControl.Properties.DrillDownPageID = DrillDownPageID;
            fieldPageControl.Properties.Editable = Editable;
            fieldPageControl.Properties.Enabled = Enabled;
            fieldPageControl.Properties.ExtendedDatatype = ExtendedDataType;
            fieldPageControl.Properties.OptionCaptionML.Set(OptionCaptionML);

            yield return fieldPageControl;
        }

        protected int GetIndentation()
        {
            // FIXME
            return 1;
        }
    }
}
