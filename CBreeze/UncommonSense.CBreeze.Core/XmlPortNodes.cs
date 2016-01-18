using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
        public class XmlPortNodes : GuidKeyedContainer<XmlPortNode>
    {
        internal XmlPortNodes()
        {
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
