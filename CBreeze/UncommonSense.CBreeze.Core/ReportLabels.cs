using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
        public class ReportLabels : IntegerKeyedAndNamedContainer<ReportLabel>
    {
        internal ReportLabels()
        {
        }

        public override void ValidateName(ReportLabel item)
        {
            TestNameNotNullOrEmpty(item);
            TestNameUnique(item);
        }
    }
}
