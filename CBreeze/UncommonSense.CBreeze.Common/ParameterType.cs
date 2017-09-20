using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Common
{
    public enum ParameterType
    {
        Action,
        Automation,
        BigInteger,
        BigText,
        Binary,
        Boolean,
        Byte,
        Char,
#if NAV2017
        ClientType,
#endif
        Code,
        Codeunit,
        DateFormula,
        Date,
        DateTime,
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
        GUID,
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
        Record,
        RecordRef,
        Report,
#if NAV2016
        ReportFormat,
        TableConnectionType,
#endif
        TestPage,
        TestRequestPage,
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
