using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public partial class ColumnQueryElement : QueryElement
    {
        private ColumnQueryElementProperties properties = new ColumnQueryElementProperties();

        internal ColumnQueryElement(Int32 id, String name, Int32? indentationLevel) : base(id, name, indentationLevel)
        {
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
            get
            {
                return this.properties;
            }
        }

    }
}
