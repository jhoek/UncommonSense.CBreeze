namespace UncommonSense.CBreeze.Core.Property.Implementation
{
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

        public override void Reset() => Value = null;

        public override object GetValue() => Value;
    }
}