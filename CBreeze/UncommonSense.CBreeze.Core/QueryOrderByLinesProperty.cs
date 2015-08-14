using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public class QueryOrderByLinesProperty : Property
    {
        private QueryOrderByLines value = new QueryOrderByLines();

        internal QueryOrderByLinesProperty(string name) : base(name)
        {
        }

        public override bool HasValue
        {
            get
            {
                return Value.Any();
            }
        }

        public QueryOrderByLines Value
        {
            get
            {
                return this.value;
            }
        }
    }

}
