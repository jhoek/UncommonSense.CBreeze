using System;
using System.Collections.Generic;
using UncommonSense.CBreeze.Common;
using UncommonSense.CBreeze.Core.Contracts;
using UncommonSense.CBreeze.Core.Property;

namespace UncommonSense.CBreeze.Core.XmlPort
{
    public class XmlPortTableElement : XmlPortNode
    {
        public XmlPortTableElement(string nodeName, int? indentationLevel = null, Guid id = new Guid())
            : base(nodeName, indentationLevel, id)
        {
            Properties = new XmlPortTableElementProperties(this);
        }

        public override XmlPortNodeType NodeType => XmlPortNodeType.Element;
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
                return XmlPortNodeAndSourceType.XmlPortTableElement;
            }
        }

        public XmlPortTableElementProperties Properties
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