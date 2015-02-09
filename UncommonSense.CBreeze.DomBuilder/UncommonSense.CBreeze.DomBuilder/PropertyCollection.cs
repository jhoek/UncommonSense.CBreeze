using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UncommonSense.CBreeze.DomBuilder
{
    public class PropertyCollection : ObjectModelElement
    {
        private List<Property> properties = new List<Property>();

        public PropertyCollection(string name, params Property[] properties)
            : base(name)
        {
            foreach (var property in properties)
            {
                property.ParentNode = this;
                this.properties.Add(property);
            }           
        }
    }
}
