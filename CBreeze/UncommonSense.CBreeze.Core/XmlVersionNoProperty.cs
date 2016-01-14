using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public class XmlVersionNoProperty : NullableValueProperty<XmlVersionNo>
    {
        internal XmlVersionNoProperty(string name)
            : base(name)
        {
        }
    }
}
