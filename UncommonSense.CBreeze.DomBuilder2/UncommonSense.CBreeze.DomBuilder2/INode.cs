using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UncommonSense.CBreeze.DomBuilder2
{
    public interface INode
    {
        IEnumerable<INode> ChildNodes
        {
            get;
        }
    }
}
