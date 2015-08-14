using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public class DataItemQueryElementTableFilterProperty : Property
    {
        private DataItemQueryElementTableFilter value = new DataItemQueryElementTableFilter();

        internal DataItemQueryElementTableFilterProperty(string name) : base(name)
        {
        }

        public override bool HasValue
        {
            get
            {
                return Value.Any();
            }
        }

        public DataItemQueryElementTableFilter Value
        {
            get
            {
                return this.value;
            }
        }
    }

}
