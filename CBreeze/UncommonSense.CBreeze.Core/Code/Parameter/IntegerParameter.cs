using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Core.Code.Parameter
{
    public class IntegerParameter : Parameter
    {
        public IntegerParameter(string name, bool var = false, int id = 0) : base(name, var, id)
        {
        }

        public override ParameterType Type => ParameterType.Integer;
    }
}