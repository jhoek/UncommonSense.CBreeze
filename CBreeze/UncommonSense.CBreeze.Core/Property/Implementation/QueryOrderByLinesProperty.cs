using System.Linq;
using UncommonSense.CBreeze.Core.Query;

namespace UncommonSense.CBreeze.Core.Property.Implementation
{
        public class QueryOrderByLinesProperty : ReferenceProperty<QueryOrderByLines>
    {
        internal QueryOrderByLinesProperty(string name)
            : base(name)
        {
        }

        public override bool HasValue
        {
            get
            {
                return Value.Any();
            }
        }
    }
}
