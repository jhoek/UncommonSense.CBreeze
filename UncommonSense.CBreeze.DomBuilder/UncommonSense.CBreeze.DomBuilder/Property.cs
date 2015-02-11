using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UncommonSense.CBreeze.DomBuilder
{
    public class Property
    {
        private string name;
        private string typeName;

        public Property(string name, string typeName)
        {
            this.name = name;
            this.typeName = typeName;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
        }

        public string TypeName
        {
            get
            {
                return this.typeName;
            }
        }
    }
}
