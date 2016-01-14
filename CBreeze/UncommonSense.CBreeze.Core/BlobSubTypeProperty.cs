using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public class BlobSubTypeProperty : NullableValueProperty<BlobSubType>
    {
        internal BlobSubTypeProperty(string name)
            : base(name)
        {
        }
    }
}
