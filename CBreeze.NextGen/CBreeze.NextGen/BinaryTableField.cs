using System;
using System.Collections.Generic;

namespace CBreeze.NextGen
{
	public class BinaryTableField : TableField
	{
		public BinaryTableField(int no, string name)
			: base(no, name)
		{
			Properties = new BinaryTableFieldProperties(this);
		}

		public BinaryTableFieldProperties Properties
		{
			get;
			internal set;
		}

		public int DataLength
		{
			get;
			internal set;
		}

		public override TableFieldType Type
		{
			get
			{
				return TableFieldType.Binary;
			}
		}

		public override string TypeName
		{
			get
			{
				return string.Format("Binary[{0}]", DataLength);
			}
		}

		public override IEnumerable<INode> ChildNodes
		{
			get
			{
				yield return Properties;
			}
		}
	}
}

