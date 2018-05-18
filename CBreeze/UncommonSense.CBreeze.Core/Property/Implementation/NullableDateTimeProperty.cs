using System;

namespace UncommonSense.CBreeze.Core.Property.Implementation
{
        public class NullableDateTimeProperty : NullableValueProperty<DateTime>
    {
        internal NullableDateTimeProperty(string name)
            : base(name)
        {
        }
    }
}