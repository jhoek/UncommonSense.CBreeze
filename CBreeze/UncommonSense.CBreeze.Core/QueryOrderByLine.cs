using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public partial class QueryOrderByLine
    {
        private String column;
        private QueryOrderByDirection? direction;

        internal QueryOrderByLine(String column, QueryOrderByDirection direction)
        {
            this.column = column;
            this.direction = direction;
        }

        public String Column
        {
            get
            {
                return this.column;
            }
        }

        public QueryOrderByDirection? Direction
        {
            get
            {
                return this.direction;
            }
        }

    }
}
