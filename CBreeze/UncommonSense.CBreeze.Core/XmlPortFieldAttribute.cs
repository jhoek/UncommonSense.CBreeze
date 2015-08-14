using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public partial class XmlPortFieldAttribute : XmlPortNode
    {
        private XmlPortFieldAttributeProperties properties = new XmlPortFieldAttributeProperties();

        internal XmlPortFieldAttribute(Guid id, String nodeName, Int32? indentationLevel) : base(id, nodeName, indentationLevel)
        {
        }

        public override XmlPortNodeType Type
        {
            get
            {
                return XmlPortNodeType.XmlPortFieldAttribute;
            }
        }

        public XmlPortFieldAttributeProperties Properties
        {
            get
            {
                return this.properties;
            }
        }

    }
}
