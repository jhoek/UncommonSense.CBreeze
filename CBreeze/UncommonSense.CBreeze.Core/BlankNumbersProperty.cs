using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public class BlankNumbersProperty : NullableValueProperty<BlankNumbers>
    {
        internal BlankNumbersProperty(string name)
            : base(name)
        {
        }
    }
}
