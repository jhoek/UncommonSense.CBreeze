using UncommonSense.CBreeze.Common;
using UncommonSense.CBreeze.Core.Contracts;

namespace UncommonSense.CBreeze.Core.Code.Variable
{
    public class OcxVariable : Variable,IHasDimensions
    {
        public OcxVariable(string name, string subType) : this(0, name, subType)
        {
        }

        public OcxVariable(int id, string name, string subType)
            : base(id, name)
        {
            SubType = subType;
        }

        public override string TypeName => $"OCX \"{SubType}\"";

        public string Dimensions
        {
            get;
            set;
        }

        public string SubType
        {
            get;
            protected set;
        }

        public override VariableType Type
        {
            get
            {
                return VariableType.Ocx;
            }
        }
    }
}