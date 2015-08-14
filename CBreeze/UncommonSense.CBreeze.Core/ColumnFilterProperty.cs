using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public class ColumnFilterProperty : Property
    {
        private ColumnFilter value = new ColumnFilter();

        internal ColumnFilterProperty(string name) : base(name)
        {
        }

        public override bool HasValue
        {
            get
            {
                return Value.Any();
            }
        }

        public ColumnFilter Value
        {
            get
            {
                return this.value;
            }
        }
    }

}
