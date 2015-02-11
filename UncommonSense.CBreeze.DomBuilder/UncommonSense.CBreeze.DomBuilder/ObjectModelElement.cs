using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UncommonSense.CBreeze.DomBuilder
{
    public abstract class ObjectModelElement : ObjectModelNode
    {
        private string name;

        public ObjectModelElement(string name)
        {
            this.name = name;
        }

        public ObjectModel ObjectModel
        {
            get
            {
                return (ParentNode as ObjectModel);
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
        }
    }
}
