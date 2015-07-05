using System.Collections.Generic;

namespace CBreeze.NextGen
{
	public class BigIntegerTableField : TableField
	{
		public BigIntegerTableField(int no, string name)
			: base(no, name)
		{
			Properties = new BigIntegerTableFieldProperties(this);
		}

		public override string ToString()
		{
			return "BigIntegerTableField";
		}

		public override TableFieldType Type
		{
			get
			{
				return TableFieldType.BigInteger;
			}
		}

		public BigIntegerTableFieldProperties Properties
		{
			get;
			internal set;
		}

		public override IEnumerable<INode> ChildNodes
		{
			get
			{
                foreach(var childNode in base.ChildNodes)
                {
                    yield return childNode;
                }
                
				yield return Properties;
			}
		}
	}
}
