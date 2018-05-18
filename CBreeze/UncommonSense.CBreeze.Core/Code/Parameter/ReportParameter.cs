using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Core.Code.Parameter
{
    public class ReportParameter : Parameter
    {
        public ReportParameter(string name, int subType, bool var = false, int id = 0) : base(name, var, id)
        {
            SubType = subType;
        }

        public int SubType
        {
            get;
            protected set;
        }

        public override ParameterType Type => ParameterType.Report;
        public override string TypeName => $"Report {SubType}";
    }
}