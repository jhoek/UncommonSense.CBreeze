using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
        public class Reports : IntegerKeyedAndNamedContainer<Report>
    {
        internal Reports(IEnumerable<Report> reports)
        {
            AddRange(reports);
        }

        public override void ValidateName(Report item)
        {
            TestNameNotNullOrEmpty(item);
            TestNameUnique(item);
        }
    }
}
