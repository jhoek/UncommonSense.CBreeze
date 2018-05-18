using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Core
{
    public class XmlPortNodeDataTypeProperty : NullableValueProperty<XmlPortNodeDataType>
    {
        internal XmlPortNodeDataTypeProperty(string name)
            : base(name)
        {
        }
    }
}
