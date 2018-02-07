using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
        public class RunObjectProperty : ReferenceProperty<RunObject>
    {
        internal RunObjectProperty(string name)
            : base(name)
        {
        }

        public override bool HasValue
        {
            get
            {
                return Value.Type.HasValue && Value.ID.HasValue;
            }
        }
    }
}
