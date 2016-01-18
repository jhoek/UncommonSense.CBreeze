using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
        public class Queries : IntegerKeyedAndNamedContainer<Query>
    {
        internal Queries()
        {
        }

        public override void ValidateName(Query item)
        {
            TestNameNotNullOrEmpty(item);
            TestNameUnique(item);
        }
    }
}
