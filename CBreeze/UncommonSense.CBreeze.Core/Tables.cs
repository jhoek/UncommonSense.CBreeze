using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    public class Tables : IntegerKeyedAndNamedContainer<Table>
    {
        internal Tables(IEnumerable<Table> tables)
        {
            AddRange(tables);
        }

        public override void ValidateName(Table item)
        {
            TestNameNotNullOrEmpty(item);
            TestNameUnique(item);
        }
    }
}
