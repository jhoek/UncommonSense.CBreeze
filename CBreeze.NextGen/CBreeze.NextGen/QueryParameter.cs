using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBreeze.NextGen
{
    public class QueryParameter : Parameter
    {
        public QueryParameter(int uid, string name, int subType) : base(uid, name)
        {
            SubType = subType;
        }

        public int SubType
        {
            get;
            internal set;
        }

        public override ParameterType Type
        {
            get
            {
                return ParameterType.Query;
            }
        }
    }
}
