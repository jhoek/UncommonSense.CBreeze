using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public partial class Trigger
    {
        private CodeLines codeLines = new CodeLines();
        private Variables variables = new Variables();

        internal Trigger()
        {
        }

        public CodeLines CodeLines
        {
            get
            {
                return this.codeLines;
            }
        }

        public Variables Variables
        {
            get
            {
                return this.variables;
            }
        }

    }
}
