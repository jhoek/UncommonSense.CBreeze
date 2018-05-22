using UncommonSense.CBreeze.Common;
using UncommonSense.CBreeze.Core.Contracts;

namespace UncommonSense.CBreeze.Core.Code.Variable
{
    public class DecimalVariable : Variable,IHasDimensions
    {
        public DecimalVariable(string name) : this(0, name)
        {
        }

        public DecimalVariable(int id, string name)
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
                return VariableType.Decimal;
            }
        }
    }
}