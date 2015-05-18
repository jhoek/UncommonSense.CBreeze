using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBreeze.NextGen
{
    public class QueryElements : KeyedContainer<int, QueryElement>
    {
        internal QueryElements(Node parentNode)
            : base(parentNode)
        {
        }

        public override string ToString()
        {
            return "Elements";
        }
    }
}
