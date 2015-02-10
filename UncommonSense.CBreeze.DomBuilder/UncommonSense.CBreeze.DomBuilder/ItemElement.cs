using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UncommonSense.CBreeze.DomBuilder
{
    public abstract class ItemElement
    {
        private string name;
        private Item item;

        public ItemElement(string name)
        {
            this.name = name;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
        }

        public Item Item
        {
            get
            {
                return this.item;
            }
            internal set
            {
                this.item = value;
            }
        }
    }
}
