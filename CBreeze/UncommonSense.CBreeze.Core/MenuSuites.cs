using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
        public class MenuSuites : IntegerKeyedAndNamedContainer<MenuSuite>
    {
        internal MenuSuites()
        {
        }

        public override void ValidateName(MenuSuite item)
        {
            TestNameNotNullOrEmpty(item);
            TestNameUnique(item);
        }
    }
}
