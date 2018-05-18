using UncommonSense.CBreeze.Common;
using UncommonSense.CBreeze.Core.Contracts;

namespace UncommonSense.CBreeze.Core.Code.Variable
{
    public class InStreamVariable : Variable,IHasDimensions
    {
        public InStreamVariable(string name) : this(0, name)
        {
        }

        public InStreamVariable(int id, string name)
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
                return VariableType.InStream;
            }
        }
    }
}