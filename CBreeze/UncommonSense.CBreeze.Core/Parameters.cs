using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
        public class Parameters : IntegerKeyedAndNamedContainer<Parameter>
    {
        internal Parameters(IHasParameters container)
        {
            Container = container;
        }

        public IHasParameters Container
        {
            get;
            protected set;
        }

        public override void ValidateName(Parameter item)
        {
            TestNameNotNullOrEmpty(item);
            TestNameUnique(item);
        }
    }
}
