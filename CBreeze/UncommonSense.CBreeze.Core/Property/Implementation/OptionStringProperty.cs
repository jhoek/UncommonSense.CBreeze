namespace UncommonSense.CBreeze.Core.Property.Implementation
{
        public class OptionStringProperty : StringProperty
    {
        internal OptionStringProperty(string name)
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
    }
}
