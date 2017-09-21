using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Core
{
    public class QueryVariable : Variable
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