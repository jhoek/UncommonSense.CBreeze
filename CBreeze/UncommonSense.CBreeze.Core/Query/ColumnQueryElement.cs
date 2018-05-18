using System.Collections.Generic;
using UncommonSense.CBreeze.Common;
using UncommonSense.CBreeze.Core.Contracts;
using UncommonSense.CBreeze.Core.Property;

namespace UncommonSense.CBreeze.Core.Query
{
    public class ColumnQueryElement : QueryElement
    {
        public ColumnQueryElement(string dataSource = null, int id = 0, string name = null, int? indentationLevel = null)
            : base(id, name, indentationLevel)
        {
            Properties = new ColumnQueryElementProperties(this);
            Properties.DataSource = dataSource;
        }

        public override QueryElementType Type
        {
            get
            {
                return QueryElementType.Column;
            }
        }

        public ColumnQueryElementProperties Properties
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

        public override IEnumerable<INode> ChildNodes
        {
            get
            {
                yield return Properties;
            }
        }
    }
}