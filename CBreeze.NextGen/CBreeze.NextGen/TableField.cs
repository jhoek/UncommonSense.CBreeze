using System;

namespace CBreeze.NextGen
{
	public abstract class TableField : Node, IKeyedValue<int>, IEquatable<TableField>
	{
		private int no;
		private string name;

		public TableField(int no, string name)
		{
			this.no = no;
			this.name = name;
		}

		public override string ToString()
		{
			return string.Format("Field {0} {1} : {2}", No, Name, TypeName);
		}

		public int No
		{
			get
			{
				return this.no;
			}
		}

		public string Name
		{
			get
			{
				return this.name;
			}
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
			if (other == null) return false;

			if (other.No == No) return true;

			if (other.Name == Name) return true;

			return false;
		}
	}
}

