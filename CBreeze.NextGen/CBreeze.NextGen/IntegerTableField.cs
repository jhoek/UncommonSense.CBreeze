using System;

namespace CBreeze.NextGen
{
	public class IntegerTableField : TableField
	{
		private IntegerTableFieldProperties properties;

		public IntegerTableField(int id, string name)
			: base(id, name)
		{
			this.properties = new IntegerTableFieldProperties(this);
		}

		public IntegerTableFieldProperties Properties
		{
			get
			{
				return properties;
			}
		}

		public override System.Collections.Generic.IEnumerable<INode> ChildNodes
		{
			get
			{
				yield return Properties;
			}
		}

		public override string TypeName
		{
			get
			{
				return "Integer";
			}
		}
	}
}

