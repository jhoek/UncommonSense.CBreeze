using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    public class TableFields : IntegerKeyedAndNamedContainer<TableField>, INode
    {
        internal TableFields(Table table)
        {
            Table = table;
        }

        public Table Table
        {
            get; protected set;
        }

        public IEnumerable<INode> ChildNodes => this.Cast<INode>();
        public INode ParentNode => Table;

        public override void ValidateName(TableField item)
        {
            TestNameNotNullOrEmpty(item);
            TestNameUnique(item);
        }
    }
}
