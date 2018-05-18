using System.Collections.Generic;
using UncommonSense.CBreeze.Common;
using UncommonSense.CBreeze.Core.Contracts;
using UncommonSense.CBreeze.Core.Table.Field.Properties;

namespace UncommonSense.CBreeze.Core.Table.Field
{
    public class CodeTableField : TableField
    {
        public CodeTableField(string name, int dataLength = 10) : this(0, name, dataLength)
        {
        }

        public CodeTableField(int no, string name, int dataLength = 10)
            : base(no, name)
        {
            DataLength = dataLength;
            Properties = new CodeTableFieldProperties(this);
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

        public CodeTableFieldProperties Properties
        {
            get;
            protected set;
        }

        public override TableFieldType Type
        {
            get
            {
                return TableFieldType.Code;
            }
        }

        public override string ToString()
        {
            return string.Format("{0}[{1}]", base.ToString(), DataLength);
        }
    }
}