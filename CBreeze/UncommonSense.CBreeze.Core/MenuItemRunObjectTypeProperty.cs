using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public class MenuItemRunObjectTypeProperty : NullableValueProperty<MenuItemRunObjectType>
    {
        internal MenuItemRunObjectTypeProperty(string name)
            : base(name)
        {
        }
    }
}
