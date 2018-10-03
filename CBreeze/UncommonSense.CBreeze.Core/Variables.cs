using System.Collections.Generic;
using System.Linq;

namespace UncommonSense.CBreeze.Core
{
    public abstract class Variables : IntegerKeyedAndNamedContainer<Variable>, INode
    {
        protected override IEnumerable<int> DefaultRange => DefaultRanges.UID;
        public IEnumerable<INode> ChildNodes => this.Cast<INode>();

        public override IEnumerable<int> ExistingIDs => this.Select(v => v.ID);
        public abstract INode ParentNode { get; }

        public override void ValidateName(Variable item)
        {
            TestNameNotNullOrEmpty(item);
            TestNameUnique(item);
        }

        protected override void InsertItem(int index, Variable item)
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