using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public class RunPageModeProperty : NullableValueProperty<RunPageMode>
    {
        internal RunPageModeProperty(string name)
            : base(name)
        {
        }
    }
}
