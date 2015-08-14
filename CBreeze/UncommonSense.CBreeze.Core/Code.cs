using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    [Serializable]
    public partial class Code
    {
        private Documentation documentation = new Documentation();
        private Events events = new Events();
        private Functions functions = new Functions();
        private Variables variables = new Variables();

        internal Code()
        {
        }

        public Documentation Documentation
        {
            get
            {
                return this.documentation;
            }
        }

        public Events Events
        {
            get
            {
                return this.events;
            }
        }

        public Functions Functions
        {
            get
            {
                return this.functions;
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
