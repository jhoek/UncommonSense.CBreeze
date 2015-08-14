using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public class TableViewProperty : Property
    {
        private TableView value = new TableView();

        internal TableViewProperty(string name) : base(name)
        {
        }

        public override bool HasValue
        {
            get
            {
                return Value.Key != null || Value.Order.HasValue || Value.TableFilter.Any();
            }
        }

        public TableView Value
        {
            get
            {
                return this.value;
            }
        }
    }

}
