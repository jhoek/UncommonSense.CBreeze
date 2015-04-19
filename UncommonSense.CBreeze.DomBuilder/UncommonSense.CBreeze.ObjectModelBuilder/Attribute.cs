using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UncommonSense.CBreeze.ObjectModelBuilder
{
    public class Attribute
    {
        public Attribute(ObjectModelElement type, string name)
        {
            Type = type;
            Name = name;
        }

        public ObjectModelElement Type
        {
            get;
            internal set;
        }

        public string Name
        {
            get;
            internal set;
        }
    }
}
