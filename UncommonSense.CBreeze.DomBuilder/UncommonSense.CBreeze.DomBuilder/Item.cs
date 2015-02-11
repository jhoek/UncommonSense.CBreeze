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
        private List<Attribute> attributes = new List<Attribute>();

        public Item(string name, params Attribute[] attributes)
            : this(name, null, attributes)
        {
        }

        public Item(string name, string baseItemName, params Attribute[] attributes)
            : base(name)
        {
            this.baseItemName = baseItemName;

            foreach (var attribute in attributes)
            {
                attribute.Item = this;
                this.attributes.Add(attribute);
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

        public IEnumerable<Attribute> Attributes
        {
            get
            {
                foreach (var attribute in attributes)
                {
                    yield return attribute;
                }
            }
        }
    }
}
