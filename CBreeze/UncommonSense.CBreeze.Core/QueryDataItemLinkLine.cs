using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public class QueryDataItemLinkLine
    {
        public QueryDataItemLinkLine(string field, string referenceTable, string referenceField)
        {
            Field = field;
            ReferenceTable = referenceTable;
            ReferenceField = referenceField;
        }

        public string Field
        {
            get;
            protected set;
        }

        public string ReferenceTable
        {
            get;
            protected set;
        }

        public string ReferenceField
        {
            get;
            protected set;
        }
    }
}
