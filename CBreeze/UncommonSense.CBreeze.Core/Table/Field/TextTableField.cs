using System.Collections.Generic;
using UncommonSense.CBreeze.Common;
using UncommonSense.CBreeze.Core.Contracts;

namespace UncommonSense.CBreeze.Core.Table.Field
{
    public class TextTableField : TableField
    {
        public TextTableField(string name, int dataLength = 30) : this(0, name, dataLength)
        {
        }

        public TextTableField(int no, string name, int dataLength = 30)
            : base(no, name)
        {
            DataLength = dataLength;
            Properties = new TextTableFieldProperties(this);
        }

        public override Property.Properties AllProperties
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
                yield return Properties;
            }
        }

        public int DataLength
        {
            get;
            protected set;
        }

        public TextTableFieldProperties Properties
        {
            get;
            protected set;
        }

        public override TableFieldType Type
        {
            get
            {
                return TableFieldType.Text;
            }
        }

        public override string ToString()
        {
            return string.Format("{0}[{1}]", base.ToString(), DataLength);
        }
    }
}