using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
        public class DecimalTableField : TableField
    {
        public DecimalTableField(int no, string name)
            : base(no, name)
        {
            Properties = new DecimalTableFieldProperties();
        }

        public override TableFieldType Type
        {
            get
            {
                return TableFieldType.Decimal;
            }
        }

        public DecimalTableFieldProperties Properties
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
