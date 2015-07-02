using System;

namespace CBreeze.NextGen
{
	public class BlobTableField : TableField
	{
		public BlobTableField(int id, string name)
			: base(id, name)
		{
			Properties = new BlobTableFieldProperties(this);
		}

		public BlobTableFieldProperties Properties
		{
			get;
			internal set;
		}

		public override TableFieldType Type
		{
			get
			{
				return TableFieldType.Blob;
			}
		}

		public override System.Collections.Generic.IEnumerable<INode> ChildNodes
		{
			get
			{
				return Properties;
			}
		}
	}
}

