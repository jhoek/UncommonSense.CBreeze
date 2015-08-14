using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public partial class XmlPortTableElement : XmlPortNode
    {
        private XmlPortTableElementProperties properties = new XmlPortTableElementProperties();

        internal XmlPortTableElement(Guid id, String nodeName, Int32? indentationLevel) : base(id, nodeName, indentationLevel)
        {
        }

        public override XmlPortNodeType Type
        {
            get
            {
                return XmlPortNodeType.XmlPortTableElement;
            }
        }

        public XmlPortTableElementProperties Properties
        {
            get
            {
                return this.properties;
            }
        }

    }
}
