using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UncommonSense.CBreeze.Core
{
    public abstract class ValueProperty<T> : Property
    {
        internal ValueProperty(string name)
            : base(name)
        {
        }

        public T Value
        {
            get;
            set;
        }
    }
}
