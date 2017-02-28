using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    public class ActionList : IntegerKeyedAndNamedContainer<PageActionBase>, INode
    {
        // Ctor made public so that ActionListProperty can new this up
        public ActionList()
        {
        }

        protected override void InsertItem(int index, PageActionBase item)
        {
            base.InsertItem(index, item);
            item.Container = this;
        }

        protected override void RemoveItem(int index)
        {
            this.ElementAt(index).Container = null;
            base.RemoveItem(index);
        }

        public override void ValidateName(PageActionBase item)
        {
            TestNameUnique(item);
        }

        public IPage Page
        {
            get;
            internal set;
        }

        public INode ParentNode => Page;

        public IEnumerable<INode> ChildNodes => this.Cast<INode>();
    }
}
