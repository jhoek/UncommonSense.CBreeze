using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public class XmlPortEncodingProperty : NullableValueProperty<XmlPortEncoding>
    {
        internal XmlPortEncodingProperty(string name)
            : base(name)
        {
        }
    }
}
