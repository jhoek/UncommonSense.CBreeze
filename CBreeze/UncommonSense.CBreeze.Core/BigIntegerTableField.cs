using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Core
{
        public class BigIntegerTableField : TableField
    {
        public BigIntegerTableField(int no, string name)
            : base(no, name)
        {
            Properties = new BigIntegerTableFieldProperties(this);
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

        public override IEnumerable<INode> ChildNodes
        {
            get
            {
                yield return Properties;
            }
        }
    }
}
