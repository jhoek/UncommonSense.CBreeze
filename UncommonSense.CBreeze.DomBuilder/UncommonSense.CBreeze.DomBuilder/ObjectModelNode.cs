using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UncommonSense.CBreeze.DomBuilder
{
    public abstract class ObjectModelNode
    {
        private ObjectModelNode parentNode;

        public ObjectModelNode ParentNode
        {
            get
            {
                return this.parentNode;
            }
            internal set
            {
                this.parentNode = value;
            }
        }
    }
}
