using UncommonSense.CBreeze.Core.Property.Type;

namespace UncommonSense.CBreeze.Core.Property.Implementation
{
#if NAV2015
        public class AccessByPermissionProperty : ReferenceProperty<AccessByPermission>
    {
        internal AccessByPermissionProperty(string name)
            : base(name)
        {
        }

        public override bool HasValue
        {
            get
            {
                return Value.ObjectType.HasValue && Value.ObjectID.HasValue;
            }
        }
    }
#endif
}
