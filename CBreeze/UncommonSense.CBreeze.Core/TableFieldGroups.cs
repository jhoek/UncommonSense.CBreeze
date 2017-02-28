using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    public class TableFieldGroups : IntegerKeyedAndNamedContainer<TableFieldGroup>, INode
    {
        internal TableFieldGroups(Table table)
        {
            Table = table;
        }

        public Table Table
        {
            get; protected set;
        }

        public INode ParentNode => Table;

        public IEnumerable<INode> ChildNodes => this.Cast<INode>();

        protected override void InsertItem(int index, TableFieldGroup item)
        {
            base.InsertItem(index, item);
            item.Container = this;
        }

        protected override void RemoveItem(int index)
        {
            this[index].Container = null;
            base.RemoveItem(index);
        }

        public override void ValidateName(TableFieldGroup item)
        {
            TestNameUnique(item);
        }
    }
}
