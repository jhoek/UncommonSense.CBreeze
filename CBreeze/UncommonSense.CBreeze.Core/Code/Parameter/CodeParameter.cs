using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Core.Code.Parameter
{
    public class CodeParameter : Parameter
    {
        public CodeParameter(string name, bool var = false, int id = 0, int? dataLength = null) : base(name, var, id)
        {
            DataLength = dataLength.Value == 0 ? 10 : dataLength.GetValueOrDefault(10);
        }

        public int DataLength
        {
            get;
            protected set;
        }

        public override ParameterType Type => ParameterType.Code;
        public override string TypeName => $"Code[{DataLength}]";
    }
}