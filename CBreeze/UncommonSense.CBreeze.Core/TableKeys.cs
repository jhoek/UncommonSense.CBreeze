using System.Collections.Generic;
using System.Linq;

namespace UncommonSense.CBreeze.Core
{
    public class TableKeys : Collection<TableKey>, INode
    {
        public override string ToString() => "Keys";

        internal TableKeys(Table table)
        {
            Table = table;
        }

        public Table Table { get; protected set; }

        public IEnumerable<INode> ChildNodes => this.Cast<INode>();

        public INode ParentNode => Table;

        public new TableKey Add(TableKey item)
        {
            this.InsertItem(Count, item);
            return item;
        }

        public new TableKey Insert(int index, TableKey item)
        {
            this.InsertItem(index, item);
            return item;
        }

        protected override void InsertItem(int index, TableKey item)
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