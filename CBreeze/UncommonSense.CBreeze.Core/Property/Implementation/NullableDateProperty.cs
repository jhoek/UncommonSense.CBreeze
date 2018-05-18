using System;

namespace UncommonSense.CBreeze.Core.Property.Implementation
{
        public class NullableDateProperty : NullableValueProperty<DateTime>
    {
        internal NullableDateProperty(string name)
            : base(name)
        {
        }
    }
}
