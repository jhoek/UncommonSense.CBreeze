using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public partial class DecimalPlaces
    {
        private Int32? atLeast;
        private Int32? atMost;

        internal DecimalPlaces()
        {
        }

        public Int32? AtLeast
        {
            get
            {
                return this.atLeast;
            }
            set
            {
                this.atLeast = value;
            }
        }

        public Int32? AtMost
        {
            get
            {
                return this.atMost;
            }
            set
            {
                this.atMost = value;
            }
        }

    }
}
