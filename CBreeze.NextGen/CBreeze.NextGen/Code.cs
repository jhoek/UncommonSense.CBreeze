using System;
using System.Collections.Generic;

namespace CBreeze.NextGen
{
    public class Code : Node
    {
        private Variables variables;
        private Functions functions;

        internal Code()
        {
            this.variables = new Variables(this);
            this.functions = new Functions(this);
        }

        public override string ToString()
        {
            return "Code";
        }

        public Variables Variables
        {
            get
            {
                return this.variables;
            }
        }

        public Functions Functions
        {
            get
            {
                return this.functions;
            }
        }

        public override IEnumerable<INode> ChildNodes
        {
            get
            {
                yield return Variables;
                yield return Functions;
            }
        }
    }
}

