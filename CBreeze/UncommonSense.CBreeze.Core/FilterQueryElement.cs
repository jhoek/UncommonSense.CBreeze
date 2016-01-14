using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public class FilterQueryElement : QueryElement
    {
        public FilterQueryElement(int id, string name, int? indentationLevel)
            : base(id, name, indentationLevel)
        {
            Properties = new FilterQueryElementProperties();
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
