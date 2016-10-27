using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Core
{
        public class CodeTableField : TableField
    {
        public CodeTableField(int no, string name, int dataLength = 10)
            : base(no, name)
        {
            DataLength = dataLength;
            Properties = new CodeTableFieldProperties();
        }

        public override TableFieldType Type
        {
            get
            {
                return TableFieldType.Code;
            }
        }

        public override string ToString()
        {
            return string.Format("{0}[{1}]", base.ToString(), DataLength);
        }

        public CodeTableFieldProperties Properties
        {
            get;
            protected set;
        }

        public int DataLength
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
