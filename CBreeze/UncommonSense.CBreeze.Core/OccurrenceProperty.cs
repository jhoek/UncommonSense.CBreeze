using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public class OccurrenceProperty : NullableValueProperty<Occurrence>
    {
        internal OccurrenceProperty(string name)
            : base(name)
        {
        }
    }
}
