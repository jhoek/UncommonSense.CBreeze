using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public class Pages : IntegerKeyedAndNamedContainer<Page>
    {
        internal Pages()
        {
        }

        public override void ValidateName(Page item)
        {
            TestNameNotNullOrEmpty(item);
            TestNameUnique(item);
        }
    }
}
