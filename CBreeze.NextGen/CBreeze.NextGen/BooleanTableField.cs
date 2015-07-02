using System;

namespace CBreeze.NextGen
{
	public class BooleanTableField : TableField
	{
		public BooleanTableField(int id, string name)
			: base(id, name)
		{
			Properties = new BooleanTableFieldProperties(this);
		}

		public override TableFieldType Type
		{
			get
			{
				return TableFieldType.Boolean;
			}
		}

		public BooleanTableFieldProperties Properties
		{
			get;
			internal set;
		}
	}
}

