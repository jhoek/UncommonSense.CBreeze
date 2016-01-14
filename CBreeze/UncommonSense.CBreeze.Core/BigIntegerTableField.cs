using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public class BigIntegerTableField : TableField
    {
        public BigIntegerTableField(int no, string name)
            : base(no, name)
        {
            Properties = new BigIntegerTableFieldProperties();
        }

        public override TableFieldType Type
        {
            get
            {
                return TableFieldType.BigInteger;
            }
        }

        public BigIntegerTableFieldProperties Properties
        {
            get;
            protected set;
        }

        public override Properties AllProperties
        {
            get
            {
                return Properties;
            }
        }
    }
}
