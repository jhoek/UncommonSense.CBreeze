using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UncommonSense.CBreeze.Core
{
    public abstract class NullableValueProperty<T> : ValueProperty<T?> where T : struct
    {
        internal NullableValueProperty(string name)
            : base(name)
        {
        }

        public override void Reset() => Value = null;

        public override bool HasValue
        {
            get
            {
                return Value.HasValue;
            }
        }
    }
}
