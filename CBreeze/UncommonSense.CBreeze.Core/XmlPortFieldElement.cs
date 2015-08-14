using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public partial class XmlPortFieldElement : XmlPortNode
    {
        private XmlPortFieldElementProperties properties = new XmlPortFieldElementProperties();

        internal XmlPortFieldElement(Guid id, String nodeName, Int32? indentationLevel) : base(id, nodeName, indentationLevel)
        {
        }

        public override XmlPortNodeType Type
        {
            get
            {
                return XmlPortNodeType.XmlPortFieldElement;
            }
        }

        public XmlPortFieldElementProperties Properties
        {
            get
            {
                return this.properties;
            }
        }

    }
}
