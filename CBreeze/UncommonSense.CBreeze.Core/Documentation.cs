using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
        public class Documentation : IHasCodeLines
    {
        internal Documentation(Code code)
        {
            Code = code;
            CodeLines = new CodeLines();
        }

        public Code Code
        {
            get;
            protected set;
        }

        public CodeLines CodeLines
        {
            get;
            protected set;
        }
    }
}
