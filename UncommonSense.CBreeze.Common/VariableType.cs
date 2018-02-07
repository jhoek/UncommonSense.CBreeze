using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Common
{
    public enum VariableType
    {
        Action,
        Automation,
        BigInteger,
        BigText,
        Binary,
        Byte,
        Boolean,
        Char,
#if NAV2017
        ClientType,
#endif
        Codeunit,
        Code,
        DateFormula,
        DateTime,
        Date,
        Decimal,
#if NAV2017
        DefaultLayout,
#endif
        Dialog,
        DotNet,
        Duration,
        ExecutionMode,
        FieldRef,
        File,
#if NAV2016
        FilterPageBuilder,
#endif
        Guid,
        InStream,
        Integer,
        KeyRef,
#if NAV2017
        Notification,
        NotificationScope,
        ObjectType,
#endif
        Ocx,
        Option,
        OutStream,
        Page,
        Query,
        RecordID,
        RecordRef,
        Record,
        Report,
#if NAV2016
        ReportFormat,
        TableConnectionType,
#endif
        TestPage,
#if NAV2017
        TestPermissions,
#endif
        TextConst,
        Text,
#if NAV2016
        TextEncoding,
#endif
        Time,
        TransactionType,
        Variant,
        XmlPort,
    }

}
