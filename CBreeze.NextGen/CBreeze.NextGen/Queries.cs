using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBreeze.NextGen
{
    public class Queries : KeyedContainer<int, Query>
    {
        internal Queries(Node parentNode)
            : base(parentNode)
        {
        }

        public override string ToString()
        {
            return "Queries";
        }
    }
}
