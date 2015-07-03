using System;
using System.Collections.Generic;

namespace CBreeze.NextGen
{
	public abstract class Object : Node, IKeyedValue<int>
	{
		public Object(int id, string name)
		{
			ID = id;
			Name = name;
			ObjectProperties = new ObjectProperties(this);
		}

		public override string ToString()
		{
			return string.Format("{0} {1} {2}", Type, ID, Name);
		}

		public abstract ObjectType Type
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

		public ObjectProperties ObjectProperties
		{
			get;
			internal set;
		}

		public int GetKey()
		{
			return ID;
		}

		public override IEnumerable<INode> ChildNodes
		{
			get
			{
				yield return ObjectProperties;
			}
		}
	}
}

