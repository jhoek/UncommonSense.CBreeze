using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UncommonSense.CBreeze.Core
{
#if NAV2015
        public class PageActionScopeProperty : NullableValueProperty<PageActionScope>
    {
        internal PageActionScopeProperty(string name)
            : base(name)
        {
        }
    }
#endif
}
