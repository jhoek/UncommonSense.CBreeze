using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public partial class XmlPortTextElement : XmlPortNode
    {
        private XmlPortTextElementProperties properties = new XmlPortTextElementProperties();

        internal XmlPortTextElement(Guid id, String nodeName, Int32? indentationLevel) : base(id, nodeName, indentationLevel)
        {
        }

        public override XmlPortNodeType Type
        {
            get
            {
                return XmlPortNodeType.XmlPortTextElement;
            }
        }

        public XmlPortTextElementProperties Properties
        {
            get
            {
                return this.properties;
            }
        }

    }
}
