using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public class ObjectReferenceProperty : Property
    {
        private ObjectReference value = new ObjectReference();

        internal ObjectReferenceProperty(string name) : base(name)
        {
        }

        public override bool HasValue
        {
            get
            {
                return Value.ID != 0;
            }
        }

        public ObjectReference Value
        {
            get
            {
                return this.value;
            }
        }
    }

}
