using System;

namespace UncommonSense.CBreeze.Core.Property.Implementation
{
        public class DurationProperty : NullableValueProperty<TimeSpan>
    {
        internal DurationProperty(string name)
            : base(name)
        {
        }
    }
}
