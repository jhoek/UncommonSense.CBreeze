using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public partial class BigIntegerTableField : TableField
    {
        private BigIntegerTableFieldProperties properties = new BigIntegerTableFieldProperties();

        internal BigIntegerTableField(Int32 no, String name) : base(no, name)
        {
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
            get
            {
                return this.properties;
            }
        }

    }
}
