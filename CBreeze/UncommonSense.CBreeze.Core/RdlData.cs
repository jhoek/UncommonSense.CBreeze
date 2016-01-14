using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public class RdlData
    {
        internal RdlData()
        {
            Lines = new CodeLines();
        }

        public CodeLines Lines
        {
            get;
            protected set;
        }
    }
}
