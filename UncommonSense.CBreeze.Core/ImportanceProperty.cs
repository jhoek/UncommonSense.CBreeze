using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
        public class ImportanceProperty : NullableValueProperty<Importance>
    {
        internal ImportanceProperty(string name)
            : base(name)
        {
        }
    }
}
