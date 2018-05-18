using System.Collections.Generic;
using UncommonSense.CBreeze.Common;
using UncommonSense.CBreeze.Core.Contracts;
using UncommonSense.CBreeze.Core.Property;
using UncommonSense.CBreeze.Core.Table;

namespace UncommonSense.CBreeze.Core.Query
{
    public class DataItemQueryElement : QueryElement
    {
        public DataItemQueryElement(int dataItemTable, int id = 0, string name = null, int? indentationLevel = null)
            : base(id, name, indentationLevel)
        {
            Properties = new DataItemQueryElementProperties(this);
            Properties.DataItemTable = dataItemTable;
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
            get;
            protected set;
        }

        public override IEnumerable<INode> ChildNodes
        {
            get
            {
                yield return Properties;
            }
        }

        public override Properties AllProperties
        {
            get
            {
                return Properties;
            }
        }
    }
}