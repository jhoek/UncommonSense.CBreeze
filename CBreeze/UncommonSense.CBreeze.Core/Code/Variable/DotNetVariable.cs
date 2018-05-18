using UncommonSense.CBreeze.Common;
using UncommonSense.CBreeze.Core.Contracts;

namespace UncommonSense.CBreeze.Core.Code.Variable
{
    public class DotNetVariable : Variable,IHasDimensions
    {
        public DotNetVariable(string name, string subType) : this(0, name, subType)
        {
        }

        public override string TypeName => $"DotNet \"{SubType}\"";

        public DotNetVariable(int id, string name, string subType)
            : base(id, name)
        {
            SubType = subType;
        }

        public string Dimensions
        {
            get;
            set;
        }

        public bool? RunOnClient
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
                return VariableType.DotNet;
            }
        }

        public bool? WithEvents
        {
            get;
            set;
        }
    }
}