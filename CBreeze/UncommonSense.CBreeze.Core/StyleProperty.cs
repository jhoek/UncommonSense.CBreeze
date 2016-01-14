using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public class StyleProperty : NullableValueProperty<Style>
    {
        internal StyleProperty(string name)
            : base(name)
        {
        }
    }
}
