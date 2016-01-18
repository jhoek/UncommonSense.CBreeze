using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
        public class ContainerTypeProperty : NullableValueProperty<ContainerType>
    {
        internal ContainerTypeProperty(string name)
            : base(name)
        {
        }
    }
}
