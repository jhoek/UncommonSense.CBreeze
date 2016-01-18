using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
        public class GuidTableField : TableField
    {
        public GuidTableField(int no, string name)
            : base(no, name)
        {
            Properties = new GuidTableFieldProperties();
        }

        public override TableFieldType Type
        {
            get
            {
                return TableFieldType.Guid;
            }
        }

        public GuidTableFieldProperties Properties
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
