using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public class PartTypeProperty : NullableValueProperty<PartType>
    {
        internal PartTypeProperty(string name)
            : base(name)
        {
        }
    }
}
