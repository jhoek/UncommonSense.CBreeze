using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UncommonSense.CBreeze.Core
{
#if NAV2015
    [Serializable]
    public class PreviewModeProperty : NullableValueProperty<PreviewMode>
    {
        internal PreviewModeProperty(string name)
            : base(name)
        {
        }
    }
#endif
}
