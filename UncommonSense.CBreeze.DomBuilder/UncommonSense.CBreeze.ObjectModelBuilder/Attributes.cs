using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UncommonSense.CBreeze.ObjectModelBuilder
{
    public class Attributes : IEnumerable<Attribute>
    {
        private List<Attribute> innerList = new List<Attribute>();

        internal Attributes(Item item)
        {
            Item = item;
        }

        public Attribute Add(Attribute attribute)
        {
            attribute.Item = Item;
            innerList.Add(attribute);
            return attribute;
        }

        public void AddRange(params Attribute[] attributes)
        {
            foreach (var attribute in attributes)
            {
                Add(attribute);
            }
        }

        public Item Item
        {
            get;
            internal set;
        }

        public IEnumerator<Attribute> GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return innerList.GetEnumerator();
        }
    }
}
