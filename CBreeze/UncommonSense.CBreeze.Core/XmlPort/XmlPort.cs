using System.Collections.Generic;
using UncommonSense.CBreeze.Common;
using UncommonSense.CBreeze.Core.Base;
using UncommonSense.CBreeze.Core.Contracts;
using UncommonSense.CBreeze.Core.Property;
using UncommonSense.CBreeze.Core.Report;

namespace UncommonSense.CBreeze.Core.XmlPort
{
    public class XmlPort : Object, IHasCode, IHasRequestPage
    {
        public XmlPort(string name) : this(0, name)
        {
        }

        public XmlPort(int id, string name)
            : base(id, name)
        {
            Properties = new XmlPortProperties(this);
            Nodes = new XmlPortNodes(this);
            RequestPage = new RequestPage(this);
            Code = new Code.Variable.Code(this);
        }

        public override Properties AllProperties
        {
            get
            {
                return Properties;
            }
        }

        public Application Application => Container?.Application;

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

        public Code.Variable.Code Code
        {
            get;
            protected set;
        }

        public XmlPorts Container { get; internal set; }

        public XmlPortNodes Nodes
        {
            get;
            protected set;
        }

        public override INode ParentNode => Container;

        public XmlPortProperties Properties
        {
            get;
            protected set;
        }

        public RequestPage RequestPage
        {
            get;
            protected set;
        }

        public override ObjectType Type
        {
            get
            {
                return ObjectType.XmlPort;
            }
        }
    }
}