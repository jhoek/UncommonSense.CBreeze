using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public partial class Documentation
    {
        internal Documentation(Code code)
        {
            Code = code;
            Lines = new CodeLines();
        }

        public Code Code
        {
            get;
            protected set;
        }

        public CodeLines Lines
        {
            get;
            protected set;
        }
    }
}
