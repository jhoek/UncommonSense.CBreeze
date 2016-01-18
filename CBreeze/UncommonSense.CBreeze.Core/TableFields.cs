using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
        public class TableFields : IntegerKeyedAndNamedContainer<TableField>
    {
        internal TableFields()
        {
        }

        public override void ValidateName(TableField item)
        {
            TestNameNotNullOrEmpty(item);
            TestNameUnique(item);
        }
    }
}
