using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public class NullableBooleanProperty : NullableValueProperty<bool>
    {
        internal NullableBooleanProperty(string name)
            : base(name)
        {
        }
    }
}
