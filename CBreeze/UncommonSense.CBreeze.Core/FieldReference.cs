using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public partial class FieldReference
    {
        private String fieldName;

        internal FieldReference(String fieldName)
        {
            this.fieldName = fieldName;
        }

        public String FieldName
        {
            get
            {
                return this.fieldName;
            }
        }

    }
}
