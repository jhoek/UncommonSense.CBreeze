namespace UncommonSense.CBreeze.Core.Property.Implementation
{
    public class BooleanProperty : ValueProperty<bool>
    {
        internal BooleanProperty(string name) : base(name)
        {
        }

        public override void Reset() => Value = false;

        public override bool HasValue => Value;
    }
}