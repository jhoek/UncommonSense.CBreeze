using System.Collections.Generic;
using System.Linq;
using UncommonSense.CBreeze.Core.Base;
using UncommonSense.CBreeze.Core.Contracts;

namespace UncommonSense.CBreeze.Core.Page.Control
{
    public class PageControls : IntegerKeyedAndNamedContainer<PageControlBase>, INode
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

        public PageControl BySourceExpr(string sourceExpr) => this.OfType<PageControl>().FirstOrDefault(c => c.Properties.SourceExpr == sourceExpr);

        public INode ParentNode => Page;

        protected override IEnumerable<int> DefaultRange => DefaultRanges.UID;

        public override void ValidateName(PageControlBase item)
        {
            TestNameUnique(item);
        }

        protected override void InsertItem(int index, PageControlBase item)
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