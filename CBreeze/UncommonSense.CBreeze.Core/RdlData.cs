using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    public class RdlData : IHasCodeLines
    {
        internal RdlData()
        {
            CodeLines = new CodeLines();
        }

        public CodeLines CodeLines
        {
            get;
            protected set;
        }
    }
}
