// --------------------------------------------------------------------------------
// <auto-generated>
//      This code was generated by a tool.
//
//      Changes to this file may cause incorrect behaviour and will be lost if
//      the code is regenerated.
// </auto-generated>
// --------------------------------------------------------------------------------

using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public partial class BigIntegerTableField : TableField
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
