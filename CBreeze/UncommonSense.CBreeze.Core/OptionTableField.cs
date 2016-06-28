using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Core
{
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
