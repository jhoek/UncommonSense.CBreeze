using System;

namespace CBreeze.NextGen
{
	public class IntegerTableField : TableField
	{
		public IntegerTableField(int id, string name)
			: base(id, name)
		{
			Properties = new IntegerTableFieldProperties(this);
		}

		public override TableFieldType Type
		{
			get
			{
				return TableFieldType.Integer;
			}
		}

		public IntegerTableFieldProperties Properties
		{
			get;
			internal set;
		}

		public override System.Collections.Generic.IEnumerable<INode> ChildNodes
		{
			get
			{
				yield return Properties;
			}
		}
	}
}

