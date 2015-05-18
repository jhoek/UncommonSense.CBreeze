using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBreeze.NextGen
{
    public class QueryColumnElement : QueryElement
    {
        public QueryColumnElement(int id, string name, int? indentationLevel)
            : base(id, name, indentationLevel)
        {
            Properties = new QueryColumnElementProperties(this);
        }

        public override QueryElementType Type
        {
            get
            {
                return QueryElementType.Column;
            }
        }

        public QueryColumnElementProperties Properties
        {
            get;
            internal set;
        }

        public override IEnumerable<INode> ChildNodes
        {
            get
            {
                yield return Properties;
            }
        }
    }
}
