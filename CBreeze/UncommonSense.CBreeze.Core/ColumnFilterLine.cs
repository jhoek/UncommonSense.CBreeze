using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
        public class ColumnFilterLine
    {
        public ColumnFilterLine(string column, SimpleTableFilterType type, string value)
        {
            Column = column;
            Type = type;
            Value = value;
        }

        public string Column
        {
            get;
            protected set;
        }

        public SimpleTableFilterType Type
        {
            get;
            protected set;
        }

        public string Value
        {
            get;
            protected set;
        }
    }
}
