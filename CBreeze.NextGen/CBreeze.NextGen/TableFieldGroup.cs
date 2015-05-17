using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBreeze.NextGen
{
    public class TableFieldGroup : Node, IKeyedValue<int>, IEquatable<TableFieldGroup>
    {
        public TableFieldGroup(int id, string name, params int[] fieldNos)
        {
            ID = id;
            Name = name;
            Fields = new FieldList(fieldNos);
            Properties = new TableFieldGroupProperties(this);
        }

        public override string ToString()
        {
            return string.Format("{0} {1} : {2}", ID, Name, Fields);
        }

        public int ID
        {
            get;
            internal set;
        }

        public string Name
        {
            get;
            internal set;
        }

        public FieldList Fields
        {
            get;
            internal set;
        }

        public TableFieldGroupProperties Properties
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

        public int GetKey()
        {
            return ID;
        }

        public bool Equals(TableFieldGroup other)
        {
            if (other == null)
                return false;

            if (other.ID == ID)
                return true;

            if (other.Name == Name)
                return true;

            return false;
        }
    }
}
