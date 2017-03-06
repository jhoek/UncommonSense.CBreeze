using System;
using System.Collections.Generic;
using System.Linq;

namespace UncommonSense.CBreeze.Core
{
    public class Tables : IntegerKeyedAndNamedContainer<Table>, INode
    {
        internal Tables(Application application, IEnumerable<Table> tables)
        {
            Application = application;
            AddRange(tables);
        }

        public Application Application
        {
            get; protected set;
        }

        public IEnumerable<INode> ChildNodes => this.Cast<INode>();
        public INode ParentNode => Application;
        protected override IEnumerable<int> DefaultRange => DefaultRanges.ID;
        protected override bool UseAlternativeRange => false;

        public override void ValidateName(Table item)
        {
            TestNameNotNullOrEmpty(item);
            TestNameUnique(item);
        }

        protected override void InsertItem(int index, Table item)
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