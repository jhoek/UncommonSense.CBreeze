using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public class TestFunctionTypeProperty : NullableValueProperty<TestFunctionType>
    {
        internal TestFunctionTypeProperty(string name)
            : base(name)
        {
        }
    }
}
