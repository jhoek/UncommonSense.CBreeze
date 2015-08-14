using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public partial class ReportDataItemLinkLine
    {
        private String fieldName;
        private String referenceFieldName;

        internal ReportDataItemLinkLine(String fieldName, String referenceFieldName)
        {
            this.fieldName = fieldName;
            this.referenceFieldName = referenceFieldName;
        }

        public String FieldName
        {
            get
            {
                return this.fieldName;
            }
        }

        public String ReferenceFieldName
        {
            get
            {
                return this.referenceFieldName;
            }
        }

    }
}
