using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Core.Code.Parameter
{
    public class TestRequestPageParameter : Parameter
    {
        public TestRequestPageParameter(string name, int subType, bool var = false, int id = 0) : base(name, var, id)
        {
            SubType = subType;
        }

        public int SubType
        {
            get;
            protected set;
        }

        public override ParameterType Type => ParameterType.TestRequestPage;
        public override string TypeName => $"TestRequestPage {SubType}";
    }
}