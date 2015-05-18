using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBreeze.NextGen
{
    public class Query : Object, IEquatable<Query>
    {
        public Query(int id, string name)
            : base(id, name)
        {
            Properties = new QueryProperties(this);
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
            internal set;
        }

        public QueryElements Elements
        {
            get;
            internal set;
        }

        public Code Code
        {
            get;
            internal set;
        }

        public override IEnumerable<INode> ChildNodes
        {
            get
            {
                yield return ObjectProperties;
                yield return Properties;
                yield return Elements;
                yield return Code;
            }
        }

        public bool Equals(Query other)
        {
            if (other == null)
                return false;

            if (other.ID == ID)
                return true;

            if (other.Name == Name)
                return true;

            return false;
        }
    }
}
