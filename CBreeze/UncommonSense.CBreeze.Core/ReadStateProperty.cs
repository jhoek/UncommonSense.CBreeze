using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public class ReadStateProperty : NullableValueProperty<ReadState>
    {
        internal ReadStateProperty(string name)
            : base(name)
        {
        }
    }
}
