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
        Boolean,
        Byte,
        Char,
        Codeunit,
        Code,
        DateFormula,
        DateTime,
        Date,
        Decimal,
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
        TextConstant,
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
