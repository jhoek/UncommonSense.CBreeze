using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    public enum TextEncoding
    {
        MsDos,
        Utf8,
        Utf16,
#if NAV2013R2
        Windows
#endif
    }

}
