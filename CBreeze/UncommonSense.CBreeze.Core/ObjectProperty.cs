using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public class ObjectProperty : Property
    {
        internal ObjectProperty(string name)
            : base(name)
        {
        }

        public override bool HasValue
        {
            get
            {
                return Value != null;
            }
        }

        public System.Object Value
        {
            get;
            set;
        }
    }

}
