using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
        public class NullableGuidProperty : NullableValueProperty<Guid>
    {
        internal NullableGuidProperty(string name)
            : base(name)
        {
        }
    }
}
