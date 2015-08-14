using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public partial class FilterQueryElement : QueryElement
    {
        private FilterQueryElementProperties properties = new FilterQueryElementProperties();

        internal FilterQueryElement(Int32 id, String name, Int32? indentationLevel) : base(id, name, indentationLevel)
        {
        }

        public override QueryElementType Type
        {
            get
            {
                return QueryElementType.Filter;
            }
        }

        public FilterQueryElementProperties Properties
        {
            get
            {
                return this.properties;
            }
        }

    }
}
