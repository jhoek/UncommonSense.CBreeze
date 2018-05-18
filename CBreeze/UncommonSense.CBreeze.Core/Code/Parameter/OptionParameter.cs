using UncommonSense.CBreeze.Common;
using UncommonSense.CBreeze.Core.Contracts;

namespace UncommonSense.CBreeze.Core.Code.Parameter
{
    public class OptionParameter : Parameter, IHasOptionString
    {
        public OptionParameter(string name, bool var = false, int id = 0) : base(name, var, id)
        {
        }

        public string OptionString
        {
            get;
            set;
        }

        public override ParameterType Type => ParameterType.Option;

        public override string TypeName => string.IsNullOrEmpty(OptionString) ? "Option" : $"'{OptionString}'";

        public string GetOptionString()
        {
            return OptionString;
        }
    }
}