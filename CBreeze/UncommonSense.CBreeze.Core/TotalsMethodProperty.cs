using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public class TotalsMethodProperty : NullableValueProperty<TotalsMethod>
    {
        internal TotalsMethodProperty(string name)
            : base(name)
        {
        }
    }
}
