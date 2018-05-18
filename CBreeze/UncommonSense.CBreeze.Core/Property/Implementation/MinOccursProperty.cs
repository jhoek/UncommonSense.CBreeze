using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
        public class MinOccursProperty : NullableValueProperty<MinOccurs>
    {
        internal MinOccursProperty(string name)
            : base(name)
        {
        }
    }
}
