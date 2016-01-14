using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public class TextTypeProperty : NullableValueProperty<TextType>
    {
        internal TextTypeProperty(string name)
            : base(name)
        {
        }
    }
}
