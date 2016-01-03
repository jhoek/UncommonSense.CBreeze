using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UncommonSense.CBreeze.Core
{
#if NAV2016
    [Serializable]
    public class TableTypeProperty : NullableValueProperty<TableType>
    {
        internal TableTypeProperty(string name)
            : base(name)
        {
        }
    }
#endif
}
