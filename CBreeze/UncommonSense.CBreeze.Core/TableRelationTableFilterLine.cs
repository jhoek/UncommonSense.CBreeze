using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public partial class TableRelationTableFilterLine
    {
        private String fieldName;
        private TableRelationTableFilterLineType? type;
        private String value;

        internal TableRelationTableFilterLine(String fieldName, TableRelationTableFilterLineType type, String value)
        {
            this.fieldName = fieldName;
            this.type = type;
            this.value = value;
        }

        public String FieldName
        {
            get
            {
                return this.fieldName;
            }
        }

        public TableRelationTableFilterLineType? Type
        {
            get
            {
                return this.type;
            }
        }

        public String Value
        {
            get
            {
                return this.value;
            }
        }

    }
}
