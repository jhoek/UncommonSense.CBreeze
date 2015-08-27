using System.Collections.Generic;

namespace CBreeze.NextGen
{
    public partial class BooleanTableField : TableField
    {
        public BooleanTableField(int no, string name)
            : base(no, name)
        {
            Properties = new BooleanTableFieldProperties(this);
        }

        public override string ToString()
        {
            return "BooleanTableField";
        }

        public override TableFieldType Type
        {
            get
            {
                return TableFieldType.Boolean;
            }
        }

        public BooleanTableFieldProperties Properties
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

        public override IEnumerable<INode> ChildNodes
        {
            get
            {
                foreach (var childNode in base.ChildNodes)
                {
                    yield return childNode;
                }

                yield return Properties;
            }
        }
    }
}
