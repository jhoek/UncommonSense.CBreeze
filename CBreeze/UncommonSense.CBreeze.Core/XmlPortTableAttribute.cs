using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public partial class XmlPortTableAttribute : XmlPortNode
    {
        private XmlPortTableAttributeProperties properties = new XmlPortTableAttributeProperties();

        internal XmlPortTableAttribute(Guid id, String nodeName, Int32? indentationLevel) : base(id, nodeName, indentationLevel)
        {
        }

        public override XmlPortNodeType Type
        {
            get
            {
                return XmlPortNodeType.XmlPortTableAttribute;
            }
        }

        public XmlPortTableAttributeProperties Properties
        {
            get
            {
                return this.properties;
            }
        }

    }
}
