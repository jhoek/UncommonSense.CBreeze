using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public partial class BlobTableField : TableField
    {
        private BlobTableFieldProperties properties = new BlobTableFieldProperties();

        internal BlobTableField(Int32 no, String name) : base(no, name)
        {
        }

        public override TableFieldType Type
        {
            get
            {
                return TableFieldType.Blob;
            }
        }

        public BlobTableFieldProperties Properties
        {
            get
            {
                return this.properties;
            }
        }

    }
}
