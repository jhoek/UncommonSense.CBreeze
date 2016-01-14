using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public class MenuItemDepartmentCategoryProperty : NullableValueProperty<MenuItemDepartmentCategory>
    {
        internal MenuItemDepartmentCategoryProperty(string name)
            : base(name)
        {
        }
    }
}
