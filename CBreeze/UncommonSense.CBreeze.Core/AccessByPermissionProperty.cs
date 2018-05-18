using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UncommonSense.CBreeze.Core
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
