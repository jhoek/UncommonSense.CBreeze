using System;

namespace CBreeze.NextGen
{
	public class CodeTableField : TableField
	{
		private  CodeTableFieldProperties properties;

		public CodeTableField(int no, string name)
			: base(no, name)
		{
			this.properties = new CodeTableFieldProperties(this);
		}

		public CodeTableFieldProperties Properties
		{
			get
			{
				return this.properties;
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
				return "Code";
			}
		}
	}
}

