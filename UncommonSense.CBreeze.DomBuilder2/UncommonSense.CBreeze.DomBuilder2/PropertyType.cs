using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UncommonSense.CBreeze.DomBuilder2
{
    public class PropertyType : DomChildNode
    {
        [Flags]
        public enum Options
        {
            None = 0,
            ReferenceProperty= 1
        }

        private Dom dom;
        private string name;
        private string encapsulatedTypeName;
        private Options options;

        public PropertyType(string name, string encapsulatedTypeName, Options options)
        {
            if (!name.EndsWith("Property", StringComparison.InvariantCultureIgnoreCase))
                name += "Property";

            this.name = name;
            this.encapsulatedTypeName = encapsulatedTypeName;
            this.options = options;
        }

        public override string ToString()
        {
            return string.Format("PropertyType {0} encapsulates {1}", Name, EncapsulatedTypeName);
        }

        public string Name
        {
            get
            {
                return this.name;
            }
        }

        public string EncapsulatedTypeName
        {
            get
            {
                return this.encapsulatedTypeName;
            }
        }

        public override IEnumerable<INode> ChildNodes
        {
            get
            {
                yield break;
            }
        }

        public Dom Dom
        {
            get
            {
                return this.dom;
            }
            set
            {
                this.dom = value;
            }
        }
    }
}
