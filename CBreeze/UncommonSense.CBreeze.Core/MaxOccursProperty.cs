using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public class MaxOccursProperty : NullableValueProperty<MaxOccurs>
    {
        internal MaxOccursProperty(string name) : base(name)
        {
        }
    }
}
