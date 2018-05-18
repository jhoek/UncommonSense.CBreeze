using System.Linq;
using UncommonSense.CBreeze.Core.Report;

namespace UncommonSense.CBreeze.Core.Property.Implementation
{
        public class ReportDataItemLinkProperty : ReferenceProperty<ReportDataItemLink>
    {
        internal ReportDataItemLinkProperty(string name) : base(name)
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
