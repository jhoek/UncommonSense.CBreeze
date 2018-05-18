using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    public enum CodeunitSubType
    {
        Normal,
        Test,
        TestRunner,
#if NAV2015
        Upgrade,
#endif
    }

}
