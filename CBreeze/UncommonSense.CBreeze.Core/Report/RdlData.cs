using System.Collections.Generic;

namespace UncommonSense.CBreeze.Core
{
    public class RdlData : IHasCodeLines, INode
    {
        internal RdlData(Report report)
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
}