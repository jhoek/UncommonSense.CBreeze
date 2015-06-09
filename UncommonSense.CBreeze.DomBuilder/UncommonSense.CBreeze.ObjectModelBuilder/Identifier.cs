using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UncommonSense.CBreeze.ObjectModelBuilder
{
    public class Identifier : Attribute
    {
        public Identifier(string typeName, string name)
            : base(typeName, name)
        {
        }
    }
}
