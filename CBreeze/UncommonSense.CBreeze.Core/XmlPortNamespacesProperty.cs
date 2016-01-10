using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UncommonSense.CBreeze.Core
{
#if NAV2016
    [Serializable]
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
