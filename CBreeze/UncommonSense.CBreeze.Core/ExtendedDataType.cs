using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    public enum ExtendedDataType
    {
        None,
        PhoneNo,
        Url,
        EMail,
        Ratio,
        Masked,
#if NAV2017
        Person,
#endif
#if (NAV2017 && !NAV2018)
        Resource
#endif
    }
}