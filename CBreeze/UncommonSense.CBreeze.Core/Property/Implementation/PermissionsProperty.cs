using System.Linq;

namespace UncommonSense.CBreeze.Core.Property.Implementation
{
        public class PermissionsProperty : ReferenceProperty<Permissions>
    {
        internal PermissionsProperty(string name)
            : base(name)
        {
        }

        public override bool HasValue
        {
            get
            {
                return Value.Any();
            }
        }
    }
}
