using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    public class ColumnFilterProperty : ReferenceProperty<TableFilter>
    {
        internal ColumnFilterProperty(string name)
            : base(name)
        {
        }

        public override bool HasValue => Value.Any();
    }
}