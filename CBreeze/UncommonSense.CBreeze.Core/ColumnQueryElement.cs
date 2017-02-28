using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Core
{
        public class ColumnQueryElement : QueryElement
    {
        public ColumnQueryElement(int id, string name, int? indentationLevel)
            : base(id, name, indentationLevel)
        {
            Properties = new ColumnQueryElementProperties(this);
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
