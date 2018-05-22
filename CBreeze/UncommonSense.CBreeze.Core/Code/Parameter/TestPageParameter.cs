using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Core.Code.Parameter
{
    public class TestPageParameter : Parameter
    {
        public TestPageParameter(string name, int subType, bool var = false, int id = 0) : base(name, var, id)
        {
            SubType = subType;
        }

        public int SubType { get; }
        public override ParameterType Type => ParameterType.TestPage;
        public override string TypeName => $"TestPage {SubType}";
    }
}