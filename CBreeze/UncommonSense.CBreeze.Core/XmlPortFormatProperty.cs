using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public class XmlPortFormatProperty : NullableValueProperty<XmlPortFormat>
    {
        internal XmlPortFormatProperty(string name)
            : base(name)
        {
        }
    }
}
