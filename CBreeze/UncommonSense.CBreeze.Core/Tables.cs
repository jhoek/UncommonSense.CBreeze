using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public class Tables : IntegerKeyedAndNamedContainer<Table>
    {
        internal Tables()
        {
        }

        public override void ValidateName(Table item)
        {
            TestNameNotNullOrEmpty(item);
            TestNameUnique(item);
        }
    }
}
