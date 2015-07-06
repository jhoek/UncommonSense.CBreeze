using System.Collections.Generic;

namespace CBreeze.NextGen
{
    public partial class BlobTableField : TableField
	{
        public BlobTableField(int no, string name)
             : base(no, name)
		{
			Properties = new BlobTableFieldProperties(this);
		}

        public override string ToString()
		{
            return "BlobTableField";
		}

		public override TableFieldType Type
		{
			get
			{
				return TableFieldType.Blob;
			}
		}

        public BlobTableFieldProperties Properties
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
