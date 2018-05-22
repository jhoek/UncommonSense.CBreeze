using UncommonSense.CBreeze.Common;
using UncommonSense.CBreeze.Core.Contracts;

namespace UncommonSense.CBreeze.Core.Code.Variable
{
    public class ReportVariable : Variable,IHasDimensions
    {
        public ReportVariable(string name, int subType) : this(0, name, subType)
        {
        }

        public ReportVariable(int id, string name, int subType)
            : base(id, name)
        {
            SubType = subType;
        }

        public override string TypeName => $"Report {SubType}";

        public string Dimensions
        {
            get;
            set;
        }

        public int SubType
        {
            get;
            protected set;
        }

        public override VariableType Type
        {
            get
            {
                return VariableType.Report;
            }
        }
    }
}