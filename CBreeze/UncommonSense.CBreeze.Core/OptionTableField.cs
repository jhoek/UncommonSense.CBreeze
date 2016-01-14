using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public class OptionTableField : TableField, IHasOptionString
    {
        public OptionTableField(int no, string name)
            : base(no, name)
        {
            Properties = new OptionTableFieldProperties();
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

        public string GetOptionString()
        {
            return Properties.OptionString;
        }
    }
}
