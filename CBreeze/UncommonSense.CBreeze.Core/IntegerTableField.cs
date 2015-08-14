using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public partial class IntegerTableField : TableField
    {
        private IntegerTableFieldProperties properties = new IntegerTableFieldProperties();

        internal IntegerTableField(Int32 no, String name) : base(no, name)
        {
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
            get
            {
                return this.properties;
            }
        }

    }
}
