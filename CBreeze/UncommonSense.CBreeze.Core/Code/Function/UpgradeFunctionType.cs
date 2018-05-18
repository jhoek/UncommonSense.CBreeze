using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UncommonSense.CBreeze.Core
{
#if NAV2015
    public enum UpgradeFunctionType
    {
        Normal,
#if NAV2016
        UpgradePerCompany,
#else
        Upgrade,
#endif
        TableSyncSetup,
        CheckPrecondition,
#if NAV2016
        UpgradePerDatabase,
#endif
    }
#endif
}
