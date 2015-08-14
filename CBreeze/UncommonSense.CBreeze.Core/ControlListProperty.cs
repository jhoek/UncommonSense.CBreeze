using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public class ControlListProperty : Property
    {
        private ControlList value = new ControlList();

        internal ControlListProperty(string name) : base(name)
        {
        }

        public override bool HasValue
        {
            get
            {
                return Value.Any();
            }
        }

        public ControlList Value
        {
            get
            {
                return this.value;
            }
        }
    }

}
