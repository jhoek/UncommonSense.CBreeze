using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    public class StringProperty : Property
    {
        internal StringProperty(string name)
            : base(name)
        {
            Value = null;
        }

        public override bool HasValue
        {
            get
            {
                return Value != null;
            }
        }

        public virtual string Value
        {
            get;
            set;
        }

        public override void Reset() => Value = null;

        public override object GetValue() => Value;
    }
}