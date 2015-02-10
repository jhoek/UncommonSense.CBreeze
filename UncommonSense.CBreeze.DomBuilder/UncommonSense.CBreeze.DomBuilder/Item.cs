using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UncommonSense.CBreeze.DomBuilder
{
    public class Item : ObjectModelElement
    {
        private List<ItemElement> elements = new List<ItemElement>();

        public Item(string name, params ItemElement[] elements)
            : base(name)
        {
            foreach (var element in elements)
            {
                element.Item = this;
                this.elements.Add(element);
            }
        }

        public IEnumerable<ItemElement> Elements
        {
            get
            {
                foreach (var element in elements)
                {
                    yield return element;
                }
            }
        }
    }
}
