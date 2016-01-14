using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public class QueryElements : IntegerKeyedAndNamedContainer<QueryElement>
    {
        internal QueryElements(Query query)
        {
            Query = query;
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

        public override void ValidateName(QueryElement item)
        {
            TestNameUnique(item);
        }

        public Query Query
        {
            get;
            protected set;
        }
    }
}
