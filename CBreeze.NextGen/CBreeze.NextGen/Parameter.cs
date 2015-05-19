using System;
using System.Collections.Generic;

namespace CBreeze.NextGen
{
	public abstract class Parameter : Node, IKeyedValue<string>, IEquatable<Parameter>
	{
		public Parameter(int uid, string name)
		{
			UID = uid;
			Name = name;
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

		public bool Equals(Parameter other)
		{
			if (other == null)
				return false;

			if (other.UID == UID)
				return true;

			if (other.Name == Name)
				return true;

			return false;
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
	}
}

