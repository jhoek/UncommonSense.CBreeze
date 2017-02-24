using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
        public class Pages : IntegerKeyedAndNamedContainer<Page>
    {
        internal Pages(IEnumerable<Page> pages)
        {
            AddRange(pages);
        }

        public override void ValidateName(Page item)
        {
            TestNameNotNullOrEmpty(item);
            TestNameUnique(item);
        }
    }
}
