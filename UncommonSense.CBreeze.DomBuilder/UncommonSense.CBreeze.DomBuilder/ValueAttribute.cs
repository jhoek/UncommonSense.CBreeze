using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UncommonSense.CBreeze.DomBuilder
{
    public class ValueAttribute : Attribute
    {
        public ValueAttribute(string name)
            : base(name)
        {
        }

        public ValueAttribute(string name, string typeName)
            : base(name, typeName)
        {
        }
    }
}
