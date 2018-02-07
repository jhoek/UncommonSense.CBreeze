using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UncommonSense.CBreeze.Core
{
#if NAV2015
    public class WordLayout : IHasCodeLines, INode
    {
        internal WordLayout(Report report)
        {
            Report = report;
            CodeLines = new CodeLines(this);
        }

        public Report Report { get; protected set; }

        public IEnumerable<INode> ChildNodes
        {
            get
            {
                yield return CodeLines;
            }
        }

        public CodeLines CodeLines
        {
            get;
            protected set;
        }

        public INode ParentNode => Report;
    }
#endif
}
