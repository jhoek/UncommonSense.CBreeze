using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UncommonSense.CBreeze.Core
{
#if NAV2016
    public enum TableType
    {
        Normal,
        CRM,
        ExternalSQL,
#if NAV2017
        Exchange,
        MicrosoftGraph
#endif
    }
#endif
}
