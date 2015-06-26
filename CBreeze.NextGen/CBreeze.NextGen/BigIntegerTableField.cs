using System;

namespace CBreeze.NextGen
{
	public class BigIntegerTableField : TableField
	{
		public BigIntegerTableField(int id, string name) : base(id, name)
		{
			Properties = new BigIntegerTableFieldProperties(this);
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

		public override string TypeName
		{
			get
			{
				return "BigInteger";
			}
		}
	}
}

