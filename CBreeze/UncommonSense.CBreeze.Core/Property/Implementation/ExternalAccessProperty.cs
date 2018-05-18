using UncommonSense.CBreeze.Core.Property.Enumeration;

namespace UncommonSense.CBreeze.Core.Property.Implementation
{
#if NAV2016
    public class ExternalAccessProperty : NullableValueProperty<ExternalAccess>
    {
        internal ExternalAccessProperty(string name)
            : base(name)
        {
        }
    }
#endif
}
