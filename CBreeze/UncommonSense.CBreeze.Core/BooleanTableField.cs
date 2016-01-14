using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public class BooleanTableField : TableField
    {
        public BooleanTableField(int no, string name)
            : base(no, name)
        {
            Properties = new BooleanTableFieldProperties();
        }

        public override TableFieldType Type
        {
            get
            {
                return TableFieldType.Boolean;
            }
        }

        public BooleanTableFieldProperties Properties
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
