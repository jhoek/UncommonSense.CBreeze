using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public class TableFieldGroups : IntegerKeyedAndNamedContainer<TableFieldGroup>
    {
        internal TableFieldGroups()
        {
        }

        public override void ValidateName(TableFieldGroup item)
        {
            TestNameUnique(item);
        }
    }
}
