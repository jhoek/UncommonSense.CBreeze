using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public class NullableBigIntegerProperty : NullableValueProperty<long>
    {
        internal NullableBigIntegerProperty(string name)
            : base(name)
        {
        }
    }
}
