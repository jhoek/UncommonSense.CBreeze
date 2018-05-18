using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
        public class LinkField
    {
        public LinkField(int field, int referenceField)
        {
            Field = field;
            ReferenceField = referenceField;
        }

        public int Field
        {
            get;
            protected set;
        }

        public int ReferenceField
        {
            get;
            protected set;
        }
    }
}
