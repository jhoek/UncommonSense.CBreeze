using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Core
{
    public class Query : Object, IHasCode
    {
        public Query(string name) : this(0, name)
        {
        }

        public Query(int id, string name)
            : base(id, name)
        {
            Properties = new QueryProperties(this);
            Elements = new QueryElements(this);
            Code = new Code(this);
        }

        public override Properties AllProperties
        {
            get
            {
                return Properties;
            }
        }

        public override IEnumerable<INode> ChildNodes
        {
            get
            {
                yield return Properties;
                yield return Elements;
                yield return Code;
            }
        }

        public Code Code
        {
            get;
            protected set;
        }

        public Queries Container { get; internal set; }

        public QueryElements Elements
        {
            get;
            protected set;
        }

        public override INode ParentNode => Container;

        public QueryProperties Properties
        {
            get;
            protected set;
        }

        public override ObjectType Type
        {
            get
            {
                return ObjectType.Query;
            }
        }
    }
}