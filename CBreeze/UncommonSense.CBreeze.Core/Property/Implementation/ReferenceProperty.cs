﻿namespace UncommonSense.CBreeze.Core.Property.Implementation
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

        public override void Reset() => Value = new T();

        public override object GetValue() => Value;
    }
}