using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
        public class ReportDataItemLinkLine
    {
        public ReportDataItemLinkLine(string fieldName, string referenceFieldName)
        {
            FieldName = fieldName;
            ReferenceFieldName = referenceFieldName;
        }

        public string FieldName
        {
            get;
            protected set;
        }

        public string ReferenceFieldName
        {
            get;
            protected set;
        }
    }
}
