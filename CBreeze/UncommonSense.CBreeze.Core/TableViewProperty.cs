using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
        public class TableViewProperty : ReferenceProperty<TableView>
    {
        internal TableViewProperty(string name)
            : base(name)
        {
        }

        public override bool HasValue
        {
            get
            {
                return Value.Key != null || Value.Order.HasValue || Value.TableFilter.Any();
            }
        }
    }
}
