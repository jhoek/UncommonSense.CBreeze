using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public partial class DurationTableField : TableField
    {
        private DurationTableFieldProperties properties = new DurationTableFieldProperties();

        internal DurationTableField(Int32 no, String name) : base(no, name)
        {
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
            get
            {
                return this.properties;
            }
        }

    }
}
