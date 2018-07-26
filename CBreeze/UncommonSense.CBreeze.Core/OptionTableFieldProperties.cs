using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Core
{
    public class OptionTableFieldProperties : Properties
    {
#if NAV2015
        private AccessByPermissionProperty accessByPermission = new AccessByPermissionProperty("AccessByPermission");
#endif
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
#if NAV2016
        private ExternalAccessProperty externalAccess = new ExternalAccessProperty("ExternalAccess");
        private StringProperty externalName = new StringProperty("ExternalName");
        private StringProperty externalType = new StringProperty("ExternalType");
#endif
        private FieldClassProperty fieldClass = new FieldClassProperty("FieldClass");
        private StringProperty initValue = new StringProperty("InitValue");
        private StringProperty maxValue = new StringProperty("MaxValue");
        private StringProperty minValue = new StringProperty("MinValue");
        private NullableBooleanProperty notBlank = new NullableBooleanProperty("NotBlank");
#if NAV2018
        private ObsoleteStateProperty obsoleteState = new ObsoleteStateProperty("ObsoleteState");
#endif
        private TriggerProperty onLookup = new TriggerProperty("OnLookup");
        private TriggerProperty onValidate = new TriggerProperty("OnValidate");
        private MultiLanguageProperty optionCaptionML = new MultiLanguageProperty("OptionCaptionML");
#if NAV2016
        private OptionOrdinalValuesProperty optionOrdinalValues = new OptionOrdinalValuesProperty("OptionOrdinalValues");
#endif
        private OptionStringProperty optionString = new OptionStringProperty("OptionString");
        private NullableIntegerProperty signDisplacement = new NullableIntegerProperty("SignDisplacement");
        private TableRelationProperty tableRelation = new TableRelationProperty("TableRelation");
        private NullableBooleanProperty testTableRelation = new NullableBooleanProperty("TestTableRelation");
        private NullableBooleanProperty validateTableRelation = new NullableBooleanProperty("ValidateTableRelation");
        private SemiColonSeparatedStringProperty valuesAllowed = new SemiColonSeparatedStringProperty("ValuesAllowed");

        internal OptionTableFieldProperties(OptionTableField field)
        {
            Field = field;

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
#if NAV2015
            innerList.Add(accessByPermission);
#endif
#if NAV2016
            innerList.Add(externalName);
            innerList.Add(externalType);
            innerList.Add(externalAccess);
            innerList.Add(optionOrdinalValues);
#endif
#if NAV2018
            innerList.Add(obsoleteState);
#endif
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

        public OptionTableField Field { get; protected set; }

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

#if NAV2018

        public ObsoleteState? ObsoleteState
        {
            get => obsoleteState.Value;
            set => obsoleteState.Value = value;
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

        public string InitValue
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

        public string MaxValue
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

        public string MinValue
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

        public MultiLanguageValue OptionCaptionML
        {
            get
            {
                return this.optionCaptionML.Value;
            }
        }

#if NAV2016

        public string OptionOrdinalValues
        {
            get
            {
                return this.optionOrdinalValues.Value;
            }
            set
            {
                this.optionOrdinalValues.Value = value;
            }
        }

#endif

        public string OptionString
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
    }
}