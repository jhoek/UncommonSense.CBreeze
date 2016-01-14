using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public class Query : Object, IHasCode
    {
        public Query(int id, string name)
            : base(id, name)
        {
            Properties = new QueryProperties();
            Elements = new QueryElements(this);
            Code = new Code(this);
        }

        public override ObjectType Type
        {
            get
            {
                return ObjectType.Query;
            }
        }

        public QueryProperties Properties
        {
            get;
            protected set;
        }

        public QueryElements Elements
        {
            get;
            protected set;
        }

        public Code Code
        {
            get;
            protected set;
        }

        public override Properties AllProperties
        {
            get
            {
                return Properties;
            }
        }
    }
}
