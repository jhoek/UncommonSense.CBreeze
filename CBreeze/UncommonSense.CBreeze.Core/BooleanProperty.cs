using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    public class BooleanProperty : ValueProperty<bool>
    {
        internal BooleanProperty(string name) : base(name)
        {
        }

        public override void Reset() => Value = false;

        public override bool HasValue => Value;
    }
}