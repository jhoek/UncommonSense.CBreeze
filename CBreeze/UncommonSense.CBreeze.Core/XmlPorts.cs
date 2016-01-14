using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public class XmlPorts : IntegerKeyedAndNamedContainer<XmlPort>
    {
        internal XmlPorts()
        {
        }

        public override void ValidateName(XmlPort item)
        {
            
        }
    }
}
