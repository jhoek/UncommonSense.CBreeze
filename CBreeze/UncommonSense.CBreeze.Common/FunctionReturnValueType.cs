using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Common
{
    public enum FunctionReturnValueType
    {
        BigInteger,
        Binary,
        Boolean,
        Byte,
        Char,
#if NAV2017
        ClientType,
#endif
        Code,
#if NAV2018
        DataClassification,
#endif
#if NAVBC
        DataScope,
#endif
        Date,
        DateTime,
        Decimal,
#if NAV2017
        DefaultLayout,
#endif
        Duration,
        Guid,
        Integer,
#if NAV2017
        ObjectType,
#endif
        Option,
#if NAV2017
        ReportFormat,
        TableConnectionType,
        TestPermissions,
#endif
#if NAV2018
        SessionSettings,
#endif
        Text,
#if NAV2017
        TextEncoding,
#endif
        Time,
#if NAV2018
        Verbosity
#endif
    }
}