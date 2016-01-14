using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public class ActionContainerTypeProperty : NullableValueProperty<ActionContainerType>
    {
        internal ActionContainerTypeProperty(string name)
            : base(name)
        {
        }
    }
}
