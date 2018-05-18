namespace UncommonSense.CBreeze.Core.Property.Implementation
{
        public class DecimalPlacesProperty : ReferenceProperty<DecimalPlaces>
    {
        internal DecimalPlacesProperty(string name)
            : base(name)
        {
        }

        public override bool HasValue
        {
            get
            {
                return Value.AtLeast.HasValue || Value.AtMost.HasValue;
            }
        }
    }
}
