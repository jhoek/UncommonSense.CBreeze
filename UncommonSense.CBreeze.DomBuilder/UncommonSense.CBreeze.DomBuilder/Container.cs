using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UncommonSense.CBreeze.DomBuilder
{
    public class Container : ObjectModelElement
    {
        private string itemTypeName;

        public Container(string name, string itemTypeName)
            : base(name)
        {
            this.itemTypeName = itemTypeName;
        }

        public string ItemTypeName
        {
            get
            {
                return this.itemTypeName;
            }
        }
    }
}
