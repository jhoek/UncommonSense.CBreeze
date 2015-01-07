using System;

namespace CBreeze.NextGen
{
    public class Function : Node, IKeyedValue<string>, IEquatable<Function>
    {
        private int uid;
        private string name;
        private Variables variables;

        public Function(int uid, string name)
        {
            this.uid = uid;
            this.name = name;
            this.variables = new Variables(this);
        }

        public override string ToString()
        {
            return string.Format("{0}@{1}", Name, UID);
        }

        public int UID
        {
            get
            {
                return this.uid;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
        }

        public Variables Variables
        {
            get
            {
                return this.variables;
            }
        }

        public override System.Collections.Generic.IEnumerable<INode> ChildNodes
        {
            get
            {
                yield return Variables;
            }
        }

        public string GetKey()
        {
            return Name;
        }

        public bool Equals(Function other)
        {
            if (other == null)
                return false;

            if (other.UID == UID)
                return true;

            if (other.Name == Name)
                return true;

            return false;
        }
    }
}

