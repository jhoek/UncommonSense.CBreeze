using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public partial class DateTableField : TableField
    {
        private DateTableFieldProperties properties = new DateTableFieldProperties();

        internal DateTableField(Int32 no, String name) : base(no, name)
        {
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
            get
            {
                return this.properties;
            }
        }

    }
}
