using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Core
{
    public class XmlPortFieldAttribute : XmlPortNode
    {
        public XmlPortFieldAttribute(string nodeName, int? indentationLevel = null, Guid id = new Guid())
            : base(nodeName, indentationLevel, id)
        {
            Properties = new XmlPortFieldAttributeProperties(this);
        }

        public override XmlPortNodeType NodeType => XmlPortNodeType.Attribute;
        public override XmlPortSourceType SourceType => XmlPortSourceType.Field;

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