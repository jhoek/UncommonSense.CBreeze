using System.Collections.Generic;
using UncommonSense.CBreeze.Core.Contracts;

namespace UncommonSense.CBreeze.Core.Code
{
    public class Documentation : IHasCodeLines, INode
    {
        internal Documentation(Variable.Code code)
        {
            Code = code;
            CodeLines = new CodeLines(this);
        }

        public IEnumerable<INode> ChildNodes
        {
            get
            {
                yield return CodeLines;
            }
        }

        public Variable.Code Code
        {
            get;
            protected set;
        }

        public CodeLines CodeLines
        {
            get;
            protected set;
        }

        public INode ParentNode => Code;
    }
}
