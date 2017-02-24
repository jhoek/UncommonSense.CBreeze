using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
        public class XmlPorts : IntegerKeyedAndNamedContainer<XmlPort>
    {
        internal XmlPorts(IEnumerable<XmlPort> xmlPorts)
        {
            AddRange(xmlPorts);
        }

        public override void ValidateName(XmlPort item)
        {
            TestNameNotNullOrEmpty(item);
            TestNameUnique(item);
        }
    }
}
