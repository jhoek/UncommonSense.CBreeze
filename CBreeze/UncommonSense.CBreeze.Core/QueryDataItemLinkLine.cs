using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public partial class QueryDataItemLinkLine
    {
        private String field;
        private String referenceTable;
        private String referenceField;

        internal QueryDataItemLinkLine(String field, String referenceTable, String referenceField)
        {
            this.field = field;
            this.referenceField = referenceField;
            this.referenceTable = referenceTable;
        }

        public String Field
        {
            get
            {
                return this.field;
            }
        }

        public String ReferenceTable
        {
            get
            {
                return this.referenceTable;
            }
        }

        public String ReferenceField
        {
            get
            {
                return this.referenceField;
            }
        }

    }
}
