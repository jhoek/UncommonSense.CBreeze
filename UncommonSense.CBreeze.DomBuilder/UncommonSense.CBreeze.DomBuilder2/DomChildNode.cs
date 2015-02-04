using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UncommonSense.CBreeze.DomBuilder2
{
    public abstract class DomChildNode : INode
    {
        public Dom Dom
        {
            get;
            internal set;
        }

        public abstract IEnumerable<INode> ChildNodes
        {
            get;
        }
    }
}
