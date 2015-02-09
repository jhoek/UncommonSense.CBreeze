using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UncommonSense.CBreeze.DomBuilder
{
    public abstract class PropertyType : Node
    {
        private string name;

        public PropertyType(string name)
        {
            if (!name.EndsWith("property", StringComparison.InvariantCultureIgnoreCase))
                name = name + "Property";

            this.name = name;
        }

        public override string Name
        {
            get
            {
                return this.name;
            }
        }
    }

    public class ValuePropertyType : PropertyType
    {
        public ValuePropertyType(string name)
            : base(name)
        {
        }
    }

    public class ReferencePropertyType : PropertyType
    {
        public ReferencePropertyType(string name)
            : base(name)
        {
        }
    }
}
