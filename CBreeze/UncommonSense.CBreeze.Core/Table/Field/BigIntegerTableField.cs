using System.Collections.Generic;
using UncommonSense.CBreeze.Common;
using UncommonSense.CBreeze.Core.Contracts;
using UncommonSense.CBreeze.Core.Table.Field.Properties;

namespace UncommonSense.CBreeze.Core.Table.Field
{
    public class BigIntegerTableField : TableField
    {
        public BigIntegerTableField(string name) : this(0, name)
        {
        }

        public BigIntegerTableField(int no, string name)
            : base(no, name)
        {
            Properties = new BigIntegerTableFieldProperties(this);
        }

        public override Property.Properties AllProperties => Properties;

        public override IEnumerable<INode> ChildNodes 
        {
            get
            {
                yield return Properties;
            }
        }

        public BigIntegerTableFieldProperties Properties
        {
            get;
            protected set;
        }

        public override TableFieldType Type
        {
            get
            {
                return TableFieldType.BigInteger;
            }
        }
    }
}