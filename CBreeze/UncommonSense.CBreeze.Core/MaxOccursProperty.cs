using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
        public class MaxOccursProperty : NullableValueProperty<MaxOccurs>
    {
        internal MaxOccursProperty(string name) : base(name)
        {
        }
    }
}
