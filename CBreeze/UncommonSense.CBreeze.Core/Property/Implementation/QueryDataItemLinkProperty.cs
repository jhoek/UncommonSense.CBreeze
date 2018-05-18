using System.Linq;
using UncommonSense.CBreeze.Core.Query;

namespace UncommonSense.CBreeze.Core.Property.Implementation
{
        public class QueryDataItemLinkProperty : ReferenceProperty<QueryDataItemLink>
    {
        internal QueryDataItemLinkProperty(string name)
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
