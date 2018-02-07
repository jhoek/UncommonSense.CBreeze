using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    public class DataItemQueryElementTableFilterProperty : ReferenceProperty<TableFilter>
    {
        internal DataItemQueryElementTableFilterProperty(string name)
            : base(name)
        {
        }

        public override bool HasValue
        {
            get
            {
                return Value.Any();
            }
        }
    }
}