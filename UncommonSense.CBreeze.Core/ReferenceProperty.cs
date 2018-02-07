using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UncommonSense.CBreeze.Core
{
    public abstract class ReferenceProperty<T> : Property where T : new()
    {
        internal ReferenceProperty(string name) : base(name)
        {
            Value = new T();
        }

        public T Value
        {
            get;
            protected set;
        }

        public override object GetValue() => Value;
    }
}