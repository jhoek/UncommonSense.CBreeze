using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public partial class LinkField
    {
        private Int32 field;
        private Int32 referenceField;

        internal LinkField(Int32 field, Int32 referenceField)
        {
            this.field = field;
            this.referenceField = referenceField;
        }

        public Int32 Field
        {
            get
            {
                return this.field;
            }
        }

        public Int32 ReferenceField
        {
            get
            {
                return this.referenceField;
            }
        }

    }
}
