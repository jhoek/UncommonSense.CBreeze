using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
        public class NullableDateProperty : NullableValueProperty<DateTime>
    {
        internal NullableDateProperty(string name)
            : base(name)
        {
        }
    }
}
