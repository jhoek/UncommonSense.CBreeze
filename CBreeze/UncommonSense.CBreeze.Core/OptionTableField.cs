using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public partial class OptionTableField : TableField
    {
        private OptionTableFieldProperties properties = new OptionTableFieldProperties();

        internal OptionTableField(Int32 no, String name) : base(no, name)
        {
        }

        public override TableFieldType Type
        {
            get
            {
                return TableFieldType.Option;
            }
        }

        public OptionTableFieldProperties Properties
        {
            get
            {
                return this.properties;
            }
        }

    }
}
