using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Core
{
        public class TextTableField : TableField
    {
        public TextTableField(int no, string name, int dataLength = 30)
            : base(no, name)
        {
            DataLength = dataLength;
            Properties = new TextTableFieldProperties();
        }

        public override TableFieldType Type
        {
            get
            {
                return TableFieldType.Text;
            }
        }

        public override string ToString()
        {
            return string.Format("{0}[{1}]", base.ToString(), DataLength);
        }

        public int DataLength
        {
            get;
            protected set;
        }

        public TextTableFieldProperties Properties
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
