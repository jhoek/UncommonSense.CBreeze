using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UncommonSense.CBreeze.ObjectModelBuilder
{
    public class Attribute : ObjectModelNode
    {
        public Attribute(string typeName, string name)
        {
            TypeName = typeName;
            Name = name;
        }

        public string Name
        {
            get;
            internal set;
        }

        public string TypeName
        {
            get;
            internal set;
        }
    }
}
