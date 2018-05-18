using UncommonSense.CBreeze.Common;
using UncommonSense.CBreeze.Core.Contracts;

namespace UncommonSense.CBreeze.Core.Code.Variable
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
