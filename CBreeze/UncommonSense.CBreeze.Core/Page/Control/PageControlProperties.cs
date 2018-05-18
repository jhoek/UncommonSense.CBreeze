using UncommonSense.CBreeze.Core.Code.Variable;
using UncommonSense.CBreeze.Core.Contracts;
using UncommonSense.CBreeze.Core.Property;
using UncommonSense.CBreeze.Core.Property.Enumeration;
using UncommonSense.CBreeze.Core.Property.Implementation;
using UncommonSense.CBreeze.Core.Property.Type;
using UncommonSense.CBreeze.Core.Table.Relation;

namespace UncommonSense.CBreeze.Core.Page.Control
{
        public class PageControlProperties : Properties
    {
#if NAV2015
        private AccessByPermissionProperty accessByPermission = new AccessByPermissionProperty("AccessByPermission");
#endif
#if NAV2017
        private TagListProperty applicationArea = new TagListProperty("ApplicationArea");
#endif
        private NullableBooleanProperty assistEdit = new NullableBooleanProperty("AssistEdit");
        private StringProperty autoFormatExpr = new StringProperty("AutoFormatExpr");
        private AutoFormatTypeProperty autoFormatType = new AutoFormatTypeProperty("AutoFormatType");
        private BlankNumbersProperty blankNumbers = new BlankNumbersProperty("BlankNumbers");
        private NullableBooleanProperty blankZero = new NullableBooleanProperty("BlankZero");
        private StringProperty captionClass = new StringProperty("CaptionClass");
        private MultiLanguageProperty captionML = new MultiLanguageProperty("CaptionML");
        private StringProperty charAllowed = new StringProperty("CharAllowed");
        private NullableBooleanProperty closingDates = new NullableBooleanProperty("ClosingDates");
        private NullableIntegerProperty columnSpan = new NullableIntegerProperty("ColumnSpan");
        private StringProperty controlAddIn = new StringProperty("ControlAddIn");
        private NullableBooleanProperty dateFormula = new NullableBooleanProperty("DateFormula");
        private DecimalPlacesProperty decimalPlaces = new DecimalPlacesProperty("DecimalPlaces");
        private StringProperty description = new StringProperty("Description");
        private NullableBooleanProperty drillDown = new NullableBooleanProperty("DrillDown");
        private StringProperty drillDownPageID = new StringProperty("DrillDownPageID");
        private StringProperty editable = new StringProperty("Editable");
        private StringProperty enabled = new StringProperty("Enabled");
        private ExtendedDataTypeProperty extendedDatatype = new ExtendedDataTypeProperty("ExtendedDatatype");
        private StringProperty hideValue = new StringProperty("HideValue");
#if NAV2015
        private StringProperty image = new StringProperty("Image");
#endif
        private ImportanceProperty importance = new ImportanceProperty("Importance");
        private NullableBooleanProperty lookup = new NullableBooleanProperty("Lookup");
        private StringProperty lookupPageID = new StringProperty("LookupPageID");
        private ObjectProperty maxValue = new ObjectProperty("MaxValue");
        private ObjectProperty minValue = new ObjectProperty("MinValue");
        private NullableBooleanProperty multiLine = new NullableBooleanProperty("MultiLine");
        private StringProperty name = new StringProperty("Name");
        private NullableBooleanProperty notBlank = new NullableBooleanProperty("NotBlank");
        private NullableBooleanProperty numeric = new NullableBooleanProperty("Numeric");
        private TriggerProperty onAssistEdit = new TriggerProperty("OnAssistEdit");
        private TriggerProperty onControlAddIn = new TriggerProperty("OnControlAddIn");
        private TriggerProperty onDrillDown = new TriggerProperty("OnDrillDown");
        private TriggerProperty onLookup = new TriggerProperty("OnLookup");
        private TriggerProperty onValidate = new TriggerProperty("OnValidate");
        private MultiLanguageProperty optionCaptionML = new MultiLanguageProperty("OptionCaptionML");
        private StringProperty quickEntry = new StringProperty("QuickEntry");
        private NullableIntegerProperty rowSpan = new NullableIntegerProperty("RowSpan");
        private NullableBooleanProperty showCaption = new NullableBooleanProperty("ShowCaption");
#if NAV2015
        private StringProperty showMandatory = new StringProperty("ShowMandatory");
#endif
        private StringProperty sourceExpr = new StringProperty("SourceExpr");
        private StyleProperty style = new StyleProperty("Style");
        private StringProperty styleExpr = new StringProperty("StyleExpr");
        private TableRelationProperty tableRelation = new TableRelationProperty("TableRelation");
        private NullableBooleanProperty title = new NullableBooleanProperty("Title");
        private MultiLanguageProperty toolTipML = new MultiLanguageProperty("ToolTipML");
        private SemiColonSeparatedStringProperty valuesAllowed = new SemiColonSeparatedStringProperty("ValuesAllowed");
        private StringProperty visible = new StringProperty("Visible");
        private NullableIntegerProperty width = new NullableIntegerProperty("Width");

