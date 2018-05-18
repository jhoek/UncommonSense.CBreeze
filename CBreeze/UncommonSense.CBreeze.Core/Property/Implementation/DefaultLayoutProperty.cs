using UncommonSense.CBreeze.Core.Property.Enumeration;

namespace UncommonSense.CBreeze.Core.Property.Implementation
{
#if NAV2015
        public class DefaultLayoutProperty : NullableValueProperty<DefaultLayout>
    {
        internal DefaultLayoutProperty(string name)
            : base(name)
        {
        }
    }
#endif
}
