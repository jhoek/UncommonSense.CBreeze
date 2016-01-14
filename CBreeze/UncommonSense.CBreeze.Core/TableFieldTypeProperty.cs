using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public class TableFieldTypeProperty : NullableValueProperty<TableFieldType>
    {
        internal TableFieldTypeProperty(string name)
            : base(name)
        {
        }
    }
}
