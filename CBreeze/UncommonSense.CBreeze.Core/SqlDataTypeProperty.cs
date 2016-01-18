using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
        public class SqlDataTypeProperty : NullableValueProperty<SqlDataType>
    {
        internal SqlDataTypeProperty(string name)
            : base(name)
        {
        }
    }
}
