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

        public IEnumerable<INode> ChildNodes => this.Cast<INode>();

        public override IEnumerable<int> ExistingIDs => Page.Actions.Select(a => a.ID).Concat(Page.Controls.Select(c => c.ID));

        public IPage Page
        {
            get;
            protected set;
        }

        protected override bool UseAlternativeRange => (Range ?? DefaultRange).Contains(Page.ObjectID);

        public INode ParentNode => Page;

        protected override IEnumerable<int> DefaultRange => DefaultRanges.UID;

        public override void ValidateName(PageControl item)
        {
            TestNameUnique(item);
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
    }
}