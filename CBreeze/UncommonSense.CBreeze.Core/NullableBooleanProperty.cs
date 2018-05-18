using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
        public class NullableBooleanProperty : NullableValueProperty<bool>
    {
        internal NullableBooleanProperty(string name)
            : base(name)
        {
        }
    }
}
