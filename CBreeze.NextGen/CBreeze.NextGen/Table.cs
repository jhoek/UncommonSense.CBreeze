using System;
using System.Collections.Generic;

namespace CBreeze.NextGen
{
	public class Table : Object, IEquatable<Table>
	{
		public Table(int id, string name)
			: base(id, name)
		{
			Properties = new TableProperties(this);
			Fields = new TableFields(this);
			Keys = new TableKeys(this);
			FieldGroups = new TableFieldGroups(this);
			Code = new Code(this);
		}

		public override ObjectType Type
		{
			get
			{
				return ObjectType.Table;
			}
		}

		public TableProperties Properties
		{
			get;
			internal set;
		}

		public TableFields Fields
		{
			get;
			internal set;
		}

        public TableKeys Keys
        {
            get;
            internal set;
        }

        public TableFieldGroups FieldGroups
        {
            get;
            internal set;
        }

		public Code Code
		{
			get;
			internal set;
		}

		public override IEnumerable<INode> ChildNodes
		{
			get
			{
				yield return ObjectProperties;
				yield return Properties;
				yield return Fields;
				yield return Keys;
				yield return FieldGroups;
				yield return Code;
			}
		}

		public bool Equals(Table other)
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

