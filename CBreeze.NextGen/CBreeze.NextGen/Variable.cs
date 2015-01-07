using System;
using System.Collections.Generic;

namespace CBreeze.NextGen
{
	public abstract class Variable : Node, IKeyedValue<string>, IEquatable<Variable>
	{
		private int uid;
		private string name;

		public Variable(int uid, string name)
		{
			this.uid = uid;
			this.name = name;
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

