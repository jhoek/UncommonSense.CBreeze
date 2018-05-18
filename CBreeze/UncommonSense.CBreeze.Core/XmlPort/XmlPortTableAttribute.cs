using System;
using System.Collections.Generic;
using UncommonSense.CBreeze.Common;
using UncommonSense.CBreeze.Core.Contracts;
using UncommonSense.CBreeze.Core.Property;

namespace UncommonSense.CBreeze.Core.XmlPort
{
    public class XmlPortTableAttribute : XmlPortNode
    {
        public XmlPortTableAttribute(string nodeName, int? indentationLevel = null, Guid id = new Guid())
            : base(nodeName, indentationLevel, id)
        {
            Properties = new XmlPortTableAttributeProperties(this);
        }

        public override XmlPortNodeType NodeType => XmlPortNodeType.Attribute;
        public override XmlPortSourceType SourceType => XmlPortSourceType.Table;

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