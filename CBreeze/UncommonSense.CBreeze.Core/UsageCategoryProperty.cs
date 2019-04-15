using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UncommonSense.CBreeze.Core
{
#if NAVBC
    public class UsageCategoryProperty : NullableValueProperty<UsageCategory>
    {
        internal UsageCategoryProperty(string name) : base(name) { }
    }
#endif
}
