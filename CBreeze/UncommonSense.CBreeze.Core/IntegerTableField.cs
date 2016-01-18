using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
        public class IntegerTableField : TableField
    {
        public IntegerTableField(int no, string name)
            : base(no, name)
        {
            Properties = new IntegerTableFieldProperties();
        }

        public override TableFieldType Type
        {
            get
            {
                return TableFieldType.Integer;
            }
        }

        public IntegerTableFieldProperties Properties
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
