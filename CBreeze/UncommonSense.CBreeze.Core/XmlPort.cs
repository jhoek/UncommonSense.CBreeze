using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Core
{
    public class XmlPort : Object, IHasCode
    {
        public XmlPort(int id, string name)
            : base(id, name)
        {
            Properties = new XmlPortProperties(this);
            Nodes = new XmlPortNodes(this);
            RequestPage = new XmlPortRequestPage(this);
            Code = new Code(this);
        }

        public override ObjectType Type
        {
            get
            {
                return ObjectType.XmlPort;
            }
        }

        public XmlPorts Container { get; internal set; }

        public XmlPortProperties Properties
        {
            get;
            protected set;
        }

        public XmlPortNodes Nodes
        {
            get;
            protected set;
        }

        public XmlPortRequestPage RequestPage
        {
            get;
            protected set;
        }

        public Code Code
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

        public override IEnumerable<INode> ChildNodes
        {
            get
            {
                yield return Properties;
                yield return Nodes;
                yield return RequestPage;
                yield return Code;
            }
        }

        public override INode ParentNode => Container;
    }
}
