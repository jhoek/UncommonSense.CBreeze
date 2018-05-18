using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Core
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