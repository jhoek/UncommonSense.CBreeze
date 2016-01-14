using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public class SqlJoinTypeProperty : NullableValueProperty<SqlJoinType>
    {
        internal SqlJoinTypeProperty(string name)
            : base(name)
        {
        }
    }
}
