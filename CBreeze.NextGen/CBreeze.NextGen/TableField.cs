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
			return string.Format("Field {0} {1} : {2}", No, Name, Type);
		}

		public abstract TableFieldType Type
		{
			get;
		}

		/// <summary>
		/// Gets or sets the no.
		/// </summary>
		/// <value>The no.</value>
		public int No
		{
			get;
			internal set;
		}

		/// <summary>
		/// Gets or sets the name.
		/// </summary>
		/// <value>The name.</value>
		public string Name
		{
			get;
			internal set;
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

