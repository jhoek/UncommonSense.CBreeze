using UncommonSense.CBreeze.Common;
using UncommonSense.CBreeze.Core.Contracts;

namespace UncommonSense.CBreeze.Core.Code.Variable
{
    public class GuidVariable : Variable,IHasDimensions
    {
        public GuidVariable(string name) : this(0, name)
        {
        }

        public GuidVariable(int id, string name)
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
                return VariableType.Guid;
            }
        }

        public override string TypeName => "GUID";
    }
}