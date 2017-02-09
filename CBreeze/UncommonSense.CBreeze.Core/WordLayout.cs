using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UncommonSense.CBreeze.Core
{
#if NAV2015
        public class WordLayout : IHasCodeLines
    {
        internal WordLayout()
        {
            CodeLines = new CodeLines();
        }

        public CodeLines CodeLines
        {
            get;
            protected set;
        }
    }
#endif
}
