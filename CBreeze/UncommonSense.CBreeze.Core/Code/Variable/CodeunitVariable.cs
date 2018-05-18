using UncommonSense.CBreeze.Common;
using UncommonSense.CBreeze.Core.Contracts;

namespace UncommonSense.CBreeze.Core.Code.Variable
{
    public class CodeunitVariable : Variable,IHasDimensions
    {
        public CodeunitVariable(string name, int subType) : this(0, name, subType)
        {
        }

        public override string TypeName => $"Codeunit {SubType}";

        public CodeunitVariable(int id, string name, int subType)
            : base(id, name)
        {
            SubType = subType;
        }

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
                return VariableType.Codeunit;
            }
        }
    }
}