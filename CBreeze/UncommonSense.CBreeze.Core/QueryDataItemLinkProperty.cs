using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public class QueryDataItemLinkProperty : Property
    {
        private QueryDataItemLink value = new QueryDataItemLink();

        internal QueryDataItemLinkProperty(string name) : base(name)
        {
        }

        public override bool HasValue
        {
            get
            {
                return Value.Any();
            }
        }

        public QueryDataItemLink Value
        {
            get
            {
                return this.value;
            }
        }
    }

}
