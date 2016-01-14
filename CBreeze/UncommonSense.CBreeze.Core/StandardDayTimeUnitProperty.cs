using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public class StandardDayTimeUnitProperty : NullableValueProperty<StandardDayTimeUnit>
    {
        internal StandardDayTimeUnitProperty(string name)
            : base(name)
        {
        }
    }
}
