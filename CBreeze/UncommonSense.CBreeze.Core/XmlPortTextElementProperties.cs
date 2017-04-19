using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Core
{
    public class XmlPortTextElementProperties : Properties
    {
        private XmlPortNodeDataTypeProperty dataType = new XmlPortNodeDataTypeProperty("DataType");
        private MaxOccursProperty maxOccurs = new MaxOccursProperty("MaxOccurs");
        private MinOccursProperty minOccurs = new MinOccursProperty("MinOccurs");
#if NAV2016
        private StringProperty namespacePrefix = new StringProperty("NamespacePrefix");
#endif
        private ScopedTriggerProperty onAfterAssignVariable = new ScopedTriggerProperty("OnAfterAssignVariable");
        private ScopedTriggerProperty onBeforePassVariable = new ScopedTriggerProperty("OnBeforePassVariable");
        private TextTypeProperty textType = new TextTypeProperty("TextType");
#if NAV2013R2
        private NullableBooleanProperty unbound = new NullableBooleanProperty("Unbound");
#endif
        private StringProperty variableName = new StringProperty("VariableName");
        private NullableIntegerProperty width = new NullableIntegerProperty("Width");

        internal XmlPortTextElementProperties(XmlPortTextElement xmlPortTextElement)
        {
            XmlPortTextElement = xmlPortTextElement;

            innerList.Add(variableName);
            innerList.Add(textType);
            innerList.Add(dataType);
#if NAV2016
            innerList.Add(namespacePrefix);
#endif
            innerList.Add(minOccurs);
            innerList.Add(maxOccurs);
#if NAV2013R2
            innerList.Add(unbound);
#endif
            innerList.Add(onAfterAssignVariable);
            innerList.Add(onBeforePassVariable);
            innerList.Add(width);
        }

        public XmlPortTextElement XmlPortTextElement
        {
            get; protected set;
        }

        public override INode ParentNode => XmlPortTextElement;

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

        public string VariableName
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