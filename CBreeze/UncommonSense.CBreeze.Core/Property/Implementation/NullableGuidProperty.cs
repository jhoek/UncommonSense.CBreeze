using System;

namespace UncommonSense.CBreeze.Core.Property.Implementation
{
        public class NullableGuidProperty : NullableValueProperty<Guid>
    {
        internal NullableGuidProperty(string name)
            : base(name)
        {
        }
    }
}
