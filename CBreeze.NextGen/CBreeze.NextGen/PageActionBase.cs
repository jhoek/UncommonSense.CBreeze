using System;

namespace CBreeze.NextGen
{
	public abstract class PageActionBase : Node, IKeyedValue<int>, IEquatable<QueryElement>
	{
		public PageActionBase(int id, string name, int? indentationLevel)
		{
			ID = id;
			Name = name;
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

