using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
        public class Documentation
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
