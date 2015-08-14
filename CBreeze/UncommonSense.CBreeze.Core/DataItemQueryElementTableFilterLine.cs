using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public partial class DataItemQueryElementTableFilterLine
    {
        private String fieldName;
        private DataItemQueryElementTableFilterLineType? type;
        private String value;

        internal DataItemQueryElementTableFilterLine(String fieldName, DataItemQueryElementTableFilterLineType type, String value)
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

        public DataItemQueryElementTableFilterLineType? Type
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
