using System;

namespace CBreeze.NextGen
{
	public class IntegerTableField : TableField
	{
		public IntegerTableField(int no, string name)
			: base(no, name)
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

        public override Properties AllProperties
        {
            get
            {
                return Properties;
            }
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

