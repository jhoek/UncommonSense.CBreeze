using UncommonSense.CBreeze.Common;
using UncommonSense.CBreeze.Core.Contracts;

namespace UncommonSense.CBreeze.Core.Code.Variable
{
    public class DateFormulaVariable : Variable,IHasDimensions
    {
        public DateFormulaVariable(string name) : this(0, name)
        {
        }

        public DateFormulaVariable(int id, string name)
            : base(id, name)
        {
        }

        public string Dimensions
        {
            get;
            set;
        }

        public override VariableType Type
        {
            get
            {
                return VariableType.DateFormula;
            }
        }
    }
}