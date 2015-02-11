using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UncommonSense.CBreeze.DomBuilder
{
    public class ReferenceAttribute : Attribute
    {
        public ReferenceAttribute(string name)
            : base(name)
        {
        }

        public ReferenceAttribute(string name, string typeName)
            : base(name, typeName)
        {
        }
    }
}
