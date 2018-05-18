using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

#if NAV2017
namespace UncommonSense.CBreeze.Core
{
    public class TestPermissionsProperty : NullableValueProperty<TestPermissions>
    {
        internal TestPermissionsProperty(string name) : base(name) { }
    }
}
#endif 