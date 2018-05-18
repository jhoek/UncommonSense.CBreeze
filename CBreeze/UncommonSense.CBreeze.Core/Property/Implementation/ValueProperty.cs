namespace UncommonSense.CBreeze.Core.Property.Implementation
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

        public override object GetValue() => Value;
    }
}