        internal PageControlProperties(PageControl control)
        {
            Control = control;

            innerList.Add(name);
            innerList.Add(extendedDatatype);
            innerList.Add(width);
#if NAV2015
            innerList.Add(accessByPermission);
#endif
            innerList.Add(lookup);
            innerList.Add(drillDown);
            innerList.Add(assistEdit);
            innerList.Add(captionML);
            innerList.Add(toolTipML);
            innerList.Add(optionCaptionML);
#if NAV2017
            innerList.Add(applicationArea);
#endif
            innerList.Add(decimalPlaces);
            innerList.Add(notBlank);
            innerList.Add(numeric);
            innerList.Add(charAllowed);
            innerList.Add(dateFormula);
            innerList.Add(closingDates);
            innerList.Add(blankNumbers);
            innerList.Add(blankZero);
            innerList.Add(description);
            innerList.Add(sourceExpr);
            innerList.Add(autoFormatType);
            innerList.Add(autoFormatExpr);
            innerList.Add(captionClass);
            innerList.Add(title);
            innerList.Add(minValue);
            innerList.Add(maxValue);
            innerList.Add(valuesAllowed);
            innerList.Add(tableRelation);
            innerList.Add(importance);
            innerList.Add(visible);
            innerList.Add(enabled);
            innerList.Add(editable);
#if NAV2015
            innerList.Add(image);
#endif
            innerList.Add(lookupPageID);
            innerList.Add(drillDownPageID);
            innerList.Add(multiLine);
            innerList.Add(hideValue);
            innerList.Add(style);
            innerList.Add(styleExpr);
            innerList.Add(controlAddIn);
            innerList.Add(rowSpan);
            innerList.Add(columnSpan);
            innerList.Add(onValidate);
            innerList.Add(onLookup);
            innerList.Add(onDrillDown);
            innerList.Add(onAssistEdit);
            innerList.Add(onControlAddIn);
#if NAV2015
            innerList.Add(showMandatory);
#endif
            innerList.Add(showCaption);
            innerList.Add(quickEntry);
        }

        public PageControl Control { get; protected set; }

        public override INode ParentNode => Control;

#if NAV2015
        public AccessByPermission AccessByPermission
        {
            get
            {
                return this.accessByPermission.Value;
            }
        }
#endif

#if NAV2017
        public TagList ApplicationArea => applicationArea.Value;
#endif

        public bool? AssistEdit
        {
            get
            {
                return this.assistEdit.Value;
            }
            set
            {
                this.assistEdit.Value = value;
            }
        }

        public string AutoFormatExpr
        {
            get
            {
                return this.autoFormatExpr.Value;
            }
            set
            {
                this.autoFormatExpr.Value = value;
            }
        }

        public AutoFormatType? AutoFormatType
        {
            get
            {
                return this.autoFormatType.Value;
            }
            set
            {
                this.autoFormatType.Value = value;
            }
        }

        public BlankNumbers? BlankNumbers
        {
            get
            {
                return this.blankNumbers.Value;
            }
            set
            {
                this.blankNumbers.Value = value;
            }
        }

        public bool? BlankZero
        {
            get
            {
                return this.blankZero.Value;
            }
            set
            {
                this.blankZero.Value = value;
            }
        }

        public string CaptionClass
        {
            get
            {
                return this.captionClass.Value;
            }
            set
            {
                this.captionClass.Value = value;
            }
        }

        public MultiLanguageValue CaptionML
        {
            get
            {
                return this.captionML.Value;
            }
        }

        public string CharAllowed
        {
            get
            {
                return this.charAllowed.Value;
            }
            set
            {
                this.charAllowed.Value = value;
            }
        }

        public bool? ClosingDates
        {
            get
            {
                return this.closingDates.Value;
            }
            set
            {
                this.closingDates.Value = value;
            }
        }

        public int? ColumnSpan
        {
            get
            {
                return this.columnSpan.Value;
            }
            set
            {
                this.columnSpan.Value = value;
            }
        }

        public string ControlAddIn
        {
            get
            {
                return this.controlAddIn.Value;
            }
            set
            {
                this.controlAddIn.Value = value;
            }
        }

        public bool? DateFormula
        {
            get
            {
                return this.dateFormula.Value;
            }
            set
            {
                this.dateFormula.Value = value;
            }
        }

        public DecimalPlaces DecimalPlaces
        {
            get
            {
                return this.decimalPlaces.Value;
            }
        }

        public string Description
        {
            get
            {
                return this.description.Value;
            }
            set
            {
                this.description.Value = value;
            }
        }

        public bool? DrillDown
        {
            get
            {
                return this.drillDown.Value;
            }
            set
            {
                this.drillDown.Value = value;
            }
        }

