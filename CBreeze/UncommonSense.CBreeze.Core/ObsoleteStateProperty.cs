using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Core
{
#if NAV2018

    public class ObsoleteStateProperty : NullableValueProperty<ObsoleteState>
    {
        internal ObsoleteStateProperty(string name) : base(name)
        {
        }
    }

#endif
}