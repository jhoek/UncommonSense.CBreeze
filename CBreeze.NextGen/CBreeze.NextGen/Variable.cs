using System;
using System.Collections.Generic;

namespace CBreeze.NextGen
{
	public abstract class Variable : Node, IKeyedValue<string>, IEquatable<Variable>
	{
		public Variable(int uid, string name)
		{
			UID = uid;
			Name = name;
		}

		public int UID
		{
			get;
			internal set;
		}

		public string Name
		{
			get;
			internal set;
		}

        public string Dimensions
        {
            get;
            set;
        }

		public override IEnumerable<INode> ChildNodes
		{
			get
			{
				yield break;
			}
		}

		public string GetKey()
		{
			return Name;
		}

		public bool Equals(Variable other)
		{
			if (other == null) return false;

			if (other.UID == UID) return true;

			if (other.Name == Name) return true;

			return false;
		}
	}
}

