using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBreeze.NextGen
{
    public abstract class QueryElement : Node, IKeyedValue<int>, IEquatable<QueryElement>   
    {
        public QueryElement(int id, string name, int? indentationLevel)
        {
            ID = id;
            Name = name;
            IndentationLevel = indentationLevel;
        }

        public abstract QueryElementType Type
        {
            get;
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

        public int? IndentationLevel
        {
            get;
            internal set;
        }

        public int GetKey()
        {
            return ID;
        }

        public bool Equals(QueryElement other)
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
