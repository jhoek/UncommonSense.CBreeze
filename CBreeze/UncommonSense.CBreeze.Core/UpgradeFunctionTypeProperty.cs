using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UncommonSense.CBreeze.Core
{
#if NAV2015
        public class UpgradeFunctionTypeProperty : NullableValueProperty<UpgradeFunctionType>
    {
        internal UpgradeFunctionTypeProperty(string name)
            : base(name)
        {
        }
    }
#endif
}
