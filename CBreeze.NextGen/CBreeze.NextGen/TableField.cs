using System;

namespace CBreeze.NextGen
{
	public abstract class TableField : Node, IKeyedValue<int>, IEquatable<TableField>
	{
		public TableField(int no, string name)
		{
			No = no;
			Name = name;
		}

		public override string ToString()
		{
			return string.Format("Field {0} {1} : {2}", No, Name, TypeName);
		}

		public int No
		{
			get;
			internal set;
		}

		public string Name
		{
			get;
			internal set;
		}

		public abstract string TypeName
		{
			get;
		}

		public int GetKey()
		{
			return No;
		}

		public bool Equals(TableField other)
		{
			if (other == null)
				return false;

			if (other.No == No)
				return true;

			if (other.Name == Name)
				return true;

			return false;
		}
	}
}

