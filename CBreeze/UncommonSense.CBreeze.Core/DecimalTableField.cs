using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public partial class DecimalTableField : TableField
    {
        private DecimalTableFieldProperties properties = new DecimalTableFieldProperties();

        internal DecimalTableField(Int32 no, String name) : base(no, name)
        {
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
            get
            {
                return this.properties;
            }
        }

    }
}
