using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Core
{
    public class QueryTypeProperty : NullableValueProperty<QueryType>
    {
        internal QueryTypeProperty(string name) : base(name)
        {
        }
    }
}