using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

#if NAV2017
namespace UncommonSense.CBreeze.Core
{
    public enum TestPermissions
    {
        InheritFromTestCodeunit,
        Restrictive,
        NonRestrictive,
        Disabled
    }
}
#endif