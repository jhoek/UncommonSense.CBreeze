using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    public class XmlPortNodes : GuidKeyedContainer<XmlPortNode>, INode
    {
        internal XmlPortNodes(XmlPort xmlPort)
        {
            XmlPort = xmlPort;
        }

        public IEnumerable<INode> ChildNodes => this.Cast<INode>();

        public INode ParentNode => XmlPort;

        public XmlPort XmlPort
        {
            get; protected set;
        }

        protected override void InsertItem(int index, XmlPortNode item)
        {
            base.InsertItem(index, item);
            item.Container = this;
        }

        protected override void RemoveItem(int index)
        {
            this[index].Container = null;
            base.RemoveItem(index);
        }
    }
}
