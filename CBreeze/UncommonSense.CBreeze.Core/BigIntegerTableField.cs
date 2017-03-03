using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Core
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