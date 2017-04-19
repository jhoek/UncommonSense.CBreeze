using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Core
{
    public class IntegerTableField : TableField
    {
        public IntegerTableField(string name) : this(0, name)
        {
        }

        public IntegerTableField(int no, string name)
            : base(no, name)
        {
            Properties = new IntegerTableFieldProperties(this);
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

        public IntegerTableFieldProperties Properties
        {
            get;
            protected set;
        }

        public override TableFieldType Type
        {
            get
            {
                return TableFieldType.Integer;
            }
        }
    }
}