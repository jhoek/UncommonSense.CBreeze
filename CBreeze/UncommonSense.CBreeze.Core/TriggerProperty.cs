using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public class TriggerProperty : ReferenceProperty<Trigger>
    {
        internal TriggerProperty(string name)
            : base(name)
        {
        }

        public override bool HasValue
        {
            get
            {
                return Value.CodeLines.Any() || Value.Variables.Any();
            }
        }
    }
}
