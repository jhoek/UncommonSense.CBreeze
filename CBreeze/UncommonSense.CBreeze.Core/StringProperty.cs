using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public class StringProperty : Property
    {
        private System.String value = null;

        internal StringProperty(string name) : base(name)
        {
        }

        public override bool HasValue
        {
            get
            {
                return Value != null;
            }
        }

        public System.String Value
        {
            get
            {
                return this.value;
            }
            set
            {
                this.value = value;
            }
        }
    }

}
