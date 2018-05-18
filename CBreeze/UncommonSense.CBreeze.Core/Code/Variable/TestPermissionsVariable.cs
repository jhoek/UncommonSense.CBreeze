using UncommonSense.CBreeze.Common;
using UncommonSense.CBreeze.Core.Contracts;

namespace UncommonSense.CBreeze.Core.Code.Variable
{
#if NAV2017
    public class TestPermissionsVariable : Variable,IHasDimensions
    {
        public TestPermissionsVariable(string name) : this(0, name) { }
        public TestPermissionsVariable(int id, string name) : base(id, name) { }
        public string Dimensions { get; set; }
        public override VariableType Type => VariableType.TestPermissions;
    }
#endif 
}
