using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UncommonSense.CBreeze.DomBuilder2
{
    public class Attribute : IChildNodeOfItem
    {
        private string name;
        private string typeName;

        public Attribute(string name, string typeName)
        {
            this.name = name;
            this.typeName = typeName;
        }

        public override string ToString()
        {
            return string.Format("Attribute {0} : {1}", Name, TypeName);
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

        public IEnumerable<INode> ChildNodes
        {
            get
            {
                yield break;
            }
        }
    }
}
