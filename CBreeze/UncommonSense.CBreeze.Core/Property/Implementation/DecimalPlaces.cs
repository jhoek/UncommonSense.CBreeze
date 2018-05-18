namespace UncommonSense.CBreeze.Core.Property.Implementation
{
        public class DecimalPlaces
    {
        // Made ctor public so that DecimalPlacesProperty can new up a new instance
        public DecimalPlaces()
        {
        }

        public int? AtLeast
        {
            get;
            set;
        }

        public int? AtMost
        {
            get;
            set;
        }
    }
}
