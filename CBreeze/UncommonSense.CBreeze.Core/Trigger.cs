using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public partial class Trigger : IHasVariables
    {
        public Trigger()
        {
            CodeLines = new CodeLines();
            Variables = new Variables(this);
        }

        public CodeLines CodeLines
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
