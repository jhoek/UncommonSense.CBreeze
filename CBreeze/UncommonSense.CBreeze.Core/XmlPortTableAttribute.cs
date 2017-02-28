using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
        public class XmlPortTableAttribute : XmlPortNode
    {
        public XmlPortTableAttribute(Guid id, string nodeName, int? indentationLevel)
            : base(id, nodeName, indentationLevel)
        {
            Properties = new XmlPortTableAttributeProperties(this);
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
                return XmlPortNodeAndSourceType.XmlPortTableAttribute;
            }
        }

        public XmlPortTableAttributeProperties Properties
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
