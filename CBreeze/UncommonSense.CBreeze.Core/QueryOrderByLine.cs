using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public partial class QueryOrderByLine
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
