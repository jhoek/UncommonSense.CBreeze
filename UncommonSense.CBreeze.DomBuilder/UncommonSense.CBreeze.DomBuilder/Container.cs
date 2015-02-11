using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UncommonSense.CBreeze.DomBuilder
{
    public class Container : ObjectModelElement
    {
        private Item itemType;

        public Container(string name, Item itemType)
            : base(name)
        {
            this.itemType = itemType;
        }

        public Item ItemType
        {
            get
            {
                return this.itemType;
            }
        }
    }
}
