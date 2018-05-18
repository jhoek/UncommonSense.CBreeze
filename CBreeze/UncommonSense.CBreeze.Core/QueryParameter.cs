using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Core
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