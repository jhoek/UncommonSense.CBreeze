using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UncommonSense.CBreeze.DomBuilder
{
    public class Property : ItemElement
    {
        private string typeName;

        public Property(string name, string typeName)
            : base(name)
        {
            this.typeName = typeName;
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
