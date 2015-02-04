using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UncommonSense.CBreeze.DomBuilder2
{
    public class Property :  IChildNodeOfItem
    {
        private string name;
        private string propertyTypeName;

        public Property(string name, string propertyTypeName)
        {
            if (!propertyTypeName.EndsWith("Property", StringComparison.InvariantCultureIgnoreCase))
                propertyTypeName += "Property";

            this.name = name;
            this.propertyTypeName = propertyTypeName;
        }

        public override string ToString()
        {
            return string.Format("Property {0} : {1}", Name, PropertyTypeName);
        }

        public string Name
        {
            get
            {
                return this.name;
            }
        }

        public string PropertyTypeName
        {
            get
            {
                return this.propertyTypeName;
            }
        }

        public IEnumerable<INode> ChildNodes
        {
            get
            {
                yield break;
            }
        }
    }
}
