using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UncommonSense.CBreeze.Core
{
#if NAV2015
    [Serializable]
    public class WordLayout
    {
        internal WordLayout()
        {
            Lines = new CodeLines();
        }

        public CodeLines Lines
        {
            get;
            protected set;
        }
    }
#endif
}
