using UncommonSense.CBreeze.Common;
using UncommonSense.CBreeze.Core.Contracts;

namespace UncommonSense.CBreeze.Core.Code.Variable
{
#if NAV2017
    public class ClientTypeVariable : Variable,IHasDimensions
    {
        public ClientTypeVariable(string name) : this(0, name) { }
        public ClientTypeVariable(int id, string name) : base(id, name) { }
        public string Dimensions { get; set; }
        public override VariableType Type => VariableType.ClientType;
    }
#endif
}
