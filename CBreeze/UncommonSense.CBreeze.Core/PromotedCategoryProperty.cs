using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public class PromotedCategoryProperty : NullableValueProperty<PromotedCategory>
    {
        internal PromotedCategoryProperty(string name)
            : base(name)
        {
        }
    }
}
