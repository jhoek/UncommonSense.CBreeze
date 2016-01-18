using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
        public class DateTableField : TableField
    {
        public DateTableField(int no, string name)
            : base(no, name)
        {
            Properties = new DateTableFieldProperties();
        }

        public override TableFieldType Type
        {
            get
            {
                return TableFieldType.Date;
            }
        }

        public DateTableFieldProperties Properties
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
