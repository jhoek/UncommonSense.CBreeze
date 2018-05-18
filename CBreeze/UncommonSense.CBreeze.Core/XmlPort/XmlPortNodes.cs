using System.Collections.Generic;
using System.Linq;
using UncommonSense.CBreeze.Core.Base;
using UncommonSense.CBreeze.Core.Contracts;

namespace UncommonSense.CBreeze.Core.XmlPort
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
