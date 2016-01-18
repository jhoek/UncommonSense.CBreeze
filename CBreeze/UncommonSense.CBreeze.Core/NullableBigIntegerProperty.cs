using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
        public class NullableBigIntegerProperty : NullableValueProperty<long>
    {
        internal NullableBigIntegerProperty(string name)
            : base(name)
        {
        }
    }
}
