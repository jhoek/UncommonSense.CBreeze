using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public class ReportElements : IntegerKeyedAndNamedContainer<ReportElement>
    {
        internal ReportElements()
        {
        }

        public override void ValidateName(ReportElement item)
        {
            if (item is ColumnReportElement)
                TestNameNotNullOrEmpty(item);

            TestNameUnique(item);
        }
    }
}
