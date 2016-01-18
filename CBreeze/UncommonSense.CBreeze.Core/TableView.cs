using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
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
