using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBreeze.NextGen
{
    public class TableKey : Node, IEquatable<TableKey>
    {
        public TableKey(params int[] fieldNos)
        {
            Fields = new FieldList(fieldNos);
        }

        public FieldList Fields
        {
            get;
            internal set;
        }

        public override IEnumerable<INode> ChildNodes
        {
            get
            {
                yield break;
            }
        }

        public bool Equals(TableKey other)
        {
            if (other == null)
                return false;

            if (other.Fields == Fields) // FIXME: value equality
                return true;

            return false;
        }
    }
}
