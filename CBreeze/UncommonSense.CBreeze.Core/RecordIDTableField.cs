using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public class RecordIDTableField : TableField
    {
        public RecordIDTableField(int no, string name)
            : base(no, name)
        {
            Properties = new RecordIDTableFieldProperties();
        }

        public override TableFieldType Type
        {
            get
            {
                return TableFieldType.RecordID;
            }
        }

        public RecordIDTableFieldProperties Properties
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
