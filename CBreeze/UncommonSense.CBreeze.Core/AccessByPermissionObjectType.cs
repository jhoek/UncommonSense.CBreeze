using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UncommonSense.CBreeze.Core
{
#if NAV2015
    [Serializable]
    public enum AccessByPermissionObjectType
    {
        TableData,
        Table,
        Report,
        Codeunit,
        XmlPort,
        Page,
        Query,
        System
    }
#endif
}
