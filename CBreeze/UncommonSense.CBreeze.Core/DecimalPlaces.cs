using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public class DecimalPlaces
    {
        // Made ctor public so that DecimalPlacesProperty can new up a new instance
        public DecimalPlaces()
        {
        }

        public int? AtLeast
        {
            get;
            set;
        }

        public int? AtMost
        {
            get;
            set;
        }
    }
}
