using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UncommonSense.CBreeze.ObjectModelBuilder
{
    public class PropertyCollection : ObjectModelElement, IEnumerable<Property>
    {
        private List<Property> innerList = new List<Property>();

        public PropertyCollection(string name)
            : base(name)
        {
        }

        public Property Add(Property property)
        {
            property.Collection = this;
            innerList.Add(property);
            return property;
        }

        public void AddRange(params Property[] properties)
        {
            foreach (var property in properties)
            {
                Add(property);
            }
        }

        public IEnumerator<Property> GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return innerList.GetEnumerator();
        }
    }
}
