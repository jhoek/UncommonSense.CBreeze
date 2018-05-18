using System.Linq;
using UncommonSense.CBreeze.Core.XmlPort;

namespace UncommonSense.CBreeze.Core.Property.Implementation
{
#if NAV2016
        public class XmlPortNamespacesProperty : ReferenceProperty<XmlPortNamespaces>
    {
        internal XmlPortNamespacesProperty(string name)
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
#endif
}
