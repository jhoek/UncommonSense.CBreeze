using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Core
{
    public class TableFieldTypeProperty : NullableValueProperty<TableFieldType>
    {
        internal TableFieldTypeProperty(string name)
            : base(name)
        {
        }
    }
}
