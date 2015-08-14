using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public partial class DataItemQueryElement : QueryElement
    {
        private DataItemQueryElementProperties properties = new DataItemQueryElementProperties();

        internal DataItemQueryElement(Int32 id, String name, Int32? indentationLevel) : base(id, name, indentationLevel)
        {
        }

        public override QueryElementType Type
        {
            get
            {
                return QueryElementType.DataItem;
            }
        }

        public DataItemQueryElementProperties Properties
        {
            get
            {
                return this.properties;
            }
        }

    }
}
