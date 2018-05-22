using UncommonSense.CBreeze.Common;
using UncommonSense.CBreeze.Core.Code.Variable;
using UncommonSense.CBreeze.Core.Contracts;
using UncommonSense.CBreeze.Core.Property;
using UncommonSense.CBreeze.Core.Property.Enumeration;
using UncommonSense.CBreeze.Core.Property.Implementation;

namespace UncommonSense.CBreeze.Core.XmlPort
{
        public class XmlPortFieldElementProperties : Properties
    {
        private NullableBooleanProperty autoCalcField = new NullableBooleanProperty("AutoCalcField");
        private XmlPortNodeDataTypeProperty dataType = new XmlPortNodeDataTypeProperty("DataType");
        private NullableBooleanProperty fieldValidate = new NullableBooleanProperty("FieldValidate");
        private MaxOccursProperty maxOccurs = new MaxOccursProperty("MaxOccurs");
        private MinOccursProperty minOccurs = new MinOccursProperty("MinOccurs");
#if NAV2016
        private StringProperty namespacePrefix = new StringProperty("NamespacePrefix");
#endif
        private ScopedTriggerProperty onAfterAssignField = new ScopedTriggerProperty("OnAfterAssignField");
        private ScopedTriggerProperty onBeforePassField = new ScopedTriggerProperty("OnBeforePassField");
        private SourceFieldProperty sourceField = new SourceFieldProperty("SourceField");
#if NAV2013R2
        private NullableBooleanProperty unbound = new NullableBooleanProperty("Unbound");
#endif
        private NullableIntegerProperty width = new NullableIntegerProperty("Width");

        internal XmlPortFieldElementProperties(XmlPortFieldElement xmlPortFieldElement)
        {
            XmlPortFieldElement = xmlPortFieldElement;

            innerList.Add(dataType);
            innerList.Add(fieldValidate);
            innerList.Add(autoCalcField);
            innerList.Add(sourceField);
#if NAV2016
            innerList.Add(namespacePrefix);
#endif
            innerList.Add(minOccurs);
            innerList.Add(maxOccurs);
#if NAV2013R2
            innerList.Add(unbound);
#endif
            innerList.Add(onAfterAssignField);
            innerList.Add(onBeforePassField);
            innerList.Add(width);
        }

        public XmlPortFieldElement XmlPortFieldElement { get; protected set; }

        public override INode ParentNode => XmlPortFieldElement;

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

#if NAV2016
        public string NamespacePrefix
        {
            get
            {
                return this.namespacePrefix.Value;
            }
            set
            {
                this.namespacePrefix.Value = value;
            }
        }
#endif

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

#if NAV2013R2
        public bool? Unbound
        {
            get
            {
                return this.unbound.Value;
            }
            set
            {
                this.unbound.Value = value;
            }
        }
#endif

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
