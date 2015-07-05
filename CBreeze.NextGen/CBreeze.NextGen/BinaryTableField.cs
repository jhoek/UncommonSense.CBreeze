using System.Collections.Generic;

namespace CBreeze.NextGen
{
	public class BinaryTableField : TableField
	{
        public BinaryTableField(int no, string name, int dataLength)
			: base(no, name)
		{
            DataLength = dataLength;
			Properties = new BinaryTableFieldProperties(this);
		}

        public override string ToString()
		{
            return "BinaryTableField";
        }
        
        public override TableFieldType Type
        {
            get
            {
                return TableFieldType.Binary;
            }
		}

		public int DataLength
		{
			get;
			internal set;
		}

        public BinaryTableFieldProperties Properties
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
