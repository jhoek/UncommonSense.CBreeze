using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public partial class RdlData
    {
        private CodeLines lines = new CodeLines();

        internal RdlData()
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
