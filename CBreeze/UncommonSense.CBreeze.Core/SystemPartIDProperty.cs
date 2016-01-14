using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public class SystemPartIDProperty : NullableValueProperty<SystemPartID>
    {
        internal SystemPartIDProperty(string name)
            : base(name)
        {
        }
    }

}
