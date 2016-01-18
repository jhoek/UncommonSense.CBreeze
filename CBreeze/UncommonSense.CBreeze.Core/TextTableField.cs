using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

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
