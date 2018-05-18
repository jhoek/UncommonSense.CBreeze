using System.Collections.Generic;
using UncommonSense.CBreeze.Common;
using UncommonSense.CBreeze.Core.Base;
using UncommonSense.CBreeze.Core.Code.Variable;
using UncommonSense.CBreeze.Core.Contracts;
using UncommonSense.CBreeze.Core.Property;

namespace UncommonSense.CBreeze.Core.Query
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
            Code = new Code.Variable.Code(this);
        }

        public override Properties AllProperties => Properties;
        public Application Application => Container?.Application;

        public override IEnumerable<INode> ChildNodes
        {
            get
            {
                yield return Properties;
                yield return Elements;
                yield return Code;
            }
        }

        public Code.Variable.Code Code { get; protected set; }
        public Queries Container { get; internal set; }
        public QueryElements Elements { get; protected set; }
        public override INode ParentNode => Container;
        public QueryProperties Properties { get; protected set; }
        public override ObjectType Type => ObjectType.Query;
    }
}