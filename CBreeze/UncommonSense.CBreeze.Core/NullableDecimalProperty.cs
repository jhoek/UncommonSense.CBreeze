using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public class NullableDecimalProperty : NullableValueProperty<decimal>
    {
        internal NullableDecimalProperty(string name)
            : base(name)
        {
        }
    }
}
