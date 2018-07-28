using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    public class PageTypeProperty : NullableValueProperty<PageType>
    {
        internal PageTypeProperty(string name)
            : base(name)
        {
        }
    }
}