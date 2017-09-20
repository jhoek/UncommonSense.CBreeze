using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Common
{
    public enum TableFieldType
    {
        BigInteger,
        Binary,
        BLOB,
        Boolean,
        Code,
        DateFormula,
        Date,
        DateTime,
        Decimal,
        Duration,
        Guid,
        Integer,
#if NAV2017
        Media,
        MediaSet,
#endif
        Option,
        RecordID,
        TableFilter,
        Text,
        Time,
    }

}
