using UncommonSense.CBreeze.Common;
using UncommonSense.CBreeze.Core.Contracts;
using UncommonSense.CBreeze.Core.Query;

namespace UncommonSense.CBreeze.Core.Code.Variable
{
    public class QueryVariable : Variable,IHasDimensions
    {
        public QueryVariable(string name, int subType) : this(0, name, subType)
        {
        }

        public QueryVariable(int id, string name, int subType)
            : base(id, name)
        {
            SubType = subType;
        }

        public override string TypeName => $"Query {SubType}";

        public string Dimensions
        {
            get;
            set;
        }

        public QuerySecurityFiltering? SecurityFiltering
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
                return VariableType.Query;
            }
        }
    }
}