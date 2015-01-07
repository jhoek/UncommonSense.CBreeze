using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UncommonSense.CBreeze.Read
{
    internal struct TableRelationFilterLine
    {
        private string fieldName;
        private string type;
        private string value;
        private bool valueIsFilter;
        private bool onlyMaxLimit;

        internal TableRelationFilterLine(string fieldName, string type, string value, bool valueIsFilter, bool onlyMaxLimit)
        {
            this.fieldName = fieldName;
            this.type = type;
            this.value = value;
            this.valueIsFilter = valueIsFilter;
            this.onlyMaxLimit = onlyMaxLimit;
        }

        internal string FieldName
        {
            get
            {
                return this.fieldName;
            }
        }

        internal string Type
        {
            get
            {
                return this.type;
            }
        }

        internal string Value
        {
            get
            {
                return this.value;
            }
        }

        internal bool ValueIsFilter
        {
            get
            {
                return this.valueIsFilter;
            }
        }

        internal bool OnlyMaxLimit
        {
            get
            {
                return this.onlyMaxLimit;
            }
        }
    }
}
