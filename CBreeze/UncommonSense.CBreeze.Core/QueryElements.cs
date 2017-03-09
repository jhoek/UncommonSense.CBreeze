using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    public class QueryElements : IntegerKeyedAndNamedContainer<QueryElement>, INode
    {
        internal QueryElements(Query query)
        {
            Query = query;
        }

        public IEnumerable<INode> ChildNodes => this.Cast<INode>();
        public INode ParentNode => Query;

        public Query Query
        {
            get;
            protected set;
        }

        protected override IEnumerable<int> DefaultRange => DefaultRanges.UID;

        public override void ValidateName(QueryElement item)
        {
            TestNameUnique(item);
        }

        protected override void InsertItem(int index, QueryElement item)
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