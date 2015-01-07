using System;
using System.Collections.Generic;

namespace CBreeze.NextGen
{
	public abstract class Object : Node, IKeyedValue<int>
	{
		private int id;
		private string name;
		private  ObjectProperties objectProperties;

		public Object(int id, string name)
		{
			this.id = id;
			this.name = name;
            this.objectProperties = new ObjectProperties(this);
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
			get
			{
				return this.id;
			}
		}

		public string Name
		{
			get
			{
				return this.name;
			}
		}

		public ObjectProperties ObjectProperties
		{
			get
			{
				return this.objectProperties;
			}
		}

		public int GetKey()
		{
			return ID;
		}
    }
}

