using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
        public class TextEncodingProperty : NullableValueProperty<TextEncoding>
    {
        internal TextEncodingProperty(string name)
            : base(name)
        {
        }
    }
}
