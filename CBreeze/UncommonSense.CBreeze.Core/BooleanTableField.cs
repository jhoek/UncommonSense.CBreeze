using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public partial class BooleanTableField : TableField
    {
        private BooleanTableFieldProperties properties = new BooleanTableFieldProperties();

        internal BooleanTableField(Int32 no, String name) : base(no, name)
        {
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
            get
            {
                return this.properties;
            }
        }

    }
}
