using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public class Codeunits : IntegerKeyedAndNamedContainer<Codeunit>
    {
        internal Codeunits()
        {
        }

        public override void ValidateName(Codeunit item)
        {
            TestNameNotNullOrEmpty(item);
            TestNameUnique(item);
        }
    }
}
