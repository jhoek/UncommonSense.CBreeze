using System.Collections.Generic;
using System.Linq;
using UncommonSense.CBreeze.Core.Base;
using UncommonSense.CBreeze.Core.Contracts;

namespace UncommonSense.CBreeze.Core.Page.Action
{
    public class ActionList : IntegerKeyedAndNamedContainer<PageActionBase>, INode
    {
        // Ctor made public so that ActionListProperty can new this up
        public ActionList()
        {
        }

        public IEnumerable<INode> ChildNodes => this.Cast<INode>();

        public override IEnumerable<int> ExistingIDs => Page.Actions.Select(a => a.ID).Concat(Page.Controls.Select(c => c.ID));

        public IPage Page
        {
            get;
            internal set;
        }

        public INode ParentNode => Page;
        protected override IEnumerable<int> DefaultRange => DefaultRanges.UID;

        public override void ValidateName(PageActionBase item)
        {
            TestNameUnique(item);
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
    }
}