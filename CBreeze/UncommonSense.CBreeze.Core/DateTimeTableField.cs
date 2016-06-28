using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Core
{
        public class DateTimeTableField : TableField
    {
        public DateTimeTableField(int no, string name)
            : base(no, name)
        {
            Properties = new DateTimeTableFieldProperties();
        }

        public override TableFieldType Type
        {
            get
            {
                return TableFieldType.DateTime;
            }
        }

        public DateTimeTableFieldProperties Properties
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
