using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
        public class DirectionProperty : NullableValueProperty<Direction>
    {
        internal DirectionProperty(string name)
            : base(name)
        {
        }
    }
}
