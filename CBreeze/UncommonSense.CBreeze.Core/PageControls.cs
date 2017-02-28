using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
        public class PageControls : IntegerKeyedAndNamedContainer<PageControl>, INode
    {
        internal PageControls(IPage page)
        {
            Page = page;
        }

        protected override void InsertItem(int index, PageControl item)
        {
            base.InsertItem(index, item);
            item.Container = this;
        }

        protected override void RemoveItem(int index)
        {
            this.ElementAt(index).Container = null;
            base.RemoveItem(index);
        }

        public override void ValidateName(PageControl item)
        {
            TestNameUnique(item);
        }

        public IPage Page
        {
            get;
            protected set;
        }

        public INode ParentNode => Page;
        public IEnumerable<INode> ChildNodes => this.Cast<INode>();
    }
}
