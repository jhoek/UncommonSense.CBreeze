using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public class Code : IHasVariables
    {
        internal Code(Object @object)
        {
            Object = @object;
            Documentation = new Documentation(this);
            Events = new Events(this);
            Functions = new Functions(this);
            Variables = new Variables(this);
        }

        public Object Object
        {
            get;
            protected set;
        }

        public Documentation Documentation
        {
            get;
            protected set;
        }

        public Events Events
        {
            get;
            protected set;
        }

        public Functions Functions
        {
            get;
            protected set;
        }

        public Variables Variables
        {
            get;
            protected set;
        }
    }
}
