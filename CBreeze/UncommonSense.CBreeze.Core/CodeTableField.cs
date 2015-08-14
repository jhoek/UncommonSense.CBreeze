using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public partial class CodeTableField : TableField
    {
        private CodeTableFieldProperties properties = new CodeTableFieldProperties();
        private Int32 dataLength;

        internal CodeTableField(Int32 no, String name, Int32 dataLength = 10) : base(no, name)
        {
            this.dataLength = dataLength;
        }

        public override TableFieldType Type
        {
            get
            {
                return TableFieldType.Code;
            }
        }

        public CodeTableFieldProperties Properties
        {
            get
            {
                return this.properties;
            }
        }

        public Int32 DataLength
        {
            get
            {
                return this.dataLength;
            }
        }

    }
}
