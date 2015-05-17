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
            Properties = new TableKeyProperties(this);
        }

        public override string ToString()
        {
            return string.Join(",", Fields.Select(f => f.ToString()));
        }

        public FieldList Fields
        {
            get;
            internal set;
        }

        public TableKeyProperties Properties
        {
            get;
            internal set;
        }

        public override IEnumerable<INode> ChildNodes
        {
            get
            {
                yield return Properties;
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
