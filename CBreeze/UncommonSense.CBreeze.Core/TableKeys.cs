using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace UncommonSense.CBreeze.Core
{
        public class TableKeys : Collection<TableKey>
    {
        internal TableKeys()
        {
        }

        public new TableKey Add(TableKey item)
        {
            this.InsertItem(Count, item);
            return item;
        }

        public new TableKey Insert(int index, TableKey item)
        {
            this.InsertItem(index, item);
            return item;
        }
    }
}
