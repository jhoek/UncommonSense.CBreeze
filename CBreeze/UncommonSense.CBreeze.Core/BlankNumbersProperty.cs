using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
        public class BlankNumbersProperty : NullableValueProperty<BlankNumbers>
    {
        internal BlankNumbersProperty(string name)
            : base(name)
        {
        }
    }
}
