using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
        public class Variables : IntegerKeyedAndNamedContainer<Variable>
    {
        internal Variables(IHasVariables container)
        {
        }

        public IHasVariables Container
        {
            get;
            protected set;
        }

        public override void ValidateName(Variable item)
        {
            TestNameNotNullOrEmpty(item);
        }
    }
}
