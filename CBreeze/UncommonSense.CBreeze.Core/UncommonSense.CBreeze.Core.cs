using System;
using System.Xml;
using System.Text;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    #region Property Types

    [Serializable]
    public abstract class Property
    {
        private string name;

        internal Property(string name)
        {
            this.name = name;
        }

        public abstract bool HasValue
        {
            get;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
        }
    }

    [Serializable]
    public class ActionContainerTypeProperty : Property
    {
        private ActionContainerType? value = null;

        internal ActionContainerTypeProperty(string name) : base(name)
        {
        }

        public override bool HasValue
        {
            get
            {
                return Value.HasValue;
            }
        }

        public ActionContainerType? Value
        {
            get
            {
                return this.value;
            }
            set
            {
                this.value = value;
            }
        }
    }

    [Serializable]
    public class ActionListProperty : Property
    {
        private ActionList value = new ActionList();

        internal ActionListProperty(string name) : base(name)
        {
        }

        public override bool HasValue
        {
            get
            {
                return Value.Any();
            }
        }

        public ActionList Value
        {
            get
            {
                return this.value;
            }
        }
    }

    [Serializable]
    public class AutoFormatTypeProperty : Property
    {
        private AutoFormatType? value = null;

        internal AutoFormatTypeProperty(string name) : base(name)
        {
        }

        public override bool HasValue
        {
            get
            {
                return Value.HasValue;
            }
        }

        public AutoFormatType? Value
        {
            get
            {
                return this.value;
            }
            set
            {
                this.value = value;
            }
        }
    }

    [Serializable]
    public class BlankNumbersProperty : Property
    {
        private BlankNumbers? value = null;

        internal BlankNumbersProperty(string name) : base(name)
        {
        }

        public override bool HasValue
        {
            get
            {
                return Value.HasValue;
            }
        }

        public BlankNumbers? Value
        {
            get
            {
                return this.value;
            }
            set
            {
                this.value = value;
            }
        }
    }

    [Serializable]
    public class BlobSubTypeProperty : Property
    {
        private BlobSubType? value = null;

        internal BlobSubTypeProperty(string name) : base(name)
        {
        }

        public override bool HasValue
        {
            get
            {
                return Value.HasValue;
            }
        }

        public BlobSubType? Value
        {
            get
            {
                return this.value;
            }
            set
            {
                this.value = value;
            }
        }
    }

    [Serializable]
    public class BooleanProperty : Property
    {
        private System.Boolean value = false;

        internal BooleanProperty(string name) : base(name)
        {
        }

        public override bool HasValue
        {
            get
            {
                return Value;
            }
        }

        public System.Boolean Value
        {
            get
            {
                return this.value;
            }
            set
            {
                this.value = value;
            }
        }
    }

    [Serializable]
    public class CalcFormulaProperty : Property
    {
        private CalcFormula value = new CalcFormula();

        internal CalcFormulaProperty(string name) : base(name)
        {
        }

        public override bool HasValue
        {
            get
            {
                return Value.Method.HasValue;
            }
        }

        public CalcFormula Value
        {
            get
            {
                return this.value;
            }
        }
    }

    [Serializable]
    public class CodeunitSubTypeProperty : Property
    {
        private CodeunitSubType? value = null;

        internal CodeunitSubTypeProperty(string name) : base(name)
        {
        }

        public override bool HasValue
        {
            get
            {
                return Value.HasValue;
            }
        }

        public CodeunitSubType? Value
        {
            get
            {
                return this.value;
            }
            set
            {
                this.value = value;
            }
        }
    }

    [Serializable]
    public class ColumnFilterProperty : Property
    {
        private ColumnFilter value = new ColumnFilter();

        internal ColumnFilterProperty(string name) : base(name)
        {
        }

        public override bool HasValue
        {
            get
            {
                return Value.Any();
            }
        }

        public ColumnFilter Value
        {
            get
            {
                return this.value;
            }
        }
    }

    [Serializable]
    public class ContainerTypeProperty : Property
    {
        private ContainerType? value = null;

        internal ContainerTypeProperty(string name) : base(name)
        {
        }

        public override bool HasValue
        {
            get
            {
                return Value.HasValue;
            }
        }

        public ContainerType? Value
        {
            get
            {
                return this.value;
            }
            set
            {
                this.value = value;
            }
        }
    }

    [Serializable]
    public class ControlListProperty : Property
    {
        private ControlList value = new ControlList();

        internal ControlListProperty(string name) : base(name)
        {
        }

        public override bool HasValue
        {
            get
            {
                return Value.Any();
            }
        }

        public ControlList Value
        {
            get
            {
                return this.value;
            }
        }
    }

    [Serializable]
    public class DataItemLinkTypeProperty : Property
    {
        private DataItemLinkType? value = null;

        internal DataItemLinkTypeProperty(string name) : base(name)
        {
        }

        public override bool HasValue
        {
            get
            {
                return Value.HasValue;
            }
        }

        public DataItemLinkType? Value
        {
            get
            {
                return this.value;
            }
            set
            {
                this.value = value;
            }
        }
    }

    [Serializable]
    public class DataItemQueryElementTableFilterProperty : Property
    {
        private DataItemQueryElementTableFilter value = new DataItemQueryElementTableFilter();

        internal DataItemQueryElementTableFilterProperty(string name) : base(name)
        {
        }

        public override bool HasValue
        {
            get
            {
                return Value.Any();
            }
        }

        public DataItemQueryElementTableFilter Value
        {
            get
            {
                return this.value;
            }
        }
    }

    [Serializable]
    public class DateMethodProperty : Property
    {
        private DateMethod? value = null;

        internal DateMethodProperty(string name) : base(name)
        {
        }

        public override bool HasValue
        {
            get
            {
                return Value.HasValue;
            }
        }

        public DateMethod? Value
        {
            get
            {
                return this.value;
            }
            set
            {
                this.value = value;
            }
        }
    }

    [Serializable]
    public class DecimalPlacesProperty : Property
    {
        private DecimalPlaces value = new DecimalPlaces();

        internal DecimalPlacesProperty(string name) : base(name)
        {
        }

        public override bool HasValue
        {
            get
            {
                return Value.AtLeast.HasValue || Value.AtMost.HasValue;
            }
        }

        public DecimalPlaces Value
        {
            get
            {
                return this.value;
            }
        }
    }

    [Serializable]
    public class DirectionProperty : Property
    {
        private Direction? value = null;

        internal DirectionProperty(string name) : base(name)
        {
        }

        public override bool HasValue
        {
            get
            {
                return Value.HasValue;
            }
        }

        public Direction? Value
        {
            get
            {
                return this.value;
            }
            set
            {
                this.value = value;
            }
        }
    }

    [Serializable]
    public class DurationProperty : Property
    {
        private System.TimeSpan? value = null;

        internal DurationProperty(string name) : base(name)
        {
        }

        public override bool HasValue
        {
            get
            {
                return Value.HasValue;
            }
        }

        public System.TimeSpan? Value
        {
            get
            {
                return this.value;
            }
            set
            {
                this.value = value;
            }
        }
    }

    [Serializable]
    public class ExtendedDataTypeProperty : Property
    {
        private ExtendedDataType? value = null;

        internal ExtendedDataTypeProperty(string name) : base(name)
        {
        }

        public override bool HasValue
        {
            get
            {
                return Value.HasValue;
            }
        }

        public ExtendedDataType? Value
        {
            get
            {
                return this.value;
            }
            set
            {
                this.value = value;
            }
        }
    }

    [Serializable]
    public class FieldClassProperty : Property
    {
        private FieldClass? value = null;

        internal FieldClassProperty(string name) : base(name)
        {
        }

        public override bool HasValue
        {
            get
            {
                return Value.HasValue;
            }
        }

        public FieldClass? Value
        {
            get
            {
                return this.value;
            }
            set
            {
                this.value = value;
            }
        }
    }

    [Serializable]
    public class FieldListProperty : Property
    {
        private FieldList value = new FieldList();

        internal FieldListProperty(string name) : base(name)
        {
        }

        public override bool HasValue
        {
            get
            {
                return Value.Any();
            }
        }

        public FieldList Value
        {
            get
            {
                return this.value;
            }
        }
    }

    [Serializable]
    public class FormatEvaluateProperty : Property
    {
        private FormatEvaluate? value = null;

        internal FormatEvaluateProperty(string name) : base(name)
        {
        }

        public override bool HasValue
        {
            get
            {
                return Value.HasValue;
            }
        }

        public FormatEvaluate? Value
        {
            get
            {
                return this.value;
            }
            set
            {
                this.value = value;
            }
        }
    }

    [Serializable]
    public class FunctionTypeProperty : Property
    {
        private FunctionType? value = null;

        internal FunctionTypeProperty(string name) : base(name)
        {
        }

        public override bool HasValue
        {
            get
            {
                return Value.HasValue;
            }
        }

        public FunctionType? Value
        {
            get
            {
                return this.value;
            }
            set
            {
                this.value = value;
            }
        }
    }

    [Serializable]
    public class GroupPageControlLayoutProperty : Property
    {
        private GroupPageControlLayout? value = null;

        internal GroupPageControlLayoutProperty(string name) : base(name)
        {
        }

        public override bool HasValue
        {
            get
            {
                return Value.HasValue;
            }
        }

        public GroupPageControlLayout? Value
        {
            get
            {
                return this.value;
            }
            set
            {
                this.value = value;
            }
        }
    }

    [Serializable]
    public class GroupTypeProperty : Property
    {
        private GroupType? value = null;

        internal GroupTypeProperty(string name) : base(name)
        {
        }

        public override bool HasValue
        {
            get
            {
                return Value.HasValue;
            }
        }

        public GroupType? Value
        {
            get
            {
                return this.value;
            }
            set
            {
                this.value = value;
            }
        }
    }

    [Serializable]
    public class ImportanceProperty : Property
    {
        private Importance? value = null;

        internal ImportanceProperty(string name) : base(name)
        {
        }

        public override bool HasValue
        {
            get
            {
                return Value.HasValue;
            }
        }

        public Importance? Value
        {
            get
            {
                return this.value;
            }
            set
            {
                this.value = value;
            }
        }
    }

    [Serializable]
    public class LinkFieldsProperty : Property
    {
        private LinkFields value = new LinkFields();

        internal LinkFieldsProperty(string name) : base(name)
        {
        }

        public override bool HasValue
        {
            get
            {
                return Value.Any();
            }
        }

        public LinkFields Value
        {
            get
            {
                return this.value;
            }
        }
    }

    [Serializable]
    public class MaxOccursProperty : Property
    {
        private MaxOccurs? value = null;

        internal MaxOccursProperty(string name) : base(name)
        {
        }

        public override bool HasValue
        {
            get
            {
                return Value.HasValue;
            }
        }

        public MaxOccurs? Value
        {
            get
            {
                return this.value;
            }
            set
            {
                this.value = value;
            }
        }
    }

    [Serializable]
    public class MenuItemDepartmentCategoryProperty : Property
    {
        private MenuItemDepartmentCategory? value = null;

        internal MenuItemDepartmentCategoryProperty(string name) : base(name)
        {
        }

        public override bool HasValue
        {
            get
            {
                return Value.HasValue;
            }
        }

        public MenuItemDepartmentCategory? Value
        {
            get
            {
                return this.value;
            }
            set
            {
                this.value = value;
            }
        }
    }

    [Serializable]
    public class MenuItemRunObjectTypeProperty : Property
    {
        private MenuItemRunObjectType? value = null;

        internal MenuItemRunObjectTypeProperty(string name) : base(name)
        {
        }

        public override bool HasValue
        {
            get
            {
                return Value.HasValue;
            }
        }

        public MenuItemRunObjectType? Value
        {
            get
            {
                return this.value;
            }
            set
            {
                this.value = value;
            }
        }
    }

    [Serializable]
    public class MethodTypeProperty : Property
    {
        private MethodType? value = null;

        internal MethodTypeProperty(string name) : base(name)
        {
        }

        public override bool HasValue
        {
            get
            {
                return Value.HasValue;
            }
        }

        public MethodType? Value
        {
            get
            {
                return this.value;
            }
            set
            {
                this.value = value;
            }
        }
    }

    [Serializable]
    public class MinOccursProperty : Property
    {
        private MinOccurs? value = null;

        internal MinOccursProperty(string name) : base(name)
        {
        }

        public override bool HasValue
        {
            get
            {
                return Value.HasValue;
            }
        }

        public MinOccurs? Value
        {
            get
            {
                return this.value;
            }
            set
            {
                this.value = value;
            }
        }
    }

    [Serializable]
    public class MultiLanguageProperty : Property
    {
        private MultiLanguageValue value = new MultiLanguageValue();

        internal MultiLanguageProperty(string name) : base(name)
        {
        }

        public override bool HasValue
        {
            get
            {
                return Value.Any();
            }
        }

        public MultiLanguageValue Value
        {
            get
            {
                return this.value;
            }
        }
    }

    [Serializable]
    public class NullableBigIntegerProperty : Property
    {
        private System.Int64? value = null;

        internal NullableBigIntegerProperty(string name) : base(name)
        {
        }

        public override bool HasValue
        {
            get
            {
                return Value.HasValue;
            }
        }

        public System.Int64? Value
        {
            get
            {
                return this.value;
            }
            set
            {
                this.value = value;
            }
        }
    }

    [Serializable]
    public class NullableBooleanProperty : Property
    {
        private System.Boolean? value = null;

        internal NullableBooleanProperty(string name) : base(name)
        {
        }

        public override bool HasValue
        {
            get
            {
                return Value.HasValue;
            }
        }

        public System.Boolean? Value
        {
            get
            {
                return this.value;
            }
            set
            {
                this.value = value;
            }
        }
    }

    [Serializable]
    public class NullableDateProperty : Property
    {
        private System.DateTime? value = null;

        internal NullableDateProperty(string name) : base(name)
        {
        }

        public override bool HasValue
        {
            get
            {
                return Value.HasValue;
            }
        }

        public System.DateTime? Value
        {
            get
            {
                return this.value;
            }
            set
            {
                this.value = value;
            }
        }
    }

    [Serializable]
    public class NullableDateTimeProperty : Property
    {
        private System.DateTime? value = null;

        internal NullableDateTimeProperty(string name) : base(name)
        {
        }

        public override bool HasValue
        {
            get
            {
                return Value.HasValue;
            }
        }

        public System.DateTime? Value
        {
            get
            {
                return this.value;
            }
            set
            {
                this.value = value;
            }
        }
    }

    [Serializable]
    public class NullableDecimalProperty : Property
    {
        private System.Decimal? value = null;

        internal NullableDecimalProperty(string name) : base(name)
        {
        }

        public override bool HasValue
        {
            get
            {
                return Value.HasValue;
            }
        }

        public System.Decimal? Value
        {
            get
            {
                return this.value;
            }
            set
            {
                this.value = value;
            }
        }
    }

    [Serializable]
    public class NullableGuidProperty : Property
    {
        private System.Guid? value = null;

        internal NullableGuidProperty(string name) : base(name)
        {
        }

        public override bool HasValue
        {
            get
            {
                return Value.HasValue;
            }
        }

        public System.Guid? Value
        {
            get
            {
                return this.value;
            }
            set
            {
                this.value = value;
            }
        }
    }

    [Serializable]
    public class NullableIntegerProperty : Property
    {
        private System.Int32? value = null;

        internal NullableIntegerProperty(string name) : base(name)
        {
        }

        public override bool HasValue
        {
            get
            {
                return Value.HasValue;
            }
        }

        public System.Int32? Value
        {
            get
            {
                return this.value;
            }
            set
            {
                this.value = value;
            }
        }
    }

    [Serializable]
    public class NullableTimeProperty : Property
    {
        private System.TimeSpan? value = null;

        internal NullableTimeProperty(string name) : base(name)
        {
        }

        public override bool HasValue
        {
            get
            {
                return Value.HasValue;
            }
        }

        public System.TimeSpan? Value
        {
            get
            {
                return this.value;
            }
            set
            {
                this.value = value;
            }
        }
    }

    [Serializable]
    public class ObjectProperty : Property
    {
        private System.Object value = null;

        internal ObjectProperty(string name) : base(name)
        {
        }

        public override bool HasValue
        {
            get
            {
                return Value != null;
            }
        }

        public System.Object Value
        {
            get
            {
                return this.value;
            }
            set
            {
                this.value = value;
            }
        }
    }

    [Serializable]
    public class ObjectReferenceProperty : Property
    {
        private ObjectReference value = new ObjectReference();

        internal ObjectReferenceProperty(string name) : base(name)
        {
        }

        public override bool HasValue
        {
            get
            {
                return Value.ID != 0;
            }
        }

        public ObjectReference Value
        {
            get
            {
                return this.value;
            }
        }
    }

    [Serializable]
    public class OccurrenceProperty : Property
    {
        private Occurrence? value = null;

        internal OccurrenceProperty(string name) : base(name)
        {
        }

        public override bool HasValue
        {
            get
            {
                return Value.HasValue;
            }
        }

        public Occurrence? Value
        {
            get
            {
                return this.value;
            }
            set
            {
                this.value = value;
            }
        }
    }

    [Serializable]
    public class OptionStringProperty : Property
    {
        private System.String value = null;

        internal OptionStringProperty(string name) : base(name)
        {
        }

        public override bool HasValue
        {
            get
            {
                return Value != null;
            }
        }

        public System.String Value
        {
            get
            {
                return this.value;
            }
            set
            {
                this.value = value;
            }
        }
    }

    [Serializable]
    public class PageReferenceProperty : Property
    {
        private System.Int32? value = null;

        internal PageReferenceProperty(string name) : base(name)
        {
        }

        public override bool HasValue
        {
            get
            {
                return Value.HasValue;
            }
        }

        public System.Int32? Value
        {
            get
            {
                return this.value;
            }
            set
            {
                this.value = value;
            }
        }
    }

    [Serializable]
    public class PageTypeProperty : Property
    {
        private PageType? value = null;

        internal PageTypeProperty(string name) : base(name)
        {
        }

        public override bool HasValue
        {
            get
            {
                return Value.HasValue;
            }
        }

        public PageType? Value
        {
            get
            {
                return this.value;
            }
            set
            {
                this.value = value;
            }
        }
    }

    [Serializable]
    public class PaperSourceProperty : Property
    {
        private PaperSource? value = null;

        internal PaperSourceProperty(string name) : base(name)
        {
        }

        public override bool HasValue
        {
            get
            {
                return Value.HasValue;
            }
        }

        public PaperSource? Value
        {
            get
            {
                return this.value;
            }
            set
            {
                this.value = value;
            }
        }
    }

    [Serializable]
    public class PartTypeProperty : Property
    {
        private PartType? value = null;

        internal PartTypeProperty(string name) : base(name)
        {
        }

        public override bool HasValue
        {
            get
            {
                return Value.HasValue;
            }
        }

        public PartType? Value
        {
            get
            {
                return this.value;
            }
            set
            {
                this.value = value;
            }
        }
    }

    [Serializable]
    public class PermissionsProperty : Property
    {
        private Permissions value = new Permissions();

        internal PermissionsProperty(string name) : base(name)
        {
        }

        public override bool HasValue
        {
            get
            {
                return Value.Any();
            }
        }

        public Permissions Value
        {
            get
            {
                return this.value;
            }
        }
    }

    [Serializable]
    public class PromotedCategoryProperty : Property
    {
        private PromotedCategory? value = null;

        internal PromotedCategoryProperty(string name) : base(name)
        {
        }

        public override bool HasValue
        {
            get
            {
                return Value.HasValue;
            }
        }

        public PromotedCategory? Value
        {
            get
            {
                return this.value;
            }
            set
            {
                this.value = value;
            }
        }
    }

    [Serializable]
    public class QueryDataItemLinkProperty : Property
    {
        private QueryDataItemLink value = new QueryDataItemLink();

        internal QueryDataItemLinkProperty(string name) : base(name)
        {
        }

        public override bool HasValue
        {
            get
            {
                return Value.Any();
            }
        }

        public QueryDataItemLink Value
        {
            get
            {
                return this.value;
            }
        }
    }

    [Serializable]
    public class QueryOrderByLinesProperty : Property
    {
        private QueryOrderByLines value = new QueryOrderByLines();

        internal QueryOrderByLinesProperty(string name) : base(name)
        {
        }

        public override bool HasValue
        {
            get
            {
                return Value.Any();
            }
        }

        public QueryOrderByLines Value
        {
            get
            {
                return this.value;
            }
        }
    }

    [Serializable]
    public class ReadStateProperty : Property
    {
        private ReadState? value = null;

        internal ReadStateProperty(string name) : base(name)
        {
        }

        public override bool HasValue
        {
            get
            {
                return Value.HasValue;
            }
        }

        public ReadState? Value
        {
            get
            {
                return this.value;
            }
            set
            {
                this.value = value;
            }
        }
    }

    [Serializable]
    public class ReportDataItemLinkProperty : Property
    {
        private ReportDataItemLink value = new ReportDataItemLink();

        internal ReportDataItemLinkProperty(string name) : base(name)
        {
        }

        public override bool HasValue
        {
            get
            {
                return Value.Any();
            }
        }

        public ReportDataItemLink Value
        {
            get
            {
                return this.value;
            }
        }
    }

    [Serializable]
    public class RunObjectLinkProperty : Property
    {
        private RunObjectLink value = new RunObjectLink();

        internal RunObjectLinkProperty(string name) : base(name)
        {
        }

        public override bool HasValue
        {
            get
            {
                return Value.Any();
            }
        }

        public RunObjectLink Value
        {
            get
            {
                return this.value;
            }
        }
    }

    [Serializable]
    public class RunPageModeProperty : Property
    {
        private RunPageMode? value = null;

        internal RunPageModeProperty(string name) : base(name)
        {
        }

        public override bool HasValue
        {
            get
            {
                return Value.HasValue;
            }
        }

        public RunPageMode? Value
        {
            get
            {
                return this.value;
            }
            set
            {
                this.value = value;
            }
        }
    }

    [Serializable]
    public class ScopedTriggerProperty : Property
    {
        private Trigger value = new Trigger();

        internal ScopedTriggerProperty(string name) : base(name)
        {
        }

        public override bool HasValue
        {
            get
            {
                return Value.CodeLines.Any() || Value.Variables.Any();
            }
        }

        public Trigger Value
        {
            get
            {
                return this.value;
            }
        }
    }

    [Serializable]
    public class SemiColonSeparatedStringProperty : Property
    {
        private System.String value = null;

        internal SemiColonSeparatedStringProperty(string name) : base(name)
        {
        }

        public override bool HasValue
        {
            get
            {
                return Value != null;
            }
        }

        public System.String Value
        {
            get
            {
                return this.value;
            }
            set
            {
                this.value = value;
            }
        }
    }

    [Serializable]
    public class SIFTLevelsProperty : Property
    {
        private SIFTLevels value = new SIFTLevels();

        internal SIFTLevelsProperty(string name) : base(name)
        {
        }

        public override bool HasValue
        {
            get
            {
                return Value.Any();
            }
        }

        public SIFTLevels Value
        {
            get
            {
                return this.value;
            }
        }
    }

    [Serializable]
    public class SourceFieldProperty : Property
    {
        private SourceField value = new SourceField();

        internal SourceFieldProperty(string name) : base(name)
        {
        }

        public override bool HasValue
        {
            get
            {
                return Value.TableVariableName != null || value.FieldName != null;
            }
        }

        public SourceField Value
        {
            get
            {
                return this.value;
            }
        }
    }

    [Serializable]
    public class SqlDataTypeProperty : Property
    {
        private SqlDataType? value = null;

        internal SqlDataTypeProperty(string name) : base(name)
        {
        }

        public override bool HasValue
        {
            get
            {
                return Value.HasValue;
            }
        }

        public SqlDataType? Value
        {
            get
            {
                return this.value;
            }
            set
            {
                this.value = value;
            }
        }
    }

    [Serializable]
    public class SqlJoinTypeProperty : Property
    {
        private SqlJoinType? value = null;

        internal SqlJoinTypeProperty(string name) : base(name)
        {
        }

        public override bool HasValue
        {
            get
            {
                return Value.HasValue;
            }
        }

        public SqlJoinType? Value
        {
            get
            {
                return this.value;
            }
            set
            {
                this.value = value;
            }
        }
    }

    [Serializable]
    public class StandardDayTimeUnitProperty : Property
    {
        private StandardDayTimeUnit? value = null;

        internal StandardDayTimeUnitProperty(string name) : base(name)
        {
        }

        public override bool HasValue
        {
            get
            {
                return Value.HasValue;
            }
        }

        public StandardDayTimeUnit? Value
        {
            get
            {
                return this.value;
            }
            set
            {
                this.value = value;
            }
        }
    }

    [Serializable]
    public class StringProperty : Property
    {
        private System.String value = null;

        internal StringProperty(string name) : base(name)
        {
        }

        public override bool HasValue
        {
            get
            {
                return Value != null;
            }
        }

        public System.String Value
        {
            get
            {
                return this.value;
            }
            set
            {
                this.value = value;
            }
        }
    }

    [Serializable]
    public class StyleProperty : Property
    {
        private Style? value = null;

        internal StyleProperty(string name) : base(name)
        {
        }

        public override bool HasValue
        {
            get
            {
                return Value.HasValue;
            }
        }

        public Style? Value
        {
            get
            {
                return this.value;
            }
            set
            {
                this.value = value;
            }
        }
    }

    [Serializable]
    public class SystemPartIDProperty : Property
    {
        private SystemPartID? value = null;

        internal SystemPartIDProperty(string name) : base(name)
        {
        }

        public override bool HasValue
        {
            get
            {
                return Value.HasValue;
            }
        }

        public SystemPartID? Value
        {
            get
            {
                return this.value;
            }
            set
            {
                this.value = value;
            }
        }
    }

    [Serializable]
    public class TableFieldTypeProperty : Property
    {
        private TableFieldType? value = null;

        internal TableFieldTypeProperty(string name) : base(name)
        {
        }

        public override bool HasValue
        {
            get
            {
                return Value.HasValue;
            }
        }

        public TableFieldType? Value
        {
            get
            {
                return this.value;
            }
            set
            {
                this.value = value;
            }
        }
    }

    [Serializable]
    public class TableReferenceProperty : Property
    {
        private System.Int32? value = null;

        internal TableReferenceProperty(string name) : base(name)
        {
        }

        public override bool HasValue
        {
            get
            {
                return Value.HasValue;
            }
        }

        public System.Int32? Value
        {
            get
            {
                return this.value;
            }
            set
            {
                this.value = value;
            }
        }
    }

    [Serializable]
    public class TableRelationLinesProperty : Property
    {
        private TableRelationLines value = new TableRelationLines();

        internal TableRelationLinesProperty(string name) : base(name)
        {
        }

        public override bool HasValue
        {
            get
            {
                return Value.Any();
            }
        }

        public TableRelationLines Value
        {
            get
            {
                return this.value;
            }
        }
    }

    [Serializable]
    public class TableViewProperty : Property
    {
        private TableView value = new TableView();

        internal TableViewProperty(string name) : base(name)
        {
        }

        public override bool HasValue
        {
            get
            {
                return Value.Key != null || Value.Order.HasValue || Value.TableFilter.Any();
            }
        }

        public TableView Value
        {
            get
            {
                return this.value;
            }
        }
    }

    [Serializable]
    public class TestIsolationProperty : Property
    {
        private TestIsolation? value = null;

        internal TestIsolationProperty(string name) : base(name)
        {
        }

        public override bool HasValue
        {
            get
            {
                return Value.HasValue;
            }
        }

        public TestIsolation? Value
        {
            get
            {
                return this.value;
            }
        }
    }

    [Serializable]
    public class TextEncodingProperty : Property
    {
        private TextEncoding? value = null;

        internal TextEncodingProperty(string name) : base(name)
        {
        }

        public override bool HasValue
        {
            get
            {
                return Value.HasValue;
            }
        }

        public TextEncoding? Value
        {
            get
            {
                return this.value;
            }
            set
            {
                this.value = value;
            }
        }
    }

    [Serializable]
    public class TextTypeProperty : Property
    {
        private TextType? value = null;

        internal TextTypeProperty(string name) : base(name)
        {
        }

        public override bool HasValue
        {
            get
            {
                return Value.HasValue;
            }
        }

        public TextType? Value
        {
            get
            {
                return this.value;
            }
            set
            {
                this.value = value;
            }
        }
    }

    [Serializable]
    public class TotalsMethodProperty : Property
    {
        private TotalsMethod? value = null;

        internal TotalsMethodProperty(string name) : base(name)
        {
        }

        public override bool HasValue
        {
            get
            {
                return Value.HasValue;
            }
        }

        public TotalsMethod? Value
        {
            get
            {
                return this.value;
            }
            set
            {
                this.value = value;
            }
        }
    }

    [Serializable]
    public class TransactionModelProperty : Property
    {
        private TransactionModel? value = null;

        internal TransactionModelProperty(string name) : base(name)
        {
        }

        public override bool HasValue
        {
            get
            {
                return Value.HasValue;
            }
        }

        public TransactionModel? Value
        {
            get
            {
                return this.value;
            }
            set
            {
                this.value = value;
            }
        }
    }

    [Serializable]
    public class TransactionTypeProperty : Property
    {
        private TransactionType? value = null;

        internal TransactionTypeProperty(string name) : base(name)
        {
        }

        public override bool HasValue
        {
            get
            {
                return Value.HasValue;
            }
        }

        public TransactionType? Value
        {
            get
            {
                return this.value;
            }
            set
            {
                this.value = value;
            }
        }
    }

    [Serializable]
    public class TriggerProperty : Property
    {
        private Trigger value = new Trigger();

        internal TriggerProperty(string name) : base(name)
        {
        }

        public override bool HasValue
        {
            get
            {
                return Value.CodeLines.Any() || Value.Variables.Any();
            }
        }

        public Trigger Value
        {
            get
            {
                return this.value;
            }
        }
    }

    [Serializable]
    public class XmlPortEncodingProperty : Property
    {
        private XmlPortEncoding? value = null;

        internal XmlPortEncodingProperty(string name) : base(name)
        {
        }

        public override bool HasValue
        {
            get
            {
                return Value.HasValue;
            }
        }

        public XmlPortEncoding? Value
        {
            get
            {
                return this.value;
            }
            set
            {
                this.value = value;
            }
        }
    }

    [Serializable]
    public class XmlPortFormatProperty : Property
    {
        private XmlPortFormat? value = null;

        internal XmlPortFormatProperty(string name) : base(name)
        {
        }

        public override bool HasValue
        {
            get
            {
                return Value.HasValue;
            }
        }

        public XmlPortFormat? Value
        {
            get
            {
                return this.value;
            }
            set
            {
                this.value = value;
            }
        }
    }

    [Serializable]
    public class XmlVersionNoProperty : Property
    {
        private XmlVersionNo? value = null;

        internal XmlVersionNoProperty(string name) : base(name)
        {
        }

        public override bool HasValue
        {
            get
            {
                return Value.HasValue;
            }
        }

        public XmlVersionNo? Value
        {
            get
            {
                return this.value;
            }
            set
            {
                this.value = value;
            }
        }
    }

    #endregion
    #region Property Collections
    [Serializable]
    public class BigIntegerTableFieldProperties : IEnumerable<Property>
    {
        private List<Property> innerList = new List<Property>();

        private StringProperty altSearchField = new StringProperty("AltSearchField");
        private StringProperty autoFormatExpr = new StringProperty("AutoFormatExpr");
        private AutoFormatTypeProperty autoFormatType = new AutoFormatTypeProperty("AutoFormatType");
        private NullableBooleanProperty autoIncrement = new NullableBooleanProperty("AutoIncrement");
        private BlankNumbersProperty blankNumbers = new BlankNumbersProperty("BlankNumbers");
        private NullableBooleanProperty blankZero = new NullableBooleanProperty("BlankZero");
        private CalcFormulaProperty calcFormula = new CalcFormulaProperty("CalcFormula");
        private StringProperty captionClass = new StringProperty("CaptionClass");
        private MultiLanguageProperty captionML = new MultiLanguageProperty("CaptionML");
        private StringProperty description = new StringProperty("Description");
        private NullableBooleanProperty editable = new NullableBooleanProperty("Editable");
        private ExtendedDataTypeProperty extendedDatatype = new ExtendedDataTypeProperty("ExtendedDatatype");
        private FieldClassProperty fieldClass = new FieldClassProperty("FieldClass");
        private NullableBigIntegerProperty initValue = new NullableBigIntegerProperty("InitValue");
        private NullableBigIntegerProperty maxValue = new NullableBigIntegerProperty("MaxValue");
        private NullableBigIntegerProperty minValue = new NullableBigIntegerProperty("MinValue");
        private NullableBooleanProperty notBlank = new NullableBooleanProperty("NotBlank");
        private TriggerProperty onLookup = new TriggerProperty("OnLookup");
        private TriggerProperty onValidate = new TriggerProperty("OnValidate");
        private NullableIntegerProperty signDisplacement = new NullableIntegerProperty("SignDisplacement");
        private TableRelationLinesProperty tableRelation = new TableRelationLinesProperty("TableRelation");
        private NullableBooleanProperty testTableRelation = new NullableBooleanProperty("TestTableRelation");
        private NullableBooleanProperty validateTableRelation = new NullableBooleanProperty("ValidateTableRelation");
        private SemiColonSeparatedStringProperty valuesAllowed = new SemiColonSeparatedStringProperty("ValuesAllowed");
        private NullableBooleanProperty @volatile = new NullableBooleanProperty("Volatile");
        private NullableIntegerProperty width = new NullableIntegerProperty("Width");

        internal BigIntegerTableFieldProperties()
        {
            innerList.Add(fieldClass);
            innerList.Add(calcFormula);
            innerList.Add(initValue);
            innerList.Add(tableRelation);
            innerList.Add(altSearchField);
            innerList.Add(onValidate);
            innerList.Add(onLookup);
            innerList.Add(validateTableRelation);
            innerList.Add(testTableRelation);
            innerList.Add(autoIncrement);
            innerList.Add(extendedDatatype);
            innerList.Add(width);
            innerList.Add(@volatile);
            innerList.Add(captionML);
            innerList.Add(minValue);
            innerList.Add(maxValue);
            innerList.Add(notBlank);
            innerList.Add(blankNumbers);
            innerList.Add(blankZero);
            innerList.Add(valuesAllowed);
            innerList.Add(signDisplacement);
            innerList.Add(description);
            innerList.Add(editable);
            innerList.Add(autoFormatType);
            innerList.Add(autoFormatExpr);
            innerList.Add(captionClass);
        }

      public System.String AltSearchField
        {
            get
            {
                return this.altSearchField.Value;
            }
            set
            {
                this.altSearchField.Value = value;
            }
        }

      public System.String AutoFormatExpr
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

      public System.Boolean? AutoIncrement
        {
            get
            {
                return this.autoIncrement.Value;
            }
            set
            {
                this.autoIncrement.Value = value;
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

      public System.Boolean? BlankZero
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

        public CalcFormula CalcFormula
        {
            get
            {
                return this.calcFormula.Value;
            }
        }

      public System.String CaptionClass
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

      public System.String Description
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

      public System.Boolean? Editable
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

        public FieldClass? FieldClass
        {
            get
            {
                return this.fieldClass.Value;
            }
            set
            {
                this.fieldClass.Value = value;
            }
        }

      public System.Int64? InitValue
        {
            get
            {
                return this.initValue.Value;
            }
            set
            {
                this.initValue.Value = value;
            }
        }

      public System.Int64? MaxValue
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

      public System.Int64? MinValue
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

      public System.Boolean? NotBlank
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

      public System.Int32? SignDisplacement
        {
            get
            {
                return this.signDisplacement.Value;
            }
            set
            {
                this.signDisplacement.Value = value;
            }
        }

        public TableRelationLines TableRelation
        {
            get
            {
                return this.tableRelation.Value;
            }
        }

      public System.Boolean? TestTableRelation
        {
            get
            {
                return this.testTableRelation.Value;
            }
            set
            {
                this.testTableRelation.Value = value;
            }
        }

      public System.Boolean? ValidateTableRelation
        {
            get
            {
                return this.validateTableRelation.Value;
            }
            set
            {
                this.validateTableRelation.Value = value;
            }
        }

      public System.String ValuesAllowed
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

      public System.Boolean? Volatile
        {
            get
            {
                return this.@volatile.Value;
            }
            set
            {
                this.@volatile.Value = value;
            }
        }

      public System.Int32? Width
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

        public IEnumerator<Property> GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

    }

    [Serializable]
    public class BinaryTableFieldProperties : IEnumerable<Property>
    {
        private List<Property> innerList = new List<Property>();

        private MultiLanguageProperty captionML = new MultiLanguageProperty("CaptionML");
        private StringProperty description = new StringProperty("Description");
        private TriggerProperty onLookup = new TriggerProperty("OnLookup");
        private TriggerProperty onValidate = new TriggerProperty("OnValidate");

        internal BinaryTableFieldProperties()
        {
            innerList.Add(onValidate);
            innerList.Add(onLookup);
            innerList.Add(captionML);
            innerList.Add(description);
        }

        public MultiLanguageValue CaptionML
        {
            get
            {
                return this.captionML.Value;
            }
        }

      public System.String Description
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

        public IEnumerator<Property> GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

    }

    [Serializable]
    public class BlobTableFieldProperties : IEnumerable<Property>
    {
        private List<Property> innerList = new List<Property>();

        private MultiLanguageProperty captionML = new MultiLanguageProperty("CaptionML");
        private NullableBooleanProperty compressed = new NullableBooleanProperty("Compressed");
        private StringProperty description = new StringProperty("Description");
        private TriggerProperty onLookup = new TriggerProperty("OnLookup");
        private TriggerProperty onValidate = new TriggerProperty("OnValidate");
        private StringProperty owner = new StringProperty("Owner");
        private BlobSubTypeProperty subType = new BlobSubTypeProperty("SubType");
        private NullableBooleanProperty @volatile = new NullableBooleanProperty("Volatile");

        internal BlobTableFieldProperties()
        {
            innerList.Add(onValidate);
            innerList.Add(onLookup);
            innerList.Add(compressed);
            innerList.Add(@volatile);
            innerList.Add(captionML);
            innerList.Add(description);
            innerList.Add(owner);
            innerList.Add(subType);
        }

        public MultiLanguageValue CaptionML
        {
            get
            {
                return this.captionML.Value;
            }
        }

      public System.Boolean? Compressed
        {
            get
            {
                return this.compressed.Value;
            }
            set
            {
                this.compressed.Value = value;
            }
        }

      public System.String Description
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

      public System.String Owner
        {
            get
            {
                return this.owner.Value;
            }
            set
            {
                this.owner.Value = value;
            }
        }

        public BlobSubType? SubType
        {
            get
            {
                return this.subType.Value;
            }
            set
            {
                this.subType.Value = value;
            }
        }

      public System.Boolean? Volatile
        {
            get
            {
                return this.@volatile.Value;
            }
            set
            {
                this.@volatile.Value = value;
            }
        }

        public IEnumerator<Property> GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

    }

    [Serializable]
    public class BooleanTableFieldProperties : IEnumerable<Property>
    {
        private List<Property> innerList = new List<Property>();

        private StringProperty altSearchField = new StringProperty("AltSearchField");
        private StringProperty autoFormatExpr = new StringProperty("AutoFormatExpr");
        private AutoFormatTypeProperty autoFormatType = new AutoFormatTypeProperty("AutoFormatType");
        private BlankNumbersProperty blankNumbers = new BlankNumbersProperty("BlankNumbers");
        private NullableBooleanProperty blankZero = new NullableBooleanProperty("BlankZero");
        private CalcFormulaProperty calcFormula = new CalcFormulaProperty("CalcFormula");
        private StringProperty captionClass = new StringProperty("CaptionClass");
        private MultiLanguageProperty captionML = new MultiLanguageProperty("CaptionML");
        private StringProperty description = new StringProperty("Description");
        private NullableBooleanProperty editable = new NullableBooleanProperty("Editable");
        private ExtendedDataTypeProperty extendedDatatype = new ExtendedDataTypeProperty("ExtendedDatatype");
        private FieldClassProperty fieldClass = new FieldClassProperty("FieldClass");
        private NullableBooleanProperty initValue = new NullableBooleanProperty("InitValue");
        private NullableBooleanProperty maxValue = new NullableBooleanProperty("MaxValue");
        private NullableBooleanProperty minValue = new NullableBooleanProperty("MinValue");
        private NullableBooleanProperty notBlank = new NullableBooleanProperty("NotBlank");
        private TriggerProperty onLookup = new TriggerProperty("OnLookup");
        private TriggerProperty onValidate = new TriggerProperty("OnValidate");
        private NullableIntegerProperty signDisplacement = new NullableIntegerProperty("SignDisplacement");
        private TableRelationLinesProperty tableRelation = new TableRelationLinesProperty("TableRelation");
        private NullableBooleanProperty testTableRelation = new NullableBooleanProperty("TestTableRelation");
        private NullableBooleanProperty validateTableRelation = new NullableBooleanProperty("ValidateTableRelation");
        private SemiColonSeparatedStringProperty valuesAllowed = new SemiColonSeparatedStringProperty("ValuesAllowed");

        internal BooleanTableFieldProperties()
        {
            innerList.Add(fieldClass);
            innerList.Add(initValue);
            innerList.Add(calcFormula);
            innerList.Add(tableRelation);
            innerList.Add(altSearchField);
            innerList.Add(onValidate);
            innerList.Add(onLookup);
            innerList.Add(validateTableRelation);
            innerList.Add(testTableRelation);
            innerList.Add(extendedDatatype);
            innerList.Add(captionML);
            innerList.Add(minValue);
            innerList.Add(maxValue);
            innerList.Add(notBlank);
            innerList.Add(blankNumbers);
            innerList.Add(blankZero);
            innerList.Add(valuesAllowed);
            innerList.Add(signDisplacement);
            innerList.Add(description);
            innerList.Add(editable);
            innerList.Add(autoFormatType);
            innerList.Add(autoFormatExpr);
            innerList.Add(captionClass);
        }

      public System.String AltSearchField
        {
            get
            {
                return this.altSearchField.Value;
            }
            set
            {
                this.altSearchField.Value = value;
            }
        }

      public System.String AutoFormatExpr
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

      public System.Boolean? BlankZero
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

        public CalcFormula CalcFormula
        {
            get
            {
                return this.calcFormula.Value;
            }
        }

      public System.String CaptionClass
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

      public System.String Description
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

      public System.Boolean? Editable
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

        public FieldClass? FieldClass
        {
            get
            {
                return this.fieldClass.Value;
            }
            set
            {
                this.fieldClass.Value = value;
            }
        }

      public System.Boolean? InitValue
        {
            get
            {
                return this.initValue.Value;
            }
            set
            {
                this.initValue.Value = value;
            }
        }

      public System.Boolean? MaxValue
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

      public System.Boolean? MinValue
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

      public System.Boolean? NotBlank
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

      public System.Int32? SignDisplacement
        {
            get
            {
                return this.signDisplacement.Value;
            }
            set
            {
                this.signDisplacement.Value = value;
            }
        }

        public TableRelationLines TableRelation
        {
            get
            {
                return this.tableRelation.Value;
            }
        }

      public System.Boolean? TestTableRelation
        {
            get
            {
                return this.testTableRelation.Value;
            }
            set
            {
                this.testTableRelation.Value = value;
            }
        }

      public System.Boolean? ValidateTableRelation
        {
            get
            {
                return this.validateTableRelation.Value;
            }
            set
            {
                this.validateTableRelation.Value = value;
            }
        }

      public System.String ValuesAllowed
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

        public IEnumerator<Property> GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

    }

    [Serializable]
    public class CodeTableFieldProperties : IEnumerable<Property>
    {
        private List<Property> innerList = new List<Property>();

        private StringProperty altSearchField = new StringProperty("AltSearchField");
        private StringProperty autoFormatExpr = new StringProperty("AutoFormatExpr");
        private AutoFormatTypeProperty autoFormatType = new AutoFormatTypeProperty("AutoFormatType");
        private CalcFormulaProperty calcFormula = new CalcFormulaProperty("CalcFormula");
        private StringProperty captionClass = new StringProperty("CaptionClass");
        private MultiLanguageProperty captionML = new MultiLanguageProperty("CaptionML");
        private StringProperty charAllowed = new StringProperty("CharAllowed");
        private NullableBooleanProperty dateFormula = new NullableBooleanProperty("DateFormula");
        private StringProperty description = new StringProperty("Description");
        private NullableBooleanProperty editable = new NullableBooleanProperty("Editable");
        private ExtendedDataTypeProperty extendedDatatype = new ExtendedDataTypeProperty("ExtendedDatatype");
        private FieldClassProperty fieldClass = new FieldClassProperty("FieldClass");
        private StringProperty initValue = new StringProperty("InitValue");
        private NullableBooleanProperty notBlank = new NullableBooleanProperty("NotBlank");
        private NullableBooleanProperty numeric = new NullableBooleanProperty("Numeric");
        private TriggerProperty onLookup = new TriggerProperty("OnLookup");
        private TriggerProperty onValidate = new TriggerProperty("OnValidate");
        private SqlDataTypeProperty sQLDataType = new SqlDataTypeProperty("SQLDataType");
        private TableRelationLinesProperty tableRelation = new TableRelationLinesProperty("TableRelation");
        private NullableBooleanProperty testTableRelation = new NullableBooleanProperty("TestTableRelation");
        private NullableBooleanProperty validateTableRelation = new NullableBooleanProperty("ValidateTableRelation");
        private SemiColonSeparatedStringProperty valuesAllowed = new SemiColonSeparatedStringProperty("ValuesAllowed");
        private NullableIntegerProperty width = new NullableIntegerProperty("Width");

        internal CodeTableFieldProperties()
        {
            innerList.Add(fieldClass);
            innerList.Add(calcFormula);
            innerList.Add(initValue);
            innerList.Add(tableRelation);
            innerList.Add(altSearchField);
            innerList.Add(onValidate);
            innerList.Add(onLookup);
            innerList.Add(validateTableRelation);
            innerList.Add(testTableRelation);
            innerList.Add(extendedDatatype);
            innerList.Add(width);
            innerList.Add(captionML);
            innerList.Add(sQLDataType);
            innerList.Add(notBlank);
            innerList.Add(numeric);
            innerList.Add(charAllowed);
            innerList.Add(dateFormula);
            innerList.Add(valuesAllowed);
            innerList.Add(description);
            innerList.Add(editable);
            innerList.Add(autoFormatType);
            innerList.Add(autoFormatExpr);
            innerList.Add(captionClass);
        }

      public System.String AltSearchField
        {
            get
            {
                return this.altSearchField.Value;
            }
            set
            {
                this.altSearchField.Value = value;
            }
        }

      public System.String AutoFormatExpr
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

        public CalcFormula CalcFormula
        {
            get
            {
                return this.calcFormula.Value;
            }
        }

      public System.String CaptionClass
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

      public System.String CharAllowed
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

      public System.Boolean? DateFormula
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

      public System.String Description
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

      public System.Boolean? Editable
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

        public FieldClass? FieldClass
        {
            get
            {
                return this.fieldClass.Value;
            }
            set
            {
                this.fieldClass.Value = value;
            }
        }

      public System.String InitValue
        {
            get
            {
                return this.initValue.Value;
            }
            set
            {
                this.initValue.Value = value;
            }
        }

      public System.Boolean? NotBlank
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

      public System.Boolean? Numeric
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

        public SqlDataType? SQLDataType
        {
            get
            {
                return this.sQLDataType.Value;
            }
            set
            {
                this.sQLDataType.Value = value;
            }
        }

        public TableRelationLines TableRelation
        {
            get
            {
                return this.tableRelation.Value;
            }
        }

      public System.Boolean? TestTableRelation
        {
            get
            {
                return this.testTableRelation.Value;
            }
            set
            {
                this.testTableRelation.Value = value;
            }
        }

      public System.Boolean? ValidateTableRelation
        {
            get
            {
                return this.validateTableRelation.Value;
            }
            set
            {
                this.validateTableRelation.Value = value;
            }
        }

      public System.String ValuesAllowed
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

      public System.Int32? Width
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

        public IEnumerator<Property> GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

    }

    [Serializable]
    public class CodeunitProperties : IEnumerable<Property>
    {
        private List<Property> innerList = new List<Property>();

        private NullableBooleanProperty cFRONTMayUsePermissions = new NullableBooleanProperty("CFRONTMayUsePermissions");
        private TriggerProperty onRun = new TriggerProperty("OnRun");
        private PermissionsProperty permissions = new PermissionsProperty("Permissions");
        private NullableBooleanProperty singleInstance = new NullableBooleanProperty("SingleInstance");
        private CodeunitSubTypeProperty subtype = new CodeunitSubTypeProperty("Subtype");
        private NullableIntegerProperty tableNo = new NullableIntegerProperty("TableNo");
        private TestIsolationProperty testIsolation = new TestIsolationProperty("TestIsolation");

        internal CodeunitProperties()
        {
            innerList.Add(tableNo);
            innerList.Add(permissions);
            innerList.Add(cFRONTMayUsePermissions);
            innerList.Add(singleInstance);
            innerList.Add(subtype);
            innerList.Add(testIsolation);
            innerList.Add(onRun);
        }

      public System.Boolean? CFRONTMayUsePermissions
        {
            get
            {
                return this.cFRONTMayUsePermissions.Value;
            }
            set
            {
                this.cFRONTMayUsePermissions.Value = value;
            }
        }

        public Trigger OnRun
        {
            get
            {
                return this.onRun.Value;
            }
        }

        public Permissions Permissions
        {
            get
            {
                return this.permissions.Value;
            }
        }

      public System.Boolean? SingleInstance
        {
            get
            {
                return this.singleInstance.Value;
            }
            set
            {
                this.singleInstance.Value = value;
            }
        }

        public CodeunitSubType? Subtype
        {
            get
            {
                return this.subtype.Value;
            }
            set
            {
                this.subtype.Value = value;
            }
        }

      public System.Int32? TableNo
        {
            get
            {
                return this.tableNo.Value;
            }
            set
            {
                this.tableNo.Value = value;
            }
        }

        public TestIsolation? TestIsolation
        {
            get
            {
                return this.testIsolation.Value;
            }
        }

        public IEnumerator<Property> GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

    }

    [Serializable]
    public class ColumnQueryElementProperties : IEnumerable<Property>
    {
        private List<Property> innerList = new List<Property>();

        private MultiLanguageProperty captionML = new MultiLanguageProperty("CaptionML");
        private ColumnFilterProperty columnFilter = new ColumnFilterProperty("ColumnFilter");
        private StringProperty dataSource = new StringProperty("DataSource");
        private DateMethodProperty dateMethod = new DateMethodProperty("DateMethod");
        private StringProperty description = new StringProperty("Description");
        private MethodTypeProperty methodType = new MethodTypeProperty("MethodType");
        private NullableBooleanProperty reverseSign = new NullableBooleanProperty("ReverseSign");
        private TotalsMethodProperty totalsMethod = new TotalsMethodProperty("TotalsMethod");

        internal ColumnQueryElementProperties()
        {
            innerList.Add(captionML);
            innerList.Add(description);
            innerList.Add(columnFilter);
            innerList.Add(dataSource);
            innerList.Add(reverseSign);
            innerList.Add(methodType);
            innerList.Add(dateMethod);
            innerList.Add(totalsMethod);
        }

        public MultiLanguageValue CaptionML
        {
            get
            {
                return this.captionML.Value;
            }
        }

        public ColumnFilter ColumnFilter
        {
            get
            {
                return this.columnFilter.Value;
            }
        }

      public System.String DataSource
        {
            get
            {
                return this.dataSource.Value;
            }
            set
            {
                this.dataSource.Value = value;
            }
        }

        public DateMethod? DateMethod
        {
            get
            {
                return this.dateMethod.Value;
            }
            set
            {
                this.dateMethod.Value = value;
            }
        }

      public System.String Description
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

        public MethodType? MethodType
        {
            get
            {
                return this.methodType.Value;
            }
            set
            {
                this.methodType.Value = value;
            }
        }

      public System.Boolean? ReverseSign
        {
            get
            {
                return this.reverseSign.Value;
            }
            set
            {
                this.reverseSign.Value = value;
            }
        }

        public TotalsMethod? TotalsMethod
        {
            get
            {
                return this.totalsMethod.Value;
            }
            set
            {
                this.totalsMethod.Value = value;
            }
        }

        public IEnumerator<Property> GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

    }

    [Serializable]
    public class ColumnReportElementProperties : IEnumerable<Property>
    {
        private List<Property> innerList = new List<Property>();

        private NullableBooleanProperty autoCalcField = new NullableBooleanProperty("AutoCalcField");
        private StringProperty autoFormatExpr = new StringProperty("AutoFormatExpr");
        private AutoFormatTypeProperty autoFormatType = new AutoFormatTypeProperty("AutoFormatType");
        private DecimalPlacesProperty decimalPlaces = new DecimalPlacesProperty("DecimalPlaces");
        private StringProperty description = new StringProperty("Description");
        private NullableBooleanProperty includeCaption = new NullableBooleanProperty("IncludeCaption");
        private MultiLanguageProperty optionCaptionML = new MultiLanguageProperty("OptionCaptionML");
        private OptionStringProperty optionString = new OptionStringProperty("OptionString");
        private StringProperty sourceExpr = new StringProperty("SourceExpr");

        internal ColumnReportElementProperties()
        {
            innerList.Add(optionCaptionML);
            innerList.Add(optionString);
            innerList.Add(decimalPlaces);
            innerList.Add(description);
            innerList.Add(includeCaption);
            innerList.Add(sourceExpr);
            innerList.Add(autoCalcField);
            innerList.Add(autoFormatType);
            innerList.Add(autoFormatExpr);
        }

      public System.Boolean? AutoCalcField
        {
            get
            {
                return this.autoCalcField.Value;
            }
            set
            {
                this.autoCalcField.Value = value;
            }
        }

      public System.String AutoFormatExpr
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

        public DecimalPlaces DecimalPlaces
        {
            get
            {
                return this.decimalPlaces.Value;
            }
        }

      public System.String Description
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

      public System.Boolean? IncludeCaption
        {
            get
            {
                return this.includeCaption.Value;
            }
            set
            {
                this.includeCaption.Value = value;
            }
        }

        public MultiLanguageValue OptionCaptionML
        {
            get
            {
                return this.optionCaptionML.Value;
            }
        }

      public System.String OptionString
        {
            get
            {
                return this.optionString.Value;
            }
            set
            {
                this.optionString.Value = value;
            }
        }

      public System.String SourceExpr
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

        public IEnumerator<Property> GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

    }

    [Serializable]
    public class ContainerPageControlProperties : IEnumerable<Property>
    {
        private List<Property> innerList = new List<Property>();

        private MultiLanguageProperty captionML = new MultiLanguageProperty("CaptionML");
        private ContainerTypeProperty containerType = new ContainerTypeProperty("ContainerType");
        private StringProperty description = new StringProperty("Description");
        private StringProperty name = new StringProperty("Name");

        internal ContainerPageControlProperties()
        {
            innerList.Add(name);
            innerList.Add(captionML);
            innerList.Add(description);
            innerList.Add(containerType);
        }

        public MultiLanguageValue CaptionML
        {
            get
            {
                return this.captionML.Value;
            }
        }

        public ContainerType? ContainerType
        {
            get
            {
                return this.containerType.Value;
            }
            set
            {
                this.containerType.Value = value;
            }
        }

      public System.String Description
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

      public System.String Name
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

        public IEnumerator<Property> GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

    }

    [Serializable]
    public class DataItemQueryElementProperties : IEnumerable<Property>
    {
        private List<Property> innerList = new List<Property>();

        private QueryDataItemLinkProperty dataItemLink = new QueryDataItemLinkProperty("DataItemLink");
        private DataItemLinkTypeProperty dataItemLinkType = new DataItemLinkTypeProperty("DataItemLinkType");
        private TableReferenceProperty dataItemTable = new TableReferenceProperty("DataItemTable");
        private DataItemQueryElementTableFilterProperty dataItemTableFilter = new DataItemQueryElementTableFilterProperty("DataItemTableFilter");
        private StringProperty description = new StringProperty("Description");
        private SqlJoinTypeProperty sQLJoinType = new SqlJoinTypeProperty("SQLJoinType");

        internal DataItemQueryElementProperties()
        {
            innerList.Add(dataItemTable);
            innerList.Add(description);
            innerList.Add(dataItemTableFilter);
            innerList.Add(dataItemLink);
            innerList.Add(dataItemLinkType);
            innerList.Add(sQLJoinType);
        }

        public QueryDataItemLink DataItemLink
        {
            get
            {
                return this.dataItemLink.Value;
            }
        }

        public DataItemLinkType? DataItemLinkType
        {
            get
            {
                return this.dataItemLinkType.Value;
            }
            set
            {
                this.dataItemLinkType.Value = value;
            }
        }

      public System.Int32? DataItemTable
        {
            get
            {
                return this.dataItemTable.Value;
            }
            set
            {
                this.dataItemTable.Value = value;
            }
        }

        public DataItemQueryElementTableFilter DataItemTableFilter
        {
            get
            {
                return this.dataItemTableFilter.Value;
            }
        }

      public System.String Description
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

        public SqlJoinType? SQLJoinType
        {
            get
            {
                return this.sQLJoinType.Value;
            }
            set
            {
                this.sQLJoinType.Value = value;
            }
        }

        public IEnumerator<Property> GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

    }

    [Serializable]
    public class DataItemReportElementProperties : IEnumerable<Property>
    {
        private List<Property> innerList = new List<Property>();

        private FieldListProperty calcFields = new FieldListProperty("CalcFields");
        private ReportDataItemLinkProperty dataItemLink = new ReportDataItemLinkProperty("DataItemLink");
        private StringProperty dataItemLinkReference = new StringProperty("DataItemLinkReference");
        private TableReferenceProperty dataItemTable = new TableReferenceProperty("DataItemTable");
        private TableViewProperty dataItemTableView = new TableViewProperty("DataItemTableView");
        private NullableIntegerProperty maxIteration = new NullableIntegerProperty("MaxIteration");
        private TriggerProperty onAfterGetRecord = new TriggerProperty("OnAfterGetRecord");
        private TriggerProperty onPostDataItem = new TriggerProperty("OnPostDataItem");
        private TriggerProperty onPreDataItem = new TriggerProperty("OnPreDataItem");
        private NullableBooleanProperty printOnlyIfDetail = new NullableBooleanProperty("PrintOnlyIfDetail");
        private FieldListProperty reqFilterFields = new FieldListProperty("ReqFilterFields");
        private MultiLanguageProperty reqFilterHeadingML = new MultiLanguageProperty("ReqFilterHeadingML");

        internal DataItemReportElementProperties()
        {
            innerList.Add(dataItemTable);
            innerList.Add(dataItemTableView);
            innerList.Add(maxIteration);
            innerList.Add(printOnlyIfDetail);
            innerList.Add(reqFilterHeadingML);
            innerList.Add(onPreDataItem);
            innerList.Add(onAfterGetRecord);
            innerList.Add(onPostDataItem);
            innerList.Add(reqFilterFields);
            innerList.Add(calcFields);
            innerList.Add(dataItemLinkReference);
            innerList.Add(dataItemLink);
        }

        public FieldList CalcFields
        {
            get
            {
                return this.calcFields.Value;
            }
        }

        public ReportDataItemLink DataItemLink
        {
            get
            {
                return this.dataItemLink.Value;
            }
        }

      public System.String DataItemLinkReference
        {
            get
            {
                return this.dataItemLinkReference.Value;
            }
            set
            {
                this.dataItemLinkReference.Value = value;
            }
        }

      public System.Int32? DataItemTable
        {
            get
            {
                return this.dataItemTable.Value;
            }
            set
            {
                this.dataItemTable.Value = value;
            }
        }

        public TableView DataItemTableView
        {
            get
            {
                return this.dataItemTableView.Value;
            }
        }

      public System.Int32? MaxIteration
        {
            get
            {
                return this.maxIteration.Value;
            }
            set
            {
                this.maxIteration.Value = value;
            }
        }

        public Trigger OnAfterGetRecord
        {
            get
            {
                return this.onAfterGetRecord.Value;
            }
        }

        public Trigger OnPostDataItem
        {
            get
            {
                return this.onPostDataItem.Value;
            }
        }

        public Trigger OnPreDataItem
        {
            get
            {
                return this.onPreDataItem.Value;
            }
        }

      public System.Boolean? PrintOnlyIfDetail
        {
            get
            {
                return this.printOnlyIfDetail.Value;
            }
            set
            {
                this.printOnlyIfDetail.Value = value;
            }
        }

        public FieldList ReqFilterFields
        {
            get
            {
                return this.reqFilterFields.Value;
            }
        }

        public MultiLanguageValue ReqFilterHeadingML
        {
            get
            {
                return this.reqFilterHeadingML.Value;
            }
        }

        public IEnumerator<Property> GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

    }

    [Serializable]
    public class DateFormulaTableFieldProperties : IEnumerable<Property>
    {
        private List<Property> innerList = new List<Property>();

        private StringProperty altSearchField = new StringProperty("AltSearchField");
        private StringProperty autoFormatExpr = new StringProperty("AutoFormatExpr");
        private AutoFormatTypeProperty autoFormatType = new AutoFormatTypeProperty("AutoFormatType");
        private CalcFormulaProperty calcFormula = new CalcFormulaProperty("CalcFormula");
        private StringProperty captionClass = new StringProperty("CaptionClass");
        private MultiLanguageProperty captionML = new MultiLanguageProperty("CaptionML");
        private StringProperty description = new StringProperty("Description");
        private NullableBooleanProperty editable = new NullableBooleanProperty("Editable");
        private ExtendedDataTypeProperty extendedDatatype = new ExtendedDataTypeProperty("ExtendedDatatype");
        private FieldClassProperty fieldClass = new FieldClassProperty("FieldClass");
        private StringProperty initValue = new StringProperty("InitValue");
        private NullableBooleanProperty notBlank = new NullableBooleanProperty("NotBlank");
        private TriggerProperty onLookup = new TriggerProperty("OnLookup");
        private TriggerProperty onValidate = new TriggerProperty("OnValidate");
        private TableRelationLinesProperty tableRelation = new TableRelationLinesProperty("TableRelation");
        private NullableBooleanProperty testTableRelation = new NullableBooleanProperty("TestTableRelation");
        private NullableBooleanProperty validateTableRelation = new NullableBooleanProperty("ValidateTableRelation");
        private SemiColonSeparatedStringProperty valuesAllowed = new SemiColonSeparatedStringProperty("ValuesAllowed");

        internal DateFormulaTableFieldProperties()
        {
            innerList.Add(fieldClass);
            innerList.Add(calcFormula);
            innerList.Add(initValue);
            innerList.Add(tableRelation);
            innerList.Add(altSearchField);
            innerList.Add(onValidate);
            innerList.Add(onLookup);
            innerList.Add(validateTableRelation);
            innerList.Add(testTableRelation);
            innerList.Add(extendedDatatype);
            innerList.Add(captionML);
            innerList.Add(notBlank);
            innerList.Add(valuesAllowed);
            innerList.Add(description);
            innerList.Add(editable);
            innerList.Add(autoFormatType);
            innerList.Add(autoFormatExpr);
            innerList.Add(captionClass);
        }

      public System.String AltSearchField
        {
            get
            {
                return this.altSearchField.Value;
            }
            set
            {
                this.altSearchField.Value = value;
            }
        }

      public System.String AutoFormatExpr
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

        public CalcFormula CalcFormula
        {
            get
            {
                return this.calcFormula.Value;
            }
        }

      public System.String CaptionClass
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

      public System.String Description
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

      public System.Boolean? Editable
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

        public FieldClass? FieldClass
        {
            get
            {
                return this.fieldClass.Value;
            }
            set
            {
                this.fieldClass.Value = value;
            }
        }

      public System.String InitValue
        {
            get
            {
                return this.initValue.Value;
            }
            set
            {
                this.initValue.Value = value;
            }
        }

      public System.Boolean? NotBlank
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

        public TableRelationLines TableRelation
        {
            get
            {
                return this.tableRelation.Value;
            }
        }

      public System.Boolean? TestTableRelation
        {
            get
            {
                return this.testTableRelation.Value;
            }
            set
            {
                this.testTableRelation.Value = value;
            }
        }

      public System.Boolean? ValidateTableRelation
        {
            get
            {
                return this.validateTableRelation.Value;
            }
            set
            {
                this.validateTableRelation.Value = value;
            }
        }

      public System.String ValuesAllowed
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

        public IEnumerator<Property> GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

    }

    [Serializable]
    public class DateTableFieldProperties : IEnumerable<Property>
    {
        private List<Property> innerList = new List<Property>();

        private StringProperty altSearchField = new StringProperty("AltSearchField");
        private StringProperty autoFormatExpr = new StringProperty("AutoFormatExpr");
        private AutoFormatTypeProperty autoFormatType = new AutoFormatTypeProperty("AutoFormatType");
        private BlankNumbersProperty blankNumbers = new BlankNumbersProperty("BlankNumbers");
        private CalcFormulaProperty calcFormula = new CalcFormulaProperty("CalcFormula");
        private StringProperty captionClass = new StringProperty("CaptionClass");
        private MultiLanguageProperty captionML = new MultiLanguageProperty("CaptionML");
        private NullableBooleanProperty closingDates = new NullableBooleanProperty("ClosingDates");
        private StringProperty description = new StringProperty("Description");
        private NullableBooleanProperty editable = new NullableBooleanProperty("Editable");
        private ExtendedDataTypeProperty extendedDatatype = new ExtendedDataTypeProperty("ExtendedDatatype");
        private FieldClassProperty fieldClass = new FieldClassProperty("FieldClass");
        private NullableDateProperty initValue = new NullableDateProperty("InitValue");
        private NullableDateProperty maxValue = new NullableDateProperty("MaxValue");
        private NullableDateProperty minValue = new NullableDateProperty("MinValue");
        private NullableBooleanProperty notBlank = new NullableBooleanProperty("NotBlank");
        private TriggerProperty onLookup = new TriggerProperty("OnLookup");
        private TriggerProperty onValidate = new TriggerProperty("OnValidate");
        private NullableIntegerProperty signDisplacement = new NullableIntegerProperty("SignDisplacement");
        private TableRelationLinesProperty tableRelation = new TableRelationLinesProperty("TableRelation");
        private NullableBooleanProperty testTableRelation = new NullableBooleanProperty("TestTableRelation");
        private NullableBooleanProperty validateTableRelation = new NullableBooleanProperty("ValidateTableRelation");
        private SemiColonSeparatedStringProperty valuesAllowed = new SemiColonSeparatedStringProperty("ValuesAllowed");

        internal DateTableFieldProperties()
        {
            innerList.Add(fieldClass);
            innerList.Add(calcFormula);
            innerList.Add(initValue);
            innerList.Add(tableRelation);
            innerList.Add(altSearchField);
            innerList.Add(onValidate);
            innerList.Add(onLookup);
            innerList.Add(validateTableRelation);
            innerList.Add(testTableRelation);
            innerList.Add(extendedDatatype);
            innerList.Add(captionML);
            innerList.Add(minValue);
            innerList.Add(maxValue);
            innerList.Add(notBlank);
            innerList.Add(closingDates);
            innerList.Add(blankNumbers);
            innerList.Add(valuesAllowed);
            innerList.Add(signDisplacement);
            innerList.Add(description);
            innerList.Add(editable);
            innerList.Add(autoFormatType);
            innerList.Add(autoFormatExpr);
            innerList.Add(captionClass);
        }

      public System.String AltSearchField
        {
            get
            {
                return this.altSearchField.Value;
            }
            set
            {
                this.altSearchField.Value = value;
            }
        }

      public System.String AutoFormatExpr
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

        public CalcFormula CalcFormula
        {
            get
            {
                return this.calcFormula.Value;
            }
        }

      public System.String CaptionClass
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

      public System.Boolean? ClosingDates
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

      public System.String Description
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

      public System.Boolean? Editable
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

        public FieldClass? FieldClass
        {
            get
            {
                return this.fieldClass.Value;
            }
            set
            {
                this.fieldClass.Value = value;
            }
        }

      public System.DateTime? InitValue
        {
            get
            {
                return this.initValue.Value;
            }
            set
            {
                this.initValue.Value = value;
            }
        }

      public System.DateTime? MaxValue
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

      public System.DateTime? MinValue
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

      public System.Boolean? NotBlank
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

      public System.Int32? SignDisplacement
        {
            get
            {
                return this.signDisplacement.Value;
            }
            set
            {
                this.signDisplacement.Value = value;
            }
        }

        public TableRelationLines TableRelation
        {
            get
            {
                return this.tableRelation.Value;
            }
        }

      public System.Boolean? TestTableRelation
        {
            get
            {
                return this.testTableRelation.Value;
            }
            set
            {
                this.testTableRelation.Value = value;
            }
        }

      public System.Boolean? ValidateTableRelation
        {
            get
            {
                return this.validateTableRelation.Value;
            }
            set
            {
                this.validateTableRelation.Value = value;
            }
        }

      public System.String ValuesAllowed
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

        public IEnumerator<Property> GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

    }

    [Serializable]
    public class DateTimeTableFieldProperties : IEnumerable<Property>
    {
        private List<Property> innerList = new List<Property>();

        private StringProperty altSearchField = new StringProperty("AltSearchField");
        private StringProperty autoFormatExpr = new StringProperty("AutoFormatExpr");
        private AutoFormatTypeProperty autoFormatType = new AutoFormatTypeProperty("AutoFormatType");
        private BlankNumbersProperty blankNumbers = new BlankNumbersProperty("BlankNumbers");
        private CalcFormulaProperty calcFormula = new CalcFormulaProperty("CalcFormula");
        private StringProperty captionClass = new StringProperty("CaptionClass");
        private MultiLanguageProperty captionML = new MultiLanguageProperty("CaptionML");
        private StringProperty description = new StringProperty("Description");
        private NullableBooleanProperty editable = new NullableBooleanProperty("Editable");
        private ExtendedDataTypeProperty extendedDatatype = new ExtendedDataTypeProperty("ExtendedDatatype");
        private FieldClassProperty fieldClass = new FieldClassProperty("FieldClass");
        private NullableDateTimeProperty initValue = new NullableDateTimeProperty("InitValue");
        private NullableDateTimeProperty maxValue = new NullableDateTimeProperty("MaxValue");
        private NullableDateTimeProperty minValue = new NullableDateTimeProperty("MinValue");
        private NullableBooleanProperty notBlank = new NullableBooleanProperty("NotBlank");
        private TriggerProperty onLookup = new TriggerProperty("OnLookup");
        private TriggerProperty onValidate = new TriggerProperty("OnValidate");
        private NullableIntegerProperty signDisplacement = new NullableIntegerProperty("SignDisplacement");
        private TableRelationLinesProperty tableRelation = new TableRelationLinesProperty("TableRelation");
        private NullableBooleanProperty testTableRelation = new NullableBooleanProperty("TestTableRelation");
        private NullableBooleanProperty validateTableRelation = new NullableBooleanProperty("ValidateTableRelation");
        private SemiColonSeparatedStringProperty valuesAllowed = new SemiColonSeparatedStringProperty("ValuesAllowed");
        private NullableBooleanProperty @volatile = new NullableBooleanProperty("Volatile");

        internal DateTimeTableFieldProperties()
        {
            innerList.Add(fieldClass);
            innerList.Add(calcFormula);
            innerList.Add(initValue);
            innerList.Add(tableRelation);
            innerList.Add(altSearchField);
            innerList.Add(onValidate);
            innerList.Add(onLookup);
            innerList.Add(validateTableRelation);
            innerList.Add(testTableRelation);
            innerList.Add(extendedDatatype);
            innerList.Add(@volatile);
            innerList.Add(captionML);
            innerList.Add(minValue);
            innerList.Add(maxValue);
            innerList.Add(notBlank);
            innerList.Add(blankNumbers);
            innerList.Add(valuesAllowed);
            innerList.Add(signDisplacement);
            innerList.Add(description);
            innerList.Add(editable);
            innerList.Add(autoFormatType);
            innerList.Add(autoFormatExpr);
            innerList.Add(captionClass);
        }

      public System.String AltSearchField
        {
            get
            {
                return this.altSearchField.Value;
            }
            set
            {
                this.altSearchField.Value = value;
            }
        }

      public System.String AutoFormatExpr
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

        public CalcFormula CalcFormula
        {
            get
            {
                return this.calcFormula.Value;
            }
        }

      public System.String CaptionClass
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

      public System.String Description
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

      public System.Boolean? Editable
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

        public FieldClass? FieldClass
        {
            get
            {
                return this.fieldClass.Value;
            }
            set
            {
                this.fieldClass.Value = value;
            }
        }

      public System.DateTime? InitValue
        {
            get
            {
                return this.initValue.Value;
            }
            set
            {
                this.initValue.Value = value;
            }
        }

      public System.DateTime? MaxValue
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

      public System.DateTime? MinValue
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

      public System.Boolean? NotBlank
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

      public System.Int32? SignDisplacement
        {
            get
            {
                return this.signDisplacement.Value;
            }
            set
            {
                this.signDisplacement.Value = value;
            }
        }

        public TableRelationLines TableRelation
        {
            get
            {
                return this.tableRelation.Value;
            }
        }

      public System.Boolean? TestTableRelation
        {
            get
            {
                return this.testTableRelation.Value;
            }
            set
            {
                this.testTableRelation.Value = value;
            }
        }

      public System.Boolean? ValidateTableRelation
        {
            get
            {
                return this.validateTableRelation.Value;
            }
            set
            {
                this.validateTableRelation.Value = value;
            }
        }

      public System.String ValuesAllowed
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

      public System.Boolean? Volatile
        {
            get
            {
                return this.@volatile.Value;
            }
            set
            {
                this.@volatile.Value = value;
            }
        }

        public IEnumerator<Property> GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

    }

    [Serializable]
    public class DecimalTableFieldProperties : IEnumerable<Property>
    {
        private List<Property> innerList = new List<Property>();

        private StringProperty altSearchField = new StringProperty("AltSearchField");
        private StringProperty autoFormatExpr = new StringProperty("AutoFormatExpr");
        private AutoFormatTypeProperty autoFormatType = new AutoFormatTypeProperty("AutoFormatType");
        private BlankNumbersProperty blankNumbers = new BlankNumbersProperty("BlankNumbers");
        private NullableBooleanProperty blankZero = new NullableBooleanProperty("BlankZero");
        private CalcFormulaProperty calcFormula = new CalcFormulaProperty("CalcFormula");
        private StringProperty captionClass = new StringProperty("CaptionClass");
        private MultiLanguageProperty captionML = new MultiLanguageProperty("CaptionML");
        private DecimalPlacesProperty decimalPlaces = new DecimalPlacesProperty("DecimalPlaces");
        private StringProperty description = new StringProperty("Description");
        private NullableBooleanProperty editable = new NullableBooleanProperty("Editable");
        private ExtendedDataTypeProperty extendedDatatype = new ExtendedDataTypeProperty("ExtendedDatatype");
        private FieldClassProperty fieldClass = new FieldClassProperty("FieldClass");
        private NullableDecimalProperty initValue = new NullableDecimalProperty("InitValue");
        private NullableDecimalProperty maxValue = new NullableDecimalProperty("MaxValue");
        private NullableDecimalProperty minValue = new NullableDecimalProperty("MinValue");
        private NullableBooleanProperty notBlank = new NullableBooleanProperty("NotBlank");
        private TriggerProperty onLookup = new TriggerProperty("OnLookup");
        private TriggerProperty onValidate = new TriggerProperty("OnValidate");
        private NullableIntegerProperty signDisplacement = new NullableIntegerProperty("SignDisplacement");
        private TableRelationLinesProperty tableRelation = new TableRelationLinesProperty("TableRelation");
        private NullableBooleanProperty testTableRelation = new NullableBooleanProperty("TestTableRelation");
        private NullableBooleanProperty validateTableRelation = new NullableBooleanProperty("ValidateTableRelation");
        private SemiColonSeparatedStringProperty valuesAllowed = new SemiColonSeparatedStringProperty("ValuesAllowed");
        private NullableIntegerProperty width = new NullableIntegerProperty("Width");

        internal DecimalTableFieldProperties()
        {
            innerList.Add(fieldClass);
            innerList.Add(initValue);
            innerList.Add(calcFormula);
            innerList.Add(tableRelation);
            innerList.Add(altSearchField);
            innerList.Add(onValidate);
            innerList.Add(onLookup);
            innerList.Add(validateTableRelation);
            innerList.Add(testTableRelation);
            innerList.Add(extendedDatatype);
            innerList.Add(width);
            innerList.Add(captionML);
            innerList.Add(decimalPlaces);
            innerList.Add(minValue);
            innerList.Add(maxValue);
            innerList.Add(notBlank);
            innerList.Add(blankNumbers);
            innerList.Add(blankZero);
            innerList.Add(valuesAllowed);
            innerList.Add(signDisplacement);
            innerList.Add(description);
            innerList.Add(editable);
            innerList.Add(autoFormatType);
            innerList.Add(autoFormatExpr);
            innerList.Add(captionClass);
        }

      public System.String AltSearchField
        {
            get
            {
                return this.altSearchField.Value;
            }
            set
            {
                this.altSearchField.Value = value;
            }
        }

      public System.String AutoFormatExpr
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

      public System.Boolean? BlankZero
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

        public CalcFormula CalcFormula
        {
            get
            {
                return this.calcFormula.Value;
            }
        }

      public System.String CaptionClass
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

        public DecimalPlaces DecimalPlaces
        {
            get
            {
                return this.decimalPlaces.Value;
            }
        }

      public System.String Description
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

      public System.Boolean? Editable
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

        public FieldClass? FieldClass
        {
            get
            {
                return this.fieldClass.Value;
            }
            set
            {
                this.fieldClass.Value = value;
            }
        }

      public System.Decimal? InitValue
        {
            get
            {
                return this.initValue.Value;
            }
            set
            {
                this.initValue.Value = value;
            }
        }

      public System.Decimal? MaxValue
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

      public System.Decimal? MinValue
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

      public System.Boolean? NotBlank
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

      public System.Int32? SignDisplacement
        {
            get
            {
                return this.signDisplacement.Value;
            }
            set
            {
                this.signDisplacement.Value = value;
            }
        }

        public TableRelationLines TableRelation
        {
            get
            {
                return this.tableRelation.Value;
            }
        }

      public System.Boolean? TestTableRelation
        {
            get
            {
                return this.testTableRelation.Value;
            }
            set
            {
                this.testTableRelation.Value = value;
            }
        }

      public System.Boolean? ValidateTableRelation
        {
            get
            {
                return this.validateTableRelation.Value;
            }
            set
            {
                this.validateTableRelation.Value = value;
            }
        }

      public System.String ValuesAllowed
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

      public System.Int32? Width
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

        public IEnumerator<Property> GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

    }

    [Serializable]
    public class DurationTableFieldProperties : IEnumerable<Property>
    {
        private List<Property> innerList = new List<Property>();

        private StringProperty altSearchField = new StringProperty("AltSearchField");
        private StringProperty autoFormatExpr = new StringProperty("AutoFormatExpr");
        private AutoFormatTypeProperty autoFormatType = new AutoFormatTypeProperty("AutoFormatType");
        private BlankNumbersProperty blankNumbers = new BlankNumbersProperty("BlankNumbers");
        private NullableBooleanProperty blankZero = new NullableBooleanProperty("BlankZero");
        private CalcFormulaProperty calcFormula = new CalcFormulaProperty("CalcFormula");
        private StringProperty captionClass = new StringProperty("CaptionClass");
        private MultiLanguageProperty captionML = new MultiLanguageProperty("CaptionML");
        private StringProperty description = new StringProperty("Description");
        private NullableBooleanProperty editable = new NullableBooleanProperty("Editable");
        private ExtendedDataTypeProperty extendedDatatype = new ExtendedDataTypeProperty("ExtendedDatatype");
        private FieldClassProperty fieldClass = new FieldClassProperty("FieldClass");
        private DurationProperty initValue = new DurationProperty("InitValue");
        private DurationProperty maxValue = new DurationProperty("MaxValue");
        private DurationProperty minValue = new DurationProperty("MinValue");
        private NullableBooleanProperty notBlank = new NullableBooleanProperty("NotBlank");
        private TriggerProperty onLookup = new TriggerProperty("OnLookup");
        private TriggerProperty onValidate = new TriggerProperty("OnValidate");
        private NullableIntegerProperty signDisplacement = new NullableIntegerProperty("SignDisplacement");
        private StandardDayTimeUnitProperty standardDayTimeUnit = new StandardDayTimeUnitProperty("StandardDayTimeUnit");
        private TableRelationLinesProperty tableRelation = new TableRelationLinesProperty("TableRelation");
        private NullableBooleanProperty testTableRelation = new NullableBooleanProperty("TestTableRelation");
        private NullableBooleanProperty validateTableRelation = new NullableBooleanProperty("ValidateTableRelation");
        private SemiColonSeparatedStringProperty valuesAllowed = new SemiColonSeparatedStringProperty("ValuesAllowed");

        internal DurationTableFieldProperties()
        {
            innerList.Add(fieldClass);
            innerList.Add(calcFormula);
            innerList.Add(initValue);
            innerList.Add(tableRelation);
            innerList.Add(altSearchField);
            innerList.Add(onValidate);
            innerList.Add(onLookup);
            innerList.Add(validateTableRelation);
            innerList.Add(testTableRelation);
            innerList.Add(extendedDatatype);
            innerList.Add(captionML);
            innerList.Add(minValue);
            innerList.Add(maxValue);
            innerList.Add(notBlank);
            innerList.Add(blankNumbers);
            innerList.Add(blankZero);
            innerList.Add(valuesAllowed);
            innerList.Add(signDisplacement);
            innerList.Add(description);
            innerList.Add(editable);
            innerList.Add(standardDayTimeUnit);
            innerList.Add(autoFormatType);
            innerList.Add(autoFormatExpr);
            innerList.Add(captionClass);
        }

      public System.String AltSearchField
        {
            get
            {
                return this.altSearchField.Value;
            }
            set
            {
                this.altSearchField.Value = value;
            }
        }

      public System.String AutoFormatExpr
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

      public System.Boolean? BlankZero
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

        public CalcFormula CalcFormula
        {
            get
            {
                return this.calcFormula.Value;
            }
        }

      public System.String CaptionClass
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

      public System.String Description
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

      public System.Boolean? Editable
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

        public FieldClass? FieldClass
        {
            get
            {
                return this.fieldClass.Value;
            }
            set
            {
                this.fieldClass.Value = value;
            }
        }

      public System.TimeSpan? InitValue
        {
            get
            {
                return this.initValue.Value;
            }
            set
            {
                this.initValue.Value = value;
            }
        }

      public System.TimeSpan? MaxValue
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

      public System.TimeSpan? MinValue
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

      public System.Boolean? NotBlank
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

      public System.Int32? SignDisplacement
        {
            get
            {
                return this.signDisplacement.Value;
            }
            set
            {
                this.signDisplacement.Value = value;
            }
        }

        public StandardDayTimeUnit? StandardDayTimeUnit
        {
            get
            {
                return this.standardDayTimeUnit.Value;
            }
            set
            {
                this.standardDayTimeUnit.Value = value;
            }
        }

        public TableRelationLines TableRelation
        {
            get
            {
                return this.tableRelation.Value;
            }
        }

      public System.Boolean? TestTableRelation
        {
            get
            {
                return this.testTableRelation.Value;
            }
            set
            {
                this.testTableRelation.Value = value;
            }
        }

      public System.Boolean? ValidateTableRelation
        {
            get
            {
                return this.validateTableRelation.Value;
            }
            set
            {
                this.validateTableRelation.Value = value;
            }
        }

      public System.String ValuesAllowed
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

        public IEnumerator<Property> GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

    }

    [Serializable]
    public class FieldPageControlProperties : IEnumerable<Property>
    {
        private List<Property> innerList = new List<Property>();

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
        private StringProperty sourceExpr = new StringProperty("SourceExpr");
        private StyleProperty style = new StyleProperty("Style");
        private StringProperty styleExpr = new StringProperty("StyleExpr");
        private TableRelationLinesProperty tableRelation = new TableRelationLinesProperty("TableRelation");
        private NullableBooleanProperty title = new NullableBooleanProperty("Title");
        private MultiLanguageProperty toolTipML = new MultiLanguageProperty("ToolTipML");
        private SemiColonSeparatedStringProperty valuesAllowed = new SemiColonSeparatedStringProperty("ValuesAllowed");
        private StringProperty visible = new StringProperty("Visible");
        private NullableIntegerProperty width = new NullableIntegerProperty("Width");

        internal FieldPageControlProperties()
        {
            innerList.Add(name);
            innerList.Add(extendedDatatype);
            innerList.Add(width);
            innerList.Add(lookup);
            innerList.Add(drillDown);
            innerList.Add(assistEdit);
            innerList.Add(captionML);
            innerList.Add(toolTipML);
            innerList.Add(optionCaptionML);
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
            innerList.Add(showCaption);
            innerList.Add(quickEntry);
        }

      public System.Boolean? AssistEdit
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

      public System.String AutoFormatExpr
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

      public System.Boolean? BlankZero
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

      public System.String CaptionClass
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

      public System.String CharAllowed
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

      public System.Boolean? ClosingDates
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

      public System.Int32? ColumnSpan
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

      public System.String ControlAddIn
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

      public System.Boolean? DateFormula
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

      public System.String Description
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

      public System.Boolean? DrillDown
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

      public System.String DrillDownPageID
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

      public System.String Editable
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

      public System.String Enabled
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

      public System.String HideValue
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

      public System.Boolean? Lookup
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

      public System.String LookupPageID
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

      public System.Boolean? MultiLine
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

      public System.String Name
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

      public System.Boolean? NotBlank
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

      public System.Boolean? Numeric
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

      public System.String QuickEntry
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

      public System.Int32? RowSpan
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

      public System.Boolean? ShowCaption
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

      public System.String SourceExpr
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

      public System.String StyleExpr
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

        public TableRelationLines TableRelation
        {
            get
            {
                return this.tableRelation.Value;
            }
        }

      public System.Boolean? Title
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

      public System.String ValuesAllowed
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

      public System.String Visible
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

      public System.Int32? Width
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

        public IEnumerator<Property> GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

    }

    [Serializable]
    public class FilterQueryElementProperties : IEnumerable<Property>
    {
        private List<Property> innerList = new List<Property>();

        private MultiLanguageProperty captionML = new MultiLanguageProperty("CaptionML");
        private ColumnFilterProperty columnFilter = new ColumnFilterProperty("ColumnFilter");
        private StringProperty dataSource = new StringProperty("DataSource");
        private StringProperty description = new StringProperty("Description");

        internal FilterQueryElementProperties()
        {
            innerList.Add(captionML);
            innerList.Add(description);
            innerList.Add(columnFilter);
            innerList.Add(dataSource);
        }

        public MultiLanguageValue CaptionML
        {
            get
            {
                return this.captionML.Value;
            }
        }

        public ColumnFilter ColumnFilter
        {
            get
            {
                return this.columnFilter.Value;
            }
        }

      public System.String DataSource
        {
            get
            {
                return this.dataSource.Value;
            }
            set
            {
                this.dataSource.Value = value;
            }
        }

      public System.String Description
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

        public IEnumerator<Property> GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

    }

    [Serializable]
    public class FunctionProperties : IEnumerable<Property>
    {
        private List<Property> innerList = new List<Property>();

        private FunctionTypeProperty functionType = new FunctionTypeProperty("FunctionType");
        private StringProperty handlerFunctions = new StringProperty("HandlerFunctions");
        private NullableBooleanProperty local = new NullableBooleanProperty("Local");
        private TransactionModelProperty transactionModel = new TransactionModelProperty("TransactionModel");

        internal FunctionProperties()
        {
            innerList.Add(functionType);
            innerList.Add(handlerFunctions);
            innerList.Add(local);
            innerList.Add(transactionModel);
        }

        public FunctionType? FunctionType
        {
            get
            {
                return this.functionType.Value;
            }
            set
            {
                this.functionType.Value = value;
            }
        }

      public System.String HandlerFunctions
        {
            get
            {
                return this.handlerFunctions.Value;
            }
            set
            {
                this.handlerFunctions.Value = value;
            }
        }

      public System.Boolean? Local
        {
            get
            {
                return this.local.Value;
            }
            set
            {
                this.local.Value = value;
            }
        }

        public TransactionModel? TransactionModel
        {
            get
            {
                return this.transactionModel.Value;
            }
            set
            {
                this.transactionModel.Value = value;
            }
        }

        public IEnumerator<Property> GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

    }

    [Serializable]
    public class GroupPageControlProperties : IEnumerable<Property>
    {
        private List<Property> innerList = new List<Property>();

        private ActionListProperty actionList = new ActionListProperty("ActionList");
        private MultiLanguageProperty captionML = new MultiLanguageProperty("CaptionML");
        private StringProperty description = new StringProperty("Description");
        private StringProperty editable = new StringProperty("Editable");
        private StringProperty enabled = new StringProperty("Enabled");
        private StringProperty freezeColumnID = new StringProperty("FreezeColumnID");
        private GroupTypeProperty groupType = new GroupTypeProperty("GroupType");
        private StringProperty indentationColumnName = new StringProperty("IndentationColumnName");
        private ControlListProperty indentationControls = new ControlListProperty("IndentationControls");
        private MultiLanguageProperty instructionalTextML = new MultiLanguageProperty("InstructionalTextML");
        private GroupPageControlLayoutProperty layout = new GroupPageControlLayoutProperty("Layout");
        private StringProperty name = new StringProperty("Name");
        private NullableBooleanProperty showAsTree = new NullableBooleanProperty("ShowAsTree");
        private StringProperty visible = new StringProperty("Visible");

        internal GroupPageControlProperties()
        {
            innerList.Add(name);
            innerList.Add(captionML);
            innerList.Add(description);
            innerList.Add(visible);
            innerList.Add(enabled);
            innerList.Add(editable);
            innerList.Add(indentationColumnName);
            innerList.Add(indentationControls);
            innerList.Add(showAsTree);
            innerList.Add(groupType);
            innerList.Add(instructionalTextML);
            innerList.Add(freezeColumnID);
            innerList.Add(layout);
            innerList.Add(actionList);
        }

        public ActionList ActionList
        {
            get
            {
                return this.actionList.Value;
            }
        }

        public MultiLanguageValue CaptionML
        {
            get
            {
                return this.captionML.Value;
            }
        }

      public System.String Description
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

      public System.String Editable
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

      public System.String Enabled
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

      public System.String FreezeColumnID
        {
            get
            {
                return this.freezeColumnID.Value;
            }
            set
            {
                this.freezeColumnID.Value = value;
            }
        }

        public GroupType? GroupType
        {
            get
            {
                return this.groupType.Value;
            }
            set
            {
                this.groupType.Value = value;
            }
        }

      public System.String IndentationColumnName
        {
            get
            {
                return this.indentationColumnName.Value;
            }
            set
            {
                this.indentationColumnName.Value = value;
            }
        }

        public ControlList IndentationControls
        {
            get
            {
                return this.indentationControls.Value;
            }
        }

        public MultiLanguageValue InstructionalTextML
        {
            get
            {
                return this.instructionalTextML.Value;
            }
        }

        public GroupPageControlLayout? Layout
        {
            get
            {
                return this.layout.Value;
            }
            set
            {
                this.layout.Value = value;
            }
        }

      public System.String Name
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

      public System.Boolean? ShowAsTree
        {
            get
            {
                return this.showAsTree.Value;
            }
            set
            {
                this.showAsTree.Value = value;
            }
        }

      public System.String Visible
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

        public IEnumerator<Property> GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

    }

    [Serializable]
    public class GuidTableFieldProperties : IEnumerable<Property>
    {
        private List<Property> innerList = new List<Property>();

        private StringProperty altSearchField = new StringProperty("AltSearchField");
        private StringProperty autoFormatExpr = new StringProperty("AutoFormatExpr");
        private AutoFormatTypeProperty autoFormatType = new AutoFormatTypeProperty("AutoFormatType");
        private CalcFormulaProperty calcFormula = new CalcFormulaProperty("CalcFormula");
        private StringProperty captionClass = new StringProperty("CaptionClass");
        private MultiLanguageProperty captionML = new MultiLanguageProperty("CaptionML");
        private StringProperty description = new StringProperty("Description");
        private NullableBooleanProperty editable = new NullableBooleanProperty("Editable");
        private ExtendedDataTypeProperty extendedDatatype = new ExtendedDataTypeProperty("ExtendedDatatype");
        private FieldClassProperty fieldClass = new FieldClassProperty("FieldClass");
        private NullableGuidProperty initValue = new NullableGuidProperty("InitValue");
        private NullableBooleanProperty notBlank = new NullableBooleanProperty("NotBlank");
        private TriggerProperty onLookup = new TriggerProperty("OnLookup");
        private TriggerProperty onValidate = new TriggerProperty("OnValidate");
        private TableRelationLinesProperty tableRelation = new TableRelationLinesProperty("TableRelation");
        private NullableBooleanProperty testTableRelation = new NullableBooleanProperty("TestTableRelation");
        private NullableBooleanProperty validateTableRelation = new NullableBooleanProperty("ValidateTableRelation");
        private SemiColonSeparatedStringProperty valuesAllowed = new SemiColonSeparatedStringProperty("ValuesAllowed");

        internal GuidTableFieldProperties()
        {
            innerList.Add(fieldClass);
            innerList.Add(calcFormula);
            innerList.Add(initValue);
            innerList.Add(tableRelation);
            innerList.Add(altSearchField);
            innerList.Add(onValidate);
            innerList.Add(onLookup);
            innerList.Add(validateTableRelation);
            innerList.Add(testTableRelation);
            innerList.Add(extendedDatatype);
            innerList.Add(captionML);
            innerList.Add(notBlank);
            innerList.Add(valuesAllowed);
            innerList.Add(description);
            innerList.Add(editable);
            innerList.Add(autoFormatType);
            innerList.Add(autoFormatExpr);
            innerList.Add(captionClass);
        }

      public System.String AltSearchField
        {
            get
            {
                return this.altSearchField.Value;
            }
            set
            {
                this.altSearchField.Value = value;
            }
        }

      public System.String AutoFormatExpr
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

        public CalcFormula CalcFormula
        {
            get
            {
                return this.calcFormula.Value;
            }
        }

      public System.String CaptionClass
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

      public System.String Description
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

      public System.Boolean? Editable
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

        public FieldClass? FieldClass
        {
            get
            {
                return this.fieldClass.Value;
            }
            set
            {
                this.fieldClass.Value = value;
            }
        }

      public System.Guid? InitValue
        {
            get
            {
                return this.initValue.Value;
            }
            set
            {
                this.initValue.Value = value;
            }
        }

      public System.Boolean? NotBlank
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

        public TableRelationLines TableRelation
        {
            get
            {
                return this.tableRelation.Value;
            }
        }

      public System.Boolean? TestTableRelation
        {
            get
            {
                return this.testTableRelation.Value;
            }
            set
            {
                this.testTableRelation.Value = value;
            }
        }

      public System.Boolean? ValidateTableRelation
        {
            get
            {
                return this.validateTableRelation.Value;
            }
            set
            {
                this.validateTableRelation.Value = value;
            }
        }

      public System.String ValuesAllowed
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

        public IEnumerator<Property> GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

    }

    [Serializable]
    public class IntegerTableFieldProperties : IEnumerable<Property>
    {
        private List<Property> innerList = new List<Property>();

        private StringProperty altSearchField = new StringProperty("AltSearchField");
        private StringProperty autoFormatExpr = new StringProperty("AutoFormatExpr");
        private AutoFormatTypeProperty autoFormatType = new AutoFormatTypeProperty("AutoFormatType");
        private NullableBooleanProperty autoIncrement = new NullableBooleanProperty("AutoIncrement");
        private BlankNumbersProperty blankNumbers = new BlankNumbersProperty("BlankNumbers");
        private NullableBooleanProperty blankZero = new NullableBooleanProperty("BlankZero");
        private CalcFormulaProperty calcFormula = new CalcFormulaProperty("CalcFormula");
        private StringProperty captionClass = new StringProperty("CaptionClass");
        private MultiLanguageProperty captionML = new MultiLanguageProperty("CaptionML");
        private StringProperty description = new StringProperty("Description");
        private NullableBooleanProperty editable = new NullableBooleanProperty("Editable");
        private ExtendedDataTypeProperty extendedDatatype = new ExtendedDataTypeProperty("ExtendedDatatype");
        private FieldClassProperty fieldClass = new FieldClassProperty("FieldClass");
        private NullableIntegerProperty initValue = new NullableIntegerProperty("InitValue");
        private NullableIntegerProperty maxValue = new NullableIntegerProperty("MaxValue");
        private NullableIntegerProperty minValue = new NullableIntegerProperty("MinValue");
        private NullableBooleanProperty notBlank = new NullableBooleanProperty("NotBlank");
        private TriggerProperty onLookup = new TriggerProperty("OnLookup");
        private TriggerProperty onValidate = new TriggerProperty("OnValidate");
        private NullableIntegerProperty signDisplacement = new NullableIntegerProperty("SignDisplacement");
        private TableRelationLinesProperty tableRelation = new TableRelationLinesProperty("TableRelation");
        private NullableBooleanProperty testTableRelation = new NullableBooleanProperty("TestTableRelation");
        private NullableBooleanProperty validateTableRelation = new NullableBooleanProperty("ValidateTableRelation");
        private SemiColonSeparatedStringProperty valuesAllowed = new SemiColonSeparatedStringProperty("ValuesAllowed");
        private NullableBooleanProperty @volatile = new NullableBooleanProperty("Volatile");
        private NullableIntegerProperty width = new NullableIntegerProperty("Width");

        internal IntegerTableFieldProperties()
        {
            innerList.Add(fieldClass);
            innerList.Add(calcFormula);
            innerList.Add(initValue);
            innerList.Add(tableRelation);
            innerList.Add(altSearchField);
            innerList.Add(onValidate);
            innerList.Add(onLookup);
            innerList.Add(validateTableRelation);
            innerList.Add(testTableRelation);
            innerList.Add(autoIncrement);
            innerList.Add(extendedDatatype);
            innerList.Add(@volatile);
            innerList.Add(width);
            innerList.Add(captionML);
            innerList.Add(minValue);
            innerList.Add(maxValue);
            innerList.Add(notBlank);
            innerList.Add(blankNumbers);
            innerList.Add(blankZero);
            innerList.Add(valuesAllowed);
            innerList.Add(signDisplacement);
            innerList.Add(description);
            innerList.Add(editable);
            innerList.Add(autoFormatType);
            innerList.Add(autoFormatExpr);
            innerList.Add(captionClass);
        }

      public System.String AltSearchField
        {
            get
            {
                return this.altSearchField.Value;
            }
            set
            {
                this.altSearchField.Value = value;
            }
        }

      public System.String AutoFormatExpr
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

      public System.Boolean? AutoIncrement
        {
            get
            {
                return this.autoIncrement.Value;
            }
            set
            {
                this.autoIncrement.Value = value;
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

      public System.Boolean? BlankZero
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

        public CalcFormula CalcFormula
        {
            get
            {
                return this.calcFormula.Value;
            }
        }

      public System.String CaptionClass
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

      public System.String Description
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

      public System.Boolean? Editable
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

        public FieldClass? FieldClass
        {
            get
            {
                return this.fieldClass.Value;
            }
            set
            {
                this.fieldClass.Value = value;
            }
        }

      public System.Int32? InitValue
        {
            get
            {
                return this.initValue.Value;
            }
            set
            {
                this.initValue.Value = value;
            }
        }

      public System.Int32? MaxValue
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

      public System.Int32? MinValue
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

      public System.Boolean? NotBlank
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

      public System.Int32? SignDisplacement
        {
            get
            {
                return this.signDisplacement.Value;
            }
            set
            {
                this.signDisplacement.Value = value;
            }
        }

        public TableRelationLines TableRelation
        {
            get
            {
                return this.tableRelation.Value;
            }
        }

      public System.Boolean? TestTableRelation
        {
            get
            {
                return this.testTableRelation.Value;
            }
            set
            {
                this.testTableRelation.Value = value;
            }
        }

      public System.Boolean? ValidateTableRelation
        {
            get
            {
                return this.validateTableRelation.Value;
            }
            set
            {
                this.validateTableRelation.Value = value;
            }
        }

      public System.String ValuesAllowed
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

      public System.Boolean? Volatile
        {
            get
            {
                return this.@volatile.Value;
            }
            set
            {
                this.@volatile.Value = value;
            }
        }

      public System.Int32? Width
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

        public IEnumerator<Property> GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

    }

    [Serializable]
    public class MenuSuiteDeltaNodeProperties : IEnumerable<Property>
    {
        private List<Property> innerList = new List<Property>();

        private NullableBooleanProperty deleted = new NullableBooleanProperty("Deleted");
        private NullableGuidProperty nextNodeID = new NullableGuidProperty("NextNodeID");

        internal MenuSuiteDeltaNodeProperties()
        {
            innerList.Add(deleted);
            innerList.Add(nextNodeID);
        }

      public System.Boolean? Deleted
        {
            get
            {
                return this.deleted.Value;
            }
            set
            {
                this.deleted.Value = value;
            }
        }

      public System.Guid? NextNodeID
        {
            get
            {
                return this.nextNodeID.Value;
            }
            set
            {
                this.nextNodeID.Value = value;
            }
        }

        public IEnumerator<Property> GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

    }

    [Serializable]
    public class MenuSuiteGroupNodeProperties : IEnumerable<Property>
    {
        private List<Property> innerList = new List<Property>();

        private MultiLanguageProperty captionML = new MultiLanguageProperty("CaptionML");
        private NullableGuidProperty firstChild = new NullableGuidProperty("FirstChild");
        private NullableBooleanProperty isDepartmentPage = new NullableBooleanProperty("IsDepartmentPage");
        private NullableGuidProperty memberOfMenu = new NullableGuidProperty("MemberOfMenu");
        private StringProperty name = new StringProperty("Name");
        private NullableGuidProperty nextNodeID = new NullableGuidProperty("NextNodeID");
        private NullableGuidProperty parentNodeID = new NullableGuidProperty("ParentNodeID");
        private NullableBooleanProperty visible = new NullableBooleanProperty("Visible");

        internal MenuSuiteGroupNodeProperties()
        {
            innerList.Add(name);
            innerList.Add(captionML);
            innerList.Add(memberOfMenu);
            innerList.Add(parentNodeID);
            innerList.Add(visible);
            innerList.Add(nextNodeID);
            innerList.Add(firstChild);
            innerList.Add(isDepartmentPage);
        }

        public MultiLanguageValue CaptionML
        {
            get
            {
                return this.captionML.Value;
            }
        }

      public System.Guid? FirstChild
        {
            get
            {
                return this.firstChild.Value;
            }
            set
            {
                this.firstChild.Value = value;
            }
        }

      public System.Boolean? IsDepartmentPage
        {
            get
            {
                return this.isDepartmentPage.Value;
            }
            set
            {
                this.isDepartmentPage.Value = value;
            }
        }

      public System.Guid? MemberOfMenu
        {
            get
            {
                return this.memberOfMenu.Value;
            }
            set
            {
                this.memberOfMenu.Value = value;
            }
        }

      public System.String Name
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

      public System.Guid? NextNodeID
        {
            get
            {
                return this.nextNodeID.Value;
            }
            set
            {
                this.nextNodeID.Value = value;
            }
        }

      public System.Guid? ParentNodeID
        {
            get
            {
                return this.parentNodeID.Value;
            }
            set
            {
                this.parentNodeID.Value = value;
            }
        }

      public System.Boolean? Visible
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

        public IEnumerator<Property> GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

    }

    [Serializable]
    public class MenuSuiteItemNodeProperties : IEnumerable<Property>
    {
        private List<Property> innerList = new List<Property>();

        private MultiLanguageProperty captionML = new MultiLanguageProperty("CaptionML");
        private NullableBooleanProperty deleted = new NullableBooleanProperty("Deleted");
        private MenuItemDepartmentCategoryProperty departmentCategory = new MenuItemDepartmentCategoryProperty("DepartmentCategory");
        private NullableGuidProperty memberOfMenu = new NullableGuidProperty("MemberOfMenu");
        private StringProperty name = new StringProperty("Name");
        private NullableGuidProperty nextNodeID = new NullableGuidProperty("NextNodeID");
        private NullableGuidProperty parentNodeID = new NullableGuidProperty("ParentNodeID");
        private NullableIntegerProperty runObjectID = new NullableIntegerProperty("RunObjectID");
        private MenuItemRunObjectTypeProperty runObjectType = new MenuItemRunObjectTypeProperty("RunObjectType");
        private NullableBooleanProperty visible = new NullableBooleanProperty("Visible");

        internal MenuSuiteItemNodeProperties()
        {
            innerList.Add(name);
            innerList.Add(captionML);
            innerList.Add(memberOfMenu);
            innerList.Add(runObjectType);
            innerList.Add(runObjectID);
            innerList.Add(parentNodeID);
            innerList.Add(visible);
            innerList.Add(nextNodeID);
            innerList.Add(deleted);
            innerList.Add(departmentCategory);
        }

        public MultiLanguageValue CaptionML
        {
            get
            {
                return this.captionML.Value;
            }
        }

      public System.Boolean? Deleted
        {
            get
            {
                return this.deleted.Value;
            }
            set
            {
                this.deleted.Value = value;
            }
        }

        public MenuItemDepartmentCategory? DepartmentCategory
        {
            get
            {
                return this.departmentCategory.Value;
            }
            set
            {
                this.departmentCategory.Value = value;
            }
        }

      public System.Guid? MemberOfMenu
        {
            get
            {
                return this.memberOfMenu.Value;
            }
            set
            {
                this.memberOfMenu.Value = value;
            }
        }

      public System.String Name
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

      public System.Guid? NextNodeID
        {
            get
            {
                return this.nextNodeID.Value;
            }
            set
            {
                this.nextNodeID.Value = value;
            }
        }

      public System.Guid? ParentNodeID
        {
            get
            {
                return this.parentNodeID.Value;
            }
            set
            {
                this.parentNodeID.Value = value;
            }
        }

      public System.Int32? RunObjectID
        {
            get
            {
                return this.runObjectID.Value;
            }
            set
            {
                this.runObjectID.Value = value;
            }
        }

        public MenuItemRunObjectType? RunObjectType
        {
            get
            {
                return this.runObjectType.Value;
            }
            set
            {
                this.runObjectType.Value = value;
            }
        }

      public System.Boolean? Visible
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

        public IEnumerator<Property> GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

    }

    [Serializable]
    public class MenuSuiteMenuNodeProperties : IEnumerable<Property>
    {
        private List<Property> innerList = new List<Property>();

        private MultiLanguageProperty captionML = new MultiLanguageProperty("CaptionML");
        private NullableBooleanProperty enabled = new NullableBooleanProperty("Enabled");
        private NullableGuidProperty firstChild = new NullableGuidProperty("FirstChild");
        private NullableIntegerProperty image = new NullableIntegerProperty("Image");
        private NullableBooleanProperty isShortcut = new NullableBooleanProperty("IsShortcut");
        private NullableGuidProperty memberOfMenu = new NullableGuidProperty("MemberOfMenu");
        private StringProperty name = new StringProperty("Name");
        private NullableGuidProperty nextNodeID = new NullableGuidProperty("NextNodeID");
        private NullableGuidProperty parentNodeID = new NullableGuidProperty("ParentNodeID");
        private NullableBooleanProperty visible = new NullableBooleanProperty("Visible");

        internal MenuSuiteMenuNodeProperties()
        {
            innerList.Add(name);
            innerList.Add(captionML);
            innerList.Add(memberOfMenu);
            innerList.Add(parentNodeID);
            innerList.Add(image);
            innerList.Add(isShortcut);
            innerList.Add(visible);
            innerList.Add(enabled);
            innerList.Add(nextNodeID);
            innerList.Add(firstChild);
        }

        public MultiLanguageValue CaptionML
        {
            get
            {
                return this.captionML.Value;
            }
        }

      public System.Boolean? Enabled
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

      public System.Guid? FirstChild
        {
            get
            {
                return this.firstChild.Value;
            }
            set
            {
                this.firstChild.Value = value;
            }
        }

      public System.Int32? Image
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

      public System.Boolean? IsShortcut
        {
            get
            {
                return this.isShortcut.Value;
            }
            set
            {
                this.isShortcut.Value = value;
            }
        }

      public System.Guid? MemberOfMenu
        {
            get
            {
                return this.memberOfMenu.Value;
            }
            set
            {
                this.memberOfMenu.Value = value;
            }
        }

      public System.String Name
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

      public System.Guid? NextNodeID
        {
            get
            {
                return this.nextNodeID.Value;
            }
            set
            {
                this.nextNodeID.Value = value;
            }
        }

      public System.Guid? ParentNodeID
        {
            get
            {
                return this.parentNodeID.Value;
            }
            set
            {
                this.parentNodeID.Value = value;
            }
        }

      public System.Boolean? Visible
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

        public IEnumerator<Property> GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

    }

    [Serializable]
    public class MenuSuiteProperties : IEnumerable<Property>
    {
        private List<Property> innerList = new List<Property>();

        internal MenuSuiteProperties()
        {
        }

        public IEnumerator<Property> GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

    }

    [Serializable]
    public class MenuSuiteRootNodeProperties : IEnumerable<Property>
    {
        private List<Property> innerList = new List<Property>();

        private NullableGuidProperty firstChild = new NullableGuidProperty("FirstChild");

        internal MenuSuiteRootNodeProperties()
        {
            innerList.Add(firstChild);
        }

      public System.Guid? FirstChild
        {
            get
            {
                return this.firstChild.Value;
            }
            set
            {
                this.firstChild.Value = value;
            }
        }

        public IEnumerator<Property> GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

    }

    [Serializable]
    public class ObjectProperties : IEnumerable<Property>
    {
        private List<Property> innerList = new List<Property>();

        private NullableDateTimeProperty dateTime = new NullableDateTimeProperty("DateTime");
        private BooleanProperty modified = new BooleanProperty("Modified");
        private StringProperty versionList = new StringProperty("VersionList");

        internal ObjectProperties()
        {
            innerList.Add(dateTime);
            innerList.Add(modified);
            innerList.Add(versionList);
        }

      public System.DateTime? DateTime
        {
            get
            {
                return this.dateTime.Value;
            }
            set
            {
                this.dateTime.Value = value;
            }
        }

      public System.Boolean Modified
        {
            get
            {
                return this.modified.Value;
            }
            set
            {
                this.modified.Value = value;
            }
        }

      public System.String VersionList
        {
            get
            {
                return this.versionList.Value;
            }
            set
            {
                this.versionList.Value = value;
            }
        }

        public IEnumerator<Property> GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

    }

    [Serializable]
    public class OptionTableFieldProperties : IEnumerable<Property>
    {
        private List<Property> innerList = new List<Property>();

        private StringProperty altSearchField = new StringProperty("AltSearchField");
        private StringProperty autoFormatExpr = new StringProperty("AutoFormatExpr");
        private AutoFormatTypeProperty autoFormatType = new AutoFormatTypeProperty("AutoFormatType");
        private BlankNumbersProperty blankNumbers = new BlankNumbersProperty("BlankNumbers");
        private NullableBooleanProperty blankZero = new NullableBooleanProperty("BlankZero");
        private CalcFormulaProperty calcFormula = new CalcFormulaProperty("CalcFormula");
        private StringProperty captionClass = new StringProperty("CaptionClass");
        private MultiLanguageProperty captionML = new MultiLanguageProperty("CaptionML");
        private StringProperty description = new StringProperty("Description");
        private NullableBooleanProperty editable = new NullableBooleanProperty("Editable");
        private ExtendedDataTypeProperty extendedDatatype = new ExtendedDataTypeProperty("ExtendedDatatype");
        private FieldClassProperty fieldClass = new FieldClassProperty("FieldClass");
        private StringProperty initValue = new StringProperty("InitValue");
        private StringProperty maxValue = new StringProperty("MaxValue");
        private StringProperty minValue = new StringProperty("MinValue");
        private NullableBooleanProperty notBlank = new NullableBooleanProperty("NotBlank");
        private TriggerProperty onLookup = new TriggerProperty("OnLookup");
        private TriggerProperty onValidate = new TriggerProperty("OnValidate");
        private MultiLanguageProperty optionCaptionML = new MultiLanguageProperty("OptionCaptionML");
        private OptionStringProperty optionString = new OptionStringProperty("OptionString");
        private NullableIntegerProperty signDisplacement = new NullableIntegerProperty("SignDisplacement");
        private TableRelationLinesProperty tableRelation = new TableRelationLinesProperty("TableRelation");
        private NullableBooleanProperty testTableRelation = new NullableBooleanProperty("TestTableRelation");
        private NullableBooleanProperty validateTableRelation = new NullableBooleanProperty("ValidateTableRelation");
        private SemiColonSeparatedStringProperty valuesAllowed = new SemiColonSeparatedStringProperty("ValuesAllowed");

        internal OptionTableFieldProperties()
        {
            innerList.Add(fieldClass);
            innerList.Add(calcFormula);
            innerList.Add(initValue);
            innerList.Add(tableRelation);
            innerList.Add(altSearchField);
            innerList.Add(onValidate);
            innerList.Add(onLookup);
            innerList.Add(validateTableRelation);
            innerList.Add(testTableRelation);
            innerList.Add(extendedDatatype);
            innerList.Add(captionML);
            innerList.Add(optionCaptionML);
            innerList.Add(optionString);
            innerList.Add(minValue);
            innerList.Add(maxValue);
            innerList.Add(notBlank);
            innerList.Add(blankNumbers);
            innerList.Add(blankZero);
            innerList.Add(valuesAllowed);
            innerList.Add(signDisplacement);
            innerList.Add(description);
            innerList.Add(editable);
            innerList.Add(autoFormatType);
            innerList.Add(autoFormatExpr);
            innerList.Add(captionClass);
        }

      public System.String AltSearchField
        {
            get
            {
                return this.altSearchField.Value;
            }
            set
            {
                this.altSearchField.Value = value;
            }
        }

      public System.String AutoFormatExpr
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

      public System.Boolean? BlankZero
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

        public CalcFormula CalcFormula
        {
            get
            {
                return this.calcFormula.Value;
            }
        }

      public System.String CaptionClass
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

      public System.String Description
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

      public System.Boolean? Editable
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

        public FieldClass? FieldClass
        {
            get
            {
                return this.fieldClass.Value;
            }
            set
            {
                this.fieldClass.Value = value;
            }
        }

      public System.String InitValue
        {
            get
            {
                return this.initValue.Value;
            }
            set
            {
                this.initValue.Value = value;
            }
        }

      public System.String MaxValue
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

      public System.String MinValue
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

      public System.Boolean? NotBlank
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

      public System.String OptionString
        {
            get
            {
                return this.optionString.Value;
            }
            set
            {
                this.optionString.Value = value;
            }
        }

      public System.Int32? SignDisplacement
        {
            get
            {
                return this.signDisplacement.Value;
            }
            set
            {
                this.signDisplacement.Value = value;
            }
        }

        public TableRelationLines TableRelation
        {
            get
            {
                return this.tableRelation.Value;
            }
        }

      public System.Boolean? TestTableRelation
        {
            get
            {
                return this.testTableRelation.Value;
            }
            set
            {
                this.testTableRelation.Value = value;
            }
        }

      public System.Boolean? ValidateTableRelation
        {
            get
            {
                return this.validateTableRelation.Value;
            }
            set
            {
                this.validateTableRelation.Value = value;
            }
        }

      public System.String ValuesAllowed
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

        public IEnumerator<Property> GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

    }

    [Serializable]
    public class PageActionContainerProperties : IEnumerable<Property>
    {
        private List<Property> innerList = new List<Property>();

        private ActionContainerTypeProperty actionContainerType = new ActionContainerTypeProperty("ActionContainerType");
        private MultiLanguageProperty captionML = new MultiLanguageProperty("CaptionML");
        private StringProperty description = new StringProperty("Description");
        private StringProperty name = new StringProperty("Name");

        internal PageActionContainerProperties()
        {
            innerList.Add(name);
            innerList.Add(captionML);
            innerList.Add(description);
            innerList.Add(actionContainerType);
        }

        public ActionContainerType? ActionContainerType
        {
            get
            {
                return this.actionContainerType.Value;
            }
            set
            {
                this.actionContainerType.Value = value;
            }
        }

        public MultiLanguageValue CaptionML
        {
            get
            {
                return this.captionML.Value;
            }
        }

      public System.String Description
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

      public System.String Name
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

        public IEnumerator<Property> GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

    }

    [Serializable]
    public class PageActionGroupProperties : IEnumerable<Property>
    {
        private List<Property> innerList = new List<Property>();

        private ActionContainerTypeProperty actionContainerType = new ActionContainerTypeProperty("ActionContainerType");
        private MultiLanguageProperty captionML = new MultiLanguageProperty("CaptionML");
        private StringProperty description = new StringProperty("Description");
        private StringProperty enabled = new StringProperty("Enabled");
        private StringProperty image = new StringProperty("Image");
        private StringProperty name = new StringProperty("Name");
        private StringProperty visible = new StringProperty("Visible");

        internal PageActionGroupProperties()
        {
            innerList.Add(name);
            innerList.Add(captionML);
            innerList.Add(description);
            innerList.Add(visible);
            innerList.Add(enabled);
            innerList.Add(actionContainerType);
            innerList.Add(image);
        }

        public ActionContainerType? ActionContainerType
        {
            get
            {
                return this.actionContainerType.Value;
            }
            set
            {
                this.actionContainerType.Value = value;
            }
        }

        public MultiLanguageValue CaptionML
        {
            get
            {
                return this.captionML.Value;
            }
        }

      public System.String Description
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

      public System.String Enabled
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

      public System.String Image
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

      public System.String Name
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

      public System.String Visible
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

        public IEnumerator<Property> GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

    }

    [Serializable]
    public class PageActionProperties : IEnumerable<Property>
    {
        private List<Property> innerList = new List<Property>();

        private MultiLanguageProperty captionML = new MultiLanguageProperty("CaptionML");
        private StringProperty description = new StringProperty("Description");
        private NullableBooleanProperty ellipsis = new NullableBooleanProperty("Ellipsis");
        private StringProperty enabled = new StringProperty("Enabled");
        private StringProperty image = new StringProperty("Image");
        private NullableBooleanProperty inFooterBar = new NullableBooleanProperty("InFooterBar");
        private StringProperty name = new StringProperty("Name");
        private TriggerProperty onAction = new TriggerProperty("OnAction");
        private NullableBooleanProperty promoted = new NullableBooleanProperty("Promoted");
        private PromotedCategoryProperty promotedCategory = new PromotedCategoryProperty("PromotedCategory");
        private NullableBooleanProperty promotedIsBig = new NullableBooleanProperty("PromotedIsBig");
        private ObjectReferenceProperty runObject = new ObjectReferenceProperty("RunObject");
        private RunObjectLinkProperty runPageLink = new RunObjectLinkProperty("RunPageLink");
        private RunPageModeProperty runPageMode = new RunPageModeProperty("RunPageMode");
        private NullableBooleanProperty runPageOnRec = new NullableBooleanProperty("RunPageOnRec");
        private TableViewProperty runPageView = new TableViewProperty("RunPageView");
        private StringProperty shortCutKey = new StringProperty("ShortCutKey");
        private MultiLanguageProperty toolTipML = new MultiLanguageProperty("ToolTipML");
        private StringProperty visible = new StringProperty("Visible");

        internal PageActionProperties()
        {
            innerList.Add(name);
            innerList.Add(shortCutKey);
            innerList.Add(ellipsis);
            innerList.Add(captionML);
            innerList.Add(toolTipML);
            innerList.Add(description);
            innerList.Add(runObject);
            innerList.Add(runPageOnRec);
            innerList.Add(runPageView);
            innerList.Add(runPageLink);
            innerList.Add(promoted);
            innerList.Add(visible);
            innerList.Add(enabled);
            innerList.Add(inFooterBar);
            innerList.Add(promotedIsBig);
            innerList.Add(image);
            innerList.Add(promotedCategory);
            innerList.Add(runPageMode);
            innerList.Add(onAction);
        }

        public MultiLanguageValue CaptionML
        {
            get
            {
                return this.captionML.Value;
            }
        }

      public System.String Description
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

      public System.Boolean? Ellipsis
        {
            get
            {
                return this.ellipsis.Value;
            }
            set
            {
                this.ellipsis.Value = value;
            }
        }

      public System.String Enabled
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

      public System.String Image
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

      public System.Boolean? InFooterBar
        {
            get
            {
                return this.inFooterBar.Value;
            }
            set
            {
                this.inFooterBar.Value = value;
            }
        }

      public System.String Name
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

        public Trigger OnAction
        {
            get
            {
                return this.onAction.Value;
            }
        }

      public System.Boolean? Promoted
        {
            get
            {
                return this.promoted.Value;
            }
            set
            {
                this.promoted.Value = value;
            }
        }

        public PromotedCategory? PromotedCategory
        {
            get
            {
                return this.promotedCategory.Value;
            }
            set
            {
                this.promotedCategory.Value = value;
            }
        }

      public System.Boolean? PromotedIsBig
        {
            get
            {
                return this.promotedIsBig.Value;
            }
            set
            {
                this.promotedIsBig.Value = value;
            }
        }

        public ObjectReference RunObject
        {
            get
            {
                return this.runObject.Value;
            }
        }

        public RunObjectLink RunPageLink
        {
            get
            {
                return this.runPageLink.Value;
            }
        }

        public RunPageMode? RunPageMode
        {
            get
            {
                return this.runPageMode.Value;
            }
            set
            {
                this.runPageMode.Value = value;
            }
        }

      public System.Boolean? RunPageOnRec
        {
            get
            {
                return this.runPageOnRec.Value;
            }
            set
            {
                this.runPageOnRec.Value = value;
            }
        }

        public TableView RunPageView
        {
            get
            {
                return this.runPageView.Value;
            }
        }

      public System.String ShortCutKey
        {
            get
            {
                return this.shortCutKey.Value;
            }
            set
            {
                this.shortCutKey.Value = value;
            }
        }

        public MultiLanguageValue ToolTipML
        {
            get
            {
                return this.toolTipML.Value;
            }
        }

      public System.String Visible
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

        public IEnumerator<Property> GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

    }

    [Serializable]
    public class PageActionSeparatorProperties : IEnumerable<Property>
    {
        private List<Property> innerList = new List<Property>();

        private MultiLanguageProperty captionML = new MultiLanguageProperty("CaptionML");
        private NullableBooleanProperty isHeader = new NullableBooleanProperty("IsHeader");

        internal PageActionSeparatorProperties()
        {
            innerList.Add(captionML);
            innerList.Add(isHeader);
        }

        public MultiLanguageValue CaptionML
        {
            get
            {
                return this.captionML.Value;
            }
        }

      public System.Boolean? IsHeader
        {
            get
            {
                return this.isHeader.Value;
            }
            set
            {
                this.isHeader.Value = value;
            }
        }

        public IEnumerator<Property> GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

    }

    [Serializable]
    public class PageProperties : IEnumerable<Property>
    {
        private List<Property> innerList = new List<Property>();

        private ActionListProperty actionList = new ActionListProperty("ActionList");
        private NullableBooleanProperty autoSplitKey = new NullableBooleanProperty("AutoSplitKey");
        private MultiLanguageProperty captionML = new MultiLanguageProperty("CaptionML");
        private StringProperty cardPageID = new StringProperty("CardPageID");
        private StringProperty dataCaptionExpr = new StringProperty("DataCaptionExpr");
        private FieldListProperty dataCaptionFields = new FieldListProperty("DataCaptionFields");
        private NullableBooleanProperty delayedInsert = new NullableBooleanProperty("DelayedInsert");
        private NullableBooleanProperty deleteAllowed = new NullableBooleanProperty("DeleteAllowed");
        private StringProperty description = new StringProperty("Description");
        private NullableBooleanProperty editable = new NullableBooleanProperty("Editable");
        private NullableBooleanProperty insertAllowed = new NullableBooleanProperty("InsertAllowed");
        private MultiLanguageProperty instructionalTextML = new MultiLanguageProperty("InstructionalTextML");
        private NullableBooleanProperty linksAllowed = new NullableBooleanProperty("LinksAllowed");
        private NullableBooleanProperty modifyAllowed = new NullableBooleanProperty("ModifyAllowed");
        private NullableBooleanProperty multipleNewLines = new NullableBooleanProperty("MultipleNewLines");
        private TriggerProperty onAfterGetCurrRecord = new TriggerProperty("OnAfterGetCurrRecord");
        private TriggerProperty onAfterGetRecord = new TriggerProperty("OnAfterGetRecord");
        private TriggerProperty onClosePage = new TriggerProperty("OnClosePage");
        private TriggerProperty onDeleteRecord = new TriggerProperty("OnDeleteRecord");
        private TriggerProperty onFindRecord = new TriggerProperty("OnFindRecord");
        private TriggerProperty onInit = new TriggerProperty("OnInit");
        private TriggerProperty onInsertRecord = new TriggerProperty("OnInsertRecord");
        private TriggerProperty onModifyRecord = new TriggerProperty("OnModifyRecord");
        private TriggerProperty onNewRecord = new TriggerProperty("OnNewRecord");
        private TriggerProperty onNextRecord = new TriggerProperty("OnNextRecord");
        private TriggerProperty onOpenPage = new TriggerProperty("OnOpenPage");
        private TriggerProperty onQueryClosePage = new TriggerProperty("OnQueryClosePage");
        private PageTypeProperty pageType = new PageTypeProperty("PageType");
        private PermissionsProperty permissions = new PermissionsProperty("Permissions");
        private NullableBooleanProperty populateAllFields = new NullableBooleanProperty("PopulateAllFields");
        private MultiLanguageProperty promotedActionCategoriesML = new MultiLanguageProperty("PromotedActionCategoriesML");
        private NullableBooleanProperty refreshOnActivate = new NullableBooleanProperty("RefreshOnActivate");
        private NullableBooleanProperty saveValues = new NullableBooleanProperty("SaveValues");
        private NullableBooleanProperty showFilter = new NullableBooleanProperty("ShowFilter");
        private TableReferenceProperty sourceTable = new TableReferenceProperty("SourceTable");
        private NullableBooleanProperty sourceTableTemporary = new NullableBooleanProperty("SourceTableTemporary");
        private TableViewProperty sourceTableView = new TableViewProperty("SourceTableView");

        internal PageProperties()
        {
            innerList.Add(permissions);
            innerList.Add(editable);
            innerList.Add(captionML);
            innerList.Add(description);
            innerList.Add(saveValues);
            innerList.Add(multipleNewLines);
            innerList.Add(insertAllowed);
            innerList.Add(deleteAllowed);
            innerList.Add(modifyAllowed);
            innerList.Add(linksAllowed);
            innerList.Add(sourceTable);
            innerList.Add(dataCaptionExpr);
            innerList.Add(delayedInsert);
            innerList.Add(populateAllFields);
            innerList.Add(sourceTableView);
            innerList.Add(dataCaptionFields);
            innerList.Add(pageType);
            innerList.Add(sourceTableTemporary);
            innerList.Add(cardPageID);
            innerList.Add(instructionalTextML);
            innerList.Add(autoSplitKey);
            innerList.Add(refreshOnActivate);
            innerList.Add(promotedActionCategoriesML);
            innerList.Add(showFilter);
            innerList.Add(onInit);
            innerList.Add(onOpenPage);
            innerList.Add(onClosePage);
            innerList.Add(onFindRecord);
            innerList.Add(onNextRecord);
            innerList.Add(onAfterGetRecord);
            innerList.Add(onNewRecord);
            innerList.Add(onInsertRecord);
            innerList.Add(onModifyRecord);
            innerList.Add(onDeleteRecord);
            innerList.Add(onQueryClosePage);
            innerList.Add(onAfterGetCurrRecord);
            innerList.Add(actionList);
        }

        public ActionList ActionList
        {
            get
            {
                return this.actionList.Value;
            }
        }

      public System.Boolean? AutoSplitKey
        {
            get
            {
                return this.autoSplitKey.Value;
            }
            set
            {
                this.autoSplitKey.Value = value;
            }
        }

        public MultiLanguageValue CaptionML
        {
            get
            {
                return this.captionML.Value;
            }
        }

      public System.String CardPageID
        {
            get
            {
                return this.cardPageID.Value;
            }
            set
            {
                this.cardPageID.Value = value;
            }
        }

      public System.String DataCaptionExpr
        {
            get
            {
                return this.dataCaptionExpr.Value;
            }
            set
            {
                this.dataCaptionExpr.Value = value;
            }
        }

        public FieldList DataCaptionFields
        {
            get
            {
                return this.dataCaptionFields.Value;
            }
        }

      public System.Boolean? DelayedInsert
        {
            get
            {
                return this.delayedInsert.Value;
            }
            set
            {
                this.delayedInsert.Value = value;
            }
        }

      public System.Boolean? DeleteAllowed
        {
            get
            {
                return this.deleteAllowed.Value;
            }
            set
            {
                this.deleteAllowed.Value = value;
            }
        }

      public System.String Description
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

      public System.Boolean? Editable
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

      public System.Boolean? InsertAllowed
        {
            get
            {
                return this.insertAllowed.Value;
            }
            set
            {
                this.insertAllowed.Value = value;
            }
        }

        public MultiLanguageValue InstructionalTextML
        {
            get
            {
                return this.instructionalTextML.Value;
            }
        }

      public System.Boolean? LinksAllowed
        {
            get
            {
                return this.linksAllowed.Value;
            }
            set
            {
                this.linksAllowed.Value = value;
            }
        }

      public System.Boolean? ModifyAllowed
        {
            get
            {
                return this.modifyAllowed.Value;
            }
            set
            {
                this.modifyAllowed.Value = value;
            }
        }

      public System.Boolean? MultipleNewLines
        {
            get
            {
                return this.multipleNewLines.Value;
            }
            set
            {
                this.multipleNewLines.Value = value;
            }
        }

        public Trigger OnAfterGetCurrRecord
        {
            get
            {
                return this.onAfterGetCurrRecord.Value;
            }
        }

        public Trigger OnAfterGetRecord
        {
            get
            {
                return this.onAfterGetRecord.Value;
            }
        }

        public Trigger OnClosePage
        {
            get
            {
                return this.onClosePage.Value;
            }
        }

        public Trigger OnDeleteRecord
        {
            get
            {
                return this.onDeleteRecord.Value;
            }
        }

        public Trigger OnFindRecord
        {
            get
            {
                return this.onFindRecord.Value;
            }
        }

        public Trigger OnInit
        {
            get
            {
                return this.onInit.Value;
            }
        }

        public Trigger OnInsertRecord
        {
            get
            {
                return this.onInsertRecord.Value;
            }
        }

        public Trigger OnModifyRecord
        {
            get
            {
                return this.onModifyRecord.Value;
            }
        }

        public Trigger OnNewRecord
        {
            get
            {
                return this.onNewRecord.Value;
            }
        }

        public Trigger OnNextRecord
        {
            get
            {
                return this.onNextRecord.Value;
            }
        }

        public Trigger OnOpenPage
        {
            get
            {
                return this.onOpenPage.Value;
            }
        }

        public Trigger OnQueryClosePage
        {
            get
            {
                return this.onQueryClosePage.Value;
            }
        }

        public PageType? PageType
        {
            get
            {
                return this.pageType.Value;
            }
            set
            {
                this.pageType.Value = value;
            }
        }

        public Permissions Permissions
        {
            get
            {
                return this.permissions.Value;
            }
        }

      public System.Boolean? PopulateAllFields
        {
            get
            {
                return this.populateAllFields.Value;
            }
            set
            {
                this.populateAllFields.Value = value;
            }
        }

        public MultiLanguageValue PromotedActionCategoriesML
        {
            get
            {
                return this.promotedActionCategoriesML.Value;
            }
        }

      public System.Boolean? RefreshOnActivate
        {
            get
            {
                return this.refreshOnActivate.Value;
            }
            set
            {
                this.refreshOnActivate.Value = value;
            }
        }

      public System.Boolean? SaveValues
        {
            get
            {
                return this.saveValues.Value;
            }
            set
            {
                this.saveValues.Value = value;
            }
        }

      public System.Boolean? ShowFilter
        {
            get
            {
                return this.showFilter.Value;
            }
            set
            {
                this.showFilter.Value = value;
            }
        }

      public System.Int32? SourceTable
        {
            get
            {
                return this.sourceTable.Value;
            }
            set
            {
                this.sourceTable.Value = value;
            }
        }

      public System.Boolean? SourceTableTemporary
        {
            get
            {
                return this.sourceTableTemporary.Value;
            }
            set
            {
                this.sourceTableTemporary.Value = value;
            }
        }

        public TableView SourceTableView
        {
            get
            {
                return this.sourceTableView.Value;
            }
        }

        public IEnumerator<Property> GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

    }

    [Serializable]
    public class PartPageControlProperties : IEnumerable<Property>
    {
        private List<Property> innerList = new List<Property>();

        private MultiLanguageProperty captionML = new MultiLanguageProperty("CaptionML");
        private StringProperty chartPartID = new StringProperty("ChartPartID");
        private StringProperty description = new StringProperty("Description");
        private StringProperty editable = new StringProperty("Editable");
        private StringProperty enabled = new StringProperty("Enabled");
        private StringProperty name = new StringProperty("Name");
        private PageReferenceProperty pagePartID = new PageReferenceProperty("PagePartID");
        private PartTypeProperty partType = new PartTypeProperty("PartType");
        private NullableIntegerProperty providerID = new NullableIntegerProperty("ProviderID");
        private NullableBooleanProperty showFilter = new NullableBooleanProperty("ShowFilter");
        private RunObjectLinkProperty subPageLink = new RunObjectLinkProperty("SubPageLink");
        private TableViewProperty subPageView = new TableViewProperty("SubPageView");
        private SystemPartIDProperty systemPartID = new SystemPartIDProperty("SystemPartID");
        private MultiLanguageProperty toolTipML = new MultiLanguageProperty("ToolTipML");
        private StringProperty visible = new StringProperty("Visible");

        internal PartPageControlProperties()
        {
            innerList.Add(name);
            innerList.Add(captionML);
            innerList.Add(toolTipML);
            innerList.Add(description);
            innerList.Add(subPageView);
            innerList.Add(subPageLink);
            innerList.Add(pagePartID);
            innerList.Add(providerID);
            innerList.Add(visible);
            innerList.Add(enabled);
            innerList.Add(editable);
            innerList.Add(partType);
            innerList.Add(systemPartID);
            innerList.Add(chartPartID);
            innerList.Add(showFilter);
        }

        public MultiLanguageValue CaptionML
        {
            get
            {
                return this.captionML.Value;
            }
        }

      public System.String ChartPartID
        {
            get
            {
                return this.chartPartID.Value;
            }
            set
            {
                this.chartPartID.Value = value;
            }
        }

      public System.String Description
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

      public System.String Editable
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

      public System.String Enabled
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

      public System.String Name
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

      public System.Int32? PagePartID
        {
            get
            {
                return this.pagePartID.Value;
            }
            set
            {
                this.pagePartID.Value = value;
            }
        }

        public PartType? PartType
        {
            get
            {
                return this.partType.Value;
            }
            set
            {
                this.partType.Value = value;
            }
        }

      public System.Int32? ProviderID
        {
            get
            {
                return this.providerID.Value;
            }
            set
            {
                this.providerID.Value = value;
            }
        }

      public System.Boolean? ShowFilter
        {
            get
            {
                return this.showFilter.Value;
            }
            set
            {
                this.showFilter.Value = value;
            }
        }

        public RunObjectLink SubPageLink
        {
            get
            {
                return this.subPageLink.Value;
            }
        }

        public TableView SubPageView
        {
            get
            {
                return this.subPageView.Value;
            }
        }

        public SystemPartID? SystemPartID
        {
            get
            {
                return this.systemPartID.Value;
            }
            set
            {
                this.systemPartID.Value = value;
            }
        }

        public MultiLanguageValue ToolTipML
        {
            get
            {
                return this.toolTipML.Value;
            }
        }

      public System.String Visible
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

        public IEnumerator<Property> GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

    }

    [Serializable]
    public class QueryProperties : IEnumerable<Property>
    {
        private List<Property> innerList = new List<Property>();

        private MultiLanguageProperty captionML = new MultiLanguageProperty("CaptionML");
        private StringProperty description = new StringProperty("Description");
        private TriggerProperty onBeforeOpen = new TriggerProperty("OnBeforeOpen");
        private QueryOrderByLinesProperty orderBy = new QueryOrderByLinesProperty("OrderBy");
        private PermissionsProperty permissions = new PermissionsProperty("Permissions");
        private ReadStateProperty readState = new ReadStateProperty("ReadState");
        private NullableIntegerProperty topNumberOfRows = new NullableIntegerProperty("TopNumberOfRows");

        internal QueryProperties()
        {
            innerList.Add(permissions);
            innerList.Add(captionML);
            innerList.Add(description);
            innerList.Add(topNumberOfRows);
            innerList.Add(readState);
            innerList.Add(orderBy);
            innerList.Add(onBeforeOpen);
        }

        public MultiLanguageValue CaptionML
        {
            get
            {
                return this.captionML.Value;
            }
        }

      public System.String Description
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

        public Trigger OnBeforeOpen
        {
            get
            {
                return this.onBeforeOpen.Value;
            }
        }

        public QueryOrderByLines OrderBy
        {
            get
            {
                return this.orderBy.Value;
            }
        }

        public Permissions Permissions
        {
            get
            {
                return this.permissions.Value;
            }
        }

        public ReadState? ReadState
        {
            get
            {
                return this.readState.Value;
            }
            set
            {
                this.readState.Value = value;
            }
        }

      public System.Int32? TopNumberOfRows
        {
            get
            {
                return this.topNumberOfRows.Value;
            }
            set
            {
                this.topNumberOfRows.Value = value;
            }
        }

        public IEnumerator<Property> GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

    }

    [Serializable]
    public class RecordIDTableFieldProperties : IEnumerable<Property>
    {
        private List<Property> innerList = new List<Property>();

        private StringProperty altSearchField = new StringProperty("AltSearchField");
        private StringProperty autoFormatExpr = new StringProperty("AutoFormatExpr");
        private AutoFormatTypeProperty autoFormatType = new AutoFormatTypeProperty("AutoFormatType");
        private CalcFormulaProperty calcFormula = new CalcFormulaProperty("CalcFormula");
        private StringProperty captionClass = new StringProperty("CaptionClass");
        private MultiLanguageProperty captionML = new MultiLanguageProperty("CaptionML");
        private StringProperty description = new StringProperty("Description");
        private NullableBooleanProperty editable = new NullableBooleanProperty("Editable");
        private ExtendedDataTypeProperty extendedDatatype = new ExtendedDataTypeProperty("ExtendedDatatype");
        private FieldClassProperty fieldClass = new FieldClassProperty("FieldClass");
        private StringProperty initValue = new StringProperty("InitValue");
        private NullableBooleanProperty notBlank = new NullableBooleanProperty("NotBlank");
        private TriggerProperty onLookup = new TriggerProperty("OnLookup");
        private TriggerProperty onValidate = new TriggerProperty("OnValidate");
        private TableRelationLinesProperty tableRelation = new TableRelationLinesProperty("TableRelation");
        private NullableBooleanProperty testTableRelation = new NullableBooleanProperty("TestTableRelation");
        private NullableBooleanProperty validateTableRelation = new NullableBooleanProperty("ValidateTableRelation");
        private SemiColonSeparatedStringProperty valuesAllowed = new SemiColonSeparatedStringProperty("ValuesAllowed");

        internal RecordIDTableFieldProperties()
        {
            innerList.Add(fieldClass);
            innerList.Add(calcFormula);
            innerList.Add(initValue);
            innerList.Add(tableRelation);
            innerList.Add(altSearchField);
            innerList.Add(onValidate);
            innerList.Add(onLookup);
            innerList.Add(validateTableRelation);
            innerList.Add(testTableRelation);
            innerList.Add(extendedDatatype);
            innerList.Add(captionML);
            innerList.Add(notBlank);
            innerList.Add(valuesAllowed);
            innerList.Add(description);
            innerList.Add(editable);
            innerList.Add(autoFormatType);
            innerList.Add(autoFormatExpr);
            innerList.Add(captionClass);
        }

      public System.String AltSearchField
        {
            get
            {
                return this.altSearchField.Value;
            }
            set
            {
                this.altSearchField.Value = value;
            }
        }

      public System.String AutoFormatExpr
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

        public CalcFormula CalcFormula
        {
            get
            {
                return this.calcFormula.Value;
            }
        }

      public System.String CaptionClass
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

      public System.String Description
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

      public System.Boolean? Editable
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

        public FieldClass? FieldClass
        {
            get
            {
                return this.fieldClass.Value;
            }
            set
            {
                this.fieldClass.Value = value;
            }
        }

      public System.String InitValue
        {
            get
            {
                return this.initValue.Value;
            }
            set
            {
                this.initValue.Value = value;
            }
        }

      public System.Boolean? NotBlank
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

        public TableRelationLines TableRelation
        {
            get
            {
                return this.tableRelation.Value;
            }
        }

      public System.Boolean? TestTableRelation
        {
            get
            {
                return this.testTableRelation.Value;
            }
            set
            {
                this.testTableRelation.Value = value;
            }
        }

      public System.Boolean? ValidateTableRelation
        {
            get
            {
                return this.validateTableRelation.Value;
            }
            set
            {
                this.validateTableRelation.Value = value;
            }
        }

      public System.String ValuesAllowed
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

        public IEnumerator<Property> GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

    }

    [Serializable]
    public class ReportLabelProperties : IEnumerable<Property>
    {
        private List<Property> innerList = new List<Property>();

        private MultiLanguageProperty captionML = new MultiLanguageProperty("CaptionML");
        private StringProperty description = new StringProperty("Description");

        internal ReportLabelProperties()
        {
            innerList.Add(captionML);
            innerList.Add(description);
        }

        public MultiLanguageValue CaptionML
        {
            get
            {
                return this.captionML.Value;
            }
        }

      public System.String Description
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

        public IEnumerator<Property> GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

    }

    [Serializable]
    public class ReportProperties : IEnumerable<Property>
    {
        private List<Property> innerList = new List<Property>();

        private MultiLanguageProperty captionML = new MultiLanguageProperty("CaptionML");
        private StringProperty description = new StringProperty("Description");
        private NullableBooleanProperty enableExternalAssemblies = new NullableBooleanProperty("EnableExternalAssemblies");
        private NullableBooleanProperty enableExternalImages = new NullableBooleanProperty("EnableExternalImages");
        private NullableBooleanProperty enableHyperlinks = new NullableBooleanProperty("EnableHyperlinks");
        private TriggerProperty onInitReport = new TriggerProperty("OnInitReport");
        private TriggerProperty onPostReport = new TriggerProperty("OnPostReport");
        private TriggerProperty onPreReport = new TriggerProperty("OnPreReport");
        private PaperSourceProperty paperSourceDefaultPage = new PaperSourceProperty("PaperSourceDefaultPage");
        private PaperSourceProperty paperSourceFirstPage = new PaperSourceProperty("PaperSourceFirstPage");
        private PaperSourceProperty paperSourceLastPage = new PaperSourceProperty("PaperSourceLastPage");
        private PermissionsProperty permissions = new PermissionsProperty("Permissions");
        private NullableBooleanProperty processingOnly = new NullableBooleanProperty("ProcessingOnly");
        private NullableBooleanProperty showPrintStatus = new NullableBooleanProperty("ShowPrintStatus");
        private TransactionTypeProperty transactionType = new TransactionTypeProperty("TransactionType");
        private NullableBooleanProperty useRequestPage = new NullableBooleanProperty("UseRequestPage");
        private NullableBooleanProperty useSystemPrinter = new NullableBooleanProperty("UseSystemPrinter");

        internal ReportProperties()
        {
            innerList.Add(permissions);
            innerList.Add(transactionType);
            innerList.Add(captionML);
            innerList.Add(description);
            innerList.Add(showPrintStatus);
            innerList.Add(useSystemPrinter);
            innerList.Add(processingOnly);
            innerList.Add(enableExternalImages);
            innerList.Add(enableHyperlinks);
            innerList.Add(enableExternalAssemblies);
            innerList.Add(onInitReport);
            innerList.Add(onPreReport);
            innerList.Add(onPostReport);
            innerList.Add(paperSourceDefaultPage);
            innerList.Add(paperSourceFirstPage);
            innerList.Add(paperSourceLastPage);
            innerList.Add(useRequestPage);
        }

        public MultiLanguageValue CaptionML
        {
            get
            {
                return this.captionML.Value;
            }
        }

      public System.String Description
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

      public System.Boolean? EnableExternalAssemblies
        {
            get
            {
                return this.enableExternalAssemblies.Value;
            }
            set
            {
                this.enableExternalAssemblies.Value = value;
            }
        }

      public System.Boolean? EnableExternalImages
        {
            get
            {
                return this.enableExternalImages.Value;
            }
            set
            {
                this.enableExternalImages.Value = value;
            }
        }

      public System.Boolean? EnableHyperlinks
        {
            get
            {
                return this.enableHyperlinks.Value;
            }
            set
            {
                this.enableHyperlinks.Value = value;
            }
        }

        public Trigger OnInitReport
        {
            get
            {
                return this.onInitReport.Value;
            }
        }

        public Trigger OnPostReport
        {
            get
            {
                return this.onPostReport.Value;
            }
        }

        public Trigger OnPreReport
        {
            get
            {
                return this.onPreReport.Value;
            }
        }

        public PaperSource? PaperSourceDefaultPage
        {
            get
            {
                return this.paperSourceDefaultPage.Value;
            }
            set
            {
                this.paperSourceDefaultPage.Value = value;
            }
        }

        public PaperSource? PaperSourceFirstPage
        {
            get
            {
                return this.paperSourceFirstPage.Value;
            }
            set
            {
                this.paperSourceFirstPage.Value = value;
            }
        }

        public PaperSource? PaperSourceLastPage
        {
            get
            {
                return this.paperSourceLastPage.Value;
            }
            set
            {
                this.paperSourceLastPage.Value = value;
            }
        }

        public Permissions Permissions
        {
            get
            {
                return this.permissions.Value;
            }
        }

      public System.Boolean? ProcessingOnly
        {
            get
            {
                return this.processingOnly.Value;
            }
            set
            {
                this.processingOnly.Value = value;
            }
        }

      public System.Boolean? ShowPrintStatus
        {
            get
            {
                return this.showPrintStatus.Value;
            }
            set
            {
                this.showPrintStatus.Value = value;
            }
        }

        public TransactionType? TransactionType
        {
            get
            {
                return this.transactionType.Value;
            }
            set
            {
                this.transactionType.Value = value;
            }
        }

      public System.Boolean? UseRequestPage
        {
            get
            {
                return this.useRequestPage.Value;
            }
            set
            {
                this.useRequestPage.Value = value;
            }
        }

      public System.Boolean? UseSystemPrinter
        {
            get
            {
                return this.useSystemPrinter.Value;
            }
            set
            {
                this.useSystemPrinter.Value = value;
            }
        }

        public IEnumerator<Property> GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

    }

    [Serializable]
    public class ReportRequestPageProperties : IEnumerable<Property>
    {
        private List<Property> innerList = new List<Property>();

        private ActionListProperty actionList = new ActionListProperty("ActionList");
        private NullableBooleanProperty autoSplitKey = new NullableBooleanProperty("AutoSplitKey");
        private MultiLanguageProperty captionML = new MultiLanguageProperty("CaptionML");
        private StringProperty cardPageID = new StringProperty("CardPageID");
        private StringProperty dataCaptionExpr = new StringProperty("DataCaptionExpr");
        private FieldListProperty dataCaptionFields = new FieldListProperty("DataCaptionFields");
        private NullableBooleanProperty deleteAllowed = new NullableBooleanProperty("DeleteAllowed");
        private StringProperty description = new StringProperty("Description");
        private NullableBooleanProperty editable = new NullableBooleanProperty("Editable");
        private NullableBooleanProperty insertAllowed = new NullableBooleanProperty("InsertAllowed");
        private MultiLanguageProperty instructionalTextML = new MultiLanguageProperty("InstructionalTextML");
        private NullableBooleanProperty linksAllowed = new NullableBooleanProperty("LinksAllowed");
        private NullableBooleanProperty modifyAllowed = new NullableBooleanProperty("ModifyAllowed");
        private NullableBooleanProperty multipleNewLines = new NullableBooleanProperty("MultipleNewLines");
        private TriggerProperty onAfterGetCurrRecord = new TriggerProperty("OnAfterGetCurrRecord");
        private TriggerProperty onAfterGetRecord = new TriggerProperty("OnAfterGetRecord");
        private TriggerProperty onClosePage = new TriggerProperty("OnClosePage");
        private TriggerProperty onDeleteRecord = new TriggerProperty("OnDeleteRecord");
        private TriggerProperty onFindRecord = new TriggerProperty("OnFindRecord");
        private TriggerProperty onInit = new TriggerProperty("OnInit");
        private TriggerProperty onInsertRecord = new TriggerProperty("OnInsertRecord");
        private TriggerProperty onModifyRecord = new TriggerProperty("OnModifyRecord");
        private TriggerProperty onNewRecord = new TriggerProperty("OnNewRecord");
        private TriggerProperty onNextRecord = new TriggerProperty("OnNextRecord");
        private TriggerProperty onOpenPage = new TriggerProperty("OnOpenPage");
        private TriggerProperty onQueryClosePage = new TriggerProperty("OnQueryClosePage");
        private PermissionsProperty permissions = new PermissionsProperty("Permissions");
        private NullableBooleanProperty populateAllFields = new NullableBooleanProperty("PopulateAllFields");
        private NullableBooleanProperty saveValues = new NullableBooleanProperty("SaveValues");
        private NullableBooleanProperty showFilter = new NullableBooleanProperty("ShowFilter");
        private TableReferenceProperty sourceTable = new TableReferenceProperty("SourceTable");
        private NullableBooleanProperty sourceTableTemporary = new NullableBooleanProperty("SourceTableTemporary");
        private TableViewProperty sourceTableView = new TableViewProperty("SourceTableView");

        internal ReportRequestPageProperties()
        {
            innerList.Add(permissions);
            innerList.Add(editable);
            innerList.Add(captionML);
            innerList.Add(description);
            innerList.Add(saveValues);
            innerList.Add(multipleNewLines);
            innerList.Add(insertAllowed);
            innerList.Add(deleteAllowed);
            innerList.Add(modifyAllowed);
            innerList.Add(linksAllowed);
            innerList.Add(sourceTable);
            innerList.Add(dataCaptionExpr);
            innerList.Add(populateAllFields);
            innerList.Add(sourceTableView);
            innerList.Add(dataCaptionFields);
            innerList.Add(sourceTableTemporary);
            innerList.Add(cardPageID);
            innerList.Add(instructionalTextML);
            innerList.Add(autoSplitKey);
            innerList.Add(showFilter);
            innerList.Add(onInit);
            innerList.Add(onOpenPage);
            innerList.Add(onClosePage);
            innerList.Add(onFindRecord);
            innerList.Add(onNextRecord);
            innerList.Add(onAfterGetRecord);
            innerList.Add(onNewRecord);
            innerList.Add(onInsertRecord);
            innerList.Add(onModifyRecord);
            innerList.Add(onDeleteRecord);
            innerList.Add(onQueryClosePage);
            innerList.Add(onAfterGetCurrRecord);
            innerList.Add(actionList);
        }

        public ActionList ActionList
        {
            get
            {
                return this.actionList.Value;
            }
        }

      public System.Boolean? AutoSplitKey
        {
            get
            {
                return this.autoSplitKey.Value;
            }
            set
            {
                this.autoSplitKey.Value = value;
            }
        }

        public MultiLanguageValue CaptionML
        {
            get
            {
                return this.captionML.Value;
            }
        }

      public System.String CardPageID
        {
            get
            {
                return this.cardPageID.Value;
            }
            set
            {
                this.cardPageID.Value = value;
            }
        }

      public System.String DataCaptionExpr
        {
            get
            {
                return this.dataCaptionExpr.Value;
            }
            set
            {
                this.dataCaptionExpr.Value = value;
            }
        }

        public FieldList DataCaptionFields
        {
            get
            {
                return this.dataCaptionFields.Value;
            }
        }

      public System.Boolean? DeleteAllowed
        {
            get
            {
                return this.deleteAllowed.Value;
            }
            set
            {
                this.deleteAllowed.Value = value;
            }
        }

      public System.String Description
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

      public System.Boolean? Editable
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

      public System.Boolean? InsertAllowed
        {
            get
            {
                return this.insertAllowed.Value;
            }
            set
            {
                this.insertAllowed.Value = value;
            }
        }

        public MultiLanguageValue InstructionalTextML
        {
            get
            {
                return this.instructionalTextML.Value;
            }
        }

      public System.Boolean? LinksAllowed
        {
            get
            {
                return this.linksAllowed.Value;
            }
            set
            {
                this.linksAllowed.Value = value;
            }
        }

      public System.Boolean? ModifyAllowed
        {
            get
            {
                return this.modifyAllowed.Value;
            }
            set
            {
                this.modifyAllowed.Value = value;
            }
        }

      public System.Boolean? MultipleNewLines
        {
            get
            {
                return this.multipleNewLines.Value;
            }
            set
            {
                this.multipleNewLines.Value = value;
            }
        }

        public Trigger OnAfterGetCurrRecord
        {
            get
            {
                return this.onAfterGetCurrRecord.Value;
            }
        }

        public Trigger OnAfterGetRecord
        {
            get
            {
                return this.onAfterGetRecord.Value;
            }
        }

        public Trigger OnClosePage
        {
            get
            {
                return this.onClosePage.Value;
            }
        }

        public Trigger OnDeleteRecord
        {
            get
            {
                return this.onDeleteRecord.Value;
            }
        }

        public Trigger OnFindRecord
        {
            get
            {
                return this.onFindRecord.Value;
            }
        }

        public Trigger OnInit
        {
            get
            {
                return this.onInit.Value;
            }
        }

        public Trigger OnInsertRecord
        {
            get
            {
                return this.onInsertRecord.Value;
            }
        }

        public Trigger OnModifyRecord
        {
            get
            {
                return this.onModifyRecord.Value;
            }
        }

        public Trigger OnNewRecord
        {
            get
            {
                return this.onNewRecord.Value;
            }
        }

        public Trigger OnNextRecord
        {
            get
            {
                return this.onNextRecord.Value;
            }
        }

        public Trigger OnOpenPage
        {
            get
            {
                return this.onOpenPage.Value;
            }
        }

        public Trigger OnQueryClosePage
        {
            get
            {
                return this.onQueryClosePage.Value;
            }
        }

        public Permissions Permissions
        {
            get
            {
                return this.permissions.Value;
            }
        }

      public System.Boolean? PopulateAllFields
        {
            get
            {
                return this.populateAllFields.Value;
            }
            set
            {
                this.populateAllFields.Value = value;
            }
        }

      public System.Boolean? SaveValues
        {
            get
            {
                return this.saveValues.Value;
            }
            set
            {
                this.saveValues.Value = value;
            }
        }

      public System.Boolean? ShowFilter
        {
            get
            {
                return this.showFilter.Value;
            }
            set
            {
                this.showFilter.Value = value;
            }
        }

      public System.Int32? SourceTable
        {
            get
            {
                return this.sourceTable.Value;
            }
            set
            {
                this.sourceTable.Value = value;
            }
        }

      public System.Boolean? SourceTableTemporary
        {
            get
            {
                return this.sourceTableTemporary.Value;
            }
            set
            {
                this.sourceTableTemporary.Value = value;
            }
        }

        public TableView SourceTableView
        {
            get
            {
                return this.sourceTableView.Value;
            }
        }

        public IEnumerator<Property> GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

    }

    [Serializable]
    public class TableFieldGroupProperties : IEnumerable<Property>
    {
        private List<Property> innerList = new List<Property>();

        private MultiLanguageProperty captionML = new MultiLanguageProperty("CaptionML");

        internal TableFieldGroupProperties()
        {
            innerList.Add(captionML);
        }

        public MultiLanguageValue CaptionML
        {
            get
            {
                return this.captionML.Value;
            }
        }

        public IEnumerator<Property> GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

    }

    [Serializable]
    public class TableFilterTableFieldProperties : IEnumerable<Property>
    {
        private List<Property> innerList = new List<Property>();

        private MultiLanguageProperty captionML = new MultiLanguageProperty("CaptionML");
        private StringProperty description = new StringProperty("Description");
        private TriggerProperty onLookup = new TriggerProperty("OnLookup");
        private TriggerProperty onValidate = new TriggerProperty("OnValidate");
        private StringProperty tableIDExpr = new StringProperty("TableIDExpr");

        internal TableFilterTableFieldProperties()
        {
            innerList.Add(onValidate);
            innerList.Add(onLookup);
            innerList.Add(tableIDExpr);
            innerList.Add(captionML);
            innerList.Add(description);
        }

        public MultiLanguageValue CaptionML
        {
            get
            {
                return this.captionML.Value;
            }
        }

      public System.String Description
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

      public System.String TableIDExpr
        {
            get
            {
                return this.tableIDExpr.Value;
            }
            set
            {
                this.tableIDExpr.Value = value;
            }
        }

        public IEnumerator<Property> GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

    }

    [Serializable]
    public class TableKeyProperties : IEnumerable<Property>
    {
        private List<Property> innerList = new List<Property>();

        private NullableBooleanProperty clustered = new NullableBooleanProperty("Clustered");
        private StringProperty keyGroups = new StringProperty("KeyGroups");
        private NullableBooleanProperty maintainSIFTIndex = new NullableBooleanProperty("MaintainSIFTIndex");
        private NullableBooleanProperty maintainSQLIndex = new NullableBooleanProperty("MaintainSQLIndex");
        private SIFTLevelsProperty siftLevelsToMaintain = new SIFTLevelsProperty("SIFTLevelsToMaintain");
        private FieldListProperty sqlIndex = new FieldListProperty("SQLIndex");
        private FieldListProperty sumIndexFields = new FieldListProperty("SumIndexFields");

        internal TableKeyProperties()
        {
            innerList.Add(sumIndexFields);
            innerList.Add(keyGroups);
            innerList.Add(maintainSQLIndex);
            innerList.Add(maintainSIFTIndex);
            innerList.Add(sqlIndex);
            innerList.Add(siftLevelsToMaintain);
            innerList.Add(clustered);
        }

      public System.Boolean? Clustered
        {
            get
            {
                return this.clustered.Value;
            }
            set
            {
                this.clustered.Value = value;
            }
        }

      public System.String KeyGroups
        {
            get
            {
                return this.keyGroups.Value;
            }
            set
            {
                this.keyGroups.Value = value;
            }
        }

      public System.Boolean? MaintainSIFTIndex
        {
            get
            {
                return this.maintainSIFTIndex.Value;
            }
            set
            {
                this.maintainSIFTIndex.Value = value;
            }
        }

      public System.Boolean? MaintainSQLIndex
        {
            get
            {
                return this.maintainSQLIndex.Value;
            }
            set
            {
                this.maintainSQLIndex.Value = value;
            }
        }

        public SIFTLevels SIFTLevelsToMaintain
        {
            get
            {
                return this.siftLevelsToMaintain.Value;
            }
        }

        public FieldList SQLIndex
        {
            get
            {
                return this.sqlIndex.Value;
            }
        }

        public FieldList SumIndexFields
        {
            get
            {
                return this.sumIndexFields.Value;
            }
        }

        public IEnumerator<Property> GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

    }

    [Serializable]
    public class TableProperties : IEnumerable<Property>
    {
        private List<Property> innerList = new List<Property>();

        private MultiLanguageProperty captionML = new MultiLanguageProperty("CaptionML");
        private FieldListProperty dataCaptionFields = new FieldListProperty("DataCaptionFields");
        private NullableBooleanProperty dataPerCompany = new NullableBooleanProperty("DataPerCompany");
        private StringProperty description = new StringProperty("Description");
        private PageReferenceProperty drillDownPageID = new PageReferenceProperty("DrillDownPageID");
        private NullableBooleanProperty linkedInTransaction = new NullableBooleanProperty("LinkedInTransaction");
        private NullableBooleanProperty linkedObject = new NullableBooleanProperty("LinkedObject");
        private PageReferenceProperty lookupPageID = new PageReferenceProperty("LookupPageID");
        private TriggerProperty onDelete = new TriggerProperty("OnDelete");
        private TriggerProperty onInsert = new TriggerProperty("OnInsert");
        private TriggerProperty onModify = new TriggerProperty("OnModify");
        private TriggerProperty onRename = new TriggerProperty("OnRename");
        private NullableBooleanProperty pasteIsValid = new NullableBooleanProperty("PasteIsValid");
        private PermissionsProperty permissions = new PermissionsProperty("Permissions");

        internal TableProperties()
        {
            innerList.Add(dataPerCompany);
            innerList.Add(permissions);
            innerList.Add(dataCaptionFields);
            innerList.Add(onInsert);
            innerList.Add(onModify);
            innerList.Add(onDelete);
            innerList.Add(onRename);
            innerList.Add(captionML);
            innerList.Add(description);
            innerList.Add(pasteIsValid);
            innerList.Add(lookupPageID);
            innerList.Add(drillDownPageID);
            innerList.Add(linkedInTransaction);
            innerList.Add(linkedObject);
        }

        public MultiLanguageValue CaptionML
        {
            get
            {
                return this.captionML.Value;
            }
        }

        public FieldList DataCaptionFields
        {
            get
            {
                return this.dataCaptionFields.Value;
            }
        }

      public System.Boolean? DataPerCompany
        {
            get
            {
                return this.dataPerCompany.Value;
            }
            set
            {
                this.dataPerCompany.Value = value;
            }
        }

      public System.String Description
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

      public System.Int32? DrillDownPageID
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

      public System.Boolean? LinkedInTransaction
        {
            get
            {
                return this.linkedInTransaction.Value;
            }
            set
            {
                this.linkedInTransaction.Value = value;
            }
        }

      public System.Boolean? LinkedObject
        {
            get
            {
                return this.linkedObject.Value;
            }
            set
            {
                this.linkedObject.Value = value;
            }
        }

      public System.Int32? LookupPageID
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

        public Trigger OnDelete
        {
            get
            {
                return this.onDelete.Value;
            }
        }

        public Trigger OnInsert
        {
            get
            {
                return this.onInsert.Value;
            }
        }

        public Trigger OnModify
        {
            get
            {
                return this.onModify.Value;
            }
        }

        public Trigger OnRename
        {
            get
            {
                return this.onRename.Value;
            }
        }

      public System.Boolean? PasteIsValid
        {
            get
            {
                return this.pasteIsValid.Value;
            }
            set
            {
                this.pasteIsValid.Value = value;
            }
        }

        public Permissions Permissions
        {
            get
            {
                return this.permissions.Value;
            }
        }

        public IEnumerator<Property> GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

    }

    [Serializable]
    public class TextTableFieldProperties : IEnumerable<Property>
    {
        private List<Property> innerList = new List<Property>();

        private StringProperty altSearchField = new StringProperty("AltSearchField");
        private StringProperty autoFormatExpr = new StringProperty("AutoFormatExpr");
        private AutoFormatTypeProperty autoFormatType = new AutoFormatTypeProperty("AutoFormatType");
        private CalcFormulaProperty calcFormula = new CalcFormulaProperty("CalcFormula");
        private StringProperty captionClass = new StringProperty("CaptionClass");
        private MultiLanguageProperty captionML = new MultiLanguageProperty("CaptionML");
        private StringProperty charAllowed = new StringProperty("CharAllowed");
        private NullableBooleanProperty dateFormula = new NullableBooleanProperty("DateFormula");
        private StringProperty description = new StringProperty("Description");
        private NullableBooleanProperty editable = new NullableBooleanProperty("Editable");
        private ExtendedDataTypeProperty extendedDatatype = new ExtendedDataTypeProperty("ExtendedDatatype");
        private FieldClassProperty fieldClass = new FieldClassProperty("FieldClass");
        private StringProperty initValue = new StringProperty("InitValue");
        private NullableBooleanProperty notBlank = new NullableBooleanProperty("NotBlank");
        private NullableBooleanProperty numeric = new NullableBooleanProperty("Numeric");
        private TriggerProperty onLookup = new TriggerProperty("OnLookup");
        private TriggerProperty onValidate = new TriggerProperty("OnValidate");
        private TableRelationLinesProperty tableRelation = new TableRelationLinesProperty("TableRelation");
        private NullableBooleanProperty testTableRelation = new NullableBooleanProperty("TestTableRelation");
        private NullableBooleanProperty title = new NullableBooleanProperty("Title");
        private NullableBooleanProperty validateTableRelation = new NullableBooleanProperty("ValidateTableRelation");
        private SemiColonSeparatedStringProperty valuesAllowed = new SemiColonSeparatedStringProperty("ValuesAllowed");
        private NullableIntegerProperty width = new NullableIntegerProperty("Width");

        internal TextTableFieldProperties()
        {
            innerList.Add(fieldClass);
            innerList.Add(calcFormula);
            innerList.Add(initValue);
            innerList.Add(tableRelation);
            innerList.Add(altSearchField);
            innerList.Add(onValidate);
            innerList.Add(onLookup);
            innerList.Add(validateTableRelation);
            innerList.Add(testTableRelation);
            innerList.Add(extendedDatatype);
            innerList.Add(width);
            innerList.Add(captionML);
            innerList.Add(notBlank);
            innerList.Add(numeric);
            innerList.Add(charAllowed);
            innerList.Add(dateFormula);
            innerList.Add(title);
            innerList.Add(valuesAllowed);
            innerList.Add(description);
            innerList.Add(editable);
            innerList.Add(autoFormatType);
            innerList.Add(autoFormatExpr);
            innerList.Add(captionClass);
        }

      public System.String AltSearchField
        {
            get
            {
                return this.altSearchField.Value;
            }
            set
            {
                this.altSearchField.Value = value;
            }
        }

      public System.String AutoFormatExpr
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

        public CalcFormula CalcFormula
        {
            get
            {
                return this.calcFormula.Value;
            }
        }

      public System.String CaptionClass
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

      public System.String CharAllowed
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

      public System.Boolean? DateFormula
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

      public System.String Description
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

      public System.Boolean? Editable
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

        public FieldClass? FieldClass
        {
            get
            {
                return this.fieldClass.Value;
            }
            set
            {
                this.fieldClass.Value = value;
            }
        }

      public System.String InitValue
        {
            get
            {
                return this.initValue.Value;
            }
            set
            {
                this.initValue.Value = value;
            }
        }

      public System.Boolean? NotBlank
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

      public System.Boolean? Numeric
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

        public TableRelationLines TableRelation
        {
            get
            {
                return this.tableRelation.Value;
            }
        }

      public System.Boolean? TestTableRelation
        {
            get
            {
                return this.testTableRelation.Value;
            }
            set
            {
                this.testTableRelation.Value = value;
            }
        }

      public System.Boolean? Title
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

      public System.Boolean? ValidateTableRelation
        {
            get
            {
                return this.validateTableRelation.Value;
            }
            set
            {
                this.validateTableRelation.Value = value;
            }
        }

      public System.String ValuesAllowed
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

      public System.Int32? Width
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

        public IEnumerator<Property> GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

    }

    [Serializable]
    public class TimeTableFieldProperties : IEnumerable<Property>
    {
        private List<Property> innerList = new List<Property>();

        private StringProperty altSearchField = new StringProperty("AltSearchField");
        private StringProperty autoFormatExpr = new StringProperty("AutoFormatExpr");
        private AutoFormatTypeProperty autoFormatType = new AutoFormatTypeProperty("AutoFormatType");
        private BlankNumbersProperty blankNumbers = new BlankNumbersProperty("BlankNumbers");
        private CalcFormulaProperty calcFormula = new CalcFormulaProperty("CalcFormula");
        private StringProperty captionClass = new StringProperty("CaptionClass");
        private MultiLanguageProperty captionML = new MultiLanguageProperty("CaptionML");
        private StringProperty description = new StringProperty("Description");
        private NullableBooleanProperty editable = new NullableBooleanProperty("Editable");
        private ExtendedDataTypeProperty extendedDatatype = new ExtendedDataTypeProperty("ExtendedDatatype");
        private FieldClassProperty fieldClass = new FieldClassProperty("FieldClass");
        private NullableTimeProperty initValue = new NullableTimeProperty("InitValue");
        private NullableTimeProperty maxValue = new NullableTimeProperty("MaxValue");
        private NullableTimeProperty minValue = new NullableTimeProperty("MinValue");
        private NullableBooleanProperty notBlank = new NullableBooleanProperty("NotBlank");
        private TriggerProperty onLookup = new TriggerProperty("OnLookup");
        private TriggerProperty onValidate = new TriggerProperty("OnValidate");
        private NullableIntegerProperty signDisplacement = new NullableIntegerProperty("SignDisplacement");
        private TableRelationLinesProperty tableRelation = new TableRelationLinesProperty("TableRelation");
        private NullableBooleanProperty testTableRelation = new NullableBooleanProperty("TestTableRelation");
        private NullableBooleanProperty validateTableRelation = new NullableBooleanProperty("ValidateTableRelation");
        private SemiColonSeparatedStringProperty valuesAllowed = new SemiColonSeparatedStringProperty("ValuesAllowed");

        internal TimeTableFieldProperties()
        {
            innerList.Add(fieldClass);
            innerList.Add(calcFormula);
            innerList.Add(initValue);
            innerList.Add(tableRelation);
            innerList.Add(altSearchField);
            innerList.Add(onValidate);
            innerList.Add(onLookup);
            innerList.Add(validateTableRelation);
            innerList.Add(testTableRelation);
            innerList.Add(extendedDatatype);
            innerList.Add(captionML);
            innerList.Add(minValue);
            innerList.Add(maxValue);
            innerList.Add(notBlank);
            innerList.Add(blankNumbers);
            innerList.Add(valuesAllowed);
            innerList.Add(signDisplacement);
            innerList.Add(description);
            innerList.Add(editable);
            innerList.Add(autoFormatType);
            innerList.Add(autoFormatExpr);
            innerList.Add(captionClass);
        }

      public System.String AltSearchField
        {
            get
            {
                return this.altSearchField.Value;
            }
            set
            {
                this.altSearchField.Value = value;
            }
        }

      public System.String AutoFormatExpr
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

        public CalcFormula CalcFormula
        {
            get
            {
                return this.calcFormula.Value;
            }
        }

      public System.String CaptionClass
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

      public System.String Description
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

      public System.Boolean? Editable
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

        public FieldClass? FieldClass
        {
            get
            {
                return this.fieldClass.Value;
            }
            set
            {
                this.fieldClass.Value = value;
            }
        }

      public System.TimeSpan? InitValue
        {
            get
            {
                return this.initValue.Value;
            }
            set
            {
                this.initValue.Value = value;
            }
        }

      public System.TimeSpan? MaxValue
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

      public System.TimeSpan? MinValue
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

      public System.Boolean? NotBlank
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

      public System.Int32? SignDisplacement
        {
            get
            {
                return this.signDisplacement.Value;
            }
            set
            {
                this.signDisplacement.Value = value;
            }
        }

        public TableRelationLines TableRelation
        {
            get
            {
                return this.tableRelation.Value;
            }
        }

      public System.Boolean? TestTableRelation
        {
            get
            {
                return this.testTableRelation.Value;
            }
            set
            {
                this.testTableRelation.Value = value;
            }
        }

      public System.Boolean? ValidateTableRelation
        {
            get
            {
                return this.validateTableRelation.Value;
            }
            set
            {
                this.validateTableRelation.Value = value;
            }
        }

      public System.String ValuesAllowed
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

        public IEnumerator<Property> GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

    }

    [Serializable]
    public class XmlPortFieldAttributeProperties : IEnumerable<Property>
    {
        private List<Property> innerList = new List<Property>();

        private NullableBooleanProperty autoCalcField = new NullableBooleanProperty("AutoCalcField");
        private TableFieldTypeProperty dataType = new TableFieldTypeProperty("DataType");
        private NullableBooleanProperty fieldValidate = new NullableBooleanProperty("FieldValidate");
        private OccurrenceProperty occurrence = new OccurrenceProperty("Occurrence");
        private ScopedTriggerProperty onAfterAssignField = new ScopedTriggerProperty("OnAfterAssignField");
        private ScopedTriggerProperty onBeforePassField = new ScopedTriggerProperty("OnBeforePassField");
        private SourceFieldProperty sourceField = new SourceFieldProperty("SourceField");
        private NullableIntegerProperty width = new NullableIntegerProperty("Width");

        internal XmlPortFieldAttributeProperties()
        {
            innerList.Add(dataType);
            innerList.Add(fieldValidate);
            innerList.Add(autoCalcField);
            innerList.Add(sourceField);
            innerList.Add(occurrence);
            innerList.Add(onAfterAssignField);
            innerList.Add(onBeforePassField);
            innerList.Add(width);
        }

      public System.Boolean? AutoCalcField
        {
            get
            {
                return this.autoCalcField.Value;
            }
            set
            {
                this.autoCalcField.Value = value;
            }
        }

        public TableFieldType? DataType
        {
            get
            {
                return this.dataType.Value;
            }
            set
            {
                this.dataType.Value = value;
            }
        }

      public System.Boolean? FieldValidate
        {
            get
            {
                return this.fieldValidate.Value;
            }
            set
            {
                this.fieldValidate.Value = value;
            }
        }

        public Occurrence? Occurrence
        {
            get
            {
                return this.occurrence.Value;
            }
            set
            {
                this.occurrence.Value = value;
            }
        }

        public Trigger OnAfterAssignField
        {
            get
            {
                return this.onAfterAssignField.Value;
            }
        }

        public Trigger OnBeforePassField
        {
            get
            {
                return this.onBeforePassField.Value;
            }
        }

        public SourceField SourceField
        {
            get
            {
                return this.sourceField.Value;
            }
        }

      public System.Int32? Width
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

        public IEnumerator<Property> GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

    }

    [Serializable]
    public class XmlPortFieldElementProperties : IEnumerable<Property>
    {
        private List<Property> innerList = new List<Property>();

        private NullableBooleanProperty autoCalcField = new NullableBooleanProperty("AutoCalcField");
        private TableFieldTypeProperty dataType = new TableFieldTypeProperty("DataType");
        private NullableBooleanProperty fieldValidate = new NullableBooleanProperty("FieldValidate");
        private MaxOccursProperty maxOccurs = new MaxOccursProperty("MaxOccurs");
        private MinOccursProperty minOccurs = new MinOccursProperty("MinOccurs");
        private ScopedTriggerProperty onAfterAssignField = new ScopedTriggerProperty("OnAfterAssignField");
        private ScopedTriggerProperty onBeforePassField = new ScopedTriggerProperty("OnBeforePassField");
        private SourceFieldProperty sourceField = new SourceFieldProperty("SourceField");
        private NullableIntegerProperty width = new NullableIntegerProperty("Width");

        internal XmlPortFieldElementProperties()
        {
            innerList.Add(dataType);
            innerList.Add(fieldValidate);
            innerList.Add(autoCalcField);
            innerList.Add(sourceField);
            innerList.Add(minOccurs);
            innerList.Add(maxOccurs);
            innerList.Add(onAfterAssignField);
            innerList.Add(onBeforePassField);
            innerList.Add(width);
        }

      public System.Boolean? AutoCalcField
        {
            get
            {
                return this.autoCalcField.Value;
            }
            set
            {
                this.autoCalcField.Value = value;
            }
        }

        public TableFieldType? DataType
        {
            get
            {
                return this.dataType.Value;
            }
            set
            {
                this.dataType.Value = value;
            }
        }

      public System.Boolean? FieldValidate
        {
            get
            {
                return this.fieldValidate.Value;
            }
            set
            {
                this.fieldValidate.Value = value;
            }
        }

        public MaxOccurs? MaxOccurs
        {
            get
            {
                return this.maxOccurs.Value;
            }
            set
            {
                this.maxOccurs.Value = value;
            }
        }

        public MinOccurs? MinOccurs
        {
            get
            {
                return this.minOccurs.Value;
            }
            set
            {
                this.minOccurs.Value = value;
            }
        }

        public Trigger OnAfterAssignField
        {
            get
            {
                return this.onAfterAssignField.Value;
            }
        }

        public Trigger OnBeforePassField
        {
            get
            {
                return this.onBeforePassField.Value;
            }
        }

        public SourceField SourceField
        {
            get
            {
                return this.sourceField.Value;
            }
        }

      public System.Int32? Width
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

        public IEnumerator<Property> GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

    }

    [Serializable]
    public class XmlPortProperties : IEnumerable<Property>
    {
        private List<Property> innerList = new List<Property>();

        private MultiLanguageProperty captionML = new MultiLanguageProperty("CaptionML");
        private NullableBooleanProperty defaultFieldsValidation = new NullableBooleanProperty("DefaultFieldsValidation");
        private StringProperty defaultNamespace = new StringProperty("DefaultNamespace");
        private DirectionProperty direction = new DirectionProperty("Direction");
        private XmlPortEncodingProperty encoding = new XmlPortEncodingProperty("Encoding");
        private StringProperty fieldDelimiter = new StringProperty("FieldDelimiter");
        private StringProperty fieldSeparator = new StringProperty("FieldSeparator");
        private StringProperty fileName = new StringProperty("FileName");
        private XmlPortFormatProperty format = new XmlPortFormatProperty("Format");
        private FormatEvaluateProperty formatEvaluate = new FormatEvaluateProperty("FormatEvaluate");
        private NullableBooleanProperty inlineSchema = new NullableBooleanProperty("InlineSchema");
        private TriggerProperty onInitXMLport = new TriggerProperty("OnInitXMLport");
        private TriggerProperty onPostXMLport = new TriggerProperty("OnPostXMLport");
        private TriggerProperty onPreXMLport = new TriggerProperty("OnPreXMLport");
        private PermissionsProperty permissions = new PermissionsProperty("Permissions");
        private NullableBooleanProperty preserveWhiteSpace = new NullableBooleanProperty("PreserveWhiteSpace");
        private StringProperty recordSeparator = new StringProperty("RecordSeparator");
        private StringProperty tableSeparator = new StringProperty("TableSeparator");
        private TextEncodingProperty textEncoding = new TextEncodingProperty("TextEncoding");
        private TransactionTypeProperty transactionType = new TransactionTypeProperty("TransactionType");
        private NullableBooleanProperty useDefaultNamespace = new NullableBooleanProperty("UseDefaultNamespace");
        private NullableBooleanProperty useLax = new NullableBooleanProperty("UseLax");
        private NullableBooleanProperty useRequestPage = new NullableBooleanProperty("UseRequestPage");
        private XmlVersionNoProperty xmlVersionNo = new XmlVersionNoProperty("XmlVersionNo");

        internal XmlPortProperties()
        {
            innerList.Add(permissions);
            innerList.Add(transactionType);
            innerList.Add(captionML);
            innerList.Add(direction);
            innerList.Add(encoding);
            innerList.Add(defaultFieldsValidation);
            innerList.Add(xmlVersionNo);
            innerList.Add(formatEvaluate);
            innerList.Add(preserveWhiteSpace);
            innerList.Add(defaultNamespace);
            innerList.Add(inlineSchema);
            innerList.Add(useDefaultNamespace);
            innerList.Add(onInitXMLport);
            innerList.Add(onPreXMLport);
            innerList.Add(onPostXMLport);
            innerList.Add(textEncoding);
            innerList.Add(format);
            innerList.Add(fieldDelimiter);
            innerList.Add(fieldSeparator);
            innerList.Add(recordSeparator);
            innerList.Add(tableSeparator);
            innerList.Add(useRequestPage);
            innerList.Add(useLax);
            innerList.Add(fileName);
        }

        public MultiLanguageValue CaptionML
        {
            get
            {
                return this.captionML.Value;
            }
        }

      public System.Boolean? DefaultFieldsValidation
        {
            get
            {
                return this.defaultFieldsValidation.Value;
            }
            set
            {
                this.defaultFieldsValidation.Value = value;
            }
        }

      public System.String DefaultNamespace
        {
            get
            {
                return this.defaultNamespace.Value;
            }
            set
            {
                this.defaultNamespace.Value = value;
            }
        }

        public Direction? Direction
        {
            get
            {
                return this.direction.Value;
            }
            set
            {
                this.direction.Value = value;
            }
        }

        public XmlPortEncoding? Encoding
        {
            get
            {
                return this.encoding.Value;
            }
            set
            {
                this.encoding.Value = value;
            }
        }

      public System.String FieldDelimiter
        {
            get
            {
                return this.fieldDelimiter.Value;
            }
            set
            {
                this.fieldDelimiter.Value = value;
            }
        }

      public System.String FieldSeparator
        {
            get
            {
                return this.fieldSeparator.Value;
            }
            set
            {
                this.fieldSeparator.Value = value;
            }
        }

      public System.String FileName
        {
            get
            {
                return this.fileName.Value;
            }
            set
            {
                this.fileName.Value = value;
            }
        }

        public XmlPortFormat? Format
        {
            get
            {
                return this.format.Value;
            }
            set
            {
                this.format.Value = value;
            }
        }

        public FormatEvaluate? FormatEvaluate
        {
            get
            {
                return this.formatEvaluate.Value;
            }
            set
            {
                this.formatEvaluate.Value = value;
            }
        }

      public System.Boolean? InlineSchema
        {
            get
            {
                return this.inlineSchema.Value;
            }
            set
            {
                this.inlineSchema.Value = value;
            }
        }

        public Trigger OnInitXMLport
        {
            get
            {
                return this.onInitXMLport.Value;
            }
        }

        public Trigger OnPostXMLport
        {
            get
            {
                return this.onPostXMLport.Value;
            }
        }

        public Trigger OnPreXMLport
        {
            get
            {
                return this.onPreXMLport.Value;
            }
        }

        public Permissions Permissions
        {
            get
            {
                return this.permissions.Value;
            }
        }

      public System.Boolean? PreserveWhiteSpace
        {
            get
            {
                return this.preserveWhiteSpace.Value;
            }
            set
            {
                this.preserveWhiteSpace.Value = value;
            }
        }

      public System.String RecordSeparator
        {
            get
            {
                return this.recordSeparator.Value;
            }
            set
            {
                this.recordSeparator.Value = value;
            }
        }

      public System.String TableSeparator
        {
            get
            {
                return this.tableSeparator.Value;
            }
            set
            {
                this.tableSeparator.Value = value;
            }
        }

        public TextEncoding? TextEncoding
        {
            get
            {
                return this.textEncoding.Value;
            }
            set
            {
                this.textEncoding.Value = value;
            }
        }

        public TransactionType? TransactionType
        {
            get
            {
                return this.transactionType.Value;
            }
            set
            {
                this.transactionType.Value = value;
            }
        }

      public System.Boolean? UseDefaultNamespace
        {
            get
            {
                return this.useDefaultNamespace.Value;
            }
            set
            {
                this.useDefaultNamespace.Value = value;
            }
        }

      public System.Boolean? UseLax
        {
            get
            {
                return this.useLax.Value;
            }
            set
            {
                this.useLax.Value = value;
            }
        }

      public System.Boolean? UseRequestPage
        {
            get
            {
                return this.useRequestPage.Value;
            }
            set
            {
                this.useRequestPage.Value = value;
            }
        }

        public XmlVersionNo? XmlVersionNo
        {
            get
            {
                return this.xmlVersionNo.Value;
            }
            set
            {
                this.xmlVersionNo.Value = value;
            }
        }

        public IEnumerator<Property> GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

    }

    [Serializable]
    public class XmlPortRequestPageProperties : IEnumerable<Property>
    {
        private List<Property> innerList = new List<Property>();

        private ActionListProperty actionList = new ActionListProperty("ActionList");
        private NullableBooleanProperty autoSplitKey = new NullableBooleanProperty("AutoSplitKey");
        private MultiLanguageProperty captionML = new MultiLanguageProperty("CaptionML");
        private StringProperty cardPageID = new StringProperty("CardPageID");
        private StringProperty dataCaptionExpr = new StringProperty("DataCaptionExpr");
        private FieldListProperty dataCaptionFields = new FieldListProperty("DataCaptionFields");
        private NullableBooleanProperty deleteAllowed = new NullableBooleanProperty("DeleteAllowed");
        private StringProperty description = new StringProperty("Description");
        private NullableBooleanProperty editable = new NullableBooleanProperty("Editable");
        private NullableBooleanProperty insertAllowed = new NullableBooleanProperty("InsertAllowed");
        private MultiLanguageProperty instructionalTextML = new MultiLanguageProperty("InstructionalTextML");
        private NullableBooleanProperty linksAllowed = new NullableBooleanProperty("LinksAllowed");
        private NullableBooleanProperty modifyAllowed = new NullableBooleanProperty("ModifyAllowed");
        private NullableBooleanProperty multipleNewLines = new NullableBooleanProperty("MultipleNewLines");
        private TriggerProperty onAfterGetCurrRecord = new TriggerProperty("OnAfterGetCurrRecord");
        private TriggerProperty onAfterGetRecord = new TriggerProperty("OnAfterGetRecord");
        private TriggerProperty onClosePage = new TriggerProperty("OnClosePage");
        private TriggerProperty onDeleteRecord = new TriggerProperty("OnDeleteRecord");
        private TriggerProperty onFindRecord = new TriggerProperty("OnFindRecord");
        private TriggerProperty onInit = new TriggerProperty("OnInit");
        private TriggerProperty onInsertRecord = new TriggerProperty("OnInsertRecord");
        private TriggerProperty onModifyRecord = new TriggerProperty("OnModifyRecord");
        private TriggerProperty onNewRecord = new TriggerProperty("OnNewRecord");
        private TriggerProperty onNextRecord = new TriggerProperty("OnNextRecord");
        private TriggerProperty onOpenPage = new TriggerProperty("OnOpenPage");
        private TriggerProperty onQueryClosePage = new TriggerProperty("OnQueryClosePage");
        private PermissionsProperty permissions = new PermissionsProperty("Permissions");
        private NullableBooleanProperty populateAllFields = new NullableBooleanProperty("PopulateAllFields");
        private NullableBooleanProperty saveValues = new NullableBooleanProperty("SaveValues");
        private NullableBooleanProperty showFilter = new NullableBooleanProperty("ShowFilter");
        private NullableIntegerProperty sourceTable = new NullableIntegerProperty("SourceTable");
        private NullableBooleanProperty sourceTableTemporary = new NullableBooleanProperty("SourceTableTemporary");
        private TableViewProperty sourceTableView = new TableViewProperty("SourceTableView");

        internal XmlPortRequestPageProperties()
        {
            innerList.Add(permissions);
            innerList.Add(editable);
            innerList.Add(captionML);
            innerList.Add(description);
            innerList.Add(saveValues);
            innerList.Add(multipleNewLines);
            innerList.Add(insertAllowed);
            innerList.Add(deleteAllowed);
            innerList.Add(modifyAllowed);
            innerList.Add(linksAllowed);
            innerList.Add(sourceTable);
            innerList.Add(dataCaptionExpr);
            innerList.Add(populateAllFields);
            innerList.Add(sourceTableView);
            innerList.Add(dataCaptionFields);
            innerList.Add(sourceTableTemporary);
            innerList.Add(cardPageID);
            innerList.Add(instructionalTextML);
            innerList.Add(autoSplitKey);
            innerList.Add(showFilter);
            innerList.Add(onInit);
            innerList.Add(onOpenPage);
            innerList.Add(onClosePage);
            innerList.Add(onFindRecord);
            innerList.Add(onNextRecord);
            innerList.Add(onAfterGetRecord);
            innerList.Add(onNewRecord);
            innerList.Add(onInsertRecord);
            innerList.Add(onModifyRecord);
            innerList.Add(onDeleteRecord);
            innerList.Add(onQueryClosePage);
            innerList.Add(onAfterGetCurrRecord);
            innerList.Add(actionList);
        }

        public ActionList ActionList
        {
            get
            {
                return this.actionList.Value;
            }
        }

      public System.Boolean? AutoSplitKey
        {
            get
            {
                return this.autoSplitKey.Value;
            }
            set
            {
                this.autoSplitKey.Value = value;
            }
        }

        public MultiLanguageValue CaptionML
        {
            get
            {
                return this.captionML.Value;
            }
        }

      public System.String CardPageID
        {
            get
            {
                return this.cardPageID.Value;
            }
            set
            {
                this.cardPageID.Value = value;
            }
        }

      public System.String DataCaptionExpr
        {
            get
            {
                return this.dataCaptionExpr.Value;
            }
            set
            {
                this.dataCaptionExpr.Value = value;
            }
        }

        public FieldList DataCaptionFields
        {
            get
            {
                return this.dataCaptionFields.Value;
            }
        }

      public System.Boolean? DeleteAllowed
        {
            get
            {
                return this.deleteAllowed.Value;
            }
            set
            {
                this.deleteAllowed.Value = value;
            }
        }

      public System.String Description
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

      public System.Boolean? Editable
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

      public System.Boolean? InsertAllowed
        {
            get
            {
                return this.insertAllowed.Value;
            }
            set
            {
                this.insertAllowed.Value = value;
            }
        }

        public MultiLanguageValue InstructionalTextML
        {
            get
            {
                return this.instructionalTextML.Value;
            }
        }

      public System.Boolean? LinksAllowed
        {
            get
            {
                return this.linksAllowed.Value;
            }
            set
            {
                this.linksAllowed.Value = value;
            }
        }

      public System.Boolean? ModifyAllowed
        {
            get
            {
                return this.modifyAllowed.Value;
            }
            set
            {
                this.modifyAllowed.Value = value;
            }
        }

      public System.Boolean? MultipleNewLines
        {
            get
            {
                return this.multipleNewLines.Value;
            }
            set
            {
                this.multipleNewLines.Value = value;
            }
        }

        public Trigger OnAfterGetCurrRecord
        {
            get
            {
                return this.onAfterGetCurrRecord.Value;
            }
        }

        public Trigger OnAfterGetRecord
        {
            get
            {
                return this.onAfterGetRecord.Value;
            }
        }

        public Trigger OnClosePage
        {
            get
            {
                return this.onClosePage.Value;
            }
        }

        public Trigger OnDeleteRecord
        {
            get
            {
                return this.onDeleteRecord.Value;
            }
        }

        public Trigger OnFindRecord
        {
            get
            {
                return this.onFindRecord.Value;
            }
        }

        public Trigger OnInit
        {
            get
            {
                return this.onInit.Value;
            }
        }

        public Trigger OnInsertRecord
        {
            get
            {
                return this.onInsertRecord.Value;
            }
        }

        public Trigger OnModifyRecord
        {
            get
            {
                return this.onModifyRecord.Value;
            }
        }

        public Trigger OnNewRecord
        {
            get
            {
                return this.onNewRecord.Value;
            }
        }

        public Trigger OnNextRecord
        {
            get
            {
                return this.onNextRecord.Value;
            }
        }

        public Trigger OnOpenPage
        {
            get
            {
                return this.onOpenPage.Value;
            }
        }

        public Trigger OnQueryClosePage
        {
            get
            {
                return this.onQueryClosePage.Value;
            }
        }

        public Permissions Permissions
        {
            get
            {
                return this.permissions.Value;
            }
        }

      public System.Boolean? PopulateAllFields
        {
            get
            {
                return this.populateAllFields.Value;
            }
            set
            {
                this.populateAllFields.Value = value;
            }
        }

      public System.Boolean? SaveValues
        {
            get
            {
                return this.saveValues.Value;
            }
            set
            {
                this.saveValues.Value = value;
            }
        }

      public System.Boolean? ShowFilter
        {
            get
            {
                return this.showFilter.Value;
            }
            set
            {
                this.showFilter.Value = value;
            }
        }

      public System.Int32? SourceTable
        {
            get
            {
                return this.sourceTable.Value;
            }
            set
            {
                this.sourceTable.Value = value;
            }
        }

      public System.Boolean? SourceTableTemporary
        {
            get
            {
                return this.sourceTableTemporary.Value;
            }
            set
            {
                this.sourceTableTemporary.Value = value;
            }
        }

        public TableView SourceTableView
        {
            get
            {
                return this.sourceTableView.Value;
            }
        }

        public IEnumerator<Property> GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

    }

    [Serializable]
    public class XmlPortTableAttributeProperties : IEnumerable<Property>
    {
        private List<Property> innerList = new List<Property>();

        private NullableBooleanProperty autoReplace = new NullableBooleanProperty("AutoReplace");
        private NullableBooleanProperty autoSave = new NullableBooleanProperty("AutoSave");
        private NullableBooleanProperty autoUpdate = new NullableBooleanProperty("AutoUpdate");
        private FieldListProperty calcFields = new FieldListProperty("CalcFields");
        private LinkFieldsProperty linkFields = new LinkFieldsProperty("LinkFields");
        private StringProperty linkTable = new StringProperty("LinkTable");
        private NullableBooleanProperty linkTableForceInsert = new NullableBooleanProperty("LinkTableForceInsert");
        private OccurrenceProperty occurrence = new OccurrenceProperty("Occurrence");
        private ScopedTriggerProperty onAfterGetRecord = new ScopedTriggerProperty("OnAfterGetRecord");
        private TriggerProperty onAfterInitRecord = new TriggerProperty("OnAfterInitRecord");
        private TriggerProperty onAfterInsertRecord = new TriggerProperty("OnAfterInsertRecord");
        private TriggerProperty onAfterModifyRecord = new TriggerProperty("OnAfterModifyRecord");
        private TriggerProperty onBeforeInsertRecord = new TriggerProperty("OnBeforeInsertRecord");
        private TriggerProperty onBeforeModifyRecord = new TriggerProperty("OnBeforeModifyRecord");
        private TriggerProperty onPreXmlItem = new TriggerProperty("OnPreXmlItem");
        private FieldListProperty reqFilterFields = new FieldListProperty("ReqFilterFields");
        private MultiLanguageProperty reqFilterHeadingML = new MultiLanguageProperty("ReqFilterHeadingML");
        private NullableIntegerProperty sourceTable = new NullableIntegerProperty("SourceTable");
        private TableViewProperty sourceTableView = new TableViewProperty("SourceTableView");
        private NullableBooleanProperty temporary = new NullableBooleanProperty("Temporary");
        private StringProperty variableName = new StringProperty("VariableName");
        private NullableIntegerProperty width = new NullableIntegerProperty("Width");

        internal XmlPortTableAttributeProperties()
        {
            innerList.Add(autoReplace);
            innerList.Add(autoSave);
            innerList.Add(autoUpdate);
            innerList.Add(calcFields);
            innerList.Add(linkFields);
            innerList.Add(linkTable);
            innerList.Add(linkTableForceInsert);
            innerList.Add(occurrence);
            innerList.Add(onAfterGetRecord);
            innerList.Add(onAfterInitRecord);
            innerList.Add(onAfterInsertRecord);
            innerList.Add(onAfterModifyRecord);
            innerList.Add(onBeforeInsertRecord);
            innerList.Add(onBeforeModifyRecord);
            innerList.Add(onPreXmlItem);
            innerList.Add(reqFilterFields);
            innerList.Add(reqFilterHeadingML);
            innerList.Add(sourceTable);
            innerList.Add(sourceTableView);
            innerList.Add(temporary);
            innerList.Add(variableName);
            innerList.Add(width);
        }

      public System.Boolean? AutoReplace
        {
            get
            {
                return this.autoReplace.Value;
            }
            set
            {
                this.autoReplace.Value = value;
            }
        }

      public System.Boolean? AutoSave
        {
            get
            {
                return this.autoSave.Value;
            }
            set
            {
                this.autoSave.Value = value;
            }
        }

      public System.Boolean? AutoUpdate
        {
            get
            {
                return this.autoUpdate.Value;
            }
            set
            {
                this.autoUpdate.Value = value;
            }
        }

        public FieldList CalcFields
        {
            get
            {
                return this.calcFields.Value;
            }
        }

        public LinkFields LinkFields
        {
            get
            {
                return this.linkFields.Value;
            }
        }

      public System.String LinkTable
        {
            get
            {
                return this.linkTable.Value;
            }
            set
            {
                this.linkTable.Value = value;
            }
        }

      public System.Boolean? LinkTableForceInsert
        {
            get
            {
                return this.linkTableForceInsert.Value;
            }
            set
            {
                this.linkTableForceInsert.Value = value;
            }
        }

        public Occurrence? Occurrence
        {
            get
            {
                return this.occurrence.Value;
            }
            set
            {
                this.occurrence.Value = value;
            }
        }

        public Trigger OnAfterGetRecord
        {
            get
            {
                return this.onAfterGetRecord.Value;
            }
        }

        public Trigger OnAfterInitRecord
        {
            get
            {
                return this.onAfterInitRecord.Value;
            }
        }

        public Trigger OnAfterInsertRecord
        {
            get
            {
                return this.onAfterInsertRecord.Value;
            }
        }

        public Trigger OnAfterModifyRecord
        {
            get
            {
                return this.onAfterModifyRecord.Value;
            }
        }

        public Trigger OnBeforeInsertRecord
        {
            get
            {
                return this.onBeforeInsertRecord.Value;
            }
        }

        public Trigger OnBeforeModifyRecord
        {
            get
            {
                return this.onBeforeModifyRecord.Value;
            }
        }

        public Trigger OnPreXmlItem
        {
            get
            {
                return this.onPreXmlItem.Value;
            }
        }

        public FieldList ReqFilterFields
        {
            get
            {
                return this.reqFilterFields.Value;
            }
        }

        public MultiLanguageValue ReqFilterHeadingML
        {
            get
            {
                return this.reqFilterHeadingML.Value;
            }
        }

      public System.Int32? SourceTable
        {
            get
            {
                return this.sourceTable.Value;
            }
            set
            {
                this.sourceTable.Value = value;
            }
        }

        public TableView SourceTableView
        {
            get
            {
                return this.sourceTableView.Value;
            }
        }

      public System.Boolean? Temporary
        {
            get
            {
                return this.temporary.Value;
            }
            set
            {
                this.temporary.Value = value;
            }
        }

      public System.String VariableName
        {
            get
            {
                return this.variableName.Value;
            }
            set
            {
                this.variableName.Value = value;
            }
        }

      public System.Int32? Width
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

        public IEnumerator<Property> GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

    }

    [Serializable]
    public class XmlPortTableElementProperties : IEnumerable<Property>
    {
        private List<Property> innerList = new List<Property>();

        private NullableBooleanProperty autoReplace = new NullableBooleanProperty("AutoReplace");
        private NullableBooleanProperty autoSave = new NullableBooleanProperty("AutoSave");
        private NullableBooleanProperty autoUpdate = new NullableBooleanProperty("AutoUpdate");
        private FieldListProperty calcFields = new FieldListProperty("CalcFields");
        private LinkFieldsProperty linkFields = new LinkFieldsProperty("LinkFields");
        private StringProperty linkTable = new StringProperty("LinkTable");
        private NullableBooleanProperty linkTableForceInsert = new NullableBooleanProperty("LinkTableForceInsert");
        private MaxOccursProperty maxOccurs = new MaxOccursProperty("MaxOccurs");
        private MinOccursProperty minOccurs = new MinOccursProperty("MinOccurs");
        private ScopedTriggerProperty onAfterGetRecord = new ScopedTriggerProperty("OnAfterGetRecord");
        private ScopedTriggerProperty onAfterInitRecord = new ScopedTriggerProperty("OnAfterInitRecord");
        private ScopedTriggerProperty onAfterInsertRecord = new ScopedTriggerProperty("OnAfterInsertRecord");
        private ScopedTriggerProperty onAfterModifyRecord = new ScopedTriggerProperty("OnAfterModifyRecord");
        private ScopedTriggerProperty onBeforeInsertRecord = new ScopedTriggerProperty("OnBeforeInsertRecord");
        private ScopedTriggerProperty onBeforeModifyRecord = new ScopedTriggerProperty("OnBeforeModifyRecord");
        private ScopedTriggerProperty onPreXMLItem = new ScopedTriggerProperty("OnPreXMLItem");
        private FieldListProperty reqFilterFields = new FieldListProperty("ReqFilterFields");
        private MultiLanguageProperty reqFilterHeadingML = new MultiLanguageProperty("ReqFilterHeadingML");
        private TableReferenceProperty sourceTable = new TableReferenceProperty("SourceTable");
        private TableViewProperty sourceTableView = new TableViewProperty("SourceTableView");
        private NullableBooleanProperty temporary = new NullableBooleanProperty("Temporary");
        private StringProperty variableName = new StringProperty("VariableName");
        private NullableIntegerProperty width = new NullableIntegerProperty("Width");

        internal XmlPortTableElementProperties()
        {
            innerList.Add(reqFilterFields);
            innerList.Add(reqFilterHeadingML);
            innerList.Add(variableName);
            innerList.Add(sourceTable);
            innerList.Add(sourceTableView);
            innerList.Add(calcFields);
            innerList.Add(linkFields);
            innerList.Add(linkTable);
            innerList.Add(temporary);
            innerList.Add(linkTableForceInsert);
            innerList.Add(autoSave);
            innerList.Add(autoUpdate);
            innerList.Add(autoReplace);
            innerList.Add(minOccurs);
            innerList.Add(maxOccurs);
            innerList.Add(onAfterInitRecord);
            innerList.Add(onBeforeInsertRecord);
            innerList.Add(onPreXMLItem);
            innerList.Add(onAfterGetRecord);
            innerList.Add(onAfterInsertRecord);
            innerList.Add(onBeforeModifyRecord);
            innerList.Add(onAfterModifyRecord);
            innerList.Add(width);
        }

      public System.Boolean? AutoReplace
        {
            get
            {
                return this.autoReplace.Value;
            }
            set
            {
                this.autoReplace.Value = value;
            }
        }

      public System.Boolean? AutoSave
        {
            get
            {
                return this.autoSave.Value;
            }
            set
            {
                this.autoSave.Value = value;
            }
        }

      public System.Boolean? AutoUpdate
        {
            get
            {
                return this.autoUpdate.Value;
            }
            set
            {
                this.autoUpdate.Value = value;
            }
        }

        public FieldList CalcFields
        {
            get
            {
                return this.calcFields.Value;
            }
        }

        public LinkFields LinkFields
        {
            get
            {
                return this.linkFields.Value;
            }
        }

      public System.String LinkTable
        {
            get
            {
                return this.linkTable.Value;
            }
            set
            {
                this.linkTable.Value = value;
            }
        }

      public System.Boolean? LinkTableForceInsert
        {
            get
            {
                return this.linkTableForceInsert.Value;
            }
            set
            {
                this.linkTableForceInsert.Value = value;
            }
        }

        public MaxOccurs? MaxOccurs
        {
            get
            {
                return this.maxOccurs.Value;
            }
            set
            {
                this.maxOccurs.Value = value;
            }
        }

        public MinOccurs? MinOccurs
        {
            get
            {
                return this.minOccurs.Value;
            }
            set
            {
                this.minOccurs.Value = value;
            }
        }

        public Trigger OnAfterGetRecord
        {
            get
            {
                return this.onAfterGetRecord.Value;
            }
        }

        public Trigger OnAfterInitRecord
        {
            get
            {
                return this.onAfterInitRecord.Value;
            }
        }

        public Trigger OnAfterInsertRecord
        {
            get
            {
                return this.onAfterInsertRecord.Value;
            }
        }

        public Trigger OnAfterModifyRecord
        {
            get
            {
                return this.onAfterModifyRecord.Value;
            }
        }

        public Trigger OnBeforeInsertRecord
        {
            get
            {
                return this.onBeforeInsertRecord.Value;
            }
        }

        public Trigger OnBeforeModifyRecord
        {
            get
            {
                return this.onBeforeModifyRecord.Value;
            }
        }

        public Trigger OnPreXMLItem
        {
            get
            {
                return this.onPreXMLItem.Value;
            }
        }

        public FieldList ReqFilterFields
        {
            get
            {
                return this.reqFilterFields.Value;
            }
        }

        public MultiLanguageValue ReqFilterHeadingML
        {
            get
            {
                return this.reqFilterHeadingML.Value;
            }
        }

      public System.Int32? SourceTable
        {
            get
            {
                return this.sourceTable.Value;
            }
            set
            {
                this.sourceTable.Value = value;
            }
        }

        public TableView SourceTableView
        {
            get
            {
                return this.sourceTableView.Value;
            }
        }

      public System.Boolean? Temporary
        {
            get
            {
                return this.temporary.Value;
            }
            set
            {
                this.temporary.Value = value;
            }
        }

      public System.String VariableName
        {
            get
            {
                return this.variableName.Value;
            }
            set
            {
                this.variableName.Value = value;
            }
        }

      public System.Int32? Width
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

        public IEnumerator<Property> GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

    }

    [Serializable]
    public class XmlPortTextAttributeProperties : IEnumerable<Property>
    {
        private List<Property> innerList = new List<Property>();

        private OccurrenceProperty occurrence = new OccurrenceProperty("Occurrence");
        private ScopedTriggerProperty onAfterAssignVariable = new ScopedTriggerProperty("OnAfterAssignVariable");
        private ScopedTriggerProperty onBeforePassVariable = new ScopedTriggerProperty("OnBeforePassVariable");
        private TextTypeProperty textType = new TextTypeProperty("TextType");
        private StringProperty variableName = new StringProperty("VariableName");
        private NullableIntegerProperty width = new NullableIntegerProperty("Width");

        internal XmlPortTextAttributeProperties()
        {
            innerList.Add(variableName);
            innerList.Add(textType);
            innerList.Add(occurrence);
            innerList.Add(onAfterAssignVariable);
            innerList.Add(onBeforePassVariable);
            innerList.Add(width);
        }

        public Occurrence? Occurrence
        {
            get
            {
                return this.occurrence.Value;
            }
            set
            {
                this.occurrence.Value = value;
            }
        }

        public Trigger OnAfterAssignVariable
        {
            get
            {
                return this.onAfterAssignVariable.Value;
            }
        }

        public Trigger OnBeforePassVariable
        {
            get
            {
                return this.onBeforePassVariable.Value;
            }
        }

        public TextType? TextType
        {
            get
            {
                return this.textType.Value;
            }
            set
            {
                this.textType.Value = value;
            }
        }

      public System.String VariableName
        {
            get
            {
                return this.variableName.Value;
            }
            set
            {
                this.variableName.Value = value;
            }
        }

      public System.Int32? Width
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

        public IEnumerator<Property> GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

    }

    [Serializable]
    public class XmlPortTextElementProperties : IEnumerable<Property>
    {
        private List<Property> innerList = new List<Property>();

        private MaxOccursProperty maxOccurs = new MaxOccursProperty("MaxOccurs");
        private MinOccursProperty minOccurs = new MinOccursProperty("MinOccurs");
        private ScopedTriggerProperty onAfterAssignVariable = new ScopedTriggerProperty("OnAfterAssignVariable");
        private ScopedTriggerProperty onBeforePassVariable = new ScopedTriggerProperty("OnBeforePassVariable");
        private TextTypeProperty textType = new TextTypeProperty("TextType");
        private StringProperty variableName = new StringProperty("VariableName");
        private NullableIntegerProperty width = new NullableIntegerProperty("Width");

        internal XmlPortTextElementProperties()
        {
            innerList.Add(variableName);
            innerList.Add(textType);
            innerList.Add(minOccurs);
            innerList.Add(maxOccurs);
            innerList.Add(onAfterAssignVariable);
            innerList.Add(onBeforePassVariable);
            innerList.Add(width);
        }

        public MaxOccurs? MaxOccurs
        {
            get
            {
                return this.maxOccurs.Value;
            }
            set
            {
                this.maxOccurs.Value = value;
            }
        }

        public MinOccurs? MinOccurs
        {
            get
            {
                return this.minOccurs.Value;
            }
            set
            {
                this.minOccurs.Value = value;
            }
        }

        public Trigger OnAfterAssignVariable
        {
            get
            {
                return this.onAfterAssignVariable.Value;
            }
        }

        public Trigger OnBeforePassVariable
        {
            get
            {
                return this.onBeforePassVariable.Value;
            }
        }

        public TextType? TextType
        {
            get
            {
                return this.textType.Value;
            }
            set
            {
                this.textType.Value = value;
            }
        }

      public System.String VariableName
        {
            get
            {
                return this.variableName.Value;
            }
            set
            {
                this.variableName.Value = value;
            }
        }

      public System.Int32? Width
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

        public IEnumerator<Property> GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

    }

    #endregion
    #region Items
    [Serializable]
    public partial class Application
    {
        private Tables tables = new Tables();
        private Pages pages = new Pages();
        private Reports reports = new Reports();
        private XmlPorts xmlPorts = new XmlPorts();
        private Codeunits codeunits = new Codeunits();
        private Queries queries = new Queries();
        private MenuSuites menuSuites = new MenuSuites();

        public Tables Tables
        {
            get
            {
                return this.tables;
            }
        }

        public Pages Pages
        {
            get
            {
                return this.pages;
            }
        }

        public Reports Reports
        {
            get
            {
                return this.reports;
            }
        }

        public XmlPorts XmlPorts
        {
            get
            {
                return this.xmlPorts;
            }
        }

        public Codeunits Codeunits
        {
            get
            {
                return this.codeunits;
            }
        }

        public Queries Queries
        {
            get
            {
                return this.queries;
            }
        }

        public MenuSuites MenuSuites
        {
            get
            {
                return this.menuSuites;
            }
        }

    }

    [Serializable]
    public partial class CalcFormula
    {
        private String fieldName;
        private CalcFormulaMethod? method;
        private Boolean reverseSign;
        private CalcFormulaTableFilter tableFilter = new CalcFormulaTableFilter();
        private String tableName;

        internal CalcFormula()
        {
        }

        public String FieldName
        {
            get
            {
                return this.fieldName;
            }
            set
            {
                this.fieldName = value;
            }
        }

        public CalcFormulaMethod? Method
        {
            get
            {
                return this.method;
            }
            set
            {
                this.method = value;
            }
        }

        public Boolean ReverseSign
        {
            get
            {
                return this.reverseSign;
            }
            set
            {
                this.reverseSign = value;
            }
        }

        public CalcFormulaTableFilter TableFilter
        {
            get
            {
                return this.tableFilter;
            }
        }

        public String TableName
        {
            get
            {
                return this.tableName;
            }
            set
            {
                this.tableName = value;
            }
        }

    }

    [Serializable]
    public partial class CalcFormulaTableFilterLine
    {
        private String fieldName;
        private Boolean onlyMaxLimit;
        private CalcFormulaTableFilterType? type;
        private String value;
        private Boolean valueIsFilter;

        internal CalcFormulaTableFilterLine(String fieldName, CalcFormulaTableFilterType type, String value)
        {
            this.fieldName = fieldName;
            this.type = type;
            this.value = value;
        }

        public String FieldName
        {
            get
            {
                return this.fieldName;
            }
        }

        public Boolean OnlyMaxLimit
        {
            get
            {
                return this.onlyMaxLimit;
            }
            set
            {
                this.onlyMaxLimit = value;
            }
        }

        public CalcFormulaTableFilterType? Type
        {
            get
            {
                return this.type;
            }
        }

        public String Value
        {
            get
            {
                return this.value;
            }
        }

        public Boolean ValueIsFilter
        {
            get
            {
                return this.valueIsFilter;
            }
            set
            {
                this.valueIsFilter = value;
            }
        }

    }

    [Serializable]
    public partial class Code
    {
        private Documentation documentation = new Documentation();
        private Events events = new Events();
        private Functions functions = new Functions();
        private Variables variables = new Variables();

        internal Code()
        {
        }

        public Documentation Documentation
        {
            get
            {
                return this.documentation;
            }
        }

        public Events Events
        {
            get
            {
                return this.events;
            }
        }

        public Functions Functions
        {
            get
            {
                return this.functions;
            }
        }

        public Variables Variables
        {
            get
            {
                return this.variables;
            }
        }

    }

    [Serializable]
    public partial class CodeLine
    {
        private String text;

        internal CodeLine(String text)
        {
            this.text = text;
        }

        public String Text
        {
            get
            {
                return this.text;
            }
        }

    }

    [Serializable]
    public partial class ColumnFilterLine
    {
        private String column;
        private ColumnFilterLineType? type;
        private String value;

        internal ColumnFilterLine(String column, ColumnFilterLineType type, String value)
        {
            this.column = column;
            this.type = type;
            this.value = value;
        }

        public String Column
        {
            get
            {
                return this.column;
            }
        }

        public ColumnFilterLineType? Type
        {
            get
            {
                return this.type;
            }
        }

        public String Value
        {
            get
            {
                return this.value;
            }
        }

    }

    [Serializable]
    public partial class ControlReference
    {
        private String controlName;

        internal ControlReference(String controlName)
        {
            this.controlName = controlName;
        }

        public String ControlName
        {
            get
            {
                return this.controlName;
            }
        }

    }

    [Serializable]
    public partial class DataItemQueryElementTableFilterLine
    {
        private String fieldName;
        private DataItemQueryElementTableFilterLineType? type;
        private String value;

        internal DataItemQueryElementTableFilterLine(String fieldName, DataItemQueryElementTableFilterLineType type, String value)
        {
            this.fieldName = fieldName;
            this.type = type;
            this.value = value;
        }

        public String FieldName
        {
            get
            {
                return this.fieldName;
            }
        }

        public DataItemQueryElementTableFilterLineType? Type
        {
            get
            {
                return this.type;
            }
        }

        public String Value
        {
            get
            {
                return this.value;
            }
        }

    }

    [Serializable]
    public partial class DecimalPlaces
    {
        private Int32? atLeast;
        private Int32? atMost;

        internal DecimalPlaces()
        {
        }

        public Int32? AtLeast
        {
            get
            {
                return this.atLeast;
            }
            set
            {
                this.atLeast = value;
            }
        }

        public Int32? AtMost
        {
            get
            {
                return this.atMost;
            }
            set
            {
                this.atMost = value;
            }
        }

    }

    [Serializable]
    public partial class Documentation
    {
        private CodeLines lines = new CodeLines();

        internal Documentation()
        {
        }

        public CodeLines Lines
        {
            get
            {
                return this.lines;
            }
        }

    }

    [Serializable]
    public partial class Event
    {
        private Int32 sourceID;
        private String sourceName;
        private Int32 id;
        private String name;
        private CodeLines codeLines = new CodeLines();
        private Parameters parameters = new Parameters();
        private Variables variables = new Variables();

        internal Event(Int32 sourceID, String sourceName, Int32 id, String name)
        {
            this.id = id;
            this.name = name;
            this.sourceID = sourceID;
            this.sourceName = sourceName;
        }

        public Int32 SourceID
        {
            get
            {
                return this.sourceID;
            }
        }

        public String SourceName
        {
            get
            {
                return this.sourceName;
            }
        }

        public Int32 ID
        {
            get
            {
                return this.id;
            }
        }

        public String Name
        {
            get
            {
                return this.name;
            }
        }

        public CodeLines CodeLines
        {
            get
            {
                return this.codeLines;
            }
        }

        public Parameters Parameters
        {
            get
            {
                return this.parameters;
            }
        }

        public Variables Variables
        {
            get
            {
                return this.variables;
            }
        }

    }

    [Serializable]
    public partial class FieldReference
    {
        private String fieldName;

        internal FieldReference(String fieldName)
        {
            this.fieldName = fieldName;
        }

        public String FieldName
        {
            get
            {
                return this.fieldName;
            }
        }

    }

    [Serializable]
    public partial class Function
    {
        private Int32 id;
        private String name;
        private CodeLines codeLines = new CodeLines();
        private Parameters parameters = new Parameters();
        private FunctionProperties properties = new FunctionProperties();
        private FunctionReturnValue returnValue = new FunctionReturnValue();
        private Variables variables = new Variables();

        internal Function(Int32 id, String name)
        {
            this.id = id;
            this.name = name;
        }

        public Int32 ID
        {
            get
            {
                return this.id;
            }
        }

        public String Name
        {
            get
            {
                return this.name;
            }
        }

        public CodeLines CodeLines
        {
            get
            {
                return this.codeLines;
            }
        }

        public Parameters Parameters
        {
            get
            {
                return this.parameters;
            }
        }

        public FunctionProperties Properties
        {
            get
            {
                return this.properties;
            }
        }

        public FunctionReturnValue ReturnValue
        {
            get
            {
                return this.returnValue;
            }
        }

        public Variables Variables
        {
            get
            {
                return this.variables;
            }
        }

    }

    [Serializable]
    public partial class FunctionReturnValue
    {
        private String dimensions;
        private String name;
        private FunctionReturnValueType? type;
        private Int32? dataLength;

        internal FunctionReturnValue()
        {
        }

        public String Dimensions
        {
            get
            {
                return this.dimensions;
            }
            set
            {
                this.dimensions = value;
            }
        }

        public String Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }

        public FunctionReturnValueType? Type
        {
            get
            {
                return this.type;
            }
            set
            {
                this.type = value;
            }
        }

        public Int32? DataLength
        {
            get
            {
                return this.dataLength;
            }
            set
            {
                this.dataLength = value;
            }
        }

    }

    [Serializable]
    public partial class LinkField
    {
        private Int32 field;
        private Int32 referenceField;

        internal LinkField(Int32 field, Int32 referenceField)
        {
            this.field = field;
            this.referenceField = referenceField;
        }

        public Int32 Field
        {
            get
            {
                return this.field;
            }
        }

        public Int32 ReferenceField
        {
            get
            {
                return this.referenceField;
            }
        }

    }

    [Serializable]
    public abstract partial class MenuSuiteNode
    {
        private Guid id;

        internal MenuSuiteNode(Guid id)
        {
            this.id = id;
        }

        public Guid ID
        {
            get
            {
                return this.id;
            }
        }

    }

    [Serializable]
    public partial class MultiLanguageEntry
    {
        private String languageID;
        private String value;

        internal MultiLanguageEntry(String languageID, String value)
        {
            this.languageID = languageID;
            this.value = value;
        }

        public String LanguageID
        {
            get
            {
                return this.languageID;
            }
        }

        public String Value
        {
            get
            {
                return this.value;
            }
        }

    }

    [Serializable]
    public abstract partial class Object
    {
        private Int32 id;
        private String name;
        private ObjectProperties objectProperties = new ObjectProperties();

        internal Object(Int32 id, String name)
        {
            this.id = id;
            this.name = name;
        }

        public Int32 ID
        {
            get
            {
                return this.id;
            }
            set
            {
                this.id = value;
            }
        }

        public String Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }

        public ObjectProperties ObjectProperties
        {
            get
            {
                return this.objectProperties;
            }
        }

    }

    [Serializable]
    public partial class ObjectReference
    {
        private Int32 id;
        private RunObjectType? type;

        internal ObjectReference()
        {
        }

        public Int32 ID
        {
            get
            {
                return this.id;
            }
            set
            {
                this.id = value;
            }
        }

        public RunObjectType? Type
        {
            get
            {
                return this.type;
            }
            set
            {
                this.type = value;
            }
        }

    }

    [Serializable]
    public abstract partial class PageActionBase
    {
        private Int32 id;
        private Int32? indentationLevel;

        internal PageActionBase(Int32 id, Int32? indentationLevel)
        {
            this.id = id;
            this.indentationLevel = indentationLevel;
        }

        public Int32 ID
        {
            get
            {
                return this.id;
            }
        }

        public Int32? IndentationLevel
        {
            get
            {
                return this.indentationLevel;
            }
        }

    }

    [Serializable]
    public abstract partial class PageControl
    {
        private Int32 id;
        private Int32? indentationLevel;

        internal PageControl(Int32 id, Int32? indentationLevel)
        {
            this.id = id;
            this.indentationLevel = indentationLevel;
        }

        public Int32 ID
        {
            get
            {
                return this.id;
            }
        }

        public Int32? IndentationLevel
        {
            get
            {
                return this.indentationLevel;
            }
        }

    }

    [Serializable]
    public abstract partial class Parameter
    {
        private Boolean var;
        private Int32 id;
        private String name;

        internal Parameter(Boolean var, Int32 id, String name)
        {
            this.id = id;
            this.name = name;
            this.var = var;
        }

        public Boolean Var
        {
            get
            {
                return this.var;
            }
        }

        public Int32 ID
        {
            get
            {
                return this.id;
            }
        }

        public String Name
        {
            get
            {
                return this.name;
            }
        }

    }

    [Serializable]
    public partial class Permission
    {
        private Int32 tableID;
        private Boolean readPermission;
        private Boolean insertPermission;
        private Boolean modifyPermission;
        private Boolean deletePermission;

        internal Permission(Int32 tableID, Boolean readPermission, Boolean insertPermission, Boolean modifyPermission, Boolean deletePermission)
        {
            this.deletePermission = deletePermission;
            this.insertPermission = insertPermission;
            this.modifyPermission = modifyPermission;
            this.readPermission = readPermission;
            this.tableID = tableID;
        }

        public Int32 TableID
        {
            get
            {
                return this.tableID;
            }
        }

        public Boolean ReadPermission
        {
            get
            {
                return this.readPermission;
            }
        }

        public Boolean InsertPermission
        {
            get
            {
                return this.insertPermission;
            }
        }

        public Boolean ModifyPermission
        {
            get
            {
                return this.modifyPermission;
            }
        }

        public Boolean DeletePermission
        {
            get
            {
                return this.deletePermission;
            }
        }

    }

    [Serializable]
    public partial class QueryDataItemLinkLine
    {
        private String field;
        private String referenceTable;
        private String referenceField;

        internal QueryDataItemLinkLine(String field, String referenceTable, String referenceField)
        {
            this.field = field;
            this.referenceField = referenceField;
            this.referenceTable = referenceTable;
        }

        public String Field
        {
            get
            {
                return this.field;
            }
        }

        public String ReferenceTable
        {
            get
            {
                return this.referenceTable;
            }
        }

        public String ReferenceField
        {
            get
            {
                return this.referenceField;
            }
        }

    }

    [Serializable]
    public abstract partial class QueryElement
    {
        private Int32 id;
        private String name;
        private Int32? indentationLevel;

        internal QueryElement(Int32 id, String name, Int32? indentationLevel)
        {
            this.id = id;
            this.indentationLevel = indentationLevel;
            this.name = name;
        }

        public Int32 ID
        {
            get
            {
                return this.id;
            }
        }

        public String Name
        {
            get
            {
                return this.name;
            }
        }

        public Int32? IndentationLevel
        {
            get
            {
                return this.indentationLevel;
            }
        }

    }

    [Serializable]
    public partial class QueryOrderByLine
    {
        private String column;
        private QueryOrderByDirection? direction;

        internal QueryOrderByLine(String column, QueryOrderByDirection direction)
        {
            this.column = column;
            this.direction = direction;
        }

        public String Column
        {
            get
            {
                return this.column;
            }
        }

        public QueryOrderByDirection? Direction
        {
            get
            {
                return this.direction;
            }
        }

    }

    [Serializable]
    public partial class RdlData
    {
        private CodeLines lines = new CodeLines();

        internal RdlData()
        {
        }

        public CodeLines Lines
        {
            get
            {
                return this.lines;
            }
        }

    }

    [Serializable]
    public partial class ReportDataItemLinkLine
    {
        private String fieldName;
        private String referenceFieldName;

        internal ReportDataItemLinkLine(String fieldName, String referenceFieldName)
        {
            this.fieldName = fieldName;
            this.referenceFieldName = referenceFieldName;
        }

        public String FieldName
        {
            get
            {
                return this.fieldName;
            }
        }

        public String ReferenceFieldName
        {
            get
            {
                return this.referenceFieldName;
            }
        }

    }

    [Serializable]
    public abstract partial class ReportElement
    {
        private Int32 id;
        private Int32? indentationLevel;
        private String name;

        internal ReportElement(Int32 id, Int32? indentationLevel)
        {
            this.id = id;
            this.indentationLevel = indentationLevel;
        }

        public Int32 ID
        {
            get
            {
                return this.id;
            }
        }

        public Int32? IndentationLevel
        {
            get
            {
                return this.indentationLevel;
            }
        }

        public String Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }

    }

    [Serializable]
    public partial class ReportLabel
    {
        private Int32 id;
        private String name;
        private ReportLabelProperties properties = new ReportLabelProperties();

        internal ReportLabel(Int32 id, String name)
        {
            this.id = id;
            this.name = name;
        }

        public Int32 ID
        {
            get
            {
                return this.id;
            }
        }

        public String Name
        {
            get
            {
                return this.name;
            }
        }

        public ReportLabelProperties Properties
        {
            get
            {
                return this.properties;
            }
        }

    }

    [Serializable]
    public partial class ReportRequestPage
    {
        private PageControls controls = new PageControls();
        private ReportRequestPageProperties properties = new ReportRequestPageProperties();

        internal ReportRequestPage()
        {
        }

        public PageControls Controls
        {
            get
            {
                return this.controls;
            }
        }

        public ReportRequestPageProperties Properties
        {
            get
            {
                return this.properties;
            }
        }

    }

    [Serializable]
    public partial class RunObjectLinkLine
    {
        private String fieldName;
        private Boolean? onlyMaxLimit;
        private RunObjectLinkLineType? type;
        private String value;
        private Boolean? valueIsFilter;

        internal RunObjectLinkLine(String fieldName, RunObjectLinkLineType type, String value)
        {
            this.fieldName = fieldName;
            this.type = type;
            this.value = value;
        }

        public String FieldName
        {
            get
            {
                return this.fieldName;
            }
        }

        public Boolean? OnlyMaxLimit
        {
            get
            {
                return this.onlyMaxLimit;
            }
            set
            {
                this.onlyMaxLimit = value;
            }
        }

        public RunObjectLinkLineType? Type
        {
            get
            {
                return this.type;
            }
        }

        public String Value
        {
            get
            {
                return this.value;
            }
        }

        public Boolean? ValueIsFilter
        {
            get
            {
                return this.valueIsFilter;
            }
            set
            {
                this.valueIsFilter = value;
            }
        }

    }

    [Serializable]
    public partial class SIFTLevel
    {
        private SIFTLevelComponents components = new SIFTLevelComponents();

        internal SIFTLevel()
        {
        }

        public SIFTLevelComponents Components
        {
            get
            {
                return this.components;
            }
        }

    }

    [Serializable]
    public partial class SIFTLevelComponent
    {
        private String fieldName;
        private String aspect;

        internal SIFTLevelComponent(String fieldName, String aspect)
        {
            this.aspect = aspect;
            this.fieldName = fieldName;
        }

        public String FieldName
        {
            get
            {
                return this.fieldName;
            }
        }

        public String Aspect
        {
            get
            {
                return this.aspect;
            }
        }

    }

    [Serializable]
    public partial class SourceField
    {
        private String fieldName;
        private String tableVariableName;

        internal SourceField()
        {
        }

        public String FieldName
        {
            get
            {
                return this.fieldName;
            }
            set
            {
                this.fieldName = value;
            }
        }

        public String TableVariableName
        {
            get
            {
                return this.tableVariableName;
            }
            set
            {
                this.tableVariableName = value;
            }
        }

    }

    [Serializable]
    public abstract partial class TableField
    {
        private Int32 no;
        private String name;
        private Boolean? enabled;

        internal TableField(Int32 no, String name)
        {
            this.name = name;
            this.no = no;
        }

        public Int32 No
        {
            get
            {
                return this.no;
            }
        }

        public String Name
        {
            get
            {
                return this.name;
            }
        }

        public Boolean? Enabled
        {
            get
            {
                return this.enabled;
            }
            set
            {
                this.enabled = value;
            }
        }

    }

    [Serializable]
    public partial class TableFieldGroup
    {
        private Int32 id;
        private String name;
        private FieldList fields = new FieldList();
        private TableFieldGroupProperties properties = new TableFieldGroupProperties();

        internal TableFieldGroup(Int32 id, String name)
        {
            this.id = id;
            this.name = name;
        }

        public Int32 ID
        {
            get
            {
                return this.id;
            }
        }

        public String Name
        {
            get
            {
                return this.name;
            }
        }

        public FieldList Fields
        {
            get
            {
                return this.fields;
            }
        }

        public TableFieldGroupProperties Properties
        {
            get
            {
                return this.properties;
            }
        }

    }

    [Serializable]
    public partial class TableFilterLine
    {
        private String fieldName;
        private TableFilterType? type;
        private String value;

        internal TableFilterLine(String fieldName, TableFilterType type, String value)
        {
            this.fieldName = fieldName;
            this.type = type;
            this.value = value;
        }

        public String FieldName
        {
            get
            {
                return this.fieldName;
            }
        }

        public TableFilterType? Type
        {
            get
            {
                return this.type;
            }
        }

        public String Value
        {
            get
            {
                return this.value;
            }
        }

    }

    [Serializable]
    public partial class TableKey
    {
        private Boolean? enabled;
        private FieldList fields = new FieldList();
        private TableKeyProperties properties = new TableKeyProperties();

        internal TableKey()
        {
        }

        public Boolean? Enabled
        {
            get
            {
                return this.enabled;
            }
            set
            {
                this.enabled = value;
            }
        }

        public FieldList Fields
        {
            get
            {
                return this.fields;
            }
        }

        public TableKeyProperties Properties
        {
            get
            {
                return this.properties;
            }
        }

    }

    [Serializable]
    public partial class TableRelationCondition
    {
        private String fieldName;
        private TableRelationConditionType? type;
        private String value;

        internal TableRelationCondition(String fieldName, TableRelationConditionType type, String value)
        {
            this.fieldName = fieldName;
            this.type = type;
            this.value = value;
        }

        public String FieldName
        {
            get
            {
                return this.fieldName;
            }
        }

        public TableRelationConditionType? Type
        {
            get
            {
                return this.type;
            }
        }

        public String Value
        {
            get
            {
                return this.value;
            }
        }

    }

    [Serializable]
    public partial class TableRelationLine
    {
        private TableRelationConditions conditions = new TableRelationConditions();
        private String fieldName;
        private TableRelationTableFilter tableFilter = new TableRelationTableFilter();
        private String tableName;

        internal TableRelationLine(String tableName)
        {
            this.tableName = tableName;
        }

        public TableRelationConditions Conditions
        {
            get
            {
                return this.conditions;
            }
        }

        public String FieldName
        {
            get
            {
                return this.fieldName;
            }
            set
            {
                this.fieldName = value;
            }
        }

        public TableRelationTableFilter TableFilter
        {
            get
            {
                return this.tableFilter;
            }
        }

        public String TableName
        {
            get
            {
                return this.tableName;
            }
        }

    }

    [Serializable]
    public partial class TableRelationTableFilterLine
    {
        private String fieldName;
        private TableRelationTableFilterLineType? type;
        private String value;

        internal TableRelationTableFilterLine(String fieldName, TableRelationTableFilterLineType type, String value)
        {
            this.fieldName = fieldName;
            this.type = type;
            this.value = value;
        }

        public String FieldName
        {
            get
            {
                return this.fieldName;
            }
        }

        public TableRelationTableFilterLineType? Type
        {
            get
            {
                return this.type;
            }
        }

        public String Value
        {
            get
            {
                return this.value;
            }
        }

    }

    [Serializable]
    public partial class TableView
    {
        private String key;
        private Order? order;
        private TableFilter tableFilter = new TableFilter();

        internal TableView()
        {
        }

        public String Key
        {
            get
            {
                return this.key;
            }
            set
            {
                this.key = value;
            }
        }

        public Order? Order
        {
            get
            {
                return this.order;
            }
            set
            {
                this.order = value;
            }
        }

        public TableFilter TableFilter
        {
            get
            {
                return this.tableFilter;
            }
        }

    }

    [Serializable]
    public partial class Trigger
    {
        private CodeLines codeLines = new CodeLines();
        private Variables variables = new Variables();

        internal Trigger()
        {
        }

        public CodeLines CodeLines
        {
            get
            {
                return this.codeLines;
            }
        }

        public Variables Variables
        {
            get
            {
                return this.variables;
            }
        }

    }

    [Serializable]
    public abstract partial class Variable
    {
        private Int32 id;
        private String name;

        internal Variable(Int32 id, String name)
        {
            this.id = id;
            this.name = name;
        }

        public Int32 ID
        {
            get
            {
                return this.id;
            }
        }

        public String Name
        {
            get
            {
                return this.name;
            }
        }

    }

    [Serializable]
    public abstract partial class XmlPortNode
    {
        private Guid id;
        private String nodeName;
        private Int32? indentationLevel;

        internal XmlPortNode(Guid id, String nodeName, Int32? indentationLevel)
        {
            this.id = id;
            this.indentationLevel = indentationLevel;
            this.nodeName = nodeName;
        }

        public Guid ID
        {
            get
            {
                return this.id;
            }
        }

        public String NodeName
        {
            get
            {
                return this.nodeName;
            }
        }

        public Int32? IndentationLevel
        {
            get
            {
                return this.indentationLevel;
            }
        }

    }

    [Serializable]
    public partial class XmlPortRequestPage
    {
        private PageControls controls = new PageControls();
        private XmlPortRequestPageProperties properties = new XmlPortRequestPageProperties();

        internal XmlPortRequestPage()
        {
        }

        public PageControls Controls
        {
            get
            {
                return this.controls;
            }
        }

        public XmlPortRequestPageProperties Properties
        {
            get
            {
                return this.properties;
            }
        }

    }

    [Serializable]
    public partial class DeltaNode : MenuSuiteNode
    {
        private MenuSuiteDeltaNodeProperties properties = new MenuSuiteDeltaNodeProperties();

        internal DeltaNode(Guid id) : base(id)
        {
        }

        public MenuSuiteDeltaNodeProperties Properties
        {
            get
            {
                return this.properties;
            }
        }

    }

    [Serializable]
    public partial class GroupNode : MenuSuiteNode
    {
        private MenuSuiteGroupNodeProperties properties = new MenuSuiteGroupNodeProperties();

        internal GroupNode(Guid id) : base(id)
        {
        }

        public MenuSuiteGroupNodeProperties Properties
        {
            get
            {
                return this.properties;
            }
        }

    }

    [Serializable]
    public partial class ItemNode : MenuSuiteNode
    {
        private MenuSuiteItemNodeProperties properties = new MenuSuiteItemNodeProperties();

        internal ItemNode(Guid id) : base(id)
        {
        }

        public MenuSuiteItemNodeProperties Properties
        {
            get
            {
                return this.properties;
            }
        }

    }

    [Serializable]
    public partial class MenuNode : MenuSuiteNode
    {
        private MenuSuiteMenuNodeProperties properties = new MenuSuiteMenuNodeProperties();

        internal MenuNode(Guid id) : base(id)
        {
        }

        public MenuSuiteMenuNodeProperties Properties
        {
            get
            {
                return this.properties;
            }
        }

    }

    [Serializable]
    public partial class RootNode : MenuSuiteNode
    {
        private MenuSuiteRootNodeProperties properties = new MenuSuiteRootNodeProperties();

        internal RootNode(Guid id) : base(id)
        {
        }

        public MenuSuiteRootNodeProperties Properties
        {
            get
            {
                return this.properties;
            }
        }

    }

    [Serializable]
    public partial class Codeunit : Object
    {
        private CodeunitProperties properties = new CodeunitProperties();
        private Code code = new Code();

        internal Codeunit(Int32 id, String name) : base(id, name)
        {
        }

        public CodeunitProperties Properties
        {
            get
            {
                return this.properties;
            }
        }

        public Code Code
        {
            get
            {
                return this.code;
            }
        }

    }

    [Serializable]
    public partial class MenuSuite : Object
    {
        private MenuSuiteProperties properties = new MenuSuiteProperties();
        private MenuSuiteNodes nodes = new MenuSuiteNodes();

        internal MenuSuite(Int32 id, String name) : base(id, name)
        {
        }

        public MenuSuiteProperties Properties
        {
            get
            {
                return this.properties;
            }
        }

        public MenuSuiteNodes Nodes
        {
            get
            {
                return this.nodes;
            }
        }

    }

    [Serializable]
    public partial class Page : Object
    {
        private Code code = new Code();
        private PageControls controls = new PageControls();
        private PageProperties properties = new PageProperties();

        internal Page(Int32 id, String name) : base(id, name)
        {
        }

        public Code Code
        {
            get
            {
                return this.code;
            }
        }

        public PageControls Controls
        {
            get
            {
                return this.controls;
            }
        }

        public PageProperties Properties
        {
            get
            {
                return this.properties;
            }
        }

    }

    [Serializable]
    public partial class Query : Object
    {
        private Code code = new Code();
        private QueryElements elements = new QueryElements();
        private QueryProperties properties = new QueryProperties();

        internal Query(Int32 id, String name) : base(id, name)
        {
        }

        public Code Code
        {
            get
            {
                return this.code;
            }
        }

        public QueryElements Elements
        {
            get
            {
                return this.elements;
            }
        }

        public QueryProperties Properties
        {
            get
            {
                return this.properties;
            }
        }

    }

    [Serializable]
    public partial class Report : Object
    {
        private Code codes = new Code();
        private ReportElements elements = new ReportElements();
        private ReportLabels labels = new ReportLabels();
        private ReportProperties properties = new ReportProperties();
        private RdlData rdlData = new RdlData();
        private ReportRequestPage requestPage = new ReportRequestPage();

        internal Report(Int32 id, String name) : base(id, name)
        {
        }

        public Code Code
        {
            get
            {
                return this.codes;
            }
        }

        public ReportElements Elements
        {
            get
            {
                return this.elements;
            }
        }

        public ReportLabels Labels
        {
            get
            {
                return this.labels;
            }
        }

        public ReportProperties Properties
        {
            get
            {
                return this.properties;
            }
        }

        public RdlData RdlData
        {
            get
            {
                return this.rdlData;
            }
        }

        public ReportRequestPage RequestPage
        {
            get
            {
                return this.requestPage;
            }
        }

    }

    [Serializable]
    public partial class Table : Object
    {
        private TableFields fields = new TableFields();
        private TableProperties properties = new TableProperties();
        private TableFieldGroups fieldGroups = new TableFieldGroups();
        private TableKeys keys = new TableKeys();
        private Code code = new Code();

        internal Table(Int32 id, String name) : base(id, name)
        {
        }

        public TableFields Fields
        {
            get
            {
                return this.fields;
            }
        }

        public TableProperties Properties
        {
            get
            {
                return this.properties;
            }
        }

        public TableFieldGroups FieldGroups
        {
            get
            {
                return this.fieldGroups;
            }
        }

        public TableKeys Keys
        {
            get
            {
                return this.keys;
            }
        }

        public Code Code
        {
            get
            {
                return this.code;
            }
        }

    }

    [Serializable]
    public partial class XmlPort : Object
    {
        private Code code = new Code();
        private XmlPortNodes nodes = new XmlPortNodes();
        private XmlPortProperties properties = new XmlPortProperties();
        private XmlPortRequestPage requestPage = new XmlPortRequestPage();

        internal XmlPort(Int32 id, String name) : base(id, name)
        {
        }

        public Code Code
        {
            get
            {
                return this.code;
            }
        }

        public XmlPortNodes Nodes
        {
            get
            {
                return this.nodes;
            }
        }

        public XmlPortProperties Properties
        {
            get
            {
                return this.properties;
            }
        }

        public XmlPortRequestPage RequestPage
        {
            get
            {
                return this.requestPage;
            }
        }

    }

    [Serializable]
    public partial class PageAction : PageActionBase
    {
        private PageActionProperties properties = new PageActionProperties();

        internal PageAction(Int32 id, Int32? indentationLevel) : base(id, indentationLevel)
        {
        }

        public PageActionProperties Properties
        {
            get
            {
                return this.properties;
            }
        }

    }

    [Serializable]
    public partial class PageActionContainer : PageActionBase
    {
        private PageActionContainerProperties properties = new PageActionContainerProperties();

        internal PageActionContainer(Int32 id, Int32? indentationLevel) : base(id, indentationLevel)
        {
        }

        public PageActionContainerProperties Properties
        {
            get
            {
                return this.properties;
            }
        }

    }

    [Serializable]
    public partial class PageActionGroup : PageActionBase
    {
        private PageActionGroupProperties properties = new PageActionGroupProperties();

        internal PageActionGroup(Int32 id, Int32? indentationLevel) : base(id, indentationLevel)
        {
        }

        public PageActionGroupProperties Properties
        {
            get
            {
                return this.properties;
            }
        }

    }

    [Serializable]
    public partial class PageActionSeparator : PageActionBase
    {
        private PageActionSeparatorProperties properties = new PageActionSeparatorProperties();

        internal PageActionSeparator(Int32 id, Int32? indentationLevel) : base(id, indentationLevel)
        {
        }

        public PageActionSeparatorProperties Properties
        {
            get
            {
                return this.properties;
            }
        }

    }

    [Serializable]
    public partial class ContainerPageControl : PageControl
    {
        private ContainerPageControlProperties properties = new ContainerPageControlProperties();

        internal ContainerPageControl(Int32 id, Int32? indentationLevel) : base(id, indentationLevel)
        {
        }

        public ContainerPageControlProperties Properties
        {
            get
            {
                return this.properties;
            }
        }

    }

    [Serializable]
    public partial class FieldPageControl : PageControl
    {
        private FieldPageControlProperties properties = new FieldPageControlProperties();

        internal FieldPageControl(Int32 id, Int32? indentationLevel) : base(id, indentationLevel)
        {
        }

        public FieldPageControlProperties Properties
        {
            get
            {
                return this.properties;
            }
        }

    }

    [Serializable]
    public partial class GroupPageControl : PageControl
    {
        private GroupPageControlProperties properties = new GroupPageControlProperties();

        internal GroupPageControl(Int32 id, Int32? indentationLevel) : base(id, indentationLevel)
        {
        }

        public GroupPageControlProperties Properties
        {
            get
            {
                return this.properties;
            }
        }

    }

    [Serializable]
    public partial class PartPageControl : PageControl
    {
        private PartPageControlProperties properties = new PartPageControlProperties();

        internal PartPageControl(Int32 id, Int32? indentationLevel) : base(id, indentationLevel)
        {
        }

        public PartPageControlProperties Properties
        {
            get
            {
                return this.properties;
            }
        }

    }

    [Serializable]
    public partial class ActionParameter : Parameter
    {
        private String dimensions;

        internal ActionParameter(Boolean var, Int32 id, String name) : base(var, id, name)
        {
        }

        public String Dimensions
        {
            get
            {
                return this.dimensions;
            }
            set
            {
                this.dimensions = value;
            }
        }

    }

    [Serializable]
    public partial class AutomationParameter : Parameter
    {
        private String dimensions;
        private String subType;

        internal AutomationParameter(Boolean var, Int32 id, String name, String subType) : base(var, id, name)
        {
            this.subType = subType;
        }

        public String Dimensions
        {
            get
            {
                return this.dimensions;
            }
            set
            {
                this.dimensions = value;
            }
        }

        public String SubType
        {
            get
            {
                return this.subType;
            }
        }

    }

    [Serializable]
    public partial class BigIntegerParameter : Parameter
    {
        private String dimensions;

        internal BigIntegerParameter(Boolean var, Int32 id, String name) : base(var, id, name)
        {
        }

        public String Dimensions
        {
            get
            {
                return this.dimensions;
            }
            set
            {
                this.dimensions = value;
            }
        }

    }

    [Serializable]
    public partial class BigTextParameter : Parameter
    {
        private String dimensions;

        internal BigTextParameter(Boolean var, Int32 id, String name) : base(var, id, name)
        {
        }

        public String Dimensions
        {
            get
            {
                return this.dimensions;
            }
            set
            {
                this.dimensions = value;
            }
        }

    }

    [Serializable]
    public partial class BinaryParameter : Parameter
    {
        private Int32 dataLength;
        private String dimensions;

        internal BinaryParameter(Boolean var, Int32 id, String name, Int32 dataLength = 100) : base(var, id, name)
        {
            this.dataLength = dataLength;
        }

        public Int32 DataLength
        {
            get
            {
                return this.dataLength;
            }
        }

        public String Dimensions
        {
            get
            {
                return this.dimensions;
            }
            set
            {
                this.dimensions = value;
            }
        }

    }

    [Serializable]
    public partial class BooleanParameter : Parameter
    {
        private String dimensions;

        internal BooleanParameter(Boolean var, Int32 id, String name) : base(var, id, name)
        {
        }

        public String Dimensions
        {
            get
            {
                return this.dimensions;
            }
            set
            {
                this.dimensions = value;
            }
        }

    }

    [Serializable]
    public partial class ByteParameter : Parameter
    {
        private String dimensions;

        internal ByteParameter(Boolean var, Int32 id, String name) : base(var, id, name)
        {
        }

        public String Dimensions
        {
            get
            {
                return this.dimensions;
            }
            set
            {
                this.dimensions = value;
            }
        }

    }

    [Serializable]
    public partial class CharParameter : Parameter
    {
        private String dimensions;

        internal CharParameter(Boolean var, Int32 id, String name) : base(var, id, name)
        {
        }

        public String Dimensions
        {
            get
            {
                return this.dimensions;
            }
            set
            {
                this.dimensions = value;
            }
        }

    }

    [Serializable]
    public partial class CodeParameter : Parameter
    {
        private Int32? dataLength;
        private String dimensions;

        internal CodeParameter(Boolean var, Int32 id, String name, Int32? dataLength = null) : base(var, id, name)
        {
            this.dataLength = dataLength;
        }

        public Int32? DataLength
        {
            get
            {
                return this.dataLength;
            }
        }

        public String Dimensions
        {
            get
            {
                return this.dimensions;
            }
            set
            {
                this.dimensions = value;
            }
        }

    }

    [Serializable]
    public partial class CodeunitParameter : Parameter
    {
        private String dimensions;
        private Int32 subType;

        internal CodeunitParameter(Boolean var, Int32 id, String name, Int32 subType) : base(var, id, name)
        {
            this.subType = subType;
        }

        public String Dimensions
        {
            get
            {
                return this.dimensions;
            }
            set
            {
                this.dimensions = value;
            }
        }

        public Int32 SubType
        {
            get
            {
                return this.subType;
            }
        }

    }

    [Serializable]
    public partial class DateFormulaParameter : Parameter
    {
        private String dimensions;

        internal DateFormulaParameter(Boolean var, Int32 id, String name) : base(var, id, name)
        {
        }

        public String Dimensions
        {
            get
            {
                return this.dimensions;
            }
            set
            {
                this.dimensions = value;
            }
        }

    }

    [Serializable]
    public partial class DateParameter : Parameter
    {
        private String dimensions;

        internal DateParameter(Boolean var, Int32 id, String name) : base(var, id, name)
        {
        }

        public String Dimensions
        {
            get
            {
                return this.dimensions;
            }
            set
            {
                this.dimensions = value;
            }
        }

    }

    [Serializable]
    public partial class DateTimeParameter : Parameter
    {
        private String dimensions;

        internal DateTimeParameter(Boolean var, Int32 id, String name) : base(var, id, name)
        {
        }

        public String Dimensions
        {
            get
            {
                return this.dimensions;
            }
            set
            {
                this.dimensions = value;
            }
        }

    }

    [Serializable]
    public partial class DecimalParameter : Parameter
    {
        private String dimensions;

        internal DecimalParameter(Boolean var, Int32 id, String name) : base(var, id, name)
        {
        }

        public String Dimensions
        {
            get
            {
                return this.dimensions;
            }
            set
            {
                this.dimensions = value;
            }
        }

    }

    [Serializable]
    public partial class DialogParameter : Parameter
    {
        private String dimensions;

        internal DialogParameter(Boolean var, Int32 id, String name) : base(var, id, name)
        {
        }

        public String Dimensions
        {
            get
            {
                return this.dimensions;
            }
            set
            {
                this.dimensions = value;
            }
        }

    }

    [Serializable]
    public partial class DotNetParameter : Parameter
    {
        private String dimensions;
        private Boolean? runOnClient;
        private String subType;
        private Boolean? suppressDispose;

        internal DotNetParameter(Boolean var, Int32 id, String name, String subType) : base(var, id, name)
        {
            this.subType = subType;
        }

        public String Dimensions
        {
            get
            {
                return this.dimensions;
            }
            set
            {
                this.dimensions = value;
            }
        }

        public Boolean? RunOnClient
        {
            get
            {
                return this.runOnClient;
            }
            set
            {
                this.runOnClient = value;
            }
        }

        public String SubType
        {
            get
            {
                return this.subType;
            }
        }

        public Boolean? SuppressDispose
        {
            get
            {
                return this.suppressDispose;
            }
            set
            {
                this.suppressDispose = value;
            }
        }

    }

    [Serializable]
    public partial class DurationParameter : Parameter
    {
        private String dimensions;

        internal DurationParameter(Boolean var, Int32 id, String name) : base(var, id, name)
        {
        }

        public String Dimensions
        {
            get
            {
                return this.dimensions;
            }
            set
            {
                this.dimensions = value;
            }
        }

    }

    [Serializable]
    public partial class ExecutionModeParameter : Parameter
    {
        private String dimensions;

        internal ExecutionModeParameter(Boolean var, Int32 id, String name) : base(var, id, name)
        {
        }

        public String Dimensions
        {
            get
            {
                return this.dimensions;
            }
            set
            {
                this.dimensions = value;
            }
        }

    }

    [Serializable]
    public partial class FieldRefParameter : Parameter
    {
        private String dimensions;

        internal FieldRefParameter(Boolean var, Int32 id, String name) : base(var, id, name)
        {
        }

        public String Dimensions
        {
            get
            {
                return this.dimensions;
            }
            set
            {
                this.dimensions = value;
            }
        }

    }

    [Serializable]
    public partial class FileParameter : Parameter
    {
        private String dimensions;

        internal FileParameter(Boolean var, Int32 id, String name) : base(var, id, name)
        {
        }

        public String Dimensions
        {
            get
            {
                return this.dimensions;
            }
            set
            {
                this.dimensions = value;
            }
        }

    }

    [Serializable]
    public partial class GuidParameter : Parameter
    {
        private String dimensions;

        internal GuidParameter(Boolean var, Int32 id, String name) : base(var, id, name)
        {
        }

        public String Dimensions
        {
            get
            {
                return this.dimensions;
            }
            set
            {
                this.dimensions = value;
            }
        }

    }

    [Serializable]
    public partial class InStreamParameter : Parameter
    {
        private String dimensions;

        internal InStreamParameter(Boolean var, Int32 id, String name) : base(var, id, name)
        {
        }

        public String Dimensions
        {
            get
            {
                return this.dimensions;
            }
            set
            {
                this.dimensions = value;
            }
        }

    }

    [Serializable]
    public partial class IntegerParameter : Parameter
    {
        private String dimensions;

        internal IntegerParameter(Boolean var, Int32 id, String name) : base(var, id, name)
        {
        }

        public String Dimensions
        {
            get
            {
                return this.dimensions;
            }
            set
            {
                this.dimensions = value;
            }
        }

    }

    [Serializable]
    public partial class KeyRefParameter : Parameter
    {
        private String dimensions;

        internal KeyRefParameter(Boolean var, Int32 id, String name) : base(var, id, name)
        {
        }

        public String Dimensions
        {
            get
            {
                return this.dimensions;
            }
            set
            {
                this.dimensions = value;
            }
        }

    }

    [Serializable]
    public partial class OcxParameter : Parameter
    {
        private String dimensions;
        private String subType;

        internal OcxParameter(Boolean var, Int32 id, String name, String subType) : base(var, id, name)
        {
            this.subType = subType;
        }

        public String Dimensions
        {
            get
            {
                return this.dimensions;
            }
            set
            {
                this.dimensions = value;
            }
        }

        public String SubType
        {
            get
            {
                return this.subType;
            }
        }

    }

    [Serializable]
    public partial class OptionParameter : Parameter
    {
        private String dimensions;
        private String optionString;

        internal OptionParameter(Boolean var, Int32 id, String name) : base(var, id, name)
        {
        }

        public String Dimensions
        {
            get
            {
                return this.dimensions;
            }
            set
            {
                this.dimensions = value;
            }
        }

        public String OptionString
        {
            get
            {
                return this.optionString;
            }
            set
            {
                this.optionString = value;
            }
        }

    }

    [Serializable]
    public partial class OutStreamParameter : Parameter
    {
        private String dimensions;

        internal OutStreamParameter(Boolean var, Int32 id, String name) : base(var, id, name)
        {
        }

        public String Dimensions
        {
            get
            {
                return this.dimensions;
            }
            set
            {
                this.dimensions = value;
            }
        }

    }

    [Serializable]
    public partial class PageParameter : Parameter
    {
        private String dimensions;
        private Int32 subType;

        internal PageParameter(Boolean var, Int32 id, String name, Int32 subType) : base(var, id, name)
        {
            this.subType = subType;
        }

        public String Dimensions
        {
            get
            {
                return this.dimensions;
            }
            set
            {
                this.dimensions = value;
            }
        }

        public Int32 SubType
        {
            get
            {
                return this.subType;
            }
        }

    }

    [Serializable]
    public partial class QueryParameter : Parameter
    {
        private String dimensions;
        private QuerySecurityFiltering? securityFiltering;
        private Int32 subType;

        internal QueryParameter(Boolean var, Int32 id, String name, Int32 subType) : base(var, id, name)
        {
            this.subType = subType;
        }

        public String Dimensions
        {
            get
            {
                return this.dimensions;
            }
            set
            {
                this.dimensions = value;
            }
        }

        public QuerySecurityFiltering? SecurityFiltering
        {
            get
            {
                return this.securityFiltering;
            }
            set
            {
                this.securityFiltering = value;
            }
        }

        public Int32 SubType
        {
            get
            {
                return this.subType;
            }
        }

    }

    [Serializable]
    public partial class RecordIDParameter : Parameter
    {
        private String dimensions;

        internal RecordIDParameter(Boolean var, Int32 id, String name) : base(var, id, name)
        {
        }

        public String Dimensions
        {
            get
            {
                return this.dimensions;
            }
            set
            {
                this.dimensions = value;
            }
        }

    }

    [Serializable]
    public partial class RecordParameter : Parameter
    {
        private String dimensions;
        private RecordSecurityFiltering? securityFiltering;
        private Int32 subType;
        private Boolean? temporary;

        internal RecordParameter(Boolean var, Int32 id, String name, Int32 subType) : base(var, id, name)
        {
            this.subType = subType;
        }

        public String Dimensions
        {
            get
            {
                return this.dimensions;
            }
            set
            {
                this.dimensions = value;
            }
        }

        public RecordSecurityFiltering? SecurityFiltering
        {
            get
            {
                return this.securityFiltering;
            }
            set
            {
                this.securityFiltering = value;
            }
        }

        public Int32 SubType
        {
            get
            {
                return this.subType;
            }
        }

        public Boolean? Temporary
        {
            get
            {
                return this.temporary;
            }
            set
            {
                this.temporary = value;
            }
        }

    }

    [Serializable]
    public partial class RecordRefParameter : Parameter
    {
        private String dimensions;
        private RecordSecurityFiltering? securityFiltering;

        internal RecordRefParameter(Boolean var, Int32 id, String name) : base(var, id, name)
        {
        }

        public String Dimensions
        {
            get
            {
                return this.dimensions;
            }
            set
            {
                this.dimensions = value;
            }
        }

        public RecordSecurityFiltering? SecurityFiltering
        {
            get
            {
                return this.securityFiltering;
            }
            set
            {
                this.securityFiltering = value;
            }
        }

    }

    [Serializable]
    public partial class ReportParameter : Parameter
    {
        private String dimensions;
        private Int32 subType;

        internal ReportParameter(Boolean var, Int32 id, String name, Int32 subType) : base(var, id, name)
        {
            this.subType = subType;
        }

        public String Dimensions
        {
            get
            {
                return this.dimensions;
            }
            set
            {
                this.dimensions = value;
            }
        }

        public Int32 SubType
        {
            get
            {
                return this.subType;
            }
        }

    }

    [Serializable]
    public partial class TestPageParameter : Parameter
    {
        private String dimensions;
        private Int32 subType;

        internal TestPageParameter(Boolean var, Int32 id, String name, Int32 subType) : base(var, id, name)
        {
            this.subType = subType;
        }

        public String Dimensions
        {
            get
            {
                return this.dimensions;
            }
            set
            {
                this.dimensions = value;
            }
        }

        public Int32 SubType
        {
            get
            {
                return this.subType;
            }
        }

    }

    [Serializable]
    public partial class TestRequestPageParameter : Parameter
    {
        private String dimensions;
        private Int32 subType;

        internal TestRequestPageParameter(Boolean var, Int32 id, String name, Int32 subType) : base(var, id, name)
        {
            this.subType = subType;
        }

        public String Dimensions
        {
            get
            {
                return this.dimensions;
            }
            set
            {
                this.dimensions = value;
            }
        }

        public Int32 SubType
        {
            get
            {
                return this.subType;
            }
        }

    }

    [Serializable]
    public partial class TextParameter : Parameter
    {
        private Int32? dataLength;
        private String dimensions;

        internal TextParameter(Boolean var, Int32 id, String name, Int32? dataLength = null) : base(var, id, name)
        {
            this.dataLength = dataLength;
        }

        public Int32? DataLength
        {
            get
            {
                return this.dataLength;
            }
        }

        public String Dimensions
        {
            get
            {
                return this.dimensions;
            }
            set
            {
                this.dimensions = value;
            }
        }

    }

    [Serializable]
    public partial class TimeParameter : Parameter
    {
        private String dimensions;

        internal TimeParameter(Boolean var, Int32 id, String name) : base(var, id, name)
        {
        }

        public String Dimensions
        {
            get
            {
                return this.dimensions;
            }
            set
            {
                this.dimensions = value;
            }
        }

    }

    [Serializable]
    public partial class TransactionTypeParameter : Parameter
    {
        private String dimensions;

        internal TransactionTypeParameter(Boolean var, Int32 id, String name) : base(var, id, name)
        {
        }

        public String Dimensions
        {
            get
            {
                return this.dimensions;
            }
            set
            {
                this.dimensions = value;
            }
        }

    }

    [Serializable]
    public partial class VariantParameter : Parameter
    {
        private String dimensions;

        internal VariantParameter(Boolean var, Int32 id, String name) : base(var, id, name)
        {
        }

        public String Dimensions
        {
            get
            {
                return this.dimensions;
            }
            set
            {
                this.dimensions = value;
            }
        }

    }

    [Serializable]
    public partial class XmlPortParameter : Parameter
    {
        private String dimensions;
        private Int32 subType;

        internal XmlPortParameter(Boolean var, Int32 id, String name, Int32 subType) : base(var, id, name)
        {
            this.subType = subType;
        }

        public String Dimensions
        {
            get
            {
                return this.dimensions;
            }
            set
            {
                this.dimensions = value;
            }
        }

        public Int32 SubType
        {
            get
            {
                return this.subType;
            }
        }

    }

    [Serializable]
    public partial class ColumnQueryElement : QueryElement
    {
        private ColumnQueryElementProperties properties = new ColumnQueryElementProperties();

        internal ColumnQueryElement(Int32 id, String name, Int32? indentationLevel) : base(id, name, indentationLevel)
        {
        }

        public ColumnQueryElementProperties Properties
        {
            get
            {
                return this.properties;
            }
        }

    }

    [Serializable]
    public partial class DataItemQueryElement : QueryElement
    {
        private DataItemQueryElementProperties properties = new DataItemQueryElementProperties();

        internal DataItemQueryElement(Int32 id, String name, Int32? indentationLevel) : base(id, name, indentationLevel)
        {
        }

        public DataItemQueryElementProperties Properties
        {
            get
            {
                return this.properties;
            }
        }

    }

    [Serializable]
    public partial class FilterQueryElement : QueryElement
    {
        private FilterQueryElementProperties properties = new FilterQueryElementProperties();

        internal FilterQueryElement(Int32 id, String name, Int32? indentationLevel) : base(id, name, indentationLevel)
        {
        }

        public FilterQueryElementProperties Properties
        {
            get
            {
                return this.properties;
            }
        }

    }

    [Serializable]
    public partial class ColumnReportElement : ReportElement
    {
        private ColumnReportElementProperties properties = new ColumnReportElementProperties();

        internal ColumnReportElement(Int32 id, Int32? indentationLevel) : base(id, indentationLevel)
        {
        }

        public ColumnReportElementProperties Properties
        {
            get
            {
                return this.properties;
            }
        }

    }

    [Serializable]
    public partial class DataItemReportElement : ReportElement
    {
        private DataItemReportElementProperties properties = new DataItemReportElementProperties();

        internal DataItemReportElement(Int32 id, Int32? indentationLevel) : base(id, indentationLevel)
        {
        }

        public DataItemReportElementProperties Properties
        {
            get
            {
                return this.properties;
            }
        }

    }

    [Serializable]
    public partial class BigIntegerTableField : TableField
    {
        private BigIntegerTableFieldProperties properties = new BigIntegerTableFieldProperties();

        internal BigIntegerTableField(Int32 no, String name) : base(no, name)
        {
        }

        public BigIntegerTableFieldProperties Properties
        {
            get
            {
                return this.properties;
            }
        }

    }

    [Serializable]
    public partial class BinaryTableField : TableField
    {
        private Int32 dataLength;
        private BinaryTableFieldProperties properties = new BinaryTableFieldProperties();

        internal BinaryTableField(Int32 no, String name, Int32 dataLength = 4) : base(no, name)
        {
            this.dataLength = dataLength;
        }

        public Int32 DataLength
        {
            get
            {
                return this.dataLength;
            }
        }

        public BinaryTableFieldProperties Properties
        {
            get
            {
                return this.properties;
            }
        }

    }

    [Serializable]
    public partial class BlobTableField : TableField
    {
        private BlobTableFieldProperties properties = new BlobTableFieldProperties();

        internal BlobTableField(Int32 no, String name) : base(no, name)
        {
        }

        public BlobTableFieldProperties Properties
        {
            get
            {
                return this.properties;
            }
        }

    }

    [Serializable]
    public partial class BooleanTableField : TableField
    {
        private BooleanTableFieldProperties properties = new BooleanTableFieldProperties();

        internal BooleanTableField(Int32 no, String name) : base(no, name)
        {
        }

        public BooleanTableFieldProperties Properties
        {
            get
            {
                return this.properties;
            }
        }

    }

    [Serializable]
    public partial class CodeTableField : TableField
    {
        private CodeTableFieldProperties properties = new CodeTableFieldProperties();
        private Int32 dataLength;

        internal CodeTableField(Int32 no, String name, Int32 dataLength = 10) : base(no, name)
        {
            this.dataLength = dataLength;
        }

        public CodeTableFieldProperties Properties
        {
            get
            {
                return this.properties;
            }
        }

        public Int32 DataLength
        {
            get
            {
                return this.dataLength;
            }
        }

    }

    [Serializable]
    public partial class DateFormulaTableField : TableField
    {
        private DateFormulaTableFieldProperties properties = new DateFormulaTableFieldProperties();

        internal DateFormulaTableField(Int32 no, String name) : base(no, name)
        {
        }

        public DateFormulaTableFieldProperties Properties
        {
            get
            {
                return this.properties;
            }
        }

    }

    [Serializable]
    public partial class DateTableField : TableField
    {
        private DateTableFieldProperties properties = new DateTableFieldProperties();

        internal DateTableField(Int32 no, String name) : base(no, name)
        {
        }

        public DateTableFieldProperties Properties
        {
            get
            {
                return this.properties;
            }
        }

    }

    [Serializable]
    public partial class DateTimeTableField : TableField
    {
        private DateTimeTableFieldProperties properties = new DateTimeTableFieldProperties();

        internal DateTimeTableField(Int32 no, String name) : base(no, name)
        {
        }

        public DateTimeTableFieldProperties Properties
        {
            get
            {
                return this.properties;
            }
        }

    }

    [Serializable]
    public partial class DecimalTableField : TableField
    {
        private DecimalTableFieldProperties properties = new DecimalTableFieldProperties();

        internal DecimalTableField(Int32 no, String name) : base(no, name)
        {
        }

        public DecimalTableFieldProperties Properties
        {
            get
            {
                return this.properties;
            }
        }

    }

    [Serializable]
    public partial class DurationTableField : TableField
    {
        private DurationTableFieldProperties properties = new DurationTableFieldProperties();

        internal DurationTableField(Int32 no, String name) : base(no, name)
        {
        }

        public DurationTableFieldProperties Properties
        {
            get
            {
                return this.properties;
            }
        }

    }

    [Serializable]
    public partial class GuidTableField : TableField
    {
        private GuidTableFieldProperties properties = new GuidTableFieldProperties();

        internal GuidTableField(Int32 no, String name) : base(no, name)
        {
        }

        public GuidTableFieldProperties Properties
        {
            get
            {
                return this.properties;
            }
        }

    }

    [Serializable]
    public partial class IntegerTableField : TableField
    {
        private IntegerTableFieldProperties properties = new IntegerTableFieldProperties();

        internal IntegerTableField(Int32 no, String name) : base(no, name)
        {
        }

        public IntegerTableFieldProperties Properties
        {
            get
            {
                return this.properties;
            }
        }

    }

    [Serializable]
    public partial class OptionTableField : TableField
    {
        private OptionTableFieldProperties properties = new OptionTableFieldProperties();

        internal OptionTableField(Int32 no, String name) : base(no, name)
        {
        }

        public OptionTableFieldProperties Properties
        {
            get
            {
                return this.properties;
            }
        }

    }

    [Serializable]
    public partial class RecordIDTableField : TableField
    {
        private RecordIDTableFieldProperties properties = new RecordIDTableFieldProperties();

        internal RecordIDTableField(Int32 no, String name) : base(no, name)
        {
        }

        public RecordIDTableFieldProperties Properties
        {
            get
            {
                return this.properties;
            }
        }

    }

    [Serializable]
    public partial class TableFilterTableField : TableField
    {
        private TableFilterTableFieldProperties properties = new TableFilterTableFieldProperties();

        internal TableFilterTableField(Int32 no, String name) : base(no, name)
        {
        }

        public TableFilterTableFieldProperties Properties
        {
            get
            {
                return this.properties;
            }
        }

    }

    [Serializable]
    public partial class TextTableField : TableField
    {
        private Int32 dataLength;
        private TextTableFieldProperties properties = new TextTableFieldProperties();

        internal TextTableField(Int32 no, String name, Int32 dataLength = 30) : base(no, name)
        {
            this.dataLength = dataLength;
        }

        public Int32 DataLength
        {
            get
            {
                return this.dataLength;
            }
        }

        public TextTableFieldProperties Properties
        {
            get
            {
                return this.properties;
            }
        }

    }

    [Serializable]
    public partial class TimeTableField : TableField
    {
        private TimeTableFieldProperties properties = new TimeTableFieldProperties();

        internal TimeTableField(Int32 no, String name) : base(no, name)
        {
        }

        public TimeTableFieldProperties Properties
        {
            get
            {
                return this.properties;
            }
        }

    }

    [Serializable]
    public partial class ActionVariable : Variable
    {
        private String dimensions;

        internal ActionVariable(Int32 id, String name) : base(id, name)
        {
        }

        public String Dimensions
        {
            get
            {
                return this.dimensions;
            }
            set
            {
                this.dimensions = value;
            }
        }

    }

    [Serializable]
    public partial class AutomationVariable : Variable
    {
        private String dimensions;
        private String subType;
        private Boolean? withEvents;

        internal AutomationVariable(Int32 id, String name, String subType) : base(id, name)
        {
            this.subType = subType;
        }

        public String Dimensions
        {
            get
            {
                return this.dimensions;
            }
            set
            {
                this.dimensions = value;
            }
        }

        public String SubType
        {
            get
            {
                return this.subType;
            }
        }

        public Boolean? WithEvents
        {
            get
            {
                return this.withEvents;
            }
            set
            {
                this.withEvents = value;
            }
        }

    }

    [Serializable]
    public partial class BigIntegerVariable : Variable
    {
        private String dimensions;

        internal BigIntegerVariable(Int32 id, String name) : base(id, name)
        {
        }

        public String Dimensions
        {
            get
            {
                return this.dimensions;
            }
            set
            {
                this.dimensions = value;
            }
        }

    }

    [Serializable]
    public partial class BigTextVariable : Variable
    {
        private String dimensions;

        internal BigTextVariable(Int32 id, String name) : base(id, name)
        {
        }

        public String Dimensions
        {
            get
            {
                return this.dimensions;
            }
            set
            {
                this.dimensions = value;
            }
        }

    }

    [Serializable]
    public partial class BinaryVariable : Variable
    {
        private Int32 dataLength;
        private String dimensions;

        internal BinaryVariable(Int32 id, String name, Int32 dataLength = 100) : base(id, name)
        {
            this.dataLength = dataLength;
        }

        public Int32 DataLength
        {
            get
            {
                return this.dataLength;
            }
        }

        public String Dimensions
        {
            get
            {
                return this.dimensions;
            }
            set
            {
                this.dimensions = value;
            }
        }

    }

    [Serializable]
    public partial class BooleanVariable : Variable
    {
        private String dimensions;
        private Boolean? includeInDataset;

        internal BooleanVariable(Int32 id, String name) : base(id, name)
        {
        }

        public String Dimensions
        {
            get
            {
                return this.dimensions;
            }
            set
            {
                this.dimensions = value;
            }
        }

        public Boolean? IncludeInDataset
        {
            get
            {
                return this.includeInDataset;
            }
            set
            {
                this.includeInDataset = value;
            }
        }

    }

    [Serializable]
    public partial class ByteVariable : Variable
    {
        private String dimensions;

        internal ByteVariable(Int32 id, String name) : base(id, name)
        {
        }

        public String Dimensions
        {
            get
            {
                return this.dimensions;
            }
            set
            {
                this.dimensions = value;
            }
        }

    }

    [Serializable]
    public partial class CharVariable : Variable
    {
        private String dimensions;

        internal CharVariable(Int32 id, String name) : base(id, name)
        {
        }

        public String Dimensions
        {
            get
            {
                return this.dimensions;
            }
            set
            {
                this.dimensions = value;
            }
        }

    }

    [Serializable]
    public partial class CodeunitVariable : Variable
    {
        private String dimensions;
        private Int32 subType;

        internal CodeunitVariable(Int32 id, String name, Int32 subType) : base(id, name)
        {
            this.subType = subType;
        }

        public String Dimensions
        {
            get
            {
                return this.dimensions;
            }
            set
            {
                this.dimensions = value;
            }
        }

        public Int32 SubType
        {
            get
            {
                return this.subType;
            }
        }

    }

    [Serializable]
    public partial class CodeVariable : Variable
    {
        private Int32? dataLength;
        private String dimensions;
        private Boolean? includeInDataset;

        internal CodeVariable(Int32 id, String name, Int32? dataLength = null) : base(id, name)
        {
            this.dataLength = dataLength;
        }

        public Int32? DataLength
        {
            get
            {
                return this.dataLength;
            }
        }

        public String Dimensions
        {
            get
            {
                return this.dimensions;
            }
            set
            {
                this.dimensions = value;
            }
        }

        public Boolean? IncludeInDataset
        {
            get
            {
                return this.includeInDataset;
            }
            set
            {
                this.includeInDataset = value;
            }
        }

    }

    [Serializable]
    public partial class DateFormulaVariable : Variable
    {
        private String dimensions;

        internal DateFormulaVariable(Int32 id, String name) : base(id, name)
        {
        }

        public String Dimensions
        {
            get
            {
                return this.dimensions;
            }
            set
            {
                this.dimensions = value;
            }
        }

    }

    [Serializable]
    public partial class DateTimeVariable : Variable
    {
        private String dimensions;

        internal DateTimeVariable(Int32 id, String name) : base(id, name)
        {
        }

        public String Dimensions
        {
            get
            {
                return this.dimensions;
            }
            set
            {
                this.dimensions = value;
            }
        }

    }

    [Serializable]
    public partial class DateVariable : Variable
    {
        private String dimensions;

        internal DateVariable(Int32 id, String name) : base(id, name)
        {
        }

        public String Dimensions
        {
            get
            {
                return this.dimensions;
            }
            set
            {
                this.dimensions = value;
            }
        }

    }

    [Serializable]
    public partial class DecimalVariable : Variable
    {
        private String dimensions;

        internal DecimalVariable(Int32 id, String name) : base(id, name)
        {
        }

        public String Dimensions
        {
            get
            {
                return this.dimensions;
            }
            set
            {
                this.dimensions = value;
            }
        }

    }

    [Serializable]
    public partial class DialogVariable : Variable
    {
        private String dimensions;

        internal DialogVariable(Int32 id, String name) : base(id, name)
        {
        }

        public String Dimensions
        {
            get
            {
                return this.dimensions;
            }
            set
            {
                this.dimensions = value;
            }
        }

    }

    [Serializable]
    public partial class DotNetVariable : Variable
    {
        private String dimensions;
        private Boolean? runOnClient;
        private String subType;
        private Boolean? withEvents;

        internal DotNetVariable(Int32 id, String name, String subType) : base(id, name)
        {
            this.subType = subType;
        }

        public String Dimensions
        {
            get
            {
                return this.dimensions;
            }
            set
            {
                this.dimensions = value;
            }
        }

        public Boolean? RunOnClient
        {
            get
            {
                return this.runOnClient;
            }
            set
            {
                this.runOnClient = value;
            }
        }

        public String SubType
        {
            get
            {
                return this.subType;
            }
        }

        public Boolean? WithEvents
        {
            get
            {
                return this.withEvents;
            }
            set
            {
                this.withEvents = value;
            }
        }

    }

    [Serializable]
    public partial class DurationVariable : Variable
    {
        private String dimensions;

        internal DurationVariable(Int32 id, String name) : base(id, name)
        {
        }

        public String Dimensions
        {
            get
            {
                return this.dimensions;
            }
            set
            {
                this.dimensions = value;
            }
        }

    }

    [Serializable]
    public partial class ExecutionModeVariable : Variable
    {
        private String dimensions;

        internal ExecutionModeVariable(Int32 id, String name) : base(id, name)
        {
        }

        public String Dimensions
        {
            get
            {
                return this.dimensions;
            }
            set
            {
                this.dimensions = value;
            }
        }

    }

    [Serializable]
    public partial class FieldRefVariable : Variable
    {
        private String dimensions;

        internal FieldRefVariable(Int32 id, String name) : base(id, name)
        {
        }

        public String Dimensions
        {
            get
            {
                return this.dimensions;
            }
            set
            {
                this.dimensions = value;
            }
        }

    }

    [Serializable]
    public partial class FileVariable : Variable
    {
        private String dimensions;

        internal FileVariable(Int32 id, String name) : base(id, name)
        {
        }

        public String Dimensions
        {
            get
            {
                return this.dimensions;
            }
            set
            {
                this.dimensions = value;
            }
        }

    }

    [Serializable]
    public partial class GuidVariable : Variable
    {
        private String dimensions;

        internal GuidVariable(Int32 id, String name) : base(id, name)
        {
        }

        public String Dimensions
        {
            get
            {
                return this.dimensions;
            }
            set
            {
                this.dimensions = value;
            }
        }

    }

    [Serializable]
    public partial class InStreamVariable : Variable
    {
        private String dimensions;

        internal InStreamVariable(Int32 id, String name) : base(id, name)
        {
        }

        public String Dimensions
        {
            get
            {
                return this.dimensions;
            }
            set
            {
                this.dimensions = value;
            }
        }

    }

    [Serializable]
    public partial class IntegerVariable : Variable
    {
        private String dimensions;
        private Boolean? includeInDataset;

        internal IntegerVariable(Int32 id, String name) : base(id, name)
        {
        }

        public String Dimensions
        {
            get
            {
                return this.dimensions;
            }
            set
            {
                this.dimensions = value;
            }
        }

        public Boolean? IncludeInDataset
        {
            get
            {
                return this.includeInDataset;
            }
            set
            {
                this.includeInDataset = value;
            }
        }

    }

    [Serializable]
    public partial class KeyRefVariable : Variable
    {
        private String dimensions;

        internal KeyRefVariable(Int32 id, String name) : base(id, name)
        {
        }

        public String Dimensions
        {
            get
            {
                return this.dimensions;
            }
            set
            {
                this.dimensions = value;
            }
        }

    }

    [Serializable]
    public partial class OcxVariable : Variable
    {
        private String dimensions;
        private String subType;

        internal OcxVariable(Int32 id, String name, String subType) : base(id, name)
        {
            this.subType = subType;
        }

        public String Dimensions
        {
            get
            {
                return this.dimensions;
            }
            set
            {
                this.dimensions = value;
            }
        }

        public String SubType
        {
            get
            {
                return this.subType;
            }
        }

    }

    [Serializable]
    public partial class OptionVariable : Variable
    {
        private String dimensions;
        private String optionString;

        internal OptionVariable(Int32 id, String name) : base(id, name)
        {
        }

        public String Dimensions
        {
            get
            {
                return this.dimensions;
            }
            set
            {
                this.dimensions = value;
            }
        }

        public String OptionString
        {
            get
            {
                return this.optionString;
            }
            set
            {
                this.optionString = value;
            }
        }

    }

    [Serializable]
    public partial class OutStreamVariable : Variable
    {
        private String dimensions;

        internal OutStreamVariable(Int32 id, String name) : base(id, name)
        {
        }

        public String Dimensions
        {
            get
            {
                return this.dimensions;
            }
            set
            {
                this.dimensions = value;
            }
        }

    }

    [Serializable]
    public partial class PageVariable : Variable
    {
        private String dimensions;
        private Int32 subType;

        internal PageVariable(Int32 id, String name, Int32 subType) : base(id, name)
        {
            this.subType = subType;
        }

        public String Dimensions
        {
            get
            {
                return this.dimensions;
            }
            set
            {
                this.dimensions = value;
            }
        }

        public Int32 SubType
        {
            get
            {
                return this.subType;
            }
        }

    }

    [Serializable]
    public partial class QueryVariable : Variable
    {
        private String dimensions;
        private QuerySecurityFiltering? securityFiltering;
        private Int32 subType;

        internal QueryVariable(Int32 id, String name, Int32 subType) : base(id, name)
        {
            this.subType = subType;
        }

        public String Dimensions
        {
            get
            {
                return this.dimensions;
            }
            set
            {
                this.dimensions = value;
            }
        }

        public QuerySecurityFiltering? SecurityFiltering
        {
            get
            {
                return this.securityFiltering;
            }
            set
            {
                this.securityFiltering = value;
            }
        }

        public Int32 SubType
        {
            get
            {
                return this.subType;
            }
        }

    }

    [Serializable]
    public partial class RecordIDVariable : Variable
    {
        private String dimensions;

        internal RecordIDVariable(Int32 id, String name) : base(id, name)
        {
        }

        public String Dimensions
        {
            get
            {
                return this.dimensions;
            }
            set
            {
                this.dimensions = value;
            }
        }

    }

    [Serializable]
    public partial class RecordRefVariable : Variable
    {
        private String dimensions;
        private RecordSecurityFiltering? securityFiltering;

        internal RecordRefVariable(Int32 id, String name) : base(id, name)
        {
        }

        public String Dimensions
        {
            get
            {
                return this.dimensions;
            }
            set
            {
                this.dimensions = value;
            }
        }

        public RecordSecurityFiltering? SecurityFiltering
        {
            get
            {
                return this.securityFiltering;
            }
            set
            {
                this.securityFiltering = value;
            }
        }

    }

    [Serializable]
    public partial class RecordVariable : Variable
    {
        private String dimensions;
        private RecordSecurityFiltering? securityFiltering;
        private Int32 subType;
        private Boolean? temporary;

        internal RecordVariable(Int32 id, String name, Int32 subType) : base(id, name)
        {
            this.subType = subType;
        }

        public String Dimensions
        {
            get
            {
                return this.dimensions;
            }
            set
            {
                this.dimensions = value;
            }
        }

        public RecordSecurityFiltering? SecurityFiltering
        {
            get
            {
                return this.securityFiltering;
            }
            set
            {
                this.securityFiltering = value;
            }
        }

        public Int32 SubType
        {
            get
            {
                return this.subType;
            }
        }

        public Boolean? Temporary
        {
            get
            {
                return this.temporary;
            }
            set
            {
                this.temporary = value;
            }
        }

    }

    [Serializable]
    public partial class ReportVariable : Variable
    {
        private String dimensions;
        private Int32 subType;

        internal ReportVariable(Int32 id, String name, Int32 subType) : base(id, name)
        {
            this.subType = subType;
        }

        public String Dimensions
        {
            get
            {
                return this.dimensions;
            }
            set
            {
                this.dimensions = value;
            }
        }

        public Int32 SubType
        {
            get
            {
                return this.subType;
            }
        }

    }

    [Serializable]
    public partial class TestPageVariable : Variable
    {
        private String dimensions;
        private Int32 subType;

        internal TestPageVariable(Int32 id, String name, Int32 subType) : base(id, name)
        {
            this.subType = subType;
        }

        public String Dimensions
        {
            get
            {
                return this.dimensions;
            }
            set
            {
                this.dimensions = value;
            }
        }

        public Int32 SubType
        {
            get
            {
                return this.subType;
            }
        }

    }

    [Serializable]
    public partial class TextConstant : Variable
    {
        private MultiLanguageValue values = new MultiLanguageValue();

        internal TextConstant(Int32 id, String name) : base(id, name)
        {
        }

        public MultiLanguageValue Values
        {
            get
            {
                return this.values;
            }
        }

    }

    [Serializable]
    public partial class TextVariable : Variable
    {
        private Int32? dataLength;
        private String dimensions;
        private Boolean? includeInDataset;

        internal TextVariable(Int32 id, String name, Int32? dataLength = null) : base(id, name)
        {
            this.dataLength = dataLength;
        }

        public Int32? DataLength
        {
            get
            {
                return this.dataLength;
            }
        }

        public String Dimensions
        {
            get
            {
                return this.dimensions;
            }
            set
            {
                this.dimensions = value;
            }
        }

        public Boolean? IncludeInDataset
        {
            get
            {
                return this.includeInDataset;
            }
            set
            {
                this.includeInDataset = value;
            }
        }

    }

    [Serializable]
    public partial class TimeVariable : Variable
    {
        private String dimensions;

        internal TimeVariable(Int32 id, String name) : base(id, name)
        {
        }

        public String Dimensions
        {
            get
            {
                return this.dimensions;
            }
            set
            {
                this.dimensions = value;
            }
        }

    }

    [Serializable]
    public partial class TransactionTypeVariable : Variable
    {
        private String dimensions;

        internal TransactionTypeVariable(Int32 id, String name) : base(id, name)
        {
        }

        public String Dimensions
        {
            get
            {
                return this.dimensions;
            }
            set
            {
                this.dimensions = value;
            }
        }

    }

    [Serializable]
    public partial class VariantVariable : Variable
    {
        private String dimensions;

        internal VariantVariable(Int32 id, String name) : base(id, name)
        {
        }

        public String Dimensions
        {
            get
            {
                return this.dimensions;
            }
            set
            {
                this.dimensions = value;
            }
        }

    }

    [Serializable]
    public partial class XmlPortVariable : Variable
    {
        private String dimensions;
        private Int32 subType;

        internal XmlPortVariable(Int32 id, String name, Int32 subType) : base(id, name)
        {
            this.subType = subType;
        }

        public String Dimensions
        {
            get
            {
                return this.dimensions;
            }
            set
            {
                this.dimensions = value;
            }
        }

        public Int32 SubType
        {
            get
            {
                return this.subType;
            }
        }

    }

    [Serializable]
    public partial class XmlPortFieldAttribute : XmlPortNode
    {
        private XmlPortFieldAttributeProperties properties = new XmlPortFieldAttributeProperties();

        internal XmlPortFieldAttribute(Guid id, String nodeName, Int32? indentationLevel) : base(id, nodeName, indentationLevel)
        {
        }

        public XmlPortFieldAttributeProperties Properties
        {
            get
            {
                return this.properties;
            }
        }

    }

    [Serializable]
    public partial class XmlPortFieldElement : XmlPortNode
    {
        private XmlPortFieldElementProperties properties = new XmlPortFieldElementProperties();

        internal XmlPortFieldElement(Guid id, String nodeName, Int32? indentationLevel) : base(id, nodeName, indentationLevel)
        {
        }

        public XmlPortFieldElementProperties Properties
        {
            get
            {
                return this.properties;
            }
        }

    }

    [Serializable]
    public partial class XmlPortTableAttribute : XmlPortNode
    {
        private XmlPortTableAttributeProperties properties = new XmlPortTableAttributeProperties();

        internal XmlPortTableAttribute(Guid id, String nodeName, Int32? indentationLevel) : base(id, nodeName, indentationLevel)
        {
        }

        public XmlPortTableAttributeProperties Properties
        {
            get
            {
                return this.properties;
            }
        }

    }

    [Serializable]
    public partial class XmlPortTableElement : XmlPortNode
    {
        private XmlPortTableElementProperties properties = new XmlPortTableElementProperties();

        internal XmlPortTableElement(Guid id, String nodeName, Int32? indentationLevel) : base(id, nodeName, indentationLevel)
        {
        }

        public XmlPortTableElementProperties Properties
        {
            get
            {
                return this.properties;
            }
        }

    }

    [Serializable]
    public partial class XmlPortTextAttribute : XmlPortNode
    {
        private XmlPortTextAttributeProperties properties = new XmlPortTextAttributeProperties();

        internal XmlPortTextAttribute(Guid id, String nodeName, Int32? indentationLevel) : base(id, nodeName, indentationLevel)
        {
        }

        public XmlPortTextAttributeProperties Properties
        {
            get
            {
                return this.properties;
            }
        }

    }

    [Serializable]
    public partial class XmlPortTextElement : XmlPortNode
    {
        private XmlPortTextElementProperties properties = new XmlPortTextElementProperties();

        internal XmlPortTextElement(Guid id, String nodeName, Int32? indentationLevel) : base(id, nodeName, indentationLevel)
        {
        }

        public XmlPortTextElementProperties Properties
        {
            get
            {
                return this.properties;
            }
        }

    }

    #endregion
    #region Collections
    [Serializable]
    public class ActionList : IEnumerable<PageActionBase>
    {
        private Dictionary<Int32,PageActionBase> innerList = new Dictionary<Int32,PageActionBase>();

        internal ActionList()
        {
        }

        public PageAction AddPageAction(Int32 id, Int32? indentationLevel)
        {
            PageAction item = new PageAction(id, indentationLevel);
            innerList.Add(id, item);
            return item;
        }

        public PageActionContainer AddPageActionContainer(Int32 id, Int32? indentationLevel)
        {
            PageActionContainer item = new PageActionContainer(id, indentationLevel);
            innerList.Add(id, item);
            return item;
        }

        public PageActionGroup AddPageActionGroup(Int32 id, Int32? indentationLevel)
        {
            PageActionGroup item = new PageActionGroup(id, indentationLevel);
            innerList.Add(id, item);
            return item;
        }

        public PageActionSeparator AddPageActionSeparator(Int32 id, Int32? indentationLevel)
        {
            PageActionSeparator item = new PageActionSeparator(id, indentationLevel);
            innerList.Add(id, item);
            return item;
        }

        public bool Remove(Int32 id)
        {
            return innerList.Remove(id);
        }

        public IEnumerator<PageActionBase> GetEnumerator()
        {
            return innerList.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return innerList.Values.GetEnumerator();
        }
    }

    [Serializable]
    public class CalcFormulaTableFilter : IEnumerable<CalcFormulaTableFilterLine>
    {
        private List<CalcFormulaTableFilterLine> innerList = new List<CalcFormulaTableFilterLine>();

        internal CalcFormulaTableFilter()
        {
        }

        public int FindIndex(Predicate<CalcFormulaTableFilterLine> match)
        {
            return innerList.FindIndex(match);
        }

        public int FindIndex(int startIndex, Predicate<CalcFormulaTableFilterLine> match)
        {
            return innerList.FindIndex(startIndex, match);
        }

        public int FindIndex(int startIndex, int count,Predicate<CalcFormulaTableFilterLine> match)
        {
            return innerList.FindIndex(startIndex, count, match);
        }

        public int FindLastIndex(Predicate<CalcFormulaTableFilterLine> match)
        {
            return innerList.FindLastIndex(match);
        }

        public int FindLastIndex(int startIndex, Predicate<CalcFormulaTableFilterLine> match)
        {
            return innerList.FindLastIndex(startIndex, match);
        }

        public int FindLastIndex(int startIndex, int count, Predicate<CalcFormulaTableFilterLine> match)
        {
            return innerList.FindLastIndex(startIndex, count, match);
        }

        public CalcFormulaTableFilterLine Add(String fieldName, CalcFormulaTableFilterType type, String value)
        {
            CalcFormulaTableFilterLine item = new CalcFormulaTableFilterLine(fieldName, type, value);
            innerList.Add(item);
            return item;
        }

        public CalcFormulaTableFilterLine Insert(int index, String fieldName, CalcFormulaTableFilterType type, String value)
        {
            CalcFormulaTableFilterLine item = new CalcFormulaTableFilterLine(fieldName, type, value);
            innerList.Insert(index, item);
            return item;
        }

        public void RemoveAt(int index)
        {
            innerList.RemoveAt(index);
        }

        public IEnumerator<CalcFormulaTableFilterLine> GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return innerList.GetEnumerator();
        }
    }

    [Serializable]
    public class CodeLines : IEnumerable<CodeLine>
    {
        private List<CodeLine> innerList = new List<CodeLine>();

        internal CodeLines()
        {
        }

        public int FindIndex(Predicate<CodeLine> match)
        {
            return innerList.FindIndex(match);
        }

        public int FindIndex(int startIndex, Predicate<CodeLine> match)
        {
            return innerList.FindIndex(startIndex, match);
        }

        public int FindIndex(int startIndex, int count,Predicate<CodeLine> match)
        {
            return innerList.FindIndex(startIndex, count, match);
        }

        public int FindLastIndex(Predicate<CodeLine> match)
        {
            return innerList.FindLastIndex(match);
        }

        public int FindLastIndex(int startIndex, Predicate<CodeLine> match)
        {
            return innerList.FindLastIndex(startIndex, match);
        }

        public int FindLastIndex(int startIndex, int count, Predicate<CodeLine> match)
        {
            return innerList.FindLastIndex(startIndex, count, match);
        }

        public CodeLine Add(String text)
        {
            CodeLine item = new CodeLine(text);
            innerList.Add(item);
            return item;
        }

        public CodeLine Add(string format, params object[] args)
        {
            CodeLine item = new CodeLine(string.Format(format, args));
            innerList.Add(item);
            return item;
        }

        public CodeLine Insert(int index, String text)
        {
            CodeLine item = new CodeLine(text);
            innerList.Insert(index, item);
            return item;
        }

        public void RemoveAt(int index)
        {
            innerList.RemoveAt(index);
        }

        public IEnumerator<CodeLine> GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return innerList.GetEnumerator();
        }
    }

    [Serializable]
    public class Codeunits : IEnumerable<Codeunit>
    {
        private Dictionary<Int32,Codeunit> innerList = new Dictionary<Int32,Codeunit>();

        internal Codeunits()
        {
        }

        public Codeunit Add(Int32 id, String name)
        {
            Codeunit item = new Codeunit(id, name);
            innerList.Add(id, item);
            return item;
        }

        public bool Remove(Int32 id)
        {
            return innerList.Remove(id);
        }

        public IEnumerator<Codeunit> GetEnumerator()
        {
            return innerList.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return innerList.Values.GetEnumerator();
        }
    }

    [Serializable]
    public class ColumnFilter : IEnumerable<ColumnFilterLine>
    {
        private List<ColumnFilterLine> innerList = new List<ColumnFilterLine>();

        internal ColumnFilter()
        {
        }

        public int FindIndex(Predicate<ColumnFilterLine> match)
        {
            return innerList.FindIndex(match);
        }

        public int FindIndex(int startIndex, Predicate<ColumnFilterLine> match)
        {
            return innerList.FindIndex(startIndex, match);
        }

        public int FindIndex(int startIndex, int count,Predicate<ColumnFilterLine> match)
        {
            return innerList.FindIndex(startIndex, count, match);
        }

        public int FindLastIndex(Predicate<ColumnFilterLine> match)
        {
            return innerList.FindLastIndex(match);
        }

        public int FindLastIndex(int startIndex, Predicate<ColumnFilterLine> match)
        {
            return innerList.FindLastIndex(startIndex, match);
        }

        public int FindLastIndex(int startIndex, int count, Predicate<ColumnFilterLine> match)
        {
            return innerList.FindLastIndex(startIndex, count, match);
        }

        public ColumnFilterLine Add(String column, ColumnFilterLineType type, String value)
        {
            ColumnFilterLine item = new ColumnFilterLine(column, type, value);
            innerList.Add(item);
            return item;
        }

        public ColumnFilterLine Insert(int index, String column, ColumnFilterLineType type, String value)
        {
            ColumnFilterLine item = new ColumnFilterLine(column, type, value);
            innerList.Insert(index, item);
            return item;
        }

        public void RemoveAt(int index)
        {
            innerList.RemoveAt(index);
        }

        public IEnumerator<ColumnFilterLine> GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return innerList.GetEnumerator();
        }
    }

    [Serializable]
    public class ControlList : IEnumerable<ControlReference>
    {
        private List<ControlReference> innerList = new List<ControlReference>();

        internal ControlList()
        {
        }

        public int FindIndex(Predicate<ControlReference> match)
        {
            return innerList.FindIndex(match);
        }

        public int FindIndex(int startIndex, Predicate<ControlReference> match)
        {
            return innerList.FindIndex(startIndex, match);
        }

        public int FindIndex(int startIndex, int count,Predicate<ControlReference> match)
        {
            return innerList.FindIndex(startIndex, count, match);
        }

        public int FindLastIndex(Predicate<ControlReference> match)
        {
            return innerList.FindLastIndex(match);
        }

        public int FindLastIndex(int startIndex, Predicate<ControlReference> match)
        {
            return innerList.FindLastIndex(startIndex, match);
        }

        public int FindLastIndex(int startIndex, int count, Predicate<ControlReference> match)
        {
            return innerList.FindLastIndex(startIndex, count, match);
        }

        public ControlReference Add(String controlName)
        {
            ControlReference item = new ControlReference(controlName);
            innerList.Add(item);
            return item;
        }

        public void AddRange(params String[] controlNames)
        {
            foreach(var item in controlNames)
            {
               innerList.Add(new ControlReference(item));
             }
        }

        public ControlReference Insert(int index, String controlName)
        {
            ControlReference item = new ControlReference(controlName);
            innerList.Insert(index, item);
            return item;
        }

        public void RemoveAt(int index)
        {
            innerList.RemoveAt(index);
        }

        public IEnumerator<ControlReference> GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return innerList.GetEnumerator();
        }
    }

    [Serializable]
    public class DataItemQueryElementTableFilter : IEnumerable<DataItemQueryElementTableFilterLine>
    {
        private List<DataItemQueryElementTableFilterLine> innerList = new List<DataItemQueryElementTableFilterLine>();

        internal DataItemQueryElementTableFilter()
        {
        }

        public int FindIndex(Predicate<DataItemQueryElementTableFilterLine> match)
        {
            return innerList.FindIndex(match);
        }

        public int FindIndex(int startIndex, Predicate<DataItemQueryElementTableFilterLine> match)
        {
            return innerList.FindIndex(startIndex, match);
        }

        public int FindIndex(int startIndex, int count,Predicate<DataItemQueryElementTableFilterLine> match)
        {
            return innerList.FindIndex(startIndex, count, match);
        }

        public int FindLastIndex(Predicate<DataItemQueryElementTableFilterLine> match)
        {
            return innerList.FindLastIndex(match);
        }

        public int FindLastIndex(int startIndex, Predicate<DataItemQueryElementTableFilterLine> match)
        {
            return innerList.FindLastIndex(startIndex, match);
        }

        public int FindLastIndex(int startIndex, int count, Predicate<DataItemQueryElementTableFilterLine> match)
        {
            return innerList.FindLastIndex(startIndex, count, match);
        }

        public DataItemQueryElementTableFilterLine Add(String fieldName, DataItemQueryElementTableFilterLineType type, String value)
        {
            DataItemQueryElementTableFilterLine item = new DataItemQueryElementTableFilterLine(fieldName, type, value);
            innerList.Add(item);
            return item;
        }

        public DataItemQueryElementTableFilterLine Insert(int index, String fieldName, DataItemQueryElementTableFilterLineType type, String value)
        {
            DataItemQueryElementTableFilterLine item = new DataItemQueryElementTableFilterLine(fieldName, type, value);
            innerList.Insert(index, item);
            return item;
        }

        public void RemoveAt(int index)
        {
            innerList.RemoveAt(index);
        }

        public IEnumerator<DataItemQueryElementTableFilterLine> GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return innerList.GetEnumerator();
        }
    }

    [Serializable]
    public class Events : IEnumerable<Event>
    {
        private List<Event> innerList = new List<Event>();

        internal Events()
        {
        }

        public Event Add(Int32 sourceID, String sourceName, Int32 id, String name)
        {
            Event item = new Event(sourceID, sourceName, id, name);
            innerList.Add(item);
            return item;
        }

        public void RemoveAt(int index)
        {
            innerList.RemoveAt(index);
        }

        public IEnumerator<Event> GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return innerList.GetEnumerator();
        }
    }

    [Serializable]
    public class FieldList : IEnumerable<FieldReference>
    {
        private List<FieldReference> innerList = new List<FieldReference>();

        internal FieldList()
        {
        }

        public int FindIndex(Predicate<FieldReference> match)
        {
            return innerList.FindIndex(match);
        }

        public int FindIndex(int startIndex, Predicate<FieldReference> match)
        {
            return innerList.FindIndex(startIndex, match);
        }

        public int FindIndex(int startIndex, int count,Predicate<FieldReference> match)
        {
            return innerList.FindIndex(startIndex, count, match);
        }

        public int FindLastIndex(Predicate<FieldReference> match)
        {
            return innerList.FindLastIndex(match);
        }

        public int FindLastIndex(int startIndex, Predicate<FieldReference> match)
        {
            return innerList.FindLastIndex(startIndex, match);
        }

        public int FindLastIndex(int startIndex, int count, Predicate<FieldReference> match)
        {
            return innerList.FindLastIndex(startIndex, count, match);
        }

        public FieldReference Add(String fieldName)
        {
            FieldReference item = new FieldReference(fieldName);
            innerList.Add(item);
            return item;
        }

        public void AddRange(params String[] fieldNames)
        {
            foreach(var item in fieldNames)
            {
               innerList.Add(new FieldReference(item));
             }
        }

        public FieldReference Insert(int index, String fieldName)
        {
            FieldReference item = new FieldReference(fieldName);
            innerList.Insert(index, item);
            return item;
        }

        public void RemoveAt(int index)
        {
            innerList.RemoveAt(index);
        }

        public IEnumerator<FieldReference> GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return innerList.GetEnumerator();
        }
    }

    [Serializable]
    public class Functions : IEnumerable<Function>
    {
        private Dictionary<Int32,Function> innerList = new Dictionary<Int32,Function>();

        internal Functions()
        {
        }

        public Function Add(Int32 id, String name)
        {
            Function item = new Function(id, name);
            innerList.Add(id, item);
            return item;
        }

        public bool Remove(Int32 id)
        {
            return innerList.Remove(id);
        }

        public IEnumerator<Function> GetEnumerator()
        {
            return innerList.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return innerList.Values.GetEnumerator();
        }
    }

    [Serializable]
    public class LinkFields : IEnumerable<LinkField>
    {
        private List<LinkField> innerList = new List<LinkField>();

        internal LinkFields()
        {
        }

        public int FindIndex(Predicate<LinkField> match)
        {
            return innerList.FindIndex(match);
        }

        public int FindIndex(int startIndex, Predicate<LinkField> match)
        {
            return innerList.FindIndex(startIndex, match);
        }

        public int FindIndex(int startIndex, int count,Predicate<LinkField> match)
        {
            return innerList.FindIndex(startIndex, count, match);
        }

        public int FindLastIndex(Predicate<LinkField> match)
        {
            return innerList.FindLastIndex(match);
        }

        public int FindLastIndex(int startIndex, Predicate<LinkField> match)
        {
            return innerList.FindLastIndex(startIndex, match);
        }

        public int FindLastIndex(int startIndex, int count, Predicate<LinkField> match)
        {
            return innerList.FindLastIndex(startIndex, count, match);
        }

        public LinkField Add(Int32 field, Int32 referenceField)
        {
            LinkField item = new LinkField(field, referenceField);
            innerList.Add(item);
            return item;
        }

        public LinkField Insert(int index, Int32 field, Int32 referenceField)
        {
            LinkField item = new LinkField(field, referenceField);
            innerList.Insert(index, item);
            return item;
        }

        public void RemoveAt(int index)
        {
            innerList.RemoveAt(index);
        }

        public IEnumerator<LinkField> GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return innerList.GetEnumerator();
        }
    }

    [Serializable]
    public class MenuSuiteNodes : IEnumerable<MenuSuiteNode>
    {
        private Dictionary<Guid,MenuSuiteNode> innerList = new Dictionary<Guid,MenuSuiteNode>();

        internal MenuSuiteNodes()
        {
        }

        public DeltaNode AddDeltaNode(Guid id)
        {
            DeltaNode item = new DeltaNode(id);
            innerList.Add(id, item);
            return item;
        }

        public GroupNode AddGroupNode(Guid id)
        {
            GroupNode item = new GroupNode(id);
            innerList.Add(id, item);
            return item;
        }

        public ItemNode AddItemNode(Guid id)
        {
            ItemNode item = new ItemNode(id);
            innerList.Add(id, item);
            return item;
        }

        public MenuNode AddMenuNode(Guid id)
        {
            MenuNode item = new MenuNode(id);
            innerList.Add(id, item);
            return item;
        }

        public RootNode AddRootNode(Guid id)
        {
            RootNode item = new RootNode(id);
            innerList.Add(id, item);
            return item;
        }

        public bool Remove(Guid id)
        {
            return innerList.Remove(id);
        }

        public IEnumerator<MenuSuiteNode> GetEnumerator()
        {
            return innerList.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return innerList.Values.GetEnumerator();
        }
    }

    [Serializable]
    public class MenuSuites : IEnumerable<MenuSuite>
    {
        private Dictionary<Int32,MenuSuite> innerList = new Dictionary<Int32,MenuSuite>();

        internal MenuSuites()
        {
        }

        public MenuSuite Add(Int32 id, String name)
        {
            MenuSuite item = new MenuSuite(id, name);
            innerList.Add(id, item);
            return item;
        }

        public bool Remove(Int32 id)
        {
            return innerList.Remove(id);
        }

        public IEnumerator<MenuSuite> GetEnumerator()
        {
            return innerList.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return innerList.Values.GetEnumerator();
        }
    }

    [Serializable]
    public class MultiLanguageValue : IEnumerable<MultiLanguageEntry>
    {
        private Dictionary<String,MultiLanguageEntry> innerList = new Dictionary<String,MultiLanguageEntry>();

        internal MultiLanguageValue()
        {
        }

        public MultiLanguageEntry Add(String languageID, String value)
        {
            MultiLanguageEntry item = new MultiLanguageEntry(languageID, value);
            innerList.Add(languageID, item);
            return item;
        }

        public bool Remove(String languageID)
        {
            return innerList.Remove(languageID);
        }

        public IEnumerator<MultiLanguageEntry> GetEnumerator()
        {
            return innerList.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return innerList.Values.GetEnumerator();
        }
    }

    [Serializable]
    public class PageActions : IEnumerable<PageActionBase>
    {
        private Dictionary<Int32,PageActionBase> innerList = new Dictionary<Int32,PageActionBase>();

        internal PageActions()
        {
        }

        public PageAction AddPageAction(Int32 id, Int32? indentationLevel)
        {
            PageAction item = new PageAction(id, indentationLevel);
            innerList.Add(id, item);
            return item;
        }

        public PageActionContainer AddPageActionContainer(Int32 id, Int32? indentationLevel)
        {
            PageActionContainer item = new PageActionContainer(id, indentationLevel);
            innerList.Add(id, item);
            return item;
        }

        public PageActionGroup AddPageActionGroup(Int32 id, Int32? indentationLevel)
        {
            PageActionGroup item = new PageActionGroup(id, indentationLevel);
            innerList.Add(id, item);
            return item;
        }

        public PageActionSeparator AddPageActionSeparator(Int32 id, Int32? indentationLevel)
        {
            PageActionSeparator item = new PageActionSeparator(id, indentationLevel);
            innerList.Add(id, item);
            return item;
        }

        public bool Remove(Int32 id)
        {
            return innerList.Remove(id);
        }

        public IEnumerator<PageActionBase> GetEnumerator()
        {
            return innerList.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return innerList.Values.GetEnumerator();
        }
    }

    [Serializable]
    public class PageControls : IEnumerable<PageControl>
    {
        private Dictionary<Int32,PageControl> innerList = new Dictionary<Int32,PageControl>();

        internal PageControls()
        {
        }

        public ContainerPageControl AddContainerPageControl(Int32 id, Int32? indentationLevel)
        {
            ContainerPageControl item = new ContainerPageControl(id, indentationLevel);
            innerList.Add(id, item);
            return item;
        }

        public FieldPageControl AddFieldPageControl(Int32 id, Int32? indentationLevel)
        {
            FieldPageControl item = new FieldPageControl(id, indentationLevel);
            innerList.Add(id, item);
            return item;
        }

        public GroupPageControl AddGroupPageControl(Int32 id, Int32? indentationLevel)
        {
            GroupPageControl item = new GroupPageControl(id, indentationLevel);
            innerList.Add(id, item);
            return item;
        }

        public PartPageControl AddPartPageControl(Int32 id, Int32? indentationLevel)
        {
            PartPageControl item = new PartPageControl(id, indentationLevel);
            innerList.Add(id, item);
            return item;
        }

        public bool Remove(Int32 id)
        {
            return innerList.Remove(id);
        }

        public IEnumerator<PageControl> GetEnumerator()
        {
            return innerList.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return innerList.Values.GetEnumerator();
        }
    }

    [Serializable]
    public class Pages : IEnumerable<Page>
    {
        private Dictionary<Int32,Page> innerList = new Dictionary<Int32,Page>();

        internal Pages()
        {
        }

        public Page Add(Int32 id, String name)
        {
            Page item = new Page(id, name);
            innerList.Add(id, item);
            return item;
        }

        public bool Remove(Int32 id)
        {
            return innerList.Remove(id);
        }

        public IEnumerator<Page> GetEnumerator()
        {
            return innerList.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return innerList.Values.GetEnumerator();
        }
    }

    [Serializable]
    public class Parameters : IEnumerable<Parameter>
    {
        private Dictionary<Int32,Parameter> innerList = new Dictionary<Int32,Parameter>();

        internal Parameters()
        {
        }

        public ActionParameter AddActionParameter(Boolean var, Int32 id, String name)
        {
            ActionParameter item = new ActionParameter(var, id, name);
            innerList.Add(id, item);
            return item;
        }

        public AutomationParameter AddAutomationParameter(Boolean var, Int32 id, String name, String subType)
        {
            AutomationParameter item = new AutomationParameter(var, id, name, subType);
            innerList.Add(id, item);
            return item;
        }

        public BigIntegerParameter AddBigIntegerParameter(Boolean var, Int32 id, String name)
        {
            BigIntegerParameter item = new BigIntegerParameter(var, id, name);
            innerList.Add(id, item);
            return item;
        }

        public BigTextParameter AddBigTextParameter(Boolean var, Int32 id, String name)
        {
            BigTextParameter item = new BigTextParameter(var, id, name);
            innerList.Add(id, item);
            return item;
        }

        public BinaryParameter AddBinaryParameter(Boolean var, Int32 id, String name, Int32 dataLength = 100)
        {
            BinaryParameter item = new BinaryParameter(var, id, name, dataLength);
            innerList.Add(id, item);
            return item;
        }

        public BooleanParameter AddBooleanParameter(Boolean var, Int32 id, String name)
        {
            BooleanParameter item = new BooleanParameter(var, id, name);
            innerList.Add(id, item);
            return item;
        }

        public ByteParameter AddByteParameter(Boolean var, Int32 id, String name)
        {
            ByteParameter item = new ByteParameter(var, id, name);
            innerList.Add(id, item);
            return item;
        }

        public CharParameter AddCharParameter(Boolean var, Int32 id, String name)
        {
            CharParameter item = new CharParameter(var, id, name);
            innerList.Add(id, item);
            return item;
        }

        public CodeParameter AddCodeParameter(Boolean var, Int32 id, String name, Int32? dataLength = null)
        {
            CodeParameter item = new CodeParameter(var, id, name, dataLength);
            innerList.Add(id, item);
            return item;
        }

        public CodeunitParameter AddCodeunitParameter(Boolean var, Int32 id, String name, Int32 subType)
        {
            CodeunitParameter item = new CodeunitParameter(var, id, name, subType);
            innerList.Add(id, item);
            return item;
        }

        public DateFormulaParameter AddDateFormulaParameter(Boolean var, Int32 id, String name)
        {
            DateFormulaParameter item = new DateFormulaParameter(var, id, name);
            innerList.Add(id, item);
            return item;
        }

        public DateParameter AddDateParameter(Boolean var, Int32 id, String name)
        {
            DateParameter item = new DateParameter(var, id, name);
            innerList.Add(id, item);
            return item;
        }

        public DateTimeParameter AddDateTimeParameter(Boolean var, Int32 id, String name)
        {
            DateTimeParameter item = new DateTimeParameter(var, id, name);
            innerList.Add(id, item);
            return item;
        }

        public DecimalParameter AddDecimalParameter(Boolean var, Int32 id, String name)
        {
            DecimalParameter item = new DecimalParameter(var, id, name);
            innerList.Add(id, item);
            return item;
        }

        public DialogParameter AddDialogParameter(Boolean var, Int32 id, String name)
        {
            DialogParameter item = new DialogParameter(var, id, name);
            innerList.Add(id, item);
            return item;
        }

        public DotNetParameter AddDotNetParameter(Boolean var, Int32 id, String name, String subType)
        {
            DotNetParameter item = new DotNetParameter(var, id, name, subType);
            innerList.Add(id, item);
            return item;
        }

        public DurationParameter AddDurationParameter(Boolean var, Int32 id, String name)
        {
            DurationParameter item = new DurationParameter(var, id, name);
            innerList.Add(id, item);
            return item;
        }

        public ExecutionModeParameter AddExecutionModeParameter(Boolean var, Int32 id, String name)
        {
            ExecutionModeParameter item = new ExecutionModeParameter(var, id, name);
            innerList.Add(id, item);
            return item;
        }

        public FieldRefParameter AddFieldRefParameter(Boolean var, Int32 id, String name)
        {
            FieldRefParameter item = new FieldRefParameter(var, id, name);
            innerList.Add(id, item);
            return item;
        }

        public FileParameter AddFileParameter(Boolean var, Int32 id, String name)
        {
            FileParameter item = new FileParameter(var, id, name);
            innerList.Add(id, item);
            return item;
        }

        public GuidParameter AddGuidParameter(Boolean var, Int32 id, String name)
        {
            GuidParameter item = new GuidParameter(var, id, name);
            innerList.Add(id, item);
            return item;
        }

        public InStreamParameter AddInStreamParameter(Boolean var, Int32 id, String name)
        {
            InStreamParameter item = new InStreamParameter(var, id, name);
            innerList.Add(id, item);
            return item;
        }

        public IntegerParameter AddIntegerParameter(Boolean var, Int32 id, String name)
        {
            IntegerParameter item = new IntegerParameter(var, id, name);
            innerList.Add(id, item);
            return item;
        }

        public KeyRefParameter AddKeyRefParameter(Boolean var, Int32 id, String name)
        {
            KeyRefParameter item = new KeyRefParameter(var, id, name);
            innerList.Add(id, item);
            return item;
        }

        public OcxParameter AddOcxParameter(Boolean var, Int32 id, String name, String subType)
        {
            OcxParameter item = new OcxParameter(var, id, name, subType);
            innerList.Add(id, item);
            return item;
        }

        public OptionParameter AddOptionParameter(Boolean var, Int32 id, String name)
        {
            OptionParameter item = new OptionParameter(var, id, name);
            innerList.Add(id, item);
            return item;
        }

        public OutStreamParameter AddOutStreamParameter(Boolean var, Int32 id, String name)
        {
            OutStreamParameter item = new OutStreamParameter(var, id, name);
            innerList.Add(id, item);
            return item;
        }

        public PageParameter AddPageParameter(Boolean var, Int32 id, String name, Int32 subType)
        {
            PageParameter item = new PageParameter(var, id, name, subType);
            innerList.Add(id, item);
            return item;
        }

        public QueryParameter AddQueryParameter(Boolean var, Int32 id, String name, Int32 subType)
        {
            QueryParameter item = new QueryParameter(var, id, name, subType);
            innerList.Add(id, item);
            return item;
        }

        public RecordIDParameter AddRecordIDParameter(Boolean var, Int32 id, String name)
        {
            RecordIDParameter item = new RecordIDParameter(var, id, name);
            innerList.Add(id, item);
            return item;
        }

        public RecordParameter AddRecordParameter(Boolean var, Int32 id, String name, Int32 subType)
        {
            RecordParameter item = new RecordParameter(var, id, name, subType);
            innerList.Add(id, item);
            return item;
        }

        public RecordRefParameter AddRecordRefParameter(Boolean var, Int32 id, String name)
        {
            RecordRefParameter item = new RecordRefParameter(var, id, name);
            innerList.Add(id, item);
            return item;
        }

        public ReportParameter AddReportParameter(Boolean var, Int32 id, String name, Int32 subType)
        {
            ReportParameter item = new ReportParameter(var, id, name, subType);
            innerList.Add(id, item);
            return item;
        }

        public TestPageParameter AddTestPageParameter(Boolean var, Int32 id, String name, Int32 subType)
        {
            TestPageParameter item = new TestPageParameter(var, id, name, subType);
            innerList.Add(id, item);
            return item;
        }

        public TestRequestPageParameter AddTestRequestPageParameter(Boolean var, Int32 id, String name, Int32 subType)
        {
            TestRequestPageParameter item = new TestRequestPageParameter(var, id, name, subType);
            innerList.Add(id, item);
            return item;
        }

        public TextParameter AddTextParameter(Boolean var, Int32 id, String name, Int32? dataLength = null)
        {
            TextParameter item = new TextParameter(var, id, name, dataLength);
            innerList.Add(id, item);
            return item;
        }

        public TimeParameter AddTimeParameter(Boolean var, Int32 id, String name)
        {
            TimeParameter item = new TimeParameter(var, id, name);
            innerList.Add(id, item);
            return item;
        }

        public TransactionTypeParameter AddTransactionTypeParameter(Boolean var, Int32 id, String name)
        {
            TransactionTypeParameter item = new TransactionTypeParameter(var, id, name);
            innerList.Add(id, item);
            return item;
        }

        public VariantParameter AddVariantParameter(Boolean var, Int32 id, String name)
        {
            VariantParameter item = new VariantParameter(var, id, name);
            innerList.Add(id, item);
            return item;
        }

        public XmlPortParameter AddXmlPortParameter(Boolean var, Int32 id, String name, Int32 subType)
        {
            XmlPortParameter item = new XmlPortParameter(var, id, name, subType);
            innerList.Add(id, item);
            return item;
        }

        public bool Remove(Int32 id)
        {
            return innerList.Remove(id);
        }

        public IEnumerator<Parameter> GetEnumerator()
        {
            return innerList.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return innerList.Values.GetEnumerator();
        }
    }

    [Serializable]
    public class Permissions : IEnumerable<Permission>
    {
        private Dictionary<Int32,Permission> innerList = new Dictionary<Int32,Permission>();

        internal Permissions()
        {
        }

        public Permission Add(Int32 tableID, Boolean readPermission, Boolean insertPermission, Boolean modifyPermission, Boolean deletePermission)
        {
            Permission item = new Permission(tableID, readPermission, insertPermission, modifyPermission, deletePermission);
            innerList.Add(tableID, item);
            return item;
        }

        public bool Remove(Int32 tableID)
        {
            return innerList.Remove(tableID);
        }

        public IEnumerator<Permission> GetEnumerator()
        {
            return innerList.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return innerList.Values.GetEnumerator();
        }
    }

    [Serializable]
    public class Queries : IEnumerable<Query>
    {
        private Dictionary<Int32,Query> innerList = new Dictionary<Int32,Query>();

        internal Queries()
        {
        }

        public Query Add(Int32 id, String name)
        {
            Query item = new Query(id, name);
            innerList.Add(id, item);
            return item;
        }

        public bool Remove(Int32 id)
        {
            return innerList.Remove(id);
        }

        public IEnumerator<Query> GetEnumerator()
        {
            return innerList.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return innerList.Values.GetEnumerator();
        }
    }

    [Serializable]
    public class QueryDataItemLink : IEnumerable<QueryDataItemLinkLine>
    {
        private List<QueryDataItemLinkLine> innerList = new List<QueryDataItemLinkLine>();

        internal QueryDataItemLink()
        {
        }

        public int FindIndex(Predicate<QueryDataItemLinkLine> match)
        {
            return innerList.FindIndex(match);
        }

        public int FindIndex(int startIndex, Predicate<QueryDataItemLinkLine> match)
        {
            return innerList.FindIndex(startIndex, match);
        }

        public int FindIndex(int startIndex, int count,Predicate<QueryDataItemLinkLine> match)
        {
            return innerList.FindIndex(startIndex, count, match);
        }

        public int FindLastIndex(Predicate<QueryDataItemLinkLine> match)
        {
            return innerList.FindLastIndex(match);
        }

        public int FindLastIndex(int startIndex, Predicate<QueryDataItemLinkLine> match)
        {
            return innerList.FindLastIndex(startIndex, match);
        }

        public int FindLastIndex(int startIndex, int count, Predicate<QueryDataItemLinkLine> match)
        {
            return innerList.FindLastIndex(startIndex, count, match);
        }

        public QueryDataItemLinkLine Add(String field, String referenceTable, String referenceField)
        {
            QueryDataItemLinkLine item = new QueryDataItemLinkLine(field, referenceTable, referenceField);
            innerList.Add(item);
            return item;
        }

        public QueryDataItemLinkLine Insert(int index, String field, String referenceTable, String referenceField)
        {
            QueryDataItemLinkLine item = new QueryDataItemLinkLine(field, referenceTable, referenceField);
            innerList.Insert(index, item);
            return item;
        }

        public void RemoveAt(int index)
        {
            innerList.RemoveAt(index);
        }

        public IEnumerator<QueryDataItemLinkLine> GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return innerList.GetEnumerator();
        }
    }

    [Serializable]
    public class QueryElements : IEnumerable<QueryElement>
    {
        private Dictionary<Int32,QueryElement> innerList = new Dictionary<Int32,QueryElement>();

        internal QueryElements()
        {
        }

        public ColumnQueryElement AddColumnQueryElement(Int32 id, String name, Int32? indentationLevel)
        {
            ColumnQueryElement item = new ColumnQueryElement(id, name, indentationLevel);
            innerList.Add(id, item);
            return item;
        }

        public DataItemQueryElement AddDataItemQueryElement(Int32 id, String name, Int32? indentationLevel)
        {
            DataItemQueryElement item = new DataItemQueryElement(id, name, indentationLevel);
            innerList.Add(id, item);
            return item;
        }

        public FilterQueryElement AddFilterQueryElement(Int32 id, String name, Int32? indentationLevel)
        {
            FilterQueryElement item = new FilterQueryElement(id, name, indentationLevel);
            innerList.Add(id, item);
            return item;
        }

        public bool Remove(Int32 id)
        {
            return innerList.Remove(id);
        }

        public IEnumerator<QueryElement> GetEnumerator()
        {
            return innerList.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return innerList.Values.GetEnumerator();
        }
    }

    [Serializable]
    public class QueryOrderByLines : IEnumerable<QueryOrderByLine>
    {
        private List<QueryOrderByLine> innerList = new List<QueryOrderByLine>();

        internal QueryOrderByLines()
        {
        }

        public int FindIndex(Predicate<QueryOrderByLine> match)
        {
            return innerList.FindIndex(match);
        }

        public int FindIndex(int startIndex, Predicate<QueryOrderByLine> match)
        {
            return innerList.FindIndex(startIndex, match);
        }

        public int FindIndex(int startIndex, int count,Predicate<QueryOrderByLine> match)
        {
            return innerList.FindIndex(startIndex, count, match);
        }

        public int FindLastIndex(Predicate<QueryOrderByLine> match)
        {
            return innerList.FindLastIndex(match);
        }

        public int FindLastIndex(int startIndex, Predicate<QueryOrderByLine> match)
        {
            return innerList.FindLastIndex(startIndex, match);
        }

        public int FindLastIndex(int startIndex, int count, Predicate<QueryOrderByLine> match)
        {
            return innerList.FindLastIndex(startIndex, count, match);
        }

        public QueryOrderByLine Add(String column, QueryOrderByDirection direction)
        {
            QueryOrderByLine item = new QueryOrderByLine(column, direction);
            innerList.Add(item);
            return item;
        }

        public QueryOrderByLine Insert(int index, String column, QueryOrderByDirection direction)
        {
            QueryOrderByLine item = new QueryOrderByLine(column, direction);
            innerList.Insert(index, item);
            return item;
        }

        public void RemoveAt(int index)
        {
            innerList.RemoveAt(index);
        }

        public IEnumerator<QueryOrderByLine> GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return innerList.GetEnumerator();
        }
    }

    [Serializable]
    public class ReportDataItemLink : IEnumerable<ReportDataItemLinkLine>
    {
        private List<ReportDataItemLinkLine> innerList = new List<ReportDataItemLinkLine>();

        internal ReportDataItemLink()
        {
        }

        public int FindIndex(Predicate<ReportDataItemLinkLine> match)
        {
            return innerList.FindIndex(match);
        }

        public int FindIndex(int startIndex, Predicate<ReportDataItemLinkLine> match)
        {
            return innerList.FindIndex(startIndex, match);
        }

        public int FindIndex(int startIndex, int count,Predicate<ReportDataItemLinkLine> match)
        {
            return innerList.FindIndex(startIndex, count, match);
        }

        public int FindLastIndex(Predicate<ReportDataItemLinkLine> match)
        {
            return innerList.FindLastIndex(match);
        }

        public int FindLastIndex(int startIndex, Predicate<ReportDataItemLinkLine> match)
        {
            return innerList.FindLastIndex(startIndex, match);
        }

        public int FindLastIndex(int startIndex, int count, Predicate<ReportDataItemLinkLine> match)
        {
            return innerList.FindLastIndex(startIndex, count, match);
        }

        public ReportDataItemLinkLine Add(String fieldName, String referenceFieldName)
        {
            ReportDataItemLinkLine item = new ReportDataItemLinkLine(fieldName, referenceFieldName);
            innerList.Add(item);
            return item;
        }

        public ReportDataItemLinkLine Insert(int index, String fieldName, String referenceFieldName)
        {
            ReportDataItemLinkLine item = new ReportDataItemLinkLine(fieldName, referenceFieldName);
            innerList.Insert(index, item);
            return item;
        }

        public void RemoveAt(int index)
        {
            innerList.RemoveAt(index);
        }

        public IEnumerator<ReportDataItemLinkLine> GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return innerList.GetEnumerator();
        }
    }

    [Serializable]
    public class ReportElements : IEnumerable<ReportElement>
    {
        private Dictionary<Int32,ReportElement> innerList = new Dictionary<Int32,ReportElement>();

        internal ReportElements()
        {
        }

        public ColumnReportElement AddColumnReportElement(Int32 id, Int32? indentationLevel)
        {
            ColumnReportElement item = new ColumnReportElement(id, indentationLevel);
            innerList.Add(id, item);
            return item;
        }

        public DataItemReportElement AddDataItemReportElement(Int32 id, Int32? indentationLevel)
        {
            DataItemReportElement item = new DataItemReportElement(id, indentationLevel);
            innerList.Add(id, item);
            return item;
        }

        public bool Remove(Int32 id)
        {
            return innerList.Remove(id);
        }

        public IEnumerator<ReportElement> GetEnumerator()
        {
            return innerList.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return innerList.Values.GetEnumerator();
        }
    }

    [Serializable]
    public class ReportLabels : IEnumerable<ReportLabel>
    {
        private Dictionary<Int32,ReportLabel> innerList = new Dictionary<Int32,ReportLabel>();

        internal ReportLabels()
        {
        }

        public ReportLabel Add(Int32 id, String name)
        {
            ReportLabel item = new ReportLabel(id, name);
            innerList.Add(id, item);
            return item;
        }

        public bool Remove(Int32 id)
        {
            return innerList.Remove(id);
        }

        public IEnumerator<ReportLabel> GetEnumerator()
        {
            return innerList.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return innerList.Values.GetEnumerator();
        }
    }

    [Serializable]
    public class Reports : IEnumerable<Report>
    {
        private Dictionary<Int32,Report> innerList = new Dictionary<Int32,Report>();

        internal Reports()
        {
        }

        public Report Add(Int32 id, String name)
        {
            Report item = new Report(id, name);
            innerList.Add(id, item);
            return item;
        }

        public bool Remove(Int32 id)
        {
            return innerList.Remove(id);
        }

        public IEnumerator<Report> GetEnumerator()
        {
            return innerList.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return innerList.Values.GetEnumerator();
        }
    }

    [Serializable]
    public class RunObjectLink : IEnumerable<RunObjectLinkLine>
    {
        private List<RunObjectLinkLine> innerList = new List<RunObjectLinkLine>();

        internal RunObjectLink()
        {
        }

        public int FindIndex(Predicate<RunObjectLinkLine> match)
        {
            return innerList.FindIndex(match);
        }

        public int FindIndex(int startIndex, Predicate<RunObjectLinkLine> match)
        {
            return innerList.FindIndex(startIndex, match);
        }

        public int FindIndex(int startIndex, int count,Predicate<RunObjectLinkLine> match)
        {
            return innerList.FindIndex(startIndex, count, match);
        }

        public int FindLastIndex(Predicate<RunObjectLinkLine> match)
        {
            return innerList.FindLastIndex(match);
        }

        public int FindLastIndex(int startIndex, Predicate<RunObjectLinkLine> match)
        {
            return innerList.FindLastIndex(startIndex, match);
        }

        public int FindLastIndex(int startIndex, int count, Predicate<RunObjectLinkLine> match)
        {
            return innerList.FindLastIndex(startIndex, count, match);
        }

        public RunObjectLinkLine Add(String fieldName, RunObjectLinkLineType type, String value)
        {
            RunObjectLinkLine item = new RunObjectLinkLine(fieldName, type, value);
            innerList.Add(item);
            return item;
        }

        public RunObjectLinkLine Insert(int index, String fieldName, RunObjectLinkLineType type, String value)
        {
            RunObjectLinkLine item = new RunObjectLinkLine(fieldName, type, value);
            innerList.Insert(index, item);
            return item;
        }

        public void RemoveAt(int index)
        {
            innerList.RemoveAt(index);
        }

        public IEnumerator<RunObjectLinkLine> GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return innerList.GetEnumerator();
        }
    }

    [Serializable]
    public class SIFTLevelComponents : IEnumerable<SIFTLevelComponent>
    {
        private List<SIFTLevelComponent> innerList = new List<SIFTLevelComponent>();

        internal SIFTLevelComponents()
        {
        }

        public SIFTLevelComponent Add(String fieldName, String aspect)
        {
            SIFTLevelComponent item = new SIFTLevelComponent(fieldName, aspect);
            innerList.Add(item);
            return item;
        }

        public SIFTLevelComponent Insert(int index, String fieldName, String aspect)
        {
            SIFTLevelComponent item = new SIFTLevelComponent(fieldName, aspect);
            innerList.Insert(index, item);
            return item;
        }

        public void RemoveAt(int index)
        {
            innerList.RemoveAt(index);
        }

        public IEnumerator<SIFTLevelComponent> GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return innerList.GetEnumerator();
        }
    }

    [Serializable]
    public class SIFTLevels : IEnumerable<SIFTLevel>
    {
        private List<SIFTLevel> innerList = new List<SIFTLevel>();

        internal SIFTLevels()
        {
        }

        public SIFTLevel Add()
        {
            SIFTLevel item = new SIFTLevel();
            innerList.Add(item);
            return item;
        }

        public SIFTLevel Insert(int index)
        {
            SIFTLevel item = new SIFTLevel();
            innerList.Insert(index, item);
            return item;
        }

        public void RemoveAt(int index)
        {
            innerList.RemoveAt(index);
        }

        public IEnumerator<SIFTLevel> GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return innerList.GetEnumerator();
        }
    }

    [Serializable]
    public class TableFieldGroups : IEnumerable<TableFieldGroup>
    {
        private Dictionary<Int32,TableFieldGroup> innerList = new Dictionary<Int32,TableFieldGroup>();

        internal TableFieldGroups()
        {
        }

        public TableFieldGroup Add(Int32 id, String name)
        {
            TableFieldGroup item = new TableFieldGroup(id, name);
            innerList.Add(id, item);
            return item;
        }

        public bool Remove(Int32 id)
        {
            return innerList.Remove(id);
        }

        public IEnumerator<TableFieldGroup> GetEnumerator()
        {
            return innerList.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return innerList.Values.GetEnumerator();
        }
    }

    [Serializable]
    public class TableFields : IEnumerable<TableField>
    {
        private Dictionary<Int32,TableField> innerList = new Dictionary<Int32,TableField>();

        internal TableFields()
        {
        }

        public BigIntegerTableField AddBigIntegerTableField(Int32 no, String name)
        {
            BigIntegerTableField item = new BigIntegerTableField(no, name);
            innerList.Add(no, item);
            return item;
        }

        public BinaryTableField AddBinaryTableField(Int32 no, String name, Int32 dataLength = 4)
        {
            BinaryTableField item = new BinaryTableField(no, name, dataLength);
            innerList.Add(no, item);
            return item;
        }

        public BlobTableField AddBlobTableField(Int32 no, String name)
        {
            BlobTableField item = new BlobTableField(no, name);
            innerList.Add(no, item);
            return item;
        }

        public BooleanTableField AddBooleanTableField(Int32 no, String name)
        {
            BooleanTableField item = new BooleanTableField(no, name);
            innerList.Add(no, item);
            return item;
        }

        public CodeTableField AddCodeTableField(Int32 no, String name, Int32 dataLength = 10)
        {
            CodeTableField item = new CodeTableField(no, name, dataLength);
            innerList.Add(no, item);
            return item;
        }

        public DateFormulaTableField AddDateFormulaTableField(Int32 no, String name)
        {
            DateFormulaTableField item = new DateFormulaTableField(no, name);
            innerList.Add(no, item);
            return item;
        }

        public DateTableField AddDateTableField(Int32 no, String name)
        {
            DateTableField item = new DateTableField(no, name);
            innerList.Add(no, item);
            return item;
        }

        public DateTimeTableField AddDateTimeTableField(Int32 no, String name)
        {
            DateTimeTableField item = new DateTimeTableField(no, name);
            innerList.Add(no, item);
            return item;
        }

        public DecimalTableField AddDecimalTableField(Int32 no, String name)
        {
            DecimalTableField item = new DecimalTableField(no, name);
            innerList.Add(no, item);
            return item;
        }

        public DurationTableField AddDurationTableField(Int32 no, String name)
        {
            DurationTableField item = new DurationTableField(no, name);
            innerList.Add(no, item);
            return item;
        }

        public GuidTableField AddGuidTableField(Int32 no, String name)
        {
            GuidTableField item = new GuidTableField(no, name);
            innerList.Add(no, item);
            return item;
        }

        public IntegerTableField AddIntegerTableField(Int32 no, String name)
        {
            IntegerTableField item = new IntegerTableField(no, name);
            innerList.Add(no, item);
            return item;
        }

        public OptionTableField AddOptionTableField(Int32 no, String name)
        {
            OptionTableField item = new OptionTableField(no, name);
            innerList.Add(no, item);
            return item;
        }

        public RecordIDTableField AddRecordIDTableField(Int32 no, String name)
        {
            RecordIDTableField item = new RecordIDTableField(no, name);
            innerList.Add(no, item);
            return item;
        }

        public TableFilterTableField AddTableFilterTableField(Int32 no, String name)
        {
            TableFilterTableField item = new TableFilterTableField(no, name);
            innerList.Add(no, item);
            return item;
        }

        public TextTableField AddTextTableField(Int32 no, String name, Int32 dataLength = 30)
        {
            TextTableField item = new TextTableField(no, name, dataLength);
            innerList.Add(no, item);
            return item;
        }

        public TimeTableField AddTimeTableField(Int32 no, String name)
        {
            TimeTableField item = new TimeTableField(no, name);
            innerList.Add(no, item);
            return item;
        }

        public bool Remove(Int32 no)
        {
            return innerList.Remove(no);
        }

        public IEnumerator<TableField> GetEnumerator()
        {
            return innerList.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return innerList.Values.GetEnumerator();
        }
    }

    [Serializable]
    public class TableFilter : IEnumerable<TableFilterLine>
    {
        private List<TableFilterLine> innerList = new List<TableFilterLine>();

        internal TableFilter()
        {
        }

        public int FindIndex(Predicate<TableFilterLine> match)
        {
            return innerList.FindIndex(match);
        }

        public int FindIndex(int startIndex, Predicate<TableFilterLine> match)
        {
            return innerList.FindIndex(startIndex, match);
        }

        public int FindIndex(int startIndex, int count,Predicate<TableFilterLine> match)
        {
            return innerList.FindIndex(startIndex, count, match);
        }

        public int FindLastIndex(Predicate<TableFilterLine> match)
        {
            return innerList.FindLastIndex(match);
        }

        public int FindLastIndex(int startIndex, Predicate<TableFilterLine> match)
        {
            return innerList.FindLastIndex(startIndex, match);
        }

        public int FindLastIndex(int startIndex, int count, Predicate<TableFilterLine> match)
        {
            return innerList.FindLastIndex(startIndex, count, match);
        }

        public TableFilterLine Add(String fieldName, TableFilterType type, String value)
        {
            TableFilterLine item = new TableFilterLine(fieldName, type, value);
            innerList.Add(item);
            return item;
        }

        public TableFilterLine Insert(int index, String fieldName, TableFilterType type, String value)
        {
            TableFilterLine item = new TableFilterLine(fieldName, type, value);
            innerList.Insert(index, item);
            return item;
        }

        public void RemoveAt(int index)
        {
            innerList.RemoveAt(index);
        }

        public IEnumerator<TableFilterLine> GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return innerList.GetEnumerator();
        }
    }

    [Serializable]
    public class TableKeys : IEnumerable<TableKey>
    {
        private List<TableKey> innerList = new List<TableKey>();

        internal TableKeys()
        {
        }

        public int FindIndex(Predicate<TableKey> match)
        {
            return innerList.FindIndex(match);
        }

        public int FindIndex(int startIndex, Predicate<TableKey> match)
        {
            return innerList.FindIndex(startIndex, match);
        }

        public int FindIndex(int startIndex, int count,Predicate<TableKey> match)
        {
            return innerList.FindIndex(startIndex, count, match);
        }

        public int FindLastIndex(Predicate<TableKey> match)
        {
            return innerList.FindLastIndex(match);
        }

        public int FindLastIndex(int startIndex, Predicate<TableKey> match)
        {
            return innerList.FindLastIndex(startIndex, match);
        }

        public int FindLastIndex(int startIndex, int count, Predicate<TableKey> match)
        {
            return innerList.FindLastIndex(startIndex, count, match);
        }

        public TableKey Add()
        {
            TableKey item = new TableKey();
            innerList.Add(item);
            return item;
        }

        public TableKey Insert(int index)
        {
            TableKey item = new TableKey();
            innerList.Insert(index, item);
            return item;
        }

        public void RemoveAt(int index)
        {
            innerList.RemoveAt(index);
        }

        public IEnumerator<TableKey> GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return innerList.GetEnumerator();
        }
    }

    [Serializable]
    public class TableRelationConditions : IEnumerable<TableRelationCondition>
    {
        private List<TableRelationCondition> innerList = new List<TableRelationCondition>();

        internal TableRelationConditions()
        {
        }

        public int FindIndex(Predicate<TableRelationCondition> match)
        {
            return innerList.FindIndex(match);
        }

        public int FindIndex(int startIndex, Predicate<TableRelationCondition> match)
        {
            return innerList.FindIndex(startIndex, match);
        }

        public int FindIndex(int startIndex, int count,Predicate<TableRelationCondition> match)
        {
            return innerList.FindIndex(startIndex, count, match);
        }

        public int FindLastIndex(Predicate<TableRelationCondition> match)
        {
            return innerList.FindLastIndex(match);
        }

        public int FindLastIndex(int startIndex, Predicate<TableRelationCondition> match)
        {
            return innerList.FindLastIndex(startIndex, match);
        }

        public int FindLastIndex(int startIndex, int count, Predicate<TableRelationCondition> match)
        {
            return innerList.FindLastIndex(startIndex, count, match);
        }

        public TableRelationCondition Add(String fieldName, TableRelationConditionType type, String value)
        {
            TableRelationCondition item = new TableRelationCondition(fieldName, type, value);
            innerList.Add(item);
            return item;
        }

        public TableRelationCondition Insert(int index, String fieldName, TableRelationConditionType type, String value)
        {
            TableRelationCondition item = new TableRelationCondition(fieldName, type, value);
            innerList.Insert(index, item);
            return item;
        }

        public void RemoveAt(int index)
        {
            innerList.RemoveAt(index);
        }

        public IEnumerator<TableRelationCondition> GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return innerList.GetEnumerator();
        }
    }

    [Serializable]
    public class TableRelationLines : IEnumerable<TableRelationLine>
    {
        private List<TableRelationLine> innerList = new List<TableRelationLine>();

        internal TableRelationLines()
        {
        }

        public int FindIndex(Predicate<TableRelationLine> match)
        {
            return innerList.FindIndex(match);
        }

        public int FindIndex(int startIndex, Predicate<TableRelationLine> match)
        {
            return innerList.FindIndex(startIndex, match);
        }

        public int FindIndex(int startIndex, int count,Predicate<TableRelationLine> match)
        {
            return innerList.FindIndex(startIndex, count, match);
        }

        public int FindLastIndex(Predicate<TableRelationLine> match)
        {
            return innerList.FindLastIndex(match);
        }

        public int FindLastIndex(int startIndex, Predicate<TableRelationLine> match)
        {
            return innerList.FindLastIndex(startIndex, match);
        }

        public int FindLastIndex(int startIndex, int count, Predicate<TableRelationLine> match)
        {
            return innerList.FindLastIndex(startIndex, count, match);
        }

        public TableRelationLine Add(String tableName)
        {
            TableRelationLine item = new TableRelationLine(tableName);
            innerList.Add(item);
            return item;
        }

        public TableRelationLine Insert(int index, String tableName)
        {
            TableRelationLine item = new TableRelationLine(tableName);
            innerList.Insert(index, item);
            return item;
        }

        public void RemoveAt(int index)
        {
            innerList.RemoveAt(index);
        }

        public IEnumerator<TableRelationLine> GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return innerList.GetEnumerator();
        }
    }

    [Serializable]
    public class TableRelationTableFilter : IEnumerable<TableRelationTableFilterLine>
    {
        private List<TableRelationTableFilterLine> innerList = new List<TableRelationTableFilterLine>();

        internal TableRelationTableFilter()
        {
        }

        public int FindIndex(Predicate<TableRelationTableFilterLine> match)
        {
            return innerList.FindIndex(match);
        }

        public int FindIndex(int startIndex, Predicate<TableRelationTableFilterLine> match)
        {
            return innerList.FindIndex(startIndex, match);
        }

        public int FindIndex(int startIndex, int count,Predicate<TableRelationTableFilterLine> match)
        {
            return innerList.FindIndex(startIndex, count, match);
        }

        public int FindLastIndex(Predicate<TableRelationTableFilterLine> match)
        {
            return innerList.FindLastIndex(match);
        }

        public int FindLastIndex(int startIndex, Predicate<TableRelationTableFilterLine> match)
        {
            return innerList.FindLastIndex(startIndex, match);
        }

        public int FindLastIndex(int startIndex, int count, Predicate<TableRelationTableFilterLine> match)
        {
            return innerList.FindLastIndex(startIndex, count, match);
        }

        public TableRelationTableFilterLine Add(String fieldName, TableRelationTableFilterLineType type, String value)
        {
            TableRelationTableFilterLine item = new TableRelationTableFilterLine(fieldName, type, value);
            innerList.Add(item);
            return item;
        }

        public TableRelationTableFilterLine Insert(int index, String fieldName, TableRelationTableFilterLineType type, String value)
        {
            TableRelationTableFilterLine item = new TableRelationTableFilterLine(fieldName, type, value);
            innerList.Insert(index, item);
            return item;
        }

        public void RemoveAt(int index)
        {
            innerList.RemoveAt(index);
        }

        public IEnumerator<TableRelationTableFilterLine> GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return innerList.GetEnumerator();
        }
    }

    [Serializable]
    public class Tables : IEnumerable<Table>
    {
        private Dictionary<Int32,Table> innerList = new Dictionary<Int32,Table>();

        internal Tables()
        {
        }

        public Table Add(Int32 id, String name)
        {
            Table item = new Table(id, name);
            innerList.Add(id, item);
            return item;
        }

        public bool Remove(Int32 id)
        {
            return innerList.Remove(id);
        }

        public IEnumerator<Table> GetEnumerator()
        {
            return innerList.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return innerList.Values.GetEnumerator();
        }
    }

    [Serializable]
    public class Variables : IEnumerable<Variable>
    {
        private Dictionary<Int32,Variable> innerList = new Dictionary<Int32,Variable>();

        internal Variables()
        {
        }

        public ActionVariable AddActionVariable(Int32 id, String name)
        {
            ActionVariable item = new ActionVariable(id, name);
            innerList.Add(id, item);
            return item;
        }

        public AutomationVariable AddAutomationVariable(Int32 id, String name, String subType)
        {
            AutomationVariable item = new AutomationVariable(id, name, subType);
            innerList.Add(id, item);
            return item;
        }

        public BigIntegerVariable AddBigIntegerVariable(Int32 id, String name)
        {
            BigIntegerVariable item = new BigIntegerVariable(id, name);
            innerList.Add(id, item);
            return item;
        }

        public BigTextVariable AddBigTextVariable(Int32 id, String name)
        {
            BigTextVariable item = new BigTextVariable(id, name);
            innerList.Add(id, item);
            return item;
        }

        public BinaryVariable AddBinaryVariable(Int32 id, String name, Int32 dataLength = 100)
        {
            BinaryVariable item = new BinaryVariable(id, name, dataLength);
            innerList.Add(id, item);
            return item;
        }

        public BooleanVariable AddBooleanVariable(Int32 id, String name)
        {
            BooleanVariable item = new BooleanVariable(id, name);
            innerList.Add(id, item);
            return item;
        }

        public ByteVariable AddByteVariable(Int32 id, String name)
        {
            ByteVariable item = new ByteVariable(id, name);
            innerList.Add(id, item);
            return item;
        }

        public CharVariable AddCharVariable(Int32 id, String name)
        {
            CharVariable item = new CharVariable(id, name);
            innerList.Add(id, item);
            return item;
        }

        public CodeunitVariable AddCodeunitVariable(Int32 id, String name, Int32 subType)
        {
            CodeunitVariable item = new CodeunitVariable(id, name, subType);
            innerList.Add(id, item);
            return item;
        }

        public CodeVariable AddCodeVariable(Int32 id, String name, Int32? dataLength = null)
        {
            CodeVariable item = new CodeVariable(id, name, dataLength);
            innerList.Add(id, item);
            return item;
        }

        public DateFormulaVariable AddDateFormulaVariable(Int32 id, String name)
        {
            DateFormulaVariable item = new DateFormulaVariable(id, name);
            innerList.Add(id, item);
            return item;
        }

        public DateTimeVariable AddDateTimeVariable(Int32 id, String name)
        {
            DateTimeVariable item = new DateTimeVariable(id, name);
            innerList.Add(id, item);
            return item;
        }

        public DateVariable AddDateVariable(Int32 id, String name)
        {
            DateVariable item = new DateVariable(id, name);
            innerList.Add(id, item);
            return item;
        }

        public DecimalVariable AddDecimalVariable(Int32 id, String name)
        {
            DecimalVariable item = new DecimalVariable(id, name);
            innerList.Add(id, item);
            return item;
        }

        public DialogVariable AddDialogVariable(Int32 id, String name)
        {
            DialogVariable item = new DialogVariable(id, name);
            innerList.Add(id, item);
            return item;
        }

        public DotNetVariable AddDotNetVariable(Int32 id, String name, String subType)
        {
            DotNetVariable item = new DotNetVariable(id, name, subType);
            innerList.Add(id, item);
            return item;
        }

        public DurationVariable AddDurationVariable(Int32 id, String name)
        {
            DurationVariable item = new DurationVariable(id, name);
            innerList.Add(id, item);
            return item;
        }

        public ExecutionModeVariable AddExecutionModeVariable(Int32 id, String name)
        {
            ExecutionModeVariable item = new ExecutionModeVariable(id, name);
            innerList.Add(id, item);
            return item;
        }

        public FieldRefVariable AddFieldRefVariable(Int32 id, String name)
        {
            FieldRefVariable item = new FieldRefVariable(id, name);
            innerList.Add(id, item);
            return item;
        }

        public FileVariable AddFileVariable(Int32 id, String name)
        {
            FileVariable item = new FileVariable(id, name);
            innerList.Add(id, item);
            return item;
        }

        public GuidVariable AddGuidVariable(Int32 id, String name)
        {
            GuidVariable item = new GuidVariable(id, name);
            innerList.Add(id, item);
            return item;
        }

        public InStreamVariable AddInStreamVariable(Int32 id, String name)
        {
            InStreamVariable item = new InStreamVariable(id, name);
            innerList.Add(id, item);
            return item;
        }

        public IntegerVariable AddIntegerVariable(Int32 id, String name)
        {
            IntegerVariable item = new IntegerVariable(id, name);
            innerList.Add(id, item);
            return item;
        }

        public KeyRefVariable AddKeyRefVariable(Int32 id, String name)
        {
            KeyRefVariable item = new KeyRefVariable(id, name);
            innerList.Add(id, item);
            return item;
        }

        public OcxVariable AddOcxVariable(Int32 id, String name, String subType)
        {
            OcxVariable item = new OcxVariable(id, name, subType);
            innerList.Add(id, item);
            return item;
        }

        public OptionVariable AddOptionVariable(Int32 id, String name)
        {
            OptionVariable item = new OptionVariable(id, name);
            innerList.Add(id, item);
            return item;
        }

        public OutStreamVariable AddOutStreamVariable(Int32 id, String name)
        {
            OutStreamVariable item = new OutStreamVariable(id, name);
            innerList.Add(id, item);
            return item;
        }

        public PageVariable AddPageVariable(Int32 id, String name, Int32 subType)
        {
            PageVariable item = new PageVariable(id, name, subType);
            innerList.Add(id, item);
            return item;
        }

        public QueryVariable AddQueryVariable(Int32 id, String name, Int32 subType)
        {
            QueryVariable item = new QueryVariable(id, name, subType);
            innerList.Add(id, item);
            return item;
        }

        public RecordIDVariable AddRecordIDVariable(Int32 id, String name)
        {
            RecordIDVariable item = new RecordIDVariable(id, name);
            innerList.Add(id, item);
            return item;
        }

        public RecordRefVariable AddRecordRefVariable(Int32 id, String name)
        {
            RecordRefVariable item = new RecordRefVariable(id, name);
            innerList.Add(id, item);
            return item;
        }

        public RecordVariable AddRecordVariable(Int32 id, String name, Int32 subType)
        {
            RecordVariable item = new RecordVariable(id, name, subType);
            innerList.Add(id, item);
            return item;
        }

        public ReportVariable AddReportVariable(Int32 id, String name, Int32 subType)
        {
            ReportVariable item = new ReportVariable(id, name, subType);
            innerList.Add(id, item);
            return item;
        }

        public TestPageVariable AddTestPageVariable(Int32 id, String name, Int32 subType)
        {
            TestPageVariable item = new TestPageVariable(id, name, subType);
            innerList.Add(id, item);
            return item;
        }

        public TextConstant AddTextConstant(Int32 id, String name)
        {
            TextConstant item = new TextConstant(id, name);
            innerList.Add(id, item);
            return item;
        }

        public TextVariable AddTextVariable(Int32 id, String name, Int32? dataLength = null)
        {
            TextVariable item = new TextVariable(id, name, dataLength);
            innerList.Add(id, item);
            return item;
        }

        public TimeVariable AddTimeVariable(Int32 id, String name)
        {
            TimeVariable item = new TimeVariable(id, name);
            innerList.Add(id, item);
            return item;
        }

        public TransactionTypeVariable AddTransactionTypeVariable(Int32 id, String name)
        {
            TransactionTypeVariable item = new TransactionTypeVariable(id, name);
            innerList.Add(id, item);
            return item;
        }

        public VariantVariable AddVariantVariable(Int32 id, String name)
        {
            VariantVariable item = new VariantVariable(id, name);
            innerList.Add(id, item);
            return item;
        }

        public XmlPortVariable AddXmlPortVariable(Int32 id, String name, Int32 subType)
        {
            XmlPortVariable item = new XmlPortVariable(id, name, subType);
            innerList.Add(id, item);
            return item;
        }

        public bool Remove(Int32 id)
        {
            return innerList.Remove(id);
        }

        public IEnumerator<Variable> GetEnumerator()
        {
            return innerList.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return innerList.Values.GetEnumerator();
        }
    }

    [Serializable]
    public class XmlPortNodes : IEnumerable<XmlPortNode>
    {
        private Dictionary<Guid,XmlPortNode> innerList = new Dictionary<Guid,XmlPortNode>();

        internal XmlPortNodes()
        {
        }

        public XmlPortFieldAttribute AddXmlPortFieldAttribute(Guid id, String nodeName, Int32? indentationLevel)
        {
            XmlPortFieldAttribute item = new XmlPortFieldAttribute(id, nodeName, indentationLevel);
            innerList.Add(id, item);
            return item;
        }

        public XmlPortFieldElement AddXmlPortFieldElement(Guid id, String nodeName, Int32? indentationLevel)
        {
            XmlPortFieldElement item = new XmlPortFieldElement(id, nodeName, indentationLevel);
            innerList.Add(id, item);
            return item;
        }

        public XmlPortTableAttribute AddXmlPortTableAttribute(Guid id, String nodeName, Int32? indentationLevel)
        {
            XmlPortTableAttribute item = new XmlPortTableAttribute(id, nodeName, indentationLevel);
            innerList.Add(id, item);
            return item;
        }

        public XmlPortTableElement AddXmlPortTableElement(Guid id, String nodeName, Int32? indentationLevel)
        {
            XmlPortTableElement item = new XmlPortTableElement(id, nodeName, indentationLevel);
            innerList.Add(id, item);
            return item;
        }

        public XmlPortTextAttribute AddXmlPortTextAttribute(Guid id, String nodeName, Int32? indentationLevel)
        {
            XmlPortTextAttribute item = new XmlPortTextAttribute(id, nodeName, indentationLevel);
            innerList.Add(id, item);
            return item;
        }

        public XmlPortTextElement AddXmlPortTextElement(Guid id, String nodeName, Int32? indentationLevel)
        {
            XmlPortTextElement item = new XmlPortTextElement(id, nodeName, indentationLevel);
            innerList.Add(id, item);
            return item;
        }

        public bool Remove(Guid id)
        {
            return innerList.Remove(id);
        }

        public IEnumerator<XmlPortNode> GetEnumerator()
        {
            return innerList.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return innerList.Values.GetEnumerator();
        }
    }

    [Serializable]
    public class XmlPorts : IEnumerable<XmlPort>
    {
        private Dictionary<Int32,XmlPort> innerList = new Dictionary<Int32,XmlPort>();

        internal XmlPorts()
        {
        }

        public XmlPort Add(Int32 id, String name)
        {
            XmlPort item = new XmlPort(id, name);
            innerList.Add(id, item);
            return item;
        }

        public bool Remove(Int32 id)
        {
            return innerList.Remove(id);
        }

        public IEnumerator<XmlPort> GetEnumerator()
        {
            return innerList.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return innerList.Values.GetEnumerator();
        }
    }

    #endregion
    #region Enumerations
    public enum ActionContainerType
    {
        NewDocumentItems,
        ActionItems,
        RelatedInformation,
        Reports,
        HomeItems,
        ActivityButtons,
    }

    public enum AutoFormatType
    {
        Other,
        Amount,
        UnitAmount,
    }

    public enum BlankNumbers
    {
        DontBlank,
        BlankNeg,
        BlankNegAndZero,
        BlankZero,
        BlankZeroAndPos,
        BlankPos,
    }

    public enum BlobSubType
    {
        UserDefined,
        Bitmap,
        Memo,
    }

    public enum CalcFormulaMethod
    {
        Sum,
        Average,
        Exist,
        Count,
        Min,
        Max,
        Lookup,
    }

    public enum CalcFormulaTableFilterType
    {
        Const,
        Filter,
        Field,
    }

    public enum CodeunitSubType
    {
        Normal,
        Test,
        TestRunner,
    }

    public enum ColumnFilterLineType
    {
        Const,
        Filter,
    }

    public enum ContainerType
    {
        ContentArea,
        FactBoxArea,
        RoleCenterArea,
    }

    public enum DataItemLinkType
    {
        UseDefaultValuesIfNoMatch,
        ExcludeRowIfNoMatch,
        SqlAdvancedOptions,
    }

    public enum DataItemQueryElementTableFilterLineType
    {
        Const,
        Filter,
    }

    public enum DateMethod
    {
        Day,
        Month,
        Year,
    }

    public enum Direction
    {
        Both,
        Import,
        Export,
    }

    public enum ExtendedDataType
    {
        None,
        PhoneNo,
        Url,
        EMail,
        Ratio,
        Masked,
    }

    public enum FieldClass
    {
        Normal,
        FlowField,
        FlowFilter,
    }

    public enum FormatEvaluate
    {
        CSideFormatEvaluate,
        XmlFormatEvaluate,
    }

    public enum FunctionReturnValueType
    {
        Boolean,
        Integer,
        Decimal,
        BigInteger,
        Char,
        Text,
        Code,
        Date,
        Time,
        Duration,
        DateTime,
        Binary,
        Guid,
        Byte,
        Option,
    }

    public enum FunctionType
    {
        Normal,
        Test,
        MessageHandler,
        ConfirmHandler,
        StrMenuHandler,
        PageHandler,
        ModalPageHandler,
        ReportHandler,
        RequestPageHandler,
    }

    public enum GroupPageControlLayout
    {
        Rows,
        Columns,
    }

    public enum GroupType
    {
        Group,
        Repeater,
        CueGroup,
        FixedLayout,
        GridLayout,
    }

    public enum Importance
    {
        Standard,
        Promoted,
        Additional,
    }

    public enum MaxOccurs
    {
        Unbounded,
        Once,
    }

    public enum MenuItemDepartmentCategory
    {
        Lists,
        Tasks,
        ReportsAndAnalysis,
        Documents,
        History,
        Administration,
    }

    public enum MenuItemRunObjectType
    {
        Report,
        Codeunit,
        XmlPort,
        Page,
        Query,
    }

    public enum MenuSuiteNodeType
    {
        DeltaNode,
        GroupNode,
        ItemNode,
        MenuNode,
        RootNode,
    }

    public enum MethodType
    {
        None,
        Date,
        Totals,
    }

    public enum MinOccurs
    {
        Once,
        Zero,
    }

    public enum ObjectType
    {
        Codeunit,
        MenuSuite,
        Page,
        Query,
        Report,
        Table,
        XmlPort,
    }

    public enum Occurrence
    {
        Required,
        Optional,
    }

    public enum Order
    {
        Ascending,
        Descending,
    }

    public enum PageActionBaseType
    {
        PageAction,
        PageActionContainer,
        PageActionGroup,
        PageActionSeparator,
    }

    public enum PageControlType
    {
        ContainerPageControl,
        FieldPageControl,
        GroupPageControl,
        PartPageControl,
    }

    public enum PageType
    {
        Card,
        List,
        RoleCenter,
        CardPart,
        ListPart,
        Document,
        Worksheet,
        ListPlus,
        ConfirmationDialog,
        NavigatePage,
        StandardDialog,
    }

    public enum PaperSource
    {
        Upper,
        Lower,
        Middle,
        Manual,
        Envelope,
        ManualFeed,
        AutomaticFeed,
        TractorFeed,
        SmallFormat,
        LargeFormat,
        LargeCapacity,
        Cassette,
        FormSource,
        Custom1,
        Custom2,
        Custom3,
        Custom4,
        Custom5,
        Custom6,
        Custom7,
        Custom8,
        Custom9,
        Custom10,
        Custom11,
        Custom12,
        Custom13,
        Custom14,
        Custom15,
        Custom16,
    }

    public enum ParameterType
    {
        ActionParameter,
        AutomationParameter,
        BigIntegerParameter,
        BigTextParameter,
        BinaryParameter,
        BooleanParameter,
        ByteParameter,
        CharParameter,
        CodeParameter,
        CodeunitParameter,
        DateFormulaParameter,
        DateParameter,
        DateTimeParameter,
        DecimalParameter,
        DialogParameter,
        DotNetParameter,
        DurationParameter,
        ExecutionModeParameter,
        FieldRefParameter,
        FileParameter,
        GuidParameter,
        InStreamParameter,
        IntegerParameter,
        KeyRefParameter,
        OcxParameter,
        OptionParameter,
        OutStreamParameter,
        PageParameter,
        QueryParameter,
        RecordIDParameter,
        RecordParameter,
        RecordRefParameter,
        ReportParameter,
        TestPageParameter,
        TestRequestPageParameter,
        TextParameter,
        TimeParameter,
        TransactionTypeParameter,
        VariantParameter,
        XmlPortParameter,
    }

    public enum PartType
    {
        Page,
        System,
        Chart,
    }

    public enum PromotedCategory
    {
        New,
        Process,
        Report,
        Category4,
        Category5,
        Category6,
        Category7,
        Category8,
        Category9,
        Category10,
    }

    public enum QueryElementType
    {
        ColumnQueryElement,
        DataItemQueryElement,
        FilterQueryElement,
    }

    public enum QueryOrderByDirection
    {
        Ascending,
        Descending,
    }

    public enum QuerySecurityFiltering
    {
        Filtered,
        Ignored,
        Disallowed,
    }

    public enum ReadState
    {
        ReadUncommitted,
        ReadShared,
        ReadExclusive,
    }

    public enum RecordSecurityFiltering
    {
        Validated,
        Filtered,
        Ignored,
        Disallowed,
    }

    public enum ReportElementType
    {
        ColumnReportElement,
        DataItemReportElement,
    }

    public enum RunObjectLinkLineType
    {
        Const,
        Filter,
        Field,
    }

    public enum RunObjectType
    {
        Page,
        Report,
        Codeunit,
        XmlPort,
    }

    public enum RunPageMode
    {
        Edit,
        View,
        Create,
    }

    public enum SqlDataType
    {
        Varchar,
        Integer,
        BigInteger,
        Variant,
    }

    public enum SqlJoinType
    {
        LeftOuterJoin,
        InnerJoin,
        RightOuterJoin,
        FullOuterJoin,
        CrossJoin,
    }

    public enum StandardDayTimeUnit
    {
        Day,
        Hour,
        Minute,
        Second,
        Millisecond,
    }

    public enum Style
    {
        None,
        Standard,
        StandardAccent,
        Strong,
        StrongAccent,
        Attention,
        AttentionAccent,
        Favorable,
        Unfavorable,
        Ambiguous,
        Subordinate,
    }

    public enum SystemPartID
    {
        Outlook,
        Notes,
        MyNotes,
        RecordLinks,
        None,
    }

    public enum TableFieldType
    {
        BigIntegerTableField,
        BinaryTableField,
        BlobTableField,
        BooleanTableField,
        CodeTableField,
        DateFormulaTableField,
        DateTableField,
        DateTimeTableField,
        DecimalTableField,
        DurationTableField,
        GuidTableField,
        IntegerTableField,
        OptionTableField,
        RecordIDTableField,
        TableFilterTableField,
        TextTableField,
        TimeTableField,
    }

    public enum TableFilterType
    {
        Const,
        Filter,
    }

    public enum TableRelationConditionType
    {
        Const,
        Filter,
    }

    public enum TableRelationTableFilterLineType
    {
        Const,
        Filter,
        Field,
    }

    public enum TestIsolation
    {
        Disabled,
        Codeunit,
        Function,
    }

    public enum TextEncoding
    {
        MsDos,
        Utf8,
        Utf16,
    }

    public enum TextType
    {
        Text,
        BigText,
    }

    public enum TotalsMethod
    {
        Sum,
        Count,
        Average,
        Min,
        Max,
    }

    public enum TransactionModel
    {
        AutoCommit,
        AutoRollback,
        None,
    }

    public enum TransactionType
    {
        UpdateNoLocks,
        Update,
        Snapshot,
        Browse,
        Report,
    }

    public enum VariableType
    {
        ActionVariable,
        AutomationVariable,
        BigIntegerVariable,
        BigTextVariable,
        BinaryVariable,
        BooleanVariable,
        ByteVariable,
        CharVariable,
        CodeunitVariable,
        CodeVariable,
        DateFormulaVariable,
        DateTimeVariable,
        DateVariable,
        DecimalVariable,
        DialogVariable,
        DotNetVariable,
        DurationVariable,
        ExecutionModeVariable,
        FieldRefVariable,
        FileVariable,
        GuidVariable,
        InStreamVariable,
        IntegerVariable,
        KeyRefVariable,
        OcxVariable,
        OptionVariable,
        OutStreamVariable,
        PageVariable,
        QueryVariable,
        RecordIDVariable,
        RecordRefVariable,
        RecordVariable,
        ReportVariable,
        TestPageVariable,
        TextConstant,
        TextVariable,
        TimeVariable,
        TransactionTypeVariable,
        VariantVariable,
        XmlPortVariable,
    }

    public enum XmlPortEncoding
    {
        Utf8,
        Utf16,
        Iso8859Dash2,
    }

    public enum XmlPortFormat
    {
        Xml,
        VariableText,
        FixedText,
    }

    public enum XmlPortNodeType
    {
        XmlPortFieldAttribute,
        XmlPortFieldElement,
        XmlPortTableAttribute,
        XmlPortTableElement,
        XmlPortTextAttribute,
        XmlPortTextElement,
    }

    public enum XmlVersionNo
    {
        Version10,
        Version11,
    }

    #endregion
}
