using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public class ScopedTriggerProperty : TriggerProperty
    {
        internal ScopedTriggerProperty(string name)
            : base(name)
        {
        }
    }
}
