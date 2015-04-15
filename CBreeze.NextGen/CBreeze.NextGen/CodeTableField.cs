using System;

namespace CBreeze.NextGen
{
	public class CodeTableField : TableField
	{
		public CodeTableField(int no, string name) : base(no, name)
		{
			Properties = new CodeTableFieldProperties(this);
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

		public override string TypeName
		{
			get
			{
				return "Code";
			}
		}
	}
}

