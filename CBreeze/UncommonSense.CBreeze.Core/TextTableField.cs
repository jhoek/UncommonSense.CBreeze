using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public partial class TextTableField : TableField
    {
        private Int32 dataLength;
        private TextTableFieldProperties properties = new TextTableFieldProperties();

        internal TextTableField(Int32 no, String name, Int32 dataLength = 30) : base(no, name)
        {
            this.dataLength = dataLength;
        }

        public override TableFieldType Type
        {
            get
            {
                return TableFieldType.Text;
            }
        }

        public Int32 DataLength
        {
            get
            {
                return this.dataLength;
            }
        }

        public TextTableFieldProperties Properties
        {
            get
            {
                return this.properties;
            }
        }

    }
}
