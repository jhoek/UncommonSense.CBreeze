using UncommonSense.CBreeze.Common;
using UncommonSense.CBreeze.Core.Code.Variable;
using UncommonSense.CBreeze.Core.Contracts;
using UncommonSense.CBreeze.Core.Property;
using UncommonSense.CBreeze.Core.Property.Enumeration;
using UncommonSense.CBreeze.Core.Property.Implementation;

namespace UncommonSense.CBreeze.Core.XmlPort
{
    public class XmlPortFieldAttributeProperties : Properties
    {
        private NullableBooleanProperty autoCalcField = new NullableBooleanProperty("AutoCalcField"); // 21057
        private XmlPortNodeDataTypeProperty dataType = new XmlPortNodeDataTypeProperty("DataType"); // 0
        private NullableBooleanProperty fieldValidate = new NullableBooleanProperty("FieldValidate"); // 54079
        private OccurrenceProperty occurrence = new OccurrenceProperty("Occurrence"); // 54096
        private ScopedTriggerProperty onAfterAssignField = new ScopedTriggerProperty("OnAfterAssignField");
        private ScopedTriggerProperty onBeforePassField = new ScopedTriggerProperty("OnBeforePassField");
        private SourceFieldProperty sourceField = new SourceFieldProperty("SourceField"); // 54081
        private NullableIntegerProperty width = new NullableIntegerProperty("Width"); // 5010

        internal XmlPortFieldAttributeProperties(XmlPortFieldAttribute xmlPortFieldAttribute)
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

        public XmlPortFieldAttribute XmlPortFieldAttribute { get; protected set; }

        public override INode ParentNode => XmlPortFieldAttribute;

        public bool? AutoCalcField
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

        public XmlPortNodeDataType? DataType
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

        public bool? FieldValidate
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
