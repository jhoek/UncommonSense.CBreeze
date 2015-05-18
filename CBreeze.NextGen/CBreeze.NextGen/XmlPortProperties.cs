using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBreeze.NextGen
{
    public class XmlPortProperties : Properties
    {
        internal XmlPortProperties(Node parentNode)
            : base(parentNode)
        {
        }

        public override IEnumerable<INode> ChildNodes
        {
            get
            {
                yield break; // FIXME
            }
        }
    }
}
