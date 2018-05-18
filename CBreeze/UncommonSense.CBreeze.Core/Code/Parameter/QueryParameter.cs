using UncommonSense.CBreeze.Common;
using UncommonSense.CBreeze.Core.Query;

namespace UncommonSense.CBreeze.Core.Code.Parameter
{
    public class QueryParameter : Parameter
    {
        public QueryParameter(string name, int subType, bool var = false, int id = 0) : base(name, var, id)
        {
            SubType = subType;
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

        public override ParameterType Type => ParameterType.Query;

        public override string TypeName
        {
            get
            {
                var securityFiltering = SecurityFiltering.HasValue ? $" SECURITYFILTERING({SecurityFiltering.Value})" : "";

                return $"Query {SubType}{securityFiltering}";
            }
        }
    }
}