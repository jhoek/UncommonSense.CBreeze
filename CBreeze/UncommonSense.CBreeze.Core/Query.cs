using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Core
{
    public class Query : Object, IHasCode
    {
        public Query(int id, string name)
            : base(id, name)
        {
            Properties = new QueryProperties(this);
            Elements = new QueryElements(this);
            Code = new Code(this);
        }

        public Queries Container { get; internal set; }

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

        public override INode ParentNode => Container;

        public override IEnumerable<INode> ChildNodes
        {
            get
            {
                yield return Properties;
                yield return Elements;
                yield return Code;
            }
        }
    }
}
