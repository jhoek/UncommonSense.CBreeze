using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Core
{
#if NAV2017

    public class MediaTableFieldProperties : Properties
    {
        private AccessByPermissionProperty accessByPermission = new AccessByPermissionProperty("AccessByPermission");
        private AutoFormatTypeProperty autoFormatType = new AutoFormatTypeProperty("AutoFormatType");
        private StringProperty autoFormatExpr = new StringProperty("AutoFormatExpr");
        private CalcFormulaProperty calcFormula = new CalcFormulaProperty("CalcFormula");
        private StringProperty captionClass = new StringProperty("CaptionClass");
        private MultiLanguageProperty captionML = new MultiLanguageProperty("CaptionML");
#if NAV2018
        private DataClassificationProperty dataClassification = new DataClassificationProperty("DataClassification");
#endif
        private StringProperty description = new StringProperty("Description");
        private NullableBooleanProperty editable = new NullableBooleanProperty("Editable");
        private ExtendedDataTypeProperty extendedDataType = new ExtendedDataTypeProperty("ExtendedDatatype");
        private FieldClassProperty fieldClass = new FieldClassProperty("FieldClass");
        private NullableBooleanProperty notBlank = new NullableBooleanProperty("NotBlank");
#if NAV2018
        private ObsoleteStateProperty obsoleteState = new ObsoleteStateProperty("ObsoleteState");
        private StringProperty obsoleteReason = new StringProperty("ObsoleteReason");
#endif
        private TriggerProperty onLookup = new TriggerProperty("OnLookup");
        private TriggerProperty onValidate = new TriggerProperty("OnValidate");
        private TableRelationProperty tableRelation = new TableRelationProperty("TableRelation");
        private NullableBooleanProperty validateTableRelation = new NullableBooleanProperty("ValidateTableRelation");

        internal MediaTableFieldProperties(MediaTableField field)
        {
            Field = field;

            innerList.Add(fieldClass);
            innerList.Add(calcFormula);
            innerList.Add(tableRelation);
            innerList.Add(onValidate);
            innerList.Add(onLookup);
            innerList.Add(validateTableRelation);
            innerList.Add(extendedDataType);
            innerList.Add(accessByPermission);
#if NAV2018
            innerList.Add(obsoleteState);
            innerList.Add(obsoleteReason);
            innerList.Add(dataClassification);
#endif
            innerList.Add(captionML);
            innerList.Add(notBlank);
            innerList.Add(description);
            innerList.Add(editable);
            innerList.Add(autoFormatType);
            innerList.Add(autoFormatExpr);
            innerList.Add(captionClass);
        }

        public AccessByPermission AccessByPermission => accessByPermission.Value;

#if NAV2018

        public ObsoleteState? ObsoleteState
        {
            get => obsoleteState.Value;
            set => obsoleteState.Value = value;
        }

        public string ObsoleteReason
        {
            get => obsoleteReason.Value;
            set => obsoleteReason.Value = value;
        }

        public DataClassification? DataClassification
        {
            get => dataClassification.Value;
            set => dataClassification.Value = value;
        }

#endif

        public string AutoFormatExpr
        {
            get => autoFormatExpr.Value;
            set => autoFormatExpr.Value = value;
        }

        public AutoFormatType? AutoFormatType
        {
            get => autoFormatType.Value;
            set => autoFormatType.Value = value;
        }

        public CalcFormula CalcFormula => calcFormula.Value;

        public string CaptionClass
        {
            get => captionClass.Value;
            set => captionClass.Value = value;
        }

        public MultiLanguageValue CaptionML => captionML.Value;

        public string Description
        {
            get => description.Value;
            set => description.Value = value;
        }

        public bool? Editable
        {
            get => editable.Value;
            set => editable.Value = value;
        }

        public ExtendedDataType? ExtendedDataType
        {
            get => extendedDataType.Value;
            set => extendedDataType.Value = value;
        }

        public FieldClass? FieldClass
        {
            get => fieldClass.Value;
            set => fieldClass.Value = value;
        }

        public bool? NotBlank
        {
            get => notBlank.Value;
            set => notBlank.Value = value;
        }

        public Trigger OnLookup => onLookup.Value;

        public Trigger OnValidate => onValidate.Value;

        public TableRelation TableRelation => tableRelation.Value;

        public bool? ValidateTableRelation
        {
            get => validateTableRelation.Value;
            set => validateTableRelation.Value = value;
        }

        public MediaTableField Field { get; }
        public override INode ParentNode => Field;
    }

#endif
}