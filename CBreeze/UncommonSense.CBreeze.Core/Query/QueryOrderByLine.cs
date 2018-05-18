using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
        public class QueryOrderByLine
    {
        public QueryOrderByLine(string column, QueryOrderByDirection direction)
        {
            Column = column;
            Direction = direction;
        }

        public string Column
        {
            get;
            protected set;
        }

        public QueryOrderByDirection Direction
        {
            get;
            protected set;
        }
    }
}
