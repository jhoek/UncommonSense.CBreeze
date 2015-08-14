using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public partial class ColumnFilterLine
    {
        private String column;
        private ColumnFilterLineType? type;
        private String value;

        internal ColumnFilterLine(String column, ColumnFilterLineType type, String value)
        {
            this.column = column;
            this.type = type;
            this.value = value;
        }

        public String Column
        {
            get
            {
                return this.column;
            }
        }

        public ColumnFilterLineType? Type
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
