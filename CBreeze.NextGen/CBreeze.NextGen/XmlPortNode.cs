using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBreeze.NextGen
{
    public abstract class XmlPortNode : Node, IKeyedValue<int>, IEquatable<XmlPortNode>
    {
        public XmlPortNode(int id, string name, int? indentationLevel)
        {
            ID = id;
            Name = name;
            IndentationLevel = indentationLevel;
        }

        public override string ToString()
        {
            return string.Format("Node {0} {1}, indented {2}", ID, Name, IndentationLevel);
        }

        public abstract XmlPortNodeType Type
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

        public bool Equals(XmlPortNode other)
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
