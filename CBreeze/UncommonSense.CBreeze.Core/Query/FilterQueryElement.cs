using System.Collections.Generic;
using UncommonSense.CBreeze.Common;
using UncommonSense.CBreeze.Core.Contracts;
using UncommonSense.CBreeze.Core.Property;

namespace UncommonSense.CBreeze.Core.Query
{
    public class FilterQueryElement : QueryElement
    {
        public FilterQueryElement(string dataSource = null, int id = 0, string name = null, int? indentationLevel = null)
            : base(id, name, indentationLevel)
        {
            Properties = new FilterQueryElementProperties(this);
            Properties.DataSource = dataSource;
        }

        public override IEnumerable<INode> ChildNodes
        {
            get
            {
                yield return Properties;
            }
        }

        public override QueryElementType Type
        {
            get
            {
                return QueryElementType.Filter;
            }
        }

        public override Properties AllProperties
        {
            get
            {
                return Properties;
            }
        }

        public FilterQueryElementProperties Properties
        {
            get;
            protected set;
        }
    }
}