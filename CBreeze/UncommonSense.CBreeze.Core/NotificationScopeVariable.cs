using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Core
{
#if NAV2017
    public class NotificationScopeVariable : Variable,IHasDimensions
    {
        public NotificationScopeVariable(string name) : this(0, name) { }
        public NotificationScopeVariable(int id, string name) : base(id, name) { }
        public string Dimensions { get; set; }
        public override VariableType Type => VariableType.NotificationScope;
    }
#endif
}
