using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public partial class BinaryTableField : TableField
    {
        private Int32 dataLength;
        private BinaryTableFieldProperties properties = new BinaryTableFieldProperties();

        internal BinaryTableField(Int32 no, String name, Int32 dataLength = 4) : base(no, name)
        {
            this.dataLength = dataLength;
        }

        public override TableFieldType Type
        {
            get
            {
                return TableFieldType.Binary;
            }
        }

        public Int32 DataLength
        {
            get
            {
                return this.dataLength;
            }
        }

        public BinaryTableFieldProperties Properties
        {
            get
            {
                return this.properties;
            }
        }

    }
}
