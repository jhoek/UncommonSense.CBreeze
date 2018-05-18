using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Core.Code.Parameter
{
    public class OcxParameter : Parameter
    {
        public OcxParameter(string name, string subType, bool var = false, int id = 0) : base(name, var, id)
        {
            SubType = subType;
        }

        public string SubType
        {
            get;
            protected set;
        }

        public override ParameterType Type => ParameterType.Ocx;
        public override string TypeName => $"OCX \"{SubType}\"";
    }
}