        public string DrillDownPageID
        {
            get
            {
                return this.drillDownPageID.Value;
            }
            set
            {
                this.drillDownPageID.Value = value;
            }
        }

        public string Editable
        {
            get
            {
                return this.editable.Value;
            }
            set
            {
                this.editable.Value = value;
            }
        }

        public string Enabled
        {
            get
            {
                return this.enabled.Value;
            }
            set
            {
                this.enabled.Value = value;
            }
        }

        public ExtendedDataType? ExtendedDatatype
        {
            get
            {
                return this.extendedDatatype.Value;
            }
            set
            {
                this.extendedDatatype.Value = value;
            }
        }

        public string HideValue
        {
            get
            {
                return this.hideValue.Value;
            }
            set
            {
                this.hideValue.Value = value;
            }
        }

#if NAV2015
        public string Image
        {
            get
            {
                return this.image.Value;
            }
            set
            {
                this.image.Value = value;
            }
        }
#endif

        public Importance? Importance
        {
            get
            {
                return this.importance.Value;
            }
            set
            {
                this.importance.Value = value;
            }
        }

        public bool? Lookup
        {
            get
            {
                return this.lookup.Value;
            }
            set
            {
                this.lookup.Value = value;
            }
        }

        public string LookupPageID
        {
            get
            {
                return this.lookupPageID.Value;
            }
            set
            {
                this.lookupPageID.Value = value;
            }
        }

        public System.Object MaxValue
        {
            get
            {
                return this.maxValue.Value;
            }
            set
            {
                this.maxValue.Value = value;
            }
        }

        public System.Object MinValue
        {
            get
            {
                return this.minValue.Value;
            }
            set
            {
                this.minValue.Value = value;
            }
        }

        public bool? MultiLine
        {
            get
            {
                return this.multiLine.Value;
            }
            set
            {
                this.multiLine.Value = value;
            }
        }

        public string Name
        {
            get
            {
                return this.name.Value;
            }
            set
            {
                this.name.Value = value;
            }
        }

        public bool? NotBlank
        {
            get
            {
                return this.notBlank.Value;
            }
            set
            {
                this.notBlank.Value = value;
            }
        }

        public bool? Numeric
        {
            get
            {
                return this.numeric.Value;
            }
            set
            {
                this.numeric.Value = value;
            }
        }

        public Trigger OnAssistEdit
        {
            get
            {
                return this.onAssistEdit.Value;
            }
        }

        public Trigger OnControlAddIn
        {
            get
            {
                return this.onControlAddIn.Value;
            }
        }

        public Trigger OnDrillDown
        {
            get
            {
                return this.onDrillDown.Value;
            }
        }

        public Trigger OnLookup
        {
            get
            {
                return this.onLookup.Value;
            }
        }

        public Trigger OnValidate
        {
            get
            {
                return this.onValidate.Value;
            }
        }

        public MultiLanguageValue OptionCaptionML
        {
            get
            {
                return this.optionCaptionML.Value;
            }
        }

        public string QuickEntry
        {
            get
            {
                return this.quickEntry.Value;
            }
            set
            {
                this.quickEntry.Value = value;
            }
        }

        public int? RowSpan
        {
            get
            {
                return this.rowSpan.Value;
            }
            set
            {
                this.rowSpan.Value = value;
            }
        }

        public bool? ShowCaption
        {
            get
            {
                return this.showCaption.Value;
            }
            set
            {
                this.showCaption.Value = value;
            }
        }

#if NAV2015
        public string ShowMandatory
        {
            get
            {
                return this.showMandatory.Value;
            }
            set
            {
                this.showMandatory.Value = value;
            }
        }
#endif

        public string SourceExpr
        {
            get
            {
                return this.sourceExpr.Value;
            }
            set
            {
                this.sourceExpr.Value = value;
            }
        }

        public Style? Style
        {
            get
            {
                return this.style.Value;
            }
            set
            {
                this.style.Value = value;
            }
        }

        public string StyleExpr
        {
            get
            {
                return this.styleExpr.Value;
            }
            set
            {
                this.styleExpr.Value = value;
            }
        }

        public TableRelation TableRelation
        {
            get
            {
                return this.tableRelation.Value;
            }
        }

        public bool? Title
        {
            get
            {
                return this.title.Value;
            }
            set
            {
                this.title.Value = value;
            }
        }

        public MultiLanguageValue ToolTipML
        {
            get
            {
                return this.toolTipML.Value;
            }
        }

        public string ValuesAllowed
        {
            get
            {
                return this.valuesAllowed.Value;
            }
            set
            {
                this.valuesAllowed.Value = value;
            }
        }

        public string Visible
        {
            get
            {
                return this.visible.Value;
            }
            set
            {
                this.visible.Value = value;
            }
        }

        public int? Width
        {
            get
            {
                return this.width.Value;
            }
            set
            {
                this.width.Value = value;
            }
        }
    }
}
