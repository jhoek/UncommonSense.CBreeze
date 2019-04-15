using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    public enum PageControlGroupLayout
    {
        Rows,
        Columns,
#if NAVBC
        Wide
#endif
    }

}
