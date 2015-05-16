using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBreeze.NextGen
{
    public class TableKeys : Container<TableKey>
    {
        internal TableKeys(Node parentNode)
            : base(parentNode)
        {
        }

        public override string ToString()
        {
            return "Keys";
        }
    }
}
