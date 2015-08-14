using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public class DecimalPlacesProperty : Property
    {
        private DecimalPlaces value = new DecimalPlaces();

        internal DecimalPlacesProperty(string name) : base(name)
        {
        }

        public override bool HasValue
        {
            get
            {
                return Value.AtLeast.HasValue || Value.AtMost.HasValue;
            }
        }

        public DecimalPlaces Value
        {
            get
            {
                return this.value;
            }
        }
    }

}
