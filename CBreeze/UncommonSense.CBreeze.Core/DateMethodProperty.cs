using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public class DateMethodProperty : NullableValueProperty<DateMethod>
    {
        internal DateMethodProperty(string name)
            : base(name)
        {
        }
    }
}
