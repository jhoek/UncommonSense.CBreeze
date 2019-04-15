using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Core
{
#if NAVBC
    public class DataScopeParameter : Parameter
    {
        public DataScopeParameter(string name, bool var = false, int id = 0) : base(name, var, id) { }

        public override ParameterType Type => ParameterType.DataScope;
    }
#endif
}