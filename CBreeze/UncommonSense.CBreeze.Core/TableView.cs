using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public partial class TableView
    {
        private String key;
        private Order? order;
        private TableFilter tableFilter = new TableFilter();

        internal TableView()
        {
        }

        public String Key
        {
            get
            {
                return this.key;
            }
            set
            {
                this.key = value;
            }
        }

        public Order? Order
        {
            get
            {
                return this.order;
            }
            set
            {
                this.order = value;
            }
        }

        public TableFilter TableFilter
        {
            get
            {
                return this.tableFilter;
            }
        }

    }
}
