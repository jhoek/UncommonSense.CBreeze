using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBreeze.NextGen
{
    public class TableFieldGroups : KeyedContainer<int, TableFieldGroup>
    {
        internal TableFieldGroups(Node parentNode)
            : base(parentNode)
        {
        }

        public override string ToString()
        {
            return "FieldGroups";
        }
    }
}
