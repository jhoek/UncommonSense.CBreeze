using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UncommonSense.CBreeze.DomBuilder
{
    public class Item : ObjectModelElement
    {
        private bool isAbstract;
        private string baseItemName;
        private List<ItemElement> elements = new List<ItemElement>();

        public Item(string name, string baseItemName, params ItemElement[] elements)
            : base(name)
        {
            this.baseItemName = baseItemName;

            foreach (var element in elements)
            {
                element.Item = this;
                this.elements.Add(element);
            }
        }

        public bool IsAbstract
        {
            get
            {
                return this.isAbstract;
            }
            set
            {
                this.isAbstract = value;
            }
        }

        public string BaseItemName
        {
            get
            {
                return this.baseItemName;
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
