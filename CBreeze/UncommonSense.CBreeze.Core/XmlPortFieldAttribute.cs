using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    public class XmlPortFieldAttribute : XmlPortNode
    {
        public XmlPortFieldAttribute(Guid id, string nodeName, int? indentationLevel)
            : base(id, nodeName, indentationLevel)
        {
            Properties = new XmlPortFieldAttributeProperties(this);
        }

        public override IEnumerable<INode> ChildNodes
        {
            get
            {
                yield return Properties;
            }
        }

        public override XmlPortNodeAndSourceType Type
        {
            get
            {
                return XmlPortNodeAndSourceType.XmlPortFieldAttribute;
            }
        }

        public XmlPortFieldAttributeProperties Properties
        {
            get;
            protected set;
        }

        public override Properties AllProperties
        {
            get
            {
                return Properties;
            }
        }
    }
}
