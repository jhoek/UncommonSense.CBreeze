using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public class FieldListProperty : Property
    {
        private FieldList value = new FieldList();

        internal FieldListProperty(string name) : base(name)
        {
        }

        public override bool HasValue
        {
            get
            {
                return Value.Any();
            }
        }

        public FieldList Value
        {
            get
            {
                return this.value;
            }
        }
    }

}
