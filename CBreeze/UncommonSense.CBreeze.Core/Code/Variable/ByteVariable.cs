using UncommonSense.CBreeze.Common;
using UncommonSense.CBreeze.Core.Contracts;

namespace UncommonSense.CBreeze.Core.Code.Variable
{
    public class ByteVariable : Variable, IHasDimensions
    {
        public ByteVariable(string name) : this(0, name)
        {
        }

        public ByteVariable(int id, string name)
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
                return VariableType.Byte;
            }
        }
    }
}