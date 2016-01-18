using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UncommonSense.CBreeze.Core
{
#if NAV2016
        public class ReportFormatParameter : Parameter
    {
        public ReportFormatParameter(bool var, int id, string name)
            : base(var, id, name)
        {
        }

        public override ParameterType Type
        {
            get
            {
                return ParameterType.ReportFormat;
            }
        }
    }
#endif
}
