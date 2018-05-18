using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Core.Code.Parameter
{
    public class AutomationParameter : Parameter
    {
        public AutomationParameter(string name, string subType, bool var = false, int id = 0) : base(name, var, id)
        {
            SubType = subType;
        }

        public string SubType
        {
            get;
            protected set;
        }

        public override ParameterType Type => ParameterType.Automation;
        public override string TypeName => $"Automation \"{SubType}\"";
    }
}