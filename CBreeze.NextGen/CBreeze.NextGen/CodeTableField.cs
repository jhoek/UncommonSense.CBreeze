using System;

namespace CBreeze.NextGen
{
	public class CodeTableField : TableField
	{
		public CodeTableField(int no, string name, int length)
			: base(no, name)
		{
			Length = length;
			Properties = new CodeTableFieldProperties(this);
		}

		public override TableFieldType Type
		{
			get
			{
				return TableFieldType.Code;
			}
		}

		public int Length
		{
			get;
			internal set;
		}

		public CodeTableFieldProperties Properties
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

