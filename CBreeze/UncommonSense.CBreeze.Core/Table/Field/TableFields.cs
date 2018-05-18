using System.Collections.Generic;
using System.Linq;
using UncommonSense.CBreeze.Core.Base;
using UncommonSense.CBreeze.Core.Contracts;

namespace UncommonSense.CBreeze.Core.Table.Field
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

        protected override IEnumerable<int> DefaultRange => DefaultRanges.ID;
        protected override bool UseAlternativeRange => (Range ?? DefaultRange).Contains(Table.ID) || Table.ID == 0;

        public override void ValidateName(TableField item)
        {
            TestNameNotNullOrEmpty(item);
            TestNameUnique(item);
        }
    }
}