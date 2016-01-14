using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public class FieldClassProperty : NullableValueProperty<FieldClass>
    {
        internal FieldClassProperty(string name)
            : base(name)
        {
        }
    }
}
