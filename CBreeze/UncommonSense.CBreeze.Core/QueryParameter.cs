using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
        public class QueryParameter : Parameter
    {
        public QueryParameter(bool var, int id, string name, int subType)
            : base(var, id, name)
        {
            SubType = subType;
        }

        public override ParameterType Type
        {
            get
            {
                return ParameterType.Query;
            }
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
    }
}
