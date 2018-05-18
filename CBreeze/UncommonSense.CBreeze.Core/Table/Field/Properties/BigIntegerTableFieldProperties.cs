using UncommonSense.CBreeze.Core.Code.Variable;
using UncommonSense.CBreeze.Core.Contracts;
using UncommonSense.CBreeze.Core.Property.Enumeration;
using UncommonSense.CBreeze.Core.Property.Implementation;
using UncommonSense.CBreeze.Core.Property.Type;
using UncommonSense.CBreeze.Core.Table.Relation;

namespace UncommonSense.CBreeze.Core.Table.Field.Properties
{
    public class BigIntegerTableFieldProperties : Property.Properties
    {
#if NAV2015
        private AccessByPermissionProperty accessByPermission = new AccessByPermissionProperty("AccessByPermission");
#endif
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
#if NAV2016
        private ExternalAccessProperty externalAccess = new ExternalAccessProperty("ExternalAccess");
        private StringProperty externalName = new StringProperty("ExternalName");
        private StringProperty externalType = new StringProperty("ExternalType");
#endif
        private FieldClassProperty fieldClass = new FieldClassProperty("FieldClass");
        private NullableBigIntegerProperty initValue = new NullableBigIntegerProperty("InitValue");
        private NullableBigIntegerProperty maxValue = new NullableBigIntegerProperty("MaxValue");
        private NullableBigIntegerProperty minValue = new NullableBigIntegerProperty("MinValue");
        private NullableBooleanProperty notBlank = new NullableBooleanProperty("NotBlank");
        private TriggerProperty onLookup = new TriggerProperty("OnLookup");
        private TriggerProperty onValidate = new TriggerProperty("OnValidate");
        private NullableIntegerProperty signDisplacement = new NullableIntegerProperty("SignDisplacement");
        private TableRelationProperty tableRelation = new TableRelationProperty("TableRelation");
        private NullableBooleanProperty testTableRelation = new NullableBooleanProperty("TestTableRelation");
#if NAV2016
        private NullableBooleanProperty sqlTimeStamp = new NullableBooleanProperty("SQL Timestamp");
#endif
        private NullableBooleanProperty validateTableRelation = new NullableBooleanProperty("ValidateTableRelation");
        private SemiColonSeparatedStringProperty valuesAllowed = new SemiColonSeparatedStringProperty("ValuesAllowed");
        private NullableBooleanProperty @volatile = new NullableBooleanProperty("Volatile");
        private NullableIntegerProperty width = new NullableIntegerProperty("Width");

        internal BigIntegerTableFieldProperties(BigIntegerTableField field)
        {
            Field = field;

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
#if NAV2016
            innerList.Add(sqlTimeStamp);
#endif
            innerList.Add(extendedDatatype);
            innerList.Add(width);
            innerList.Add(@volatile);
#if NAV2015
            innerList.Add(accessByPermission);
#endif
#if NAV2016
            innerList.Add(externalName);
            innerList.Add(externalType);
            innerList.Add(externalAccess);
#endif
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

        public BigIntegerTableField Field { get; protected set; }

        public override INode ParentNode => Field;

#if NAV2015
        public AccessByPermission AccessByPermission
        {
            get
            {
                return accessByPermission.Value;
            }
        }
#endif

        public string AltSearchField
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

        public bool? AutoIncrement
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

        public CalcFormula CalcFormula
        {
            get
            {
                return this.calcFormula.Value;
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

        public bool? Editable
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

#if NAV2016
        public ExternalAccess? ExternalAccess
        {
            get
            {
                return this.externalAccess.Value;
            }
            set
            {
                this.externalAccess.Value = value;
            }
        }

        public string ExternalName
        {
            get
            {
                return this.externalName.Value;
            }
            set
            {
                this.externalName.Value = value;
            }
        }

        public string ExternalType
        {
            get
            {
                return this.externalType.Value;
            }
            set
            {
                this.externalType.Value = value;
            }
        }
#endif

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

        public long? InitValue
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

        public long? MaxValue
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

        public long? MinValue
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

        public int? SignDisplacement
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

#if NAV2016
        public bool? SqlTimestamp
        {
            get
            {
                return this.sqlTimeStamp.Value;
            }
            set
            {
                this.sqlTimeStamp.Value = value;
            }
        }
#endif

        public TableRelation TableRelation
        {
            get
            {
                return this.tableRelation.Value;
            }
        }

        public bool? TestTableRelation
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

        public bool? ValidateTableRelation
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

        public bool? Volatile
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
