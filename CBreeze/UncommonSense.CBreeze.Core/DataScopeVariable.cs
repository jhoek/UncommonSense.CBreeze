using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Core
{
#if NAVBC
    public class DataScopeVariable : Variable, IHasDimensions
    {
        public DataScopeVariable(string name) : this(0, name) { }
        public DataScopeVariable(int id, string name) : base(id, name) { }
        public string Dimensions { get; set; }
        public override VariableType Type => VariableType.DataScope;
    }
#endif
}
