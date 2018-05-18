using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Core.Code.Parameter
{
#if NAV2016

    public class ReportFormatParameter : Parameter
    {
        public ReportFormatParameter(string name, bool var = false, int id = 0) : base(name, var, id)
        {
        }

        public override ParameterType Type => ParameterType.ReportFormat;
    }

#endif
}