using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public class GroupTypeProperty : NullableValueProperty<GroupType>
    {
        internal GroupTypeProperty(string name)
            : base(name)
        {
        }
    }
}
