using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public partial class TableFilterLine
    {
        private String fieldName;
        private TableFilterType? type;
        private String value;

        internal TableFilterLine(String fieldName, TableFilterType type, String value)
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

        public TableFilterType? Type
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
