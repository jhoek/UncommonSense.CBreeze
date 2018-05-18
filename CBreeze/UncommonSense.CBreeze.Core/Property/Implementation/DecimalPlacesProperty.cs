using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
        public class DecimalPlacesProperty : ReferenceProperty<DecimalPlaces>
    {
        internal DecimalPlacesProperty(string name)
            : base(name)
        {
        }

        public override bool HasValue
        {
            get
            {
                return Value.AtLeast.HasValue || Value.AtMost.HasValue;
            }
        }
    }
}
