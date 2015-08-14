using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public partial class XmlPortTextAttribute : XmlPortNode
    {
        private XmlPortTextAttributeProperties properties = new XmlPortTextAttributeProperties();

        internal XmlPortTextAttribute(Guid id, String nodeName, Int32? indentationLevel) : base(id, nodeName, indentationLevel)
        {
        }

        public override XmlPortNodeType Type
        {
            get
            {
                return XmlPortNodeType.XmlPortTextAttribute;
            }
        }

        public XmlPortTextAttributeProperties Properties
        {
            get
            {
                return this.properties;
            }
        }

    }
}
