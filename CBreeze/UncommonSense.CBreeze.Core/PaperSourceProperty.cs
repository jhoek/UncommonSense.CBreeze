using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public class PaperSourceProperty : NullableValueProperty<PaperSource>
    {
        internal PaperSourceProperty(string name)
            : base(name)
        {
        }
    }
}
