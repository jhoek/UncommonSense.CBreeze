using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    public class Documentation : IHasCodeLines, INode
    {
        internal Documentation(Code code)
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

        public Code Code
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
