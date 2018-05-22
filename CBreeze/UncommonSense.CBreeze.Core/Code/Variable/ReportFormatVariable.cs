using UncommonSense.CBreeze.Common;
using UncommonSense.CBreeze.Core.Contracts;

namespace UncommonSense.CBreeze.Core.Code.Variable
{
#if NAV2016

    public class ReportFormatVariable : Variable,IHasDimensions
    {
        public ReportFormatVariable(string name) : this(0, name)
        {
        }

        public ReportFormatVariable(int id, string name)
            : base(id, name)
        {
        }

        public override VariableType Type
        {
            get
            {
                return VariableType.ReportFormat;
            }
        }

        public string Dimensions
        {
            get;
            set;
        }
    }

#endif
}