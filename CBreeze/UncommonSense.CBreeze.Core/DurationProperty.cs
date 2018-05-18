using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
        public class DurationProperty : NullableValueProperty<TimeSpan>
    {
        internal DurationProperty(string name)
            : base(name)
        {
        }
    }
}
