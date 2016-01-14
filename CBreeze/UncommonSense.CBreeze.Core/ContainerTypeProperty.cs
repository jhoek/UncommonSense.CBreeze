using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public class ContainerTypeProperty : NullableValueProperty<ContainerType>
    {
        internal ContainerTypeProperty(string name)
            : base(name)
        {
        }
    }
}
