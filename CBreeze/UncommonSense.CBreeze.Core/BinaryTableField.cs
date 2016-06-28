using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Core
{
        public class BinaryTableField : TableField
    {
        public BinaryTableField(int no, string name, int dataLength = 4)
            : base(no, name)
        {
            DataLength = dataLength;
            Properties = new BinaryTableFieldProperties();
        }

        public override TableFieldType Type
        {
            get
            {
                return TableFieldType.Binary;
            }
        }

        public int DataLength
        {
            get;
            protected set;
        }

        public BinaryTableFieldProperties Properties
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
