using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    public class Queries : IntegerKeyedAndNamedContainer<Query>, INode
    {
        internal Queries(Application application, IEnumerable<Query> queries)
        {
            Application = application;
            AddRange(queries);
        }

        public Application Application { get; protected set; }
        public IEnumerable<INode> ChildNodes => this.Cast<INode>();
        public INode ParentNode => Application;
        protected override IEnumerable<int> DefaultRange => DefaultRanges.ID;
        protected override bool UseAlternativeRange => false;

        public override void ValidateName(Query item)
        {
            TestNameNotNullOrEmpty(item);
            TestNameUnique(item);
        }

        protected override void InsertItem(int index, Query item)
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