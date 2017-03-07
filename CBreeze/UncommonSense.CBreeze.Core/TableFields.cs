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

        public IEnumerable<INode> ChildNodes => this.Cast<INode>();

        public INode ParentNode => Table;

        public Table Table
        {
            get; protected set;
        }

        protected override bool UseAlternativeRange => (Range ?? DefaultRange).Contains(Table.ID);

        protected override IEnumerable<int> DefaultRange => DefaultRanges.ID;

        public override void ValidateName(TableField item)
        {
            TestNameNotNullOrEmpty(item);
            TestNameUnique(item);
        }
    }
}