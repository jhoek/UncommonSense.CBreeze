using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
        public class NullableIntegerProperty : NullableValueProperty<int>
    {
        internal NullableIntegerProperty(string name)
            : base(name)
        {
        }
    }
}
