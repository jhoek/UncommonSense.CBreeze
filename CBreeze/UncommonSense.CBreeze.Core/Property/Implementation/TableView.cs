using UncommonSense.CBreeze.Core.Property.Enumeration;
using UncommonSense.CBreeze.Core.Table.Field.Properties;

namespace UncommonSense.CBreeze.Core.Property.Implementation
{
        public class TableView
    {
        public TableView()
        {
            TableFilter = new TableFilter();
        }

        public string Key
        {
            get;
            set;
        }

        public Order? Order
        {
            get;
            set;
        }

        public TableFilter TableFilter
        {
            get;
            protected set;
        }
    }
}
