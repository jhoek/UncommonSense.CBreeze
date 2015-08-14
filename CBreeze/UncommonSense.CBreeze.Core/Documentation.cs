using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public partial class Documentation
    {
        private CodeLines lines = new CodeLines();

        internal Documentation()
        {
        }

        public CodeLines Lines
        {
            get
            {
                return this.lines;
            }
        }

    }
}
