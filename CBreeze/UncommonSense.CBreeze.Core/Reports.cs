using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public class Reports : IntegerKeyedAndNamedContainer<Report>
    {
        internal Reports()
        {
        }

        public override void ValidateName(Report item)
        {
            TestNameNotNullOrEmpty(item);
            TestNameUnique(item);
        }
    }
}
