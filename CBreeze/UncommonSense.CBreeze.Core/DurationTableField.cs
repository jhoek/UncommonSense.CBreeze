using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public class DurationTableField : TableField
    {
        public DurationTableField(int no, string name)
            : base(no, name)
        {
            Properties = new DurationTableFieldProperties();
        }

        public override TableFieldType Type
        {
            get
            {
                return TableFieldType.Duration;
            }
        }

        public DurationTableFieldProperties Properties
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
