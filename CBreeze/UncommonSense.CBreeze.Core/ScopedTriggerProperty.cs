using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public class ScopedTriggerProperty : Property
    {
        private Trigger value = new Trigger();

        internal ScopedTriggerProperty(string name) : base(name)
        {
        }

        public override bool HasValue
        {
            get
            {
                return Value.CodeLines.Any() || Value.Variables.Any();
            }
        }

        public Trigger Value
        {
            get
            {
                return this.value;
            }
        }
    }

}
