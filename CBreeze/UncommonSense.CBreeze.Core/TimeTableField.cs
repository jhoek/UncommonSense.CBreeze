using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Core
{
        public class TimeTableField : TableField
    {
        public TimeTableField(int no, string name)
            : base(no, name)
        {
            Properties = new TimeTableFieldProperties();
        }

        public override TableFieldType Type
        {
            get
            {
                return TableFieldType.Time;
            }
        }

        public TimeTableFieldProperties Properties
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
