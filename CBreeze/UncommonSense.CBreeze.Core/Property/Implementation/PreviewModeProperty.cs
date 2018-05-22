using UncommonSense.CBreeze.Core.Property.Enumeration;

namespace UncommonSense.CBreeze.Core.Property.Implementation
{
#if NAV2015
        public class PreviewModeProperty : NullableValueProperty<PreviewMode>
    {
        internal PreviewModeProperty(string name)
            : base(name)
        {
        }
    }
#endif
}
