using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public class AutoFormatTypeProperty : NullableValueProperty<AutoFormatType>
    {
        internal AutoFormatTypeProperty(string name)
            : base(name)
        {
        }
    }

}
