using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBreeze.NextGen
{
    public class XmlPortNodes : KeyedContainer<int, XmlPortNode>
    {
        internal XmlPortNodes(Node parentNode)
            : base(parentNode)
        {
        }

        public override string ToString()
        {
            return "Nodes";
        }
    }
